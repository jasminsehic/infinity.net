using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Infinity.Models;
using Infinity.Util;

namespace Infinity.Clients
{
    /// <summary>
    /// Client to access information about Git repositories managed in a
    /// TFS Project Collection.
    /// </summary>
    public class GitClient
    {
        internal GitClient(ITfsClientExecutor executor)
        {
            Executor = executor;
        }

        private ITfsClientExecutor Executor { get; set; }

        #region Blobs

        /// <summary>
        /// Get the information about a Git blob by its ID.
        /// </summary>
        /// <param name="repositoryId">The ID of the repository</param>
        /// <param name="blobId">The object ID of the blob</param>
        /// <returns>The blob</returns>
        public async Task<Blob> GetBlob(Guid repositoryId, ObjectId blobId)
        {
            Assert.NotNull(repositoryId, "repositoryId");
            Assert.NotNull(blobId, "blobId");

            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/blobs/{BlobId}");
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());
            request.AddUrlSegment("BlobId", blobId.ToString());

            return await Executor.Execute<Blob>(request);
        }

        /// <summary>
        /// Download a blob's contents.
        /// </summary>
        /// <param name="repositoryId">The ID of the repository</param>
        /// <param name="blobId">The object ID of the blob</param>
        /// <param name="outputStream">The stream to write the response content to asynchronously</param>
        public async Task DownloadBlob(Guid repositoryId, ObjectId blobId, Stream outputStream)
        {
            await DownloadBlob(repositoryId, blobId, BlobFormat.Raw, outputStream);
        }

        /// <summary>
        /// Download a blob's contents.
        /// </summary>
        /// <param name="repositoryId">The ID of the repository</param>
        /// <param name="blobId">The object ID of the blob</param>
        /// <param name="format">The format to download as</param>
        /// <param name="outputStream">The stream to write the response content to asynchronously</param>
        public async Task DownloadBlob(Guid repositoryId, ObjectId blobId, BlobFormat format, Stream outputStream)
        {
            Assert.NotNull(repositoryId, "repositoryId");
            Assert.NotNull(blobId, "blobId");
            Assert.NotNull(outputStream, "outputStream");

            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/blobs/{BlobId}");
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());
            request.AddUrlSegment("BlobId", blobId.ToString());

            if (format == BlobFormat.Zip)
            {
                request.AddUrlSegment("$format", "zip");
                request.AddHeader("Accept", "application/zip");
            }
            else
            {
                request.AddUrlSegment("$format", "octetstream");
                request.AddHeader("Accept", "application/octet-stream");
            }

