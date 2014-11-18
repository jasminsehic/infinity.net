using System;
using System.ComponentModel;

namespace Infinity.Client
{
    public static class Model
    {
        public static void Write(object o)
        {
            Write(o, 1);
        }

        public static void Write(object o, int indentLevel)
        {
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(o))
            {
                object value = descriptor.GetValue(o);
                string valueString = "";

                if (value == null)
                {
                    valueString = "(null)";
                }
                else if (!value.ToString().StartsWith("Infinity.Models."))
                {
                    valueString = value.ToString();
                }

                for (int i = 0; i < indentLevel; i++)
                {
                    Console.Write("    ");
                }

                Console.WriteLine("{0}: {1}", descriptor.Name, valueString);

                if (value != null && value.ToString().StartsWith("Infinity.Models."))
                {
                    Write(value, indentLevel + 1);
                }
            }
        }
    }
}
