using System;
using Infinity.Models;

namespace Infinity.Clients
{
    /// <summary>
    /// Pull request query filters
    /// </summary>
    public class PullRequestFilters
    {
        /// <summary>
        /// Pull requests matching the given status will be returned.
        /// </summary>
        public PullRequestStatus? Status { get; set; }

        /// <summary>
        /// Pull requests created by the given user will be returned.
        /// </summary>
        public Guid? CreatorId { get; set; }

        /// <summary>
        /// Pull requests that have been assigned to the given user will
        /// be returned.
        /// </summary>
        public Guid? ReviewerId { get; set; }

        /// <summary>
        /// Pull requests originating from the given source branch will
        /// be returned.
        /// </summary>
        public string SourceRefName { get; set; }

        /// <summary>
        /// Pull requests destined for the given target branch will be
        /// returned.
        /// </summary>
        public string TargetRefName { get; set; }

        /// <summary>
        /// The maximum number of pull requests to return.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// The number of pull requests to return from the query.
        /// </summary>
        public int Skip { get; set; }
    }
}