            await Executor.Execute(request, outputStream);
        }

        #endregion

        #region Branch Statistics

        /// <summary>
        /// Get the statistics about a branch.
        /// </summary>
        /// <param name="repositoryId">The ID of the repository</param>
        /// <param name="branch">The name of the branch to return statistics for</param>
        /// <param name="baseRevision">The revision to compare this branch to</param>
        /// <returns>The branch statistics</returns>
        public async Task<BranchStatistics> GetBranchStatistics(Guid repositoryId, string branch, Revision baseRevision = null)
        {
            Assert.NotNull(repositoryId, "repositoryId");
            Assert.NotNull(branch, "branch");

            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/stats/branches/{Branch}");
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());
            request.AddUrlSegment("Branch", branch);

            if (baseRevision != null)
            {
                request.AddBody(new {
                    baseVersionType = baseRevision.Type,
                    baseVersion = baseRevision.Version
                });
            }

            return await Executor.Execute<BranchStatistics>(request);
        }

        /// <summary>
        /// Get the statistics about all branches.
        /// </summary>
        /// <param name="repositoryId">The ID of the repository</param>
        /// <returns>The branch statistics</returns>
        public async Task<IEnumerable<BranchStatistics>> GetBranchStatistics(Guid repositoryId)
        {
            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/stats/branches");
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());

            Sequence<BranchStatistics> list = await Executor.Execute<Sequence<BranchStatistics>>(request);
            return list.Value;
        }

        #endregion

        #region Commits

        /// <summary>
        /// Get a list of commits in a Git repository.
        /// </summary>
        /// <param name="repositoryId">The ID of the repository to query</param>
        /// <param name="filters">Optional commit query filters</param>
        /// <returns>A list of commits in the Git repository</returns>
        public async Task<IEnumerable<Commit>> GetCommits(Guid repositoryId, CommitFilters filters = null)
        {
            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/commits");
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());

            filters = filters ?? new CommitFilters();

            request.AddOptionalParameter("itemPath", filters.ItemPath);
            request.AddOptionalParameter("committer", filters.Committer);
            request.AddOptionalParameter("fromDate", filters.FromDate);
            request.AddOptionalParameter("toDate", filters.ToDate);
            request.AddOptionalParameter("$skip", filters.Skip, () => { return filters.Skip > 0; });
            request.AddOptionalParameter("$top", filters.Count, () => { return filters.Count > 0; });

            Sequence<Commit> list = await Executor.Execute<Sequence<Commit>>(request);
            return list.Value;
        }

        /// <summary>
        /// Get a list of commits leading to a revision, optionally beginning
        /// from a prior revision.
        /// </summary>
        /// <param name="repositoryId">The ID of the repository to query</param>
        /// <param name="targetRevision">The revision to query from</param>
        /// <param name="baseRevision">The revision to begin querying</param>
        /// <returns>A list of commits in the Git repository</returns>
        public async Task<IEnumerable<Commit>> GetCommits(Guid repositoryId, Revision targetRevision, Revision baseRevision = null)
        {
            Assert.NotNull("targetRevision", "targetRevision");

            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/commitsBatch", HttpMethod.Post);
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());

            if (baseRevision != null)
            {
                request.AddBody(new {
                    itemVersion = targetRevision.GetProperties(),
                    compareVersion = baseRevision.GetProperties()
                });
            }
            else
            {
                request.AddBody(new { itemVersion = targetRevision.GetProperties() });
            }

            Sequence<Commit> list = await Executor.Execute<Sequence<Commit>>(request);
            return list.Value;
        }

        /// <summary>
        /// Get a commit in a repository.
        /// </summary>
        /// <param name="repositoryId">The ID of the repository</param>
        /// <param name="commitId">The ID of the commit</param>
        /// <param name="changeCount">The number of changes to return, or 0 for none.</param>
        /// <returns>The commit in the Git repository</returns>
        public async Task<Commit> GetCommit(Guid repositoryId, ObjectId commitId, int changeCount = 0)
        {
            Assert.NotNull("commitId", "commitId");

            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/commits/{CommitId}");
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());
            request.AddUrlSegment("CommitId", commitId.ToString());
            request.AddOptionalParameter("changeCount", changeCount, () => { return changeCount > 0; });

            return await Executor.Execute<Commit>(request);
        }

        #endregion

        #region Diffs

        /// <summary>
        /// Get the differences between two commits.
        /// </summary>
        /// <param name="repositoryId">The repository containing the commits.</param>
        /// <param name="filters">The data to difference.</param>
        /// <returns>The differences betweeo commits.</returns>
        public async Task<Diff> GetDiff(Guid repositoryId, DiffFilters filters = null)
        {
            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/diffs/commits");
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());

            filters = filters ?? new DiffFilters();

            request.AddOptionalParameter("targetVersionType", filters.TargetRevision.Type.ToString().ToLowerInvariant(), () => { return filters.TargetRevision != null; });
            request.AddOptionalParameter("targetVersion", filters.TargetRevision.Version, () => { return filters.TargetRevision != null; });
            request.AddOptionalParameter("baseVersionType", filters.BaseRevision.Type.ToString().ToLowerInvariant(), () => { return filters.BaseRevision != null; });
            request.AddOptionalParameter("baseVersion", filters.BaseRevision.Version, () => { return filters.BaseRevision != null; });
            request.AddOptionalParameter("$skip", filters.Skip, () => { return filters.Skip > 0; });
            request.AddOptionalParameter("$top", filters.Count, () => { return filters.Count > 0; });

            return await Executor.Execute<Diff>(request);
        }

        #endregion

        #region Items

        /// <summary>
        /// Get the item in the repository at the given path.
        /// </summary>
        /// <param name="repositoryId">The ID of the repository to query</param>
        /// <param name="path">Path of the item to query</param>
        /// <param name="filters">Filters to provide additional query information</param>
        /// <param name="includeMetadata">To include item metadata or not</param>
        /// <returns>A list of commits in the Git repository</returns>
        public async Task<IEnumerable<Item>> GetItem(Guid repositoryId, string path, ItemFilters filters = null, bool includeMetadata = false)
        {
            Assert.NotNull(repositoryId, "repositoryId");
            Assert.NotNull(path, "path");

            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/items");
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());

            // This header instructs VSO to return metadata rather than the item contents
            request.AddHeader("Accept", "application/json");

            filters = filters ?? new ItemFilters();

            request.AddParameter("scopePath", path);

            request.AddOptionalParameter("recursionLevel",
                filters.RecursionLevel,
                () => { return filters.RecursionLevel != RecursionLevel.None; });

            if (includeMetadata)
            {
                request.AddParameter("includeContentMetadata", "true");
            }

            Sequence<Item> list = await Executor.Execute<Sequence<Item>>(request);
            return list.Value;
        }

        /// <summary>
        /// Get the items in the repository at the given path.
        /// </summary>
        /// <param name="repositoryId">The ID of the repository to query</param>
        /// <param name="paths">Paths (and filters) of the items to query</param>
        /// <param name="includeMetadata">True to include item metadata</param>
        /// <returns>A list of commits in the Git repository</returns>
        public async Task<IEnumerable<IEnumerable<Item>>> GetItems(Guid repositoryId, IEnumerable<Tuple<string, ItemFilters>> paths, bool includeMetadata = false)
        {
            Assert.NotNull(repositoryId, "repositoryId");
            Assert.NotNull(paths, "paths");

            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/itemsBatch", HttpMethod.Post);
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());

            // This header instructs VSO to return metadata rather than the item contents
            request.AddHeader("Accept", "application/json");

            request.AddBody(new
            {
                itemDescriptors = paths.Select(x => new { 
                    path = x.Item1,
                    version = x.Item2.Revision != null ? x.Item2.Revision.Version : "",
                    versionType = x.Item2.Revision != null ? x.Item2.Revision.Type.ToString().ToLowerInvariant() : "",
                    versionOptions = x.Item2.RevisionOptions.ToString().ToLowerInvariant(),
                    recursionLevel = x.Item2.RecursionLevel.ToString().ToLowerInvariant(),
                }),
                includeContentMetadata = includeMetadata ? "true" : "false",
            });

            Sequence<List<Item>> list = await Executor.Execute<Sequence<List<Item>>>(request);
            return list.Value;
        }

        #endregion

        #region Pull Requests

        /// <summary>
        /// Get a pull request in a Git repository.
        /// </summary>
        /// <param name="repositoryId">The ID of the repository that contains the pull request</param>
        /// <param name="id">The ID of the pull request</param>
        /// <returns>The pull request</returns>
        public async Task<PullRequest> GetPullRequest(Guid repositoryId, int id)
        {
            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/pullRequests/{Id}");
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());
            request.AddUrlSegment("Id", String.Format("{0}", id));

            return await Executor.Execute<PullRequest>(request);
        }

        /// <summary>
        /// Get a list of pull requests in a Git repository.
        /// </summary>
        /// <param name="repositoryId">The ID of the repository to query</param>
        /// <param name="filters">Optional pull request query filters</param>
        /// <returns>A list of pull requests in the Git repository</returns>
        public async Task<IEnumerable<PullRequest>> GetPullRequests(Guid repositoryId, PullRequestFilters filters = null)
        {
            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/pullRequests");
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());

            filters = filters ?? new PullRequestFilters();

            request.AddOptionalParameter("status", filters.Status.ToString().ToLower(), () => { return filters.Status != null; });
            request.AddOptionalParameter("creatorId", filters.CreatorId);
            request.AddOptionalParameter("reviewerId", filters.ReviewerId);
            request.AddOptionalParameter("sourceRefName", filters.SourceRefName);
            request.AddOptionalParameter("targetRefName", filters.TargetRefName);
            request.AddOptionalParameter("$top", filters.Count, () => { return filters.Count > 0; });
            request.AddOptionalParameter("$skip", filters.Skip, () => { return filters.Skip > 0; });

            Sequence<PullRequest> list = await Executor.Execute<Sequence<PullRequest>>(request);
            return list.Value;
        }

        /// <summary>
        /// Create a new pull request in the given repository, requesting to
        /// merge the given source branch into the given target branch.
        /// </summary>
        /// <param name="repositoryId">The repository</param>
        /// <param name="sourceRefName">Name of the source branch that contains the changes to merge</param>
        /// <param name="targetRefName">Name of the target branch that will be the destination of the merge</param>
        /// <param name="title">Title of the pull request</param>
        /// <param name="description">Description of the pull request</param>
        /// <param name="reviewers">Reviewers (optional)</param>
        /// <returns>The new pull request</returns>
        public async Task<PullRequest> CreatePullRequest(Guid repositoryId, string sourceRefName, string targetRefName, string title, string description, IEnumerable<Guid> reviewers = null)
        {
            Assert.NotNull(sourceRefName, "sourceRefName");
            Assert.NotNull(targetRefName, "targetRefName");
            Assert.NotNull(title, "title");
            Assert.NotNull(description, "description");

            if (reviewers == null)
            {
                reviewers = new Guid[0];
            }

            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/pullRequests", HttpMethod.Post);
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());
            request.AddBody(new {
                sourceRefName = sourceRefName,
                targetRefName = targetRefName,
                title = title,
                description = description,
                reviewers = reviewers.Select((id) => { return new { id = id.ToString() }; })
            });

            return await Executor.Execute<PullRequest>(request);
        }

        /// <summary>
        /// Updates the pull request data, abandoning or completing it.
        /// </summary>
        /// <param name="repositoryId">The repository</param>
        /// <param name="pullRequestId">The pull request to update</param>
        /// <param name="status">The new status</param>
        /// <param name="lastMergeSourceCommitId">The last merge source commit ID (to confirm)</param>
        /// <returns>The updated pull request</returns>
        public async Task<PullRequest> UpdatePullRequest(Guid repositoryId, int pullRequestId, PullRequestStatus status, string lastMergeSourceCommitId)
        {
            Assert.NotNull(lastMergeSourceCommitId, "lastMergeSourceCommitId");

            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/pullRequests/{PullRequestId}", new HttpMethod("PATCH"));
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());
            request.AddUrlSegment("PullRequestId", pullRequestId.ToString());
            request.AddBody(new
            {
                status = status.ToString().ToLower(),
                lastMergeSourceCommit = new { commitId = lastMergeSourceCommitId }
            });

            return await Executor.Execute<PullRequest>(request);
        }

        /// <summary>
        /// Get the reviewers listed for a pull request.
        /// </summary>
        /// <param name="repositoryId">The repository</param>
        /// <param name="pullRequestId">The pull request</param>
        /// <returns>The list of reviewers listed for the pull request</returns>
        public async Task<IEnumerable<PullRequestReviewer>> GetPullRequestReviewers(Guid repositoryId, int pullRequestId)
        {
            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/pullRequests/{PullRequestId}/reviewers");
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());
            request.AddUrlSegment("PullRequestId", pullRequestId.ToString());

            Sequence<PullRequestReviewer> list = await Executor.Execute<Sequence<PullRequestReviewer>>(request);
            return list.Value;
        }

        /// <summary>
        /// Get the information about a reviewer listed for a pull request.
        /// </summary>
        /// <param name="repositoryId">The repository</param>
        /// <param name="pullRequestId">The pull request</param>
        /// <param name="reviewerId">The reviewer</param>
        /// <returns>The reviewer for the pull request</returns>
        public async Task<PullRequestReviewer> GetPullRequestReviewer(Guid repositoryId, int pullRequestId, Guid reviewerId)
        {
            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/pullRequests/{PullRequestId}/reviewers/{ReviewerId}");
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());
            request.AddUrlSegment("PullRequestId", pullRequestId.ToString());
            request.AddUrlSegment("ReviewerId", reviewerId.ToString());

            return await Executor.Execute<PullRequestReviewer>(request);
        }

        /// <summary>
        /// Adds a reviewer to a pull request.
        /// </summary>
        /// <param name="repositoryId">The repository</param>
        /// <param name="pullRequestId">The pull request</param>
        /// <param name="reviewerId">The reviewer</param>
        /// <param name="vote">The (optional) vote for the reviewer</param>
        /// <returns>The reviewer for the pull request</returns>
        public async Task<PullRequestReviewer> AddPullRequestReviewer(Guid repositoryId, int pullRequestId, Guid reviewerId, PullRequestVote vote = PullRequestVote.None)
        {
            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/pullRequests/{PullRequestId}/reviewers/{ReviewerId}", HttpMethod.Post);
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());
            request.AddUrlSegment("PullRequestId", pullRequestId.ToString());
            request.AddUrlSegment("ReviewerId", reviewerId.ToString());
            request.AddBody(new
            {
                vote = (int)vote
            });

            return await Executor.Execute<PullRequestReviewer>(request);
        }

        /// <summary>
        /// Deletes a reviewer from a pull request
        /// </summary>
        /// <param name="repositoryId">The repository</param>
        /// <param name="pullRequestId">The pull request</param>
        /// <param name="reviewerId">The reviewer</param>
        public async Task DeletePullRequestReviewer(Guid repositoryId, int pullRequestId, Guid reviewerId)
        {
            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/pullRequests/{PullRequestId}/reviewers/{ReviewerId}", HttpMethod.Delete);
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());
            request.AddUrlSegment("PullRequestId", pullRequestId.ToString());
            request.AddUrlSegment("ReviewerId", reviewerId.ToString());

            await Executor.Execute(request);
        }


        /// <summary>
        /// Updates the reviewer's vote for a pull request.
        /// </summary>
        /// <param name="repositoryId">The repository</param>
        /// <param name="pullRequestId">The pull request</param>
        /// <param name="reviewerId">The reviewer</param>
        /// <param name="vote">The vote for the reviewer</param>
        /// <returns>The reviewer for the pull request</returns>
        public async Task<PullRequestReviewer> UpdatePullRequestReviewer(Guid repositoryId, int pullRequestId, Guid reviewerId, PullRequestVote vote)
        {
            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/pullRequests/{PullRequestId}/reviewers/{ReviewerId}", HttpMethod.Put);
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());
            request.AddUrlSegment("PullRequestId", pullRequestId.ToString());
            request.AddUrlSegment("ReviewerId", reviewerId.ToString());
            request.AddBody(new
            {
                vote = (int)vote
            });

            return await Executor.Execute<PullRequestReviewer>(request);
        }

        /// <summary>
        /// Get the labels listed for a pull request.
        /// </summary>
        /// <param name="repositoryId">The repository</param>
        /// <param name="pullRequestId">The pull request</param>
        /// <returns>The list of labels listed for the pull request</returns>
        public async Task<IEnumerable<WebApiTagDefinition>> GetPullRequestLabels(Guid repositoryId, int pullRequestId)
        {
            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/pullRequests/{PullRequestId}/labels", HttpMethod.Get, "5.1-preview");
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());
            request.AddUrlSegment("PullRequestId", pullRequestId.ToString());

            Sequence<WebApiTagDefinition> list = await Executor.Execute<Sequence<WebApiTagDefinition>>(request);
            return list.Value;
        }

        /// <summary>
        /// Get the information about a label listed for a pull request.
        /// </summary>
        /// <param name="repositoryId">The repository</param>
        /// <param name="pullRequestId">The pull request</param>
        /// <param name="labelIdOrName">The reviewer</param>
        /// <returns>The label for the pull request</returns>
        public async Task<WebApiTagDefinition> GetPullRequestLabel(Guid repositoryId, int pullRequestId, string labelIdOrName)
        {
            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/pullRequests/{PullRequestId}/labels/{labelIdOrName}");
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());
            request.AddUrlSegment("PullRequestId", pullRequestId.ToString());
            request.AddUrlSegment("labelIdOrName", labelIdOrName);

            return await Executor.Execute<WebApiTagDefinition>(request);
        }

        /// <summary>
        /// Adds a label to a pull request.
        /// </summary>
        /// <param name="repositoryId">The repository</param>
        /// <param name="pullRequestId">The pull request</param>
        /// <param name="labelName">The name of label</param>
        /// <returns>The created label</returns>
        public async Task<WebApiTagDefinition> AddPullRequestLabel(Guid repositoryId, int pullRequestId, string labelName)
        {
            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/pullRequests/{PullRequestId}/labels", HttpMethod.Post, "5.1-preview");
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());
            request.AddUrlSegment("PullRequestId", pullRequestId.ToString());
            request.AddBody(new
            {
                name = labelName
            });

            return await Executor.Execute<WebApiTagDefinition>(request);
        }

        /// <summary>
        /// Deletes a label from a pull request
        /// </summary>
        /// <param name="repositoryId">The repository</param>
        /// <param name="pullRequestId">The pull request</param>
        /// <param name="labelIdOrName">The label name or id</param>
        public async Task DeletePullRequestLabel(Guid repositoryId, int pullRequestId, string labelIdOrName)
        {
            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/pullRequests/{PullRequestId}/labels/{labelIdOrName}", HttpMethod.Delete, "5.1-preview");
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());
            request.AddUrlSegment("PullRequestId", pullRequestId.ToString());
            request.AddUrlSegment("labelIdOrName", labelIdOrName);

            await Executor.Execute(request);
        }

        #endregion

        #region Pushes

        /// <summary>
        /// Get a push in a Git repository.
        /// </summary>
        /// <param name="repositoryId">The ID of the repository to query</param>
        /// <param name="id">The ID of the push</param>
        /// <param name="includeRefUpdates">Whether to include information about references that were updated</param>
        /// <returns>A list of pushes in the Git repository</returns>
        public async Task<PushDetails> GetPush(Guid repositoryId, int id, bool includeRefUpdates = false)
        {
            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/pushes/{PushId}");
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());
            request.AddUrlSegment("PushId", id.ToString());

            if (includeRefUpdates)
            {
                request.AddParameter("includeRefUpdates", "true");
            }

            return await Executor.Execute<PushDetails>(request);
        }

        /// <summary>
        /// Get a list of pushes in a Git repository.
        /// </summary>
        /// <param name="repositoryId">The ID of the repository to query</param>
        /// <param name="filters">Optional push filters</param>
        /// <returns>A list of pushes in the Git repository</returns>
        public async Task<IEnumerable<PushDetails>> GetPushes(Guid repositoryId, PushFilters filters = null)
        {
            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/pushes");
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());

            filters = filters ?? new PushFilters();

            request.AddOptionalParameter("fromDate", filters.FromDate);
            request.AddOptionalParameter("toDate", filters.ToDate);
            request.AddOptionalParameter("pusherId", filters.Pusher);
            request.AddOptionalParameter("$skip", filters.Skip, () => { return filters.Skip > 0; });
            request.AddOptionalParameter("$top", filters.Count, () => { return filters.Count > 0; });

            Sequence<PushDetails> list = await Executor.Execute<Sequence<PushDetails>>(request);
            return list.Value;
        }

        /// <summary>
        /// Get a list of commits included in the push.
        /// </summary>
        /// <param name="repositoryId">The ID of the repository to query</param>
        /// <param name="pushId">The ID of the push to query</param>
        /// <returns>A list of commits in the push</returns>
        public async Task<IEnumerable<Commit>> GetPushCommits(Guid repositoryId, int pushId)
        {
            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/pushes/{PushId}/commits");
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());
            request.AddUrlSegment("PushId", pushId.ToString());

            Sequence<Commit> list = await Executor.Execute<Sequence<Commit>>(request);
            return list.Value;
        }

        #endregion

        #region References

        /// <summary>
        /// Get the references (branches, tags, notes) in the given repository.
        /// </summary>
        /// <param name="repositoryId">The ID of the Git repository</param>
        /// <param name="filter">The string prefix to match, excepting the <code>refs/</code> prefix.  For example, <code>heads/</code> will return branches.</param>
        /// <returns>The list of references.</returns>
        public async Task<IEnumerable<Reference>> GetReferences(Guid repositoryId, string filter = null)
        {
            Assert.NotNull(repositoryId, "repositoryId");

            if (filter != null)
            {
                Assert.IsTrue(filter.StartsWith("refs/"), "filter.StartsWith(refs/)");
                filter = filter.Substring(4);
            }

            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/refs{Filter}", HttpMethod.Get);
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());
            request.AddUrlSegment("Filter", filter != null ? filter : "");

            Sequence<Reference> references = await Executor.Execute<Sequence<Reference>>(request);
            return (references != null) ? references.Value : new List<Reference>();
        }

        #endregion

        #region Repositories

        /// <summary>
        /// Get a list of all Git repositories managed in a TFS Team Project.
        /// </summary>
        /// <param name="projectId">The ID of the Team Project to query</param>
        /// <returns>A list of repositories in the Project Collection</returns>
        public async Task<IEnumerable<Repository>> GetRepositories(Guid? projectId = null)
        {
            TfsRestRequest request;

            if (projectId != null)
            {
                request = new TfsRestRequest("/_apis/git/{ProjectId}/repositories");
                request.AddUrlSegment("ProjectId", projectId.ToString());
            }
            else
            {
                request = new TfsRestRequest("/_apis/git/repositories");
            }

            Sequence<Repository> list = await Executor.Execute<Sequence<Repository>>(request);
            return list.Value;
        }

        /// <summary>
        /// Get the information about a Git repository by its ID.
        /// </summary>
        /// <param name="id">The ID of the Git repository</param>
        /// <returns>The Git repository</returns>
        public async Task<Repository> GetRepository(Guid id)
        {
            Assert.NotNull(id, "id");

            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}");
            request.AddUrlSegment("RepositoryId", id.ToString());

            return await Executor.Execute<Repository>(request);
        }

        /// <summary>
        /// Get the information about a Git repository by its name.
        /// </summary>
        /// <param name="projectId">The ID of the Team Project that contains this repository</param>
        /// <param name="name">The name of the Git repository</param>
        /// <returns>The Git repository</returns>
        public async Task<Repository> GetRepository(Guid projectId, string name)
        {
            Assert.NotNull(projectId, "projectId");
            Assert.NotNull(name, "name");

            var request = new TfsRestRequest("/_apis/git/{ProjectId}/repositories/{Name}");
            request.AddUrlSegment("ProjectId", projectId.ToString());
            request.AddUrlSegment("Name", name);

            return await Executor.Execute<Repository>(request);
        }

        /// <summary>
        /// Create a new Git repository inside a Team Project.
        /// </summary>
        /// <param name="projectId">The ID of the Team Project that will contain this repository</param>
        /// <param name="name">The name of the repository to create</param>
        /// <returns>The Git repository created</returns>
        /// <exception cref="Infinity.Exceptions.TfsConflictException">If a repository by the same name already exists</exception>
        public async Task<Repository> CreateRepository(Guid projectId, string name)
        {
            Assert.NotNull(projectId, "projectId");
            Assert.NotNull(name, "name");

            var request = new TfsRestRequest("/_apis/git/repositories", HttpMethod.Post);
            request.AddBody(new { name = name, project = new { id = projectId.ToString() } });
            return await Executor.Execute<Repository>(request);
        }

        /// <summary>
        /// Rename a Git repository.
        /// </summary>
        /// <param name="repositoryId">The ID of the repository to rename</param>
        /// <param name="newName">The new name of the repository</param>
        /// <returns>The Git repository after update</returns>
        public async Task<Repository> RenameRepository(Guid repositoryId, string newName)
        {
            Assert.NotNull(repositoryId, "repositoryId");
            Assert.NotNull(newName, "newName");

            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}", new HttpMethod("PATCH"));
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());
            request.AddBody(new { name = newName });
            return await Executor.Execute<Repository>(request);
        }

        /// <summary>
        /// Delete the given Git repository.
        /// </summary>
        /// <param name="repositoryId">The ID of the repository to delete</param>
        public async Task DeleteRepository(Guid repositoryId)
        {
            Assert.NotNull(repositoryId, "repositoryId");

            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}", HttpMethod.Delete);
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());
            await Executor.Execute(request);
        }

        #endregion

        #region Trees

        /// <summary>
        /// Get the information about a Git tree by its ID.
        /// </summary>
        /// <param name="repositoryId">The ID of the repository</param>
        /// <param name="treeId">The object ID of the tree</param>
        /// <returns>The tree</returns>
        public async Task<Tree> GetTree(Guid repositoryId, ObjectId treeId)
        {
            Assert.NotNull(repositoryId, "repositoryId");
            Assert.NotNull(treeId, "treeId");

            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/trees/{TreeId}");
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());
            request.AddUrlSegment("TreeId", treeId.ToString());

            return await Executor.Execute<Tree>(request);
        }

        /// <summary>
        /// Download the contents of a tree as a zip file.
        /// </summary>
        /// <param name="repositoryId">The ID of the repository</param>
        /// <param name="treeId">The object ID of the tree</param>
        /// <param name="outputStream">The stream to write to asynchronously</param>
        public async Task DownloadTree(Guid repositoryId, ObjectId treeId, Stream outputStream)
        {
            Assert.NotNull(repositoryId, "repositoryId");
            Assert.NotNull(treeId, "treeId");
            Assert.NotNull(outputStream, "outputStream");

            var request = new TfsRestRequest("/_apis/git/repositories/{RepositoryId}/trees/{TreeId}");
            request.AddUrlSegment("RepositoryId", repositoryId.ToString());
            request.AddUrlSegment("TreeId", treeId.ToString());
            request.AddUrlSegment("$format", "zip");
            request.AddHeader("Accept", "application/zip");

            await Executor.Execute(request, outputStream);
        }

        #endregion
    }
}