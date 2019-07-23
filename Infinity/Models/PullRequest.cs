using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Infinity.Models
{
    /// <summary>
    /// A pull request, a reviewable request to merge one branch into
    /// another.
    /// </summary>
    public class PullRequest
    {
        /// <summary>
        /// The unique ID of the pull request.
        /// </summary>
        [JsonProperty("PullRequestId")]
        public int Id { get; set; }

        /// <summary>
        /// The URL of the REST endpoint.
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// The status of the pull request.
        /// </summary>
        public PullRequestStatus Status { get; set; }

        /// <summary>
        /// The name of the source branch of the pull request, the branch
        /// that will be merged into the target upon acceptance.
        /// </summary>
        public string SourceRefName { get; set; }

        /// <summary>
        /// The name of the target branch of the pull request, the branch
        /// that will receive the update upon acceptance.
        /// </summary>
        public string TargetRefName { get; set; }

        /// <summary>
        /// The status of the ability to automerge the source branch into
        /// the target branch.
        /// </summary>
        public PullRequestMergeStatus MergeStatus { get; set; }

        /// <summary>
        /// The ID of the merge background job.
        /// </summary>
        public Guid MergeId { get; set; }

        /// <summary>
        /// The short title of the pull request.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The detailed description of the pull request.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The time the pull request was created by the user.
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// The time the pull request was closed.
        /// </summary>
        public DateTime ClosedDate { get; set; }

        /// <summary>
        /// The head commit of the source branch.
        /// </summary>
        public CommitLink LastMergeSourceCommit { get; set; }

        /// <summary>
        /// The head commit of the target branch.
        /// </summary>
        public CommitLink LastMergeTargetCommit { get; set; }

        /// <summary>
        /// The commit that results from the merge of the source and target
        /// branches.
        /// </summary>
        public CommitLink LastMergeCommit { get; set; }

        /// <summary>
        /// The repository that the pull request was opened in.
        /// </summary>
        public Link Repository { get; set; }

        /// <summary>
        /// The creator of the pull request.
        /// </summary>
        public Identity CreatedBy { get; set; }

        /// <summary>
        /// Links to other pull request resources.
        /// </summary>
        [JsonProperty("_links")]
        public PullRequestLinks Links { get; set; }

        /// <summary>
        /// The list of reviewers on a pull request.
        /// </summary>
        public List<PullRequestReviewer> Reviewers { get; set; }

        /// <summary>
        /// The list of tags on a pull request.
        /// </summary>
        public List<WebApiTagDefinition> Labels { get; set; }
    }
}