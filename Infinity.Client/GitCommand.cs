using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Infinity;
using Infinity.Clients;
using Infinity.Models;
using Infinity.Util;

namespace Infinity.Client
{
    public class GitCommand
    {
        public GitCommand(TfsClient client)
        {
            Assert.NotNull(client, "client");

            Client = client;
        }

        private TfsClient Client { get; set; }

        public int GetRepositories(string[] args)
        {
            if (args.Length > 1)
            {
                Console.Error.WriteLine("usage: {0} Git.GetRepositories [projectId]", Program.ProgramName);
                return 1;
            }

            Guid? projectId = (args.Length > 0) ? new Guid(args[0]) : (Guid?)null;

            IEnumerable<Repository> repositories = null;

            Task.Run(async () =>
            {
                repositories = await Client.Git.GetRepositories(projectId);
            }).Wait();

            foreach (Repository repository in repositories.OrderBy(x => x.Name))
            {
                Console.WriteLine("Repository {0}:", repository.Id);
                Model.Write(repository);
            }

            return 0;
        }

        public int GetPullRequests(string[] args)
        {
            if (args.Length != 1)
            {
                Console.Error.WriteLine("usage: {0} Git.GetPullRequests <repositoryId>", Program.ProgramName);
                return 1;
            }

            Guid repositoryId = new Guid(args[0]);

            IEnumerable<PullRequest> pullRequests = null;

            Task.Run(async () =>
            {
                pullRequests = await Client.Git.GetPullRequests(repositoryId);
            }).Wait();

            foreach (PullRequest pullRequest in pullRequests.OrderBy(x => x.Id))
            {
                Console.WriteLine("Pull Request {0}:", pullRequest.Id);
                Model.Write(pullRequest);
            }

            return 0;
        }

        public int UpdatePullRequest(string[] args)
        {
            if (args.Length < 4)
            {
                Console.Error.WriteLine("usage: {0} Git.UpdatePullRequest <repositoryId> <pullRequestId> <status> <lastMergeSourceCommitId>", Program.ProgramName);
                return 1;
            }

            Guid repositoryId = new Guid(args[0]);
            int pullRequestId = int.Parse(args[1]);
            PullRequestStatus status = (PullRequestStatus)Enum.Parse(typeof(PullRequestStatus), args[2]);
            string lastMergeSourceCommitId = args[3];

            Task.Run(async () =>
            {
                await Client.Git.UpdatePullRequest(repositoryId, pullRequestId, status, lastMergeSourceCommitId);
            }).Wait();

            return 0;
        }
    }
}
