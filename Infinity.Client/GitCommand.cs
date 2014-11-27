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

        public int GetCommits(string[] args)
        {
            if (args.Length < 1)
            {
                Console.Error.WriteLine("usage: {0} <url> Git.GetCommits [repositoryId]", Program.ProgramName);
                return 1;
            }

            Guid repositoryId = new Guid(args[0]);

            CommitFilters filters = new CommitFilters();

            for (int i = 1; i < args.Length; i++)
            {
                if (args[i].StartsWith("--") || args[i].StartsWith("/"))
                {
                    string arg = args[i].Substring(args[i].StartsWith("--") ? 2 : 1);
                    string[] options = arg.Split(new char[] { '=' }, 2);

                    if (options[0] != null &&
                        options[0].Equals("author", StringComparison.InvariantCultureIgnoreCase))
                    {
                        filters.Author = options[1];
                    }
                    else if (options[0] != null &&
                        options[0].Equals("committer", StringComparison.InvariantCultureIgnoreCase))
                    {
                        filters.Committer = options[1];
                    }
                    else if (options[0] != null &&
                        options[0].Equals("itempath", StringComparison.InvariantCultureIgnoreCase))
                    {
                        filters.ItemPath = options[1];
                    }
                    else if (options[0] != null &&
                        options[0].Equals("fromdate", StringComparison.InvariantCultureIgnoreCase))
                    {
                        filters.FromDate = DateTime.Parse(options[1]);
                    }
                    else if (options[0] != null &&
                        options[0].Equals("todate", StringComparison.InvariantCultureIgnoreCase))
                    {
                        filters.ToDate = DateTime.Parse(options[1]);
                    }
                    else if (options[0] != null &&
                        options[0].Equals("skip", StringComparison.InvariantCultureIgnoreCase))
                    {
                        filters.Skip = int.Parse(options[1]);
                    }
                    else if (options[0] != null &&
                        options[0].Equals("count", StringComparison.InvariantCultureIgnoreCase))
                    {
                        filters.Count = int.Parse(options[1]);
                    }
                    else
                    {
                        Console.Error.WriteLine("{0}: unknown option '{1}'", Program.ProgramName, args[i]);
                        return 1;
                    }
                }
            }

            IEnumerable<Commit> commits = null;

            Task.Run(async () =>
            {
                commits = await Client.Git.GetCommits(repositoryId, filters);
            }).Wait();

            foreach (Commit commit in commits)
            {
                Console.WriteLine("Commit {0}:", commit.Id);
                Model.Write(commit);
            }

            return 0;
        }

        public int GetRepositories(string[] args)
        {
            if (args.Length > 1)
            {
                Console.Error.WriteLine("usage: {0} <url> Git.GetRepositories [projectId]", Program.ProgramName);
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
                Console.Error.WriteLine("usage: {0} <url> Git.GetPullRequests <repositoryId>", Program.ProgramName);
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
                Console.Error.WriteLine("usage: {0} <url> Git.UpdatePullRequest <repositoryId> <pullRequestId> <status> <lastMergeSourceCommitId>", Program.ProgramName);
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
