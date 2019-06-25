using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

        public int GetCommit(string[] args)
        {
            if (args.Length < 1)
            {
                Console.Error.WriteLine("usage: {0} <url> Git.GetCommit [repositoryId] [commitId]", Program.ProgramName);
                return 1;
            }

            Guid repositoryId = new Guid(args[0]);
            ObjectId commitId = new ObjectId(args[1]);
            int? changeCount = null;

            for (int i = 1; i < args.Length; i++)
            {
                if (args[i].StartsWith("--") || args[i].StartsWith("/"))
                {
                    string arg = args[i].Substring(args[i].StartsWith("--") ? 2 : 1);
                    string[] options = arg.Split(new char[] { '=' }, 2);

                    if (options[0] != null &&
                        options[0].Equals("changeCount", StringComparison.InvariantCultureIgnoreCase))
                    {
                        changeCount = int.Parse(options[1]);
                    }
                    else
                    {
                        Console.Error.WriteLine("{0}: unknown option '{1}'", Program.ProgramName, args[i]);
                        return 1;
                    }
                }
            }

            Commit commit = null;

            Task.Run(async () =>
            {
                if (changeCount.HasValue)
                {
                    commit = await Client.Git.GetCommit(repositoryId, commitId, changeCount.Value);
                }
                else
                {
                    commit = await Client.Git.GetCommit(repositoryId, commitId);
                }
            }).Wait();

            Console.WriteLine("Commit {0}:", commit.Id);
            Model.Write(commit);

            return 0;
        }

        public int GetTree(string[] args)
        {
            if (args.Length != 2)
            {
                Console.Error.WriteLine("usage: {0} <url> Git.GetTree [repositoryId] [treeId]", Program.ProgramName);
                return 1;
            }

            Guid repositoryId = new Guid(args[0]);
            ObjectId treeId = new ObjectId(args[1]);

            Tree tree = null;

            Task.Run(async () =>
            {
                tree = await Client.Git.GetTree(repositoryId, treeId);
            }).Wait();

            Console.WriteLine("Tree {0}:", tree.Id);
            Model.Write(tree);

            return 0;
        }

        public int DownloadTree(string[] args)
        {
            if (args.Length < 2)
            {
                Console.Error.WriteLine("usage: {0} <url> Git.DownloadTree [repositoryId] [treeId] [--filename=filename]", Program.ProgramName);
                return 1;
            }

            Guid repositoryId = new Guid(args[0]);
            ObjectId treeId = new ObjectId(args[1]);
            string filename = String.Format("{0}.zip", args[1]);

            for (int i = 1; i < args.Length; i++)
            {
                if (args[i].StartsWith("--") || args[i].StartsWith("/"))
                {
                    string arg = args[i].Substring(args[i].StartsWith("--") ? 2 : 1);
                    string[] options = arg.Split(new char[] { '=' }, 2);

                    if (options[0] != null &&
                        options[0].Equals("filename", StringComparison.InvariantCultureIgnoreCase))
                    {
                        filename = options[1];
                    }
                    else
                    {
                        Console.Error.WriteLine("{0}: unknown option '{1}'", Program.ProgramName, args[i]);
                        return 1;
                    }
                }
            }

            Task.Run(async () =>
            {
                using (Stream outputStream = File.Create(filename))
                {
                    await Client.Git.DownloadTree(repositoryId, treeId, outputStream);
                    outputStream.Close();
                }
            }).Wait();

            return 0;
        }

        public int DownloadBlob(string[] args)
        {
            if (args.Length < 2)
            {
                Console.Error.WriteLine("usage: {0} <url> Git.DownloadBlob [repositoryId] [blobId] [--filename=filename]", Program.ProgramName);
                return 1;
            }

            Guid repositoryId = new Guid(args[0]);
            ObjectId blobId = new ObjectId(args[1]);
            string filename = null;
            BlobFormat format = BlobFormat.Raw;

            for (int i = 1; i < args.Length; i++)
            {
                if (args[i].StartsWith("--") || args[i].StartsWith("/"))
                {
                    string arg = args[i].Substring(args[i].StartsWith("--") ? 2 : 1);
                    string[] options = arg.Split(new char[] { '=' }, 2);

                    if (options[0] != null &&
                        options[0].Equals("filename", StringComparison.InvariantCultureIgnoreCase))
                    {
                        filename = options[1];
                    }
                    else if (options[0] != null &&
                        options[0].Equals("format", StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (options[1].Equals("raw", StringComparison.InvariantCultureIgnoreCase))
                        {
                            format = BlobFormat.Raw;
                        }
                        else if (options[1].Equals("zip", StringComparison.InvariantCultureIgnoreCase))
                        {
                            format = BlobFormat.Zip;
                        }
                        else
                        {
                            Console.Error.WriteLine("{0}: unknown format '{1}'", Program.ProgramName, options[1]);
                            return 1;
                        }
                    }
                    else
                    {
                        Console.Error.WriteLine("{0}: unknown option '{1}'", Program.ProgramName, args[i]);
                        return 1;
                    }
                }
            }

            if (filename == null)
            {
                filename = (format == BlobFormat.Zip) ? String.Format("{0}", args[1]) : args[1];
            }

            Task.Run(async () =>
            {
                using (Stream outputStream = File.Create(filename))
                {
                    await Client.Git.DownloadBlob(repositoryId, blobId, format, outputStream);
                    outputStream.Close();
                }
            }).Wait();

            return 0;
        }

        public int GetPushes(string[] args)
        {
            if (args.Length > 1)
            {
                Console.Error.WriteLine("usage: {0} <url> Git.GetPushes [repositoryId]", Program.ProgramName);
                return 1;
            }

            Guid repositoryId = new Guid(args[0]);

            IEnumerable<PushDetails> pushes = null;

            Task.Run(async () =>
            {
                pushes = await Client.Git.GetPushes(repositoryId);
            }).Wait();

            foreach (PushDetails push in pushes)
            {
                Console.WriteLine("Push {0}:", push.Id);
                Model.Write(push);
            }

            return 0;
        }

        public int GetPush(string[] args)
        {
            if (args.Length < 1)
            {
                Console.Error.WriteLine("usage: {0} <url> Git.GetPush [repositoryId] [pushId]", Program.ProgramName);
                return 1;
            }

            Guid repositoryId = new Guid(args[0]);
            int pushId = int.Parse(args[1]);

            PushDetails push = null;

            Task.Run(async () =>
            {
                push = await Client.Git.GetPush(repositoryId, pushId);
            }).Wait();

            Console.WriteLine("Push {0}:", push.Id);
            Model.Write(push);

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

        public int GetItems(string[] args)
        {
            if (args.Length < 2)
            {
                Console.Error.WriteLine("usage: {0} <url> Git.GetItems <repositoryId> <pullRequestId> [paths...]", Program.ProgramName);
                return 1;
            }

            Guid repositoryId = new Guid(args[0]);

            List<Tuple<string, ItemFilters>> paths = new List<Tuple<string, ItemFilters>>();

            foreach (string path in args.Skip(1))
            {
                paths.Add(new Tuple<string, ItemFilters>(path, new ItemFilters()));
            }

            IEnumerable<IEnumerable<Item>> items = null;

            Task.Run(async () =>
            {
                items = await Client.Git.GetItems(repositoryId, paths, true);
            }).Wait();

            foreach (IEnumerable<Item> itemList in items)
            {
                foreach (Item item in itemList)
                {
                    Console.WriteLine("Item {0}:", item.Id);
                    Model.Write(item);
                }
            }

            return 0;
        }
    }
}
