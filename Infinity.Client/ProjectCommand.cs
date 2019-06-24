using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infinity.Models;
using Infinity.Util;

namespace Infinity.Client
{
    public class ProjectCommand
    {
        public ProjectCommand(TfsClient client)
        {
            Assert.NotNull(client, "client");

            Client = client;
        }

        private TfsClient Client { get; set; }

        public int GetProjects(string[] args)
        {
            if (args.Length != 0)
            {
                Console.Error.WriteLine("usage: {0} <url> Project.GetProjects", Program.ProgramName);
                return 1;
            }

            IEnumerable<Project> projects = null;

            Task.Run(async () =>
            {
                projects = await Client.Project.GetProjects();
            }).Wait();

            foreach (Project project in projects)
            {
                Console.WriteLine("Project {0}:", project.Id);
                Model.Write(project);
            }

            return 0;
        }
    }
}
