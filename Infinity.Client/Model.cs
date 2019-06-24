using System;
using System.Collections;
using System.ComponentModel;

namespace Infinity.Client
{
    public static class Model
    {
        public static void Write(object o)
        {
            Write(o, 1);
        }

        private static void Indent(int level)
        {
            for (int i = 0; i < level; i++)
            {
                Console.Write("    ");
            }
        }

        private static string GetValue(object o)
        {
            if (o == null)
            {
                return "(null)";
            }

            if (o is IList || o.ToString().StartsWith("Infinity.Models."))
            {
                return null;
            }

            return o.ToString();
        }

        private static void WriteChild(string key, object child, int indentLevel)
        {
            Indent(indentLevel);

            string childValue = GetValue(child);

            if (childValue != null)
            {
                Console.WriteLine("{0}: {1}", key, childValue);
            }
            else
            {
                Console.WriteLine("{0}:", key);
                Write(child, indentLevel + 1);
            }
        }

        private static void WriteChild(int i, object child, int indentLevel)
        {
            WriteChild(String.Format("[{0}]", i), child, indentLevel);
        }

        public static void Write(object o, int indentLevel)
        {
            string valueString = GetValue(o);

            if (valueString != null)
            {
                Indent(indentLevel);
                Console.WriteLine(valueString);
                return;
            }

            if (o is IList)
            {
                for (int i = 0; i < ((IList)o).Count; i++)
                {
                    WriteChild(i, ((IList)o)[i], indentLevel);
                }
            }
            else
            {
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(o))
                {
                    WriteChild(descriptor.Name, descriptor.GetValue(o), indentLevel);
                }
            }
        }
    }
}
