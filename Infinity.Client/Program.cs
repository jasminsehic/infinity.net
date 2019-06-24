using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;

namespace Infinity.Client
{
    public class Program
    {
        public static readonly string ProgramName = "infinity";

        public static int Main(string[] args)
        {
            bool commandLine = false;
            TfsClientConfiguration configuration = new TfsClientConfiguration();
            string section = null, command = null;
            string[] commandArgs = null;

            try
            {
                commandLine = ParseCommandLine(args, ref configuration, ref section, ref command, ref commandArgs);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("{0}: {1}", ProgramName, e.Message);
            }

            if (!commandLine)
            {
                Console.Error.WriteLine("usage: {0} <url> <command> [--username=<username> [--password=<password>]] [<argument>...]", ProgramName);
                return 1;
            }
            if (command == null)
            {
                Console.Error.WriteLine("{0}: '{1}' is not a {0} command", ProgramName, section);
                Console.Error.WriteLine("usage: {0} <command> [<argument>...]", ProgramName);
                return 1;
            }

            TfsClient client = new TfsClient(configuration);

            try
            {
                Type sectionType = Type.GetType(String.Format("Infinity.Client.{0}Command", section));

                if (sectionType != null)
                {
                    object commandObj = Activator.CreateInstance(sectionType, client);
                    MethodInfo commandMethod = sectionType.GetMethod(command);

                    if (commandMethod != null)
                    {
                        return (int)commandMethod.Invoke(commandObj, new object[] { commandArgs });
                    }
                }

                Console.Error.WriteLine("{0}: '{1}.{2}' is not a {0} command", ProgramName, section, command);
                Console.Error.WriteLine("usage: {0} <command> [<argument>...]", ProgramName);
            }
            catch(Exception e)
            {
                while (e is TargetInvocationException || e is AggregateException)
                {
                    e = e.InnerException;
                }

                Console.Error.WriteLine(e.Message);
            }

            return 1;
        }

        private static bool ParseCommandLine(
            string[] args,
            ref TfsClientConfiguration clientConfiguration,
            ref string section,
            ref string command,
            ref string[] commandArgs)
        {
            List<string> commandArgList = new List<string>();
            string username = null, password = null;
            int i = 0;

            if (args.Length < 2)
            {
                return false;
            }

            for (i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("--") || args[i].StartsWith("/"))
                {
                    string arg = args[i].Substring(args[i].StartsWith("--") ? 2 : 1);
                    string[] options = arg.Split(new char[] { '=' }, 2);

                    if (options[0] != null &&
                        options[0].Equals("username", StringComparison.InvariantCultureIgnoreCase))
                    {
                        username = options[1];
                    }
                    else if (options[0] != null && 
                        options[0].Equals("password", StringComparison.InvariantCultureIgnoreCase))
                    {
                        password = options[1];
                    }
                    else if (options[0] != null && 
                        options[0].Equals("useragent", StringComparison.InvariantCultureIgnoreCase))
                    {
                        clientConfiguration.UserAgent = options[1];
                    }
                    else
                    {
                        commandArgList.Add(args[i]);
                    }
                }
                else if (clientConfiguration.Url == null)
                {
                    clientConfiguration.Url = new Uri(args[i]);
                }
                else if (section == null)
                {
                    string[] commands = args[i].Split(new char[] { '.' }, 2);
                    section = commands[0];

                    if (commands.Length == 2)
                    {
                        command = commands[1];
                    }
                }
                else
                {
                    commandArgList.Add(args[i]);
                }
            }

            if (username != null || password != null)
            {
                clientConfiguration.Credentials = new NetworkCredential(username, password);
            }

            commandArgs = commandArgList.ToArray();
            return (section != null);
        }
    }
}
