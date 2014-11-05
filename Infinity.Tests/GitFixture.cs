using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RestSharp;
using Xunit;

using Infinity;
using Infinity.Clients;
using Infinity.Models;

namespace Infinity.Tests.Models
{
    public class GitFixture : MockClientFixture
    {
        #region Pull Requests

        [Fact]
        public void CanGetPullRequest()
        {
            TfsClient client = NewMockClient(
                new MockRequestConfiguration
                {
                    Uri = "/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/50?api-version=1.0",
                    ResponseResource = "Git.GetPullRequest",
                });

            PullRequest pullRequest = base.ExecuteSync<PullRequest>(
                () => { return client.Git.GetPullRequest(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), 50); });

            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequest.Links.CreatedBy.Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequest.Links.Repository.Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/50"), pullRequest.Links.Self.Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/refs/refs/heads/npaulk/feature"), pullRequest.Links.SourceBranch.Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequest.Links.SourceCommit.Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/refs/refs/heads/master"), pullRequest.Links.TargetBranch.Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequest.Links.TargetCommit.Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/50/workitems"), pullRequest.Links.WorkItems.Url);

            Assert.Equal("Normal Paulk", pullRequest.CreatedBy.DisplayName);
            Assert.Equal(new Guid("d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequest.CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequest.CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber16@hotmail.com", pullRequest.CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequest.CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 10, 28, 01, 54, 43, 248, DateTimeKind.Utc).ToLocalTime(), pullRequest.CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequest.Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequest.LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequest.LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequest.LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequest.LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequest.LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequest.LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("bdd92391-1291-45dd-b4bf-6b7e6270e8d0"), pullRequest.MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequest.MergeStatus);
            Assert.Equal(50, pullRequest.PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequest.Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequest.Repository.Url);

            Assert.Equal(1, pullRequest.Reviewers.Count);

            Assert.Equal("Christie Church", pullRequest.Reviewers[0].DisplayName);
            Assert.Equal(new Guid("3b5f0c34-4aec-4bf4-8708-1d36f0dbc468"), pullRequest.Reviewers[0].Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=3b5f0c34-4aec-4bf4-8708-1d36f0dbc468"), pullRequest.Reviewers[0].ImageUrl);
            Assert.Null(pullRequest.Reviewers[0].ReviewerUrl);
            Assert.Equal("fabrikamfiber1@hotmail.com", pullRequest.Reviewers[0].UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/3b5f0c34-4aec-4bf4-8708-1d36f0dbc468"), pullRequest.Reviewers[0].Url);
            Assert.Equal(0, pullRequest.Reviewers[0].Vote);

            Assert.Equal("refs/heads/npaulk/feature", pullRequest.SourceRefName);
            Assert.Equal(PullRequestStatus.Active, pullRequest.Status);
            Assert.Equal("refs/heads/master", pullRequest.TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequest.Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/50"), pullRequest.Url);
        }

        [Fact]
        public void CanGetPullRequests()
        {
            TfsClient client = NewMockClient(
                new MockRequestConfiguration
                {
                    Uri = "/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests?api-version=1.0",
                    ResponseResource = "Git.GetPullRequests",
                });

            IList<PullRequest> pullRequests = base.ExecuteSync<IEnumerable<PullRequest>>(
                () => { return client.Git.GetPullRequests(new Guid("278d5cd2-584d-4b63-824a-2ba458937249")); }).ToList();

            Assert.Equal(1, pullRequests.Count);

            Assert.Equal("Normal Paulk", pullRequests[0].CreatedBy.DisplayName);
            Assert.Equal(new Guid("d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[0].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[0].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber16@hotmail.com", pullRequests[0].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[0].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 10, 28, 01, 54, 43, 248, DateTimeKind.Utc).ToLocalTime(), pullRequests[0].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[0].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[0].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[0].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[0].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[0].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[0].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[0].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("bdd92391-1291-45dd-b4bf-6b7e6270e8d0"), pullRequests[0].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[0].MergeStatus);
            Assert.Equal(50, pullRequests[0].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[0].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[0].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[0].SourceRefName);
            Assert.Equal(PullRequestStatus.Active, pullRequests[0].Status);
            Assert.Equal("refs/heads/master", pullRequests[0].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[0].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/50"), pullRequests[0].Url);
        }

        [Fact]
        public void CanGetPullRequestsByStatus()
        {
            TfsClient client = NewMockClient(
                new MockRequestConfiguration
                {
                    Uri = "/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests?api-version=1.0&status=completed",
                    ResponseResource = "Git.GetPullRequestsByStatus",
                });

            IList<PullRequest> pullRequests = base.ExecuteSync<IEnumerable<PullRequest>>(
                () => {
                    return client.Git.GetPullRequests(
                        new Guid("278d5cd2-584d-4b63-824a-2ba458937249"),
                        new PullRequestFilters { Status = PullRequestStatus.Completed }
                        );
                }).ToList();

            Assert.Equal(34, pullRequests.Count);

            Assert.Equal(new DateTime(2014, 10, 28, 01, 54, 46, 640, DateTimeKind.Utc).ToLocalTime(), pullRequests[0].ClosedDate);
            Assert.Equal("Normal Paulk", pullRequests[0].CreatedBy.DisplayName);
            Assert.Equal(new Guid("d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[0].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[0].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber16@hotmail.com", pullRequests[0].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[0].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 10, 28, 01, 54, 43, 248, DateTimeKind.Utc).ToLocalTime(), pullRequests[0].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[0].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[0].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[0].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[0].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[0].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[0].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[0].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("bdd92391-1291-45dd-b4bf-6b7e6270e8d0"), pullRequests[0].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[0].MergeStatus);
            Assert.Equal(50, pullRequests[0].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[0].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[0].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[0].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[0].Status);
            Assert.Equal("refs/heads/master", pullRequests[0].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[0].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/50"), pullRequests[0].Url);

            Assert.Equal(new DateTime(2014, 10, 28, 01, 54, 24, 610, DateTimeKind.Utc).ToLocalTime(), pullRequests[1].ClosedDate);
            Assert.Equal("Normal Paulk", pullRequests[1].CreatedBy.DisplayName);
            Assert.Equal(new Guid("d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[1].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[1].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber16@hotmail.com", pullRequests[1].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[1].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 10, 28, 01, 54, 17, 970, DateTimeKind.Utc).ToLocalTime(), pullRequests[1].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[1].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[1].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[1].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[1].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[1].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[1].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[1].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("587d8cfb-1397-40e2-96da-77a7fc38df7f"), pullRequests[1].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[1].MergeStatus);
            Assert.Equal(49, pullRequests[1].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[1].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[1].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[1].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[1].Status);
            Assert.Equal("refs/heads/master", pullRequests[1].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[1].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/49"), pullRequests[1].Url);

            Assert.Equal(new DateTime(2014, 10, 07, 22, 18, 07, 151, DateTimeKind.Utc).ToLocalTime(), pullRequests[2].ClosedDate);
            Assert.Equal("Chuck Reinhart", pullRequests[2].CreatedBy.DisplayName);
            Assert.Equal(new Guid("8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[2].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[2].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber3@hotmail.com", pullRequests[2].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[2].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 10, 07, 22, 18, 01, 986, DateTimeKind.Utc).ToLocalTime(), pullRequests[2].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[2].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[2].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[2].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[2].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[2].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[2].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[2].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("d83c35db-622e-4c77-8cac-994d4fc66851"), pullRequests[2].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[2].MergeStatus);
            Assert.Equal(48, pullRequests[2].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[2].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[2].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[2].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[2].Status);
            Assert.Equal("refs/heads/master", pullRequests[2].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[2].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/48"), pullRequests[2].Url);

            Assert.Equal(new DateTime(2014, 10, 06, 22, 40, 47, 933, DateTimeKind.Utc).ToLocalTime(), pullRequests[3].ClosedDate);
            Assert.Equal("Chuck Reinhart", pullRequests[3].CreatedBy.DisplayName);
            Assert.Equal(new Guid("8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[3].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[3].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber3@hotmail.com", pullRequests[3].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[3].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 10, 06, 22, 40, 30, 047, DateTimeKind.Utc).ToLocalTime(), pullRequests[3].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[3].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[3].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[3].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[3].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[3].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[3].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[3].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("920fd401-e562-47c4-8f2b-bfdf0e1d780b"), pullRequests[3].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[3].MergeStatus);
            Assert.Equal(47, pullRequests[3].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[3].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[3].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[3].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[3].Status);
            Assert.Equal("refs/heads/master", pullRequests[3].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[3].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/47"), pullRequests[3].Url);

            Assert.Equal(new DateTime(2014, 10, 02, 18, 24, 41, 370, DateTimeKind.Utc).ToLocalTime(), pullRequests[4].ClosedDate);
            Assert.Equal("Chuck Reinhart", pullRequests[4].CreatedBy.DisplayName);
            Assert.Equal(new Guid("8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[4].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[4].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber3@hotmail.com", pullRequests[4].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[4].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 10, 02, 18, 24, 36, 910, DateTimeKind.Utc).ToLocalTime(), pullRequests[4].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[4].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[4].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[4].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[4].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[4].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[4].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[4].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("281a48c8-8675-4442-9e63-72dabf651147"), pullRequests[4].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[4].MergeStatus);
            Assert.Equal(46, pullRequests[4].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[4].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[4].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[4].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[4].Status);
            Assert.Equal("refs/heads/master", pullRequests[4].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[4].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/46"), pullRequests[4].Url);

            Assert.Equal(new DateTime(2014, 10, 02, 18, 10, 32, 689, DateTimeKind.Utc).ToLocalTime(), pullRequests[5].ClosedDate);
            Assert.Equal("Chuck Reinhart", pullRequests[5].CreatedBy.DisplayName);
            Assert.Equal(new Guid("8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[5].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[5].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber3@hotmail.com", pullRequests[5].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[5].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 10, 02, 18, 10, 27, 260, DateTimeKind.Utc).ToLocalTime(), pullRequests[5].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[5].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[5].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[5].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[5].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[5].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[5].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[5].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("c8bb3a02-9ea1-4f14-9c6b-25ecf2ea7dee"), pullRequests[5].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[5].MergeStatus);
            Assert.Equal(45, pullRequests[5].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[5].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[5].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[5].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[5].Status);
            Assert.Equal("refs/heads/master", pullRequests[5].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[5].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/45"), pullRequests[5].Url);

            Assert.Equal(new DateTime(2014, 10, 02, 18, 02, 42, 720, DateTimeKind.Utc).ToLocalTime(), pullRequests[6].ClosedDate);
            Assert.Equal("Chuck Reinhart", pullRequests[6].CreatedBy.DisplayName);
            Assert.Equal(new Guid("8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[6].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[6].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber3@hotmail.com", pullRequests[6].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[6].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 10, 02, 18, 02, 36, 592, DateTimeKind.Utc).ToLocalTime(), pullRequests[6].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[6].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[6].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[6].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[6].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[6].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[6].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[6].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("7db28c08-7f5e-4c75-848d-352b83f7d223"), pullRequests[6].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[6].MergeStatus);
            Assert.Equal(44, pullRequests[6].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[6].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[6].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[6].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[6].Status);
            Assert.Equal("refs/heads/master", pullRequests[6].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[6].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/44"), pullRequests[6].Url);

            Assert.Equal(new DateTime(2014, 10, 02, 17, 33, 01, 379, DateTimeKind.Utc).ToLocalTime(), pullRequests[7].ClosedDate);
            Assert.Equal("Chuck Reinhart", pullRequests[7].CreatedBy.DisplayName);
            Assert.Equal(new Guid("8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[7].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[7].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber3@hotmail.com", pullRequests[7].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[7].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 10, 02, 17, 32, 56, 66, DateTimeKind.Utc).ToLocalTime(), pullRequests[7].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[7].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[7].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[7].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[7].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[7].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[7].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[7].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("c5cbd8ff-7d76-4292-84d2-5bd70df12e56"), pullRequests[7].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[7].MergeStatus);
            Assert.Equal(43, pullRequests[7].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[7].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[7].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[7].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[7].Status);
            Assert.Equal("refs/heads/master", pullRequests[7].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[7].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/43"), pullRequests[7].Url);

            Assert.Equal(new DateTime(2014, 10, 02, 16, 37, 52, 814, DateTimeKind.Utc).ToLocalTime(), pullRequests[8].ClosedDate);
            Assert.Equal("Chuck Reinhart", pullRequests[8].CreatedBy.DisplayName);
            Assert.Equal(new Guid("8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[8].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[8].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber3@hotmail.com", pullRequests[8].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[8].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 10, 02, 16, 37, 48, 67, DateTimeKind.Utc).ToLocalTime(), pullRequests[8].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[8].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[8].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[8].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[8].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[8].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[8].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[8].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("43de9c66-e417-4203-b99e-0b3a51e88c8f"), pullRequests[8].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[8].MergeStatus);
            Assert.Equal(42, pullRequests[8].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[8].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[8].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[8].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[8].Status);
            Assert.Equal("refs/heads/master", pullRequests[8].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[8].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/42"), pullRequests[8].Url);

            Assert.Equal(new DateTime(2014, 10, 02, 16, 25, 01, 841, DateTimeKind.Utc).ToLocalTime(), pullRequests[9].ClosedDate);
            Assert.Equal("Chuck Reinhart", pullRequests[9].CreatedBy.DisplayName);
            Assert.Equal(new Guid("8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[9].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[9].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber3@hotmail.com", pullRequests[9].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[9].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 10, 02, 16, 24, 56, 607, DateTimeKind.Utc).ToLocalTime(), pullRequests[9].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[9].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[9].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[9].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[9].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[9].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[9].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[9].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("dabb8751-0c44-4aef-9ea5-f1e0f0ed0d2e"), pullRequests[9].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[9].MergeStatus);
            Assert.Equal(41, pullRequests[9].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[9].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[9].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[9].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[9].Status);
            Assert.Equal("refs/heads/master", pullRequests[9].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[9].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/41"), pullRequests[9].Url);

            Assert.Equal(new DateTime(2014, 10, 02, 16, 03, 44, 687, DateTimeKind.Utc).ToLocalTime(), pullRequests[10].ClosedDate);
            Assert.Equal("Chuck Reinhart", pullRequests[10].CreatedBy.DisplayName);
            Assert.Equal(new Guid("8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[10].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[10].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber3@hotmail.com", pullRequests[10].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[10].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 10, 02, 16, 03, 40, 000, DateTimeKind.Utc).ToLocalTime(), pullRequests[10].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[10].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[10].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[10].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[10].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[10].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[10].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[10].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("a9296a39-edeb-4606-9244-03f418bc40a9"), pullRequests[10].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[10].MergeStatus);
            Assert.Equal(40, pullRequests[10].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[10].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[10].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[10].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[10].Status);
            Assert.Equal("refs/heads/master", pullRequests[10].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[10].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/40"), pullRequests[10].Url);

            Assert.Equal(new DateTime(2014, 10, 01, 23, 22, 49, 497, DateTimeKind.Utc).ToLocalTime(), pullRequests[11].ClosedDate);
            Assert.Equal("Chuck Reinhart", pullRequests[11].CreatedBy.DisplayName);
            Assert.Equal(new Guid("8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[11].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[11].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber3@hotmail.com", pullRequests[11].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[11].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 10, 01, 23, 22, 44, 888, DateTimeKind.Utc).ToLocalTime(), pullRequests[11].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[11].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[11].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[11].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[11].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[11].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[11].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[11].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("86add78f-286a-4578-bbb2-a2817af015b1"), pullRequests[11].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[11].MergeStatus);
            Assert.Equal(39, pullRequests[11].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[11].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[11].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[11].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[11].Status);
            Assert.Equal("refs/heads/master", pullRequests[11].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[11].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/39"), pullRequests[11].Url);

            Assert.Equal(new DateTime(2014, 09, 30, 20, 31, 29, 548, DateTimeKind.Utc).ToLocalTime(), pullRequests[12].ClosedDate);
            Assert.Equal("Normal Paulk", pullRequests[12].CreatedBy.DisplayName);
            Assert.Equal(new Guid("d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[12].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[12].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber16@hotmail.com", pullRequests[12].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[12].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 09, 30, 20, 31, 27, 29, DateTimeKind.Utc).ToLocalTime(), pullRequests[12].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[12].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[12].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[12].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[12].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[12].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[12].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[12].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("c0757679-d11b-4cec-ba60-98e6e2b2683f"), pullRequests[12].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[12].MergeStatus);
            Assert.Equal(38, pullRequests[12].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[12].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[12].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[12].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[12].Status);
            Assert.Equal("refs/heads/master", pullRequests[12].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[12].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/38"), pullRequests[12].Url);

            Assert.Equal(new DateTime(2014, 09, 30, 20, 30, 02, 002, DateTimeKind.Utc).ToLocalTime(), pullRequests[13].ClosedDate);
            Assert.Equal("Normal Paulk", pullRequests[13].CreatedBy.DisplayName);
            Assert.Equal(new Guid("d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[13].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[13].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber16@hotmail.com", pullRequests[13].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[13].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 09, 30, 20, 29, 59, 86, DateTimeKind.Utc).ToLocalTime(), pullRequests[13].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[13].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[13].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[13].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[13].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[13].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[13].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[13].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("e5565255-857c-427f-8968-a29e8e22dd19"), pullRequests[13].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[13].MergeStatus);
            Assert.Equal(37, pullRequests[13].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[13].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[13].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[13].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[13].Status);
            Assert.Equal("refs/heads/master", pullRequests[13].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[13].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/37"), pullRequests[13].Url);

            Assert.Equal(new DateTime(2014, 09, 30, 20, 27, 37, 191, DateTimeKind.Utc).ToLocalTime(), pullRequests[14].ClosedDate);
            Assert.Equal("Normal Paulk", pullRequests[14].CreatedBy.DisplayName);
            Assert.Equal(new Guid("d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[14].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[14].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber16@hotmail.com", pullRequests[14].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[14].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 09, 30, 20, 27, 35, 066, DateTimeKind.Utc).ToLocalTime(), pullRequests[14].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[14].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[14].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[14].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[14].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[14].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[14].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[14].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("d63985c6-6533-4faa-a456-65150f63e9b0"), pullRequests[14].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[14].MergeStatus);
            Assert.Equal(36, pullRequests[14].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[14].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[14].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[14].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[14].Status);
            Assert.Equal("refs/heads/master", pullRequests[14].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[14].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/36"), pullRequests[14].Url);

            Assert.Equal(new DateTime(2014, 09, 30, 20, 23, 55, 50, DateTimeKind.Utc).ToLocalTime(), pullRequests[15].ClosedDate);
            Assert.Equal("Normal Paulk", pullRequests[15].CreatedBy.DisplayName);
            Assert.Equal(new Guid("d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[15].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[15].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber16@hotmail.com", pullRequests[15].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[15].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 09, 30, 20, 23, 53, 079, DateTimeKind.Utc).ToLocalTime(), pullRequests[15].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[15].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[15].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[15].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[15].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[15].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[15].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[15].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("35bc006b-2cc8-4228-87fb-306a5d6f36d3"), pullRequests[15].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[15].MergeStatus);
            Assert.Equal(35, pullRequests[15].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[15].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[15].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[15].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[15].Status);
            Assert.Equal("refs/heads/master", pullRequests[15].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[15].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/35"), pullRequests[15].Url);

            Assert.Equal(new DateTime(2014, 09, 30, 20, 21, 47, 296, DateTimeKind.Utc).ToLocalTime(), pullRequests[16].ClosedDate);
            Assert.Equal("Normal Paulk", pullRequests[16].CreatedBy.DisplayName);
            Assert.Equal(new Guid("d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[16].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[16].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber16@hotmail.com", pullRequests[16].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[16].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 09, 30, 20, 21, 45, 124, DateTimeKind.Utc).ToLocalTime(), pullRequests[16].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[16].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[16].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[16].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[16].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[16].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[16].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[16].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("1f640dc7-d6b4-4cae-a2f3-b2c868492217"), pullRequests[16].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[16].MergeStatus);
            Assert.Equal(34, pullRequests[16].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[16].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[16].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[16].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[16].Status);
            Assert.Equal("refs/heads/master", pullRequests[16].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[16].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/34"), pullRequests[16].Url);

            Assert.Equal(new DateTime(2014, 09, 30, 20, 19, 56, 438, DateTimeKind.Utc).ToLocalTime(), pullRequests[17].ClosedDate);
            Assert.Equal("Normal Paulk", pullRequests[17].CreatedBy.DisplayName);
            Assert.Equal(new Guid("d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[17].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[17].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber16@hotmail.com", pullRequests[17].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[17].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 09, 30, 20, 19, 53, 420, DateTimeKind.Utc).ToLocalTime(), pullRequests[17].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[17].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[17].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[17].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[17].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[17].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[17].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[17].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("c93d13f7-e8d3-43a4-add7-a6aaefeac489"), pullRequests[17].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[17].MergeStatus);
            Assert.Equal(33, pullRequests[17].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[17].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[17].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[17].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[17].Status);
            Assert.Equal("refs/heads/master", pullRequests[17].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[17].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/33"), pullRequests[17].Url);

            Assert.Equal(new DateTime(2014, 09, 30, 20, 19, 36, 747, DateTimeKind.Utc).ToLocalTime(), pullRequests[18].ClosedDate);
            Assert.Equal("Normal Paulk", pullRequests[18].CreatedBy.DisplayName);
            Assert.Equal(new Guid("d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[18].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[18].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber16@hotmail.com", pullRequests[18].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[18].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 09, 30, 20, 19, 34, 232, DateTimeKind.Utc).ToLocalTime(), pullRequests[18].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[18].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[18].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[18].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[18].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[18].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[18].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[18].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("d7ad086e-7c9e-4806-9f01-8201f385cdd0"), pullRequests[18].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[18].MergeStatus);
            Assert.Equal(32, pullRequests[18].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[18].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[18].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[18].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[18].Status);
            Assert.Equal("refs/heads/master", pullRequests[18].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[18].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/32"), pullRequests[18].Url);

            Assert.Equal(new DateTime(2014, 09, 30, 20, 16, 41, 275, DateTimeKind.Utc).ToLocalTime(), pullRequests[19].ClosedDate);
            Assert.Equal("Normal Paulk", pullRequests[19].CreatedBy.DisplayName);
            Assert.Equal(new Guid("d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[19].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[19].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber16@hotmail.com", pullRequests[19].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[19].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 09, 30, 20, 16, 38, 75, DateTimeKind.Utc).ToLocalTime(), pullRequests[19].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[19].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[19].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[19].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[19].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[19].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[19].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[19].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("206efb5b-4218-430d-858f-bfc064f6f797"), pullRequests[19].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[19].MergeStatus);
            Assert.Equal(31, pullRequests[19].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[19].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[19].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[19].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[19].Status);
            Assert.Equal("refs/heads/master", pullRequests[19].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[19].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/31"), pullRequests[19].Url);

            Assert.Equal(new DateTime(2014, 09, 30, 20, 15, 57, 086, DateTimeKind.Utc).ToLocalTime(), pullRequests[20].ClosedDate);
            Assert.Equal("Normal Paulk", pullRequests[20].CreatedBy.DisplayName);
            Assert.Equal(new Guid("d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[20].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[20].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber16@hotmail.com", pullRequests[20].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[20].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 09, 30, 20, 15, 54, 101, DateTimeKind.Utc).ToLocalTime(), pullRequests[20].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[20].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[20].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[20].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[20].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[20].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[20].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[20].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("ebf3505c-4972-4bd6-9f0e-a2288153cfa5"), pullRequests[20].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[20].MergeStatus);
            Assert.Equal(30, pullRequests[20].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[20].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[20].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[20].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[20].Status);
            Assert.Equal("refs/heads/master", pullRequests[20].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[20].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/30"), pullRequests[20].Url);

            Assert.Equal(new DateTime(2014, 09, 30, 20, 13, 34, 113, DateTimeKind.Utc).ToLocalTime(), pullRequests[21].ClosedDate);
            Assert.Equal("Normal Paulk", pullRequests[21].CreatedBy.DisplayName);
            Assert.Equal(new Guid("d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[21].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[21].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber16@hotmail.com", pullRequests[21].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[21].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 09, 30, 20, 13, 29, 712, DateTimeKind.Utc).ToLocalTime(), pullRequests[21].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[21].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[21].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[21].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[21].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[21].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[21].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[21].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("4bacf29c-9b60-4c79-9f8a-3cdd9ca1b212"), pullRequests[21].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[21].MergeStatus);
            Assert.Equal(29, pullRequests[21].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[21].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[21].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[21].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[21].Status);
            Assert.Equal("refs/heads/master", pullRequests[21].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[21].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/29"), pullRequests[21].Url);

            Assert.Equal(new DateTime(2014, 09, 30, 18, 59, 07, 311, DateTimeKind.Utc).ToLocalTime(), pullRequests[22].ClosedDate);
            Assert.Equal("Normal Paulk", pullRequests[22].CreatedBy.DisplayName);
            Assert.Equal(new Guid("d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[22].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[22].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber16@hotmail.com", pullRequests[22].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[22].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 09, 30, 18, 59, 04, 388, DateTimeKind.Utc).ToLocalTime(), pullRequests[22].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[22].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[22].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[22].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[22].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[22].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[22].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[22].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("14e99962-e9b6-4658-87e2-7ea402f8aa00"), pullRequests[22].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[22].MergeStatus);
            Assert.Equal(28, pullRequests[22].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[22].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[22].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[22].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[22].Status);
            Assert.Equal("refs/heads/master", pullRequests[22].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[22].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/28"), pullRequests[22].Url);

            Assert.Equal(new DateTime(2014, 09, 30, 18, 58, 18, 749, DateTimeKind.Utc).ToLocalTime(), pullRequests[23].ClosedDate);
            Assert.Equal("Normal Paulk", pullRequests[23].CreatedBy.DisplayName);
            Assert.Equal(new Guid("d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[23].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[23].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber16@hotmail.com", pullRequests[23].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[23].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 09, 30, 18, 58, 16, 108, DateTimeKind.Utc).ToLocalTime(), pullRequests[23].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[23].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[23].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[23].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[23].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[23].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[23].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[23].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("8f74ac43-b931-4788-9976-6e03d628b485"), pullRequests[23].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[23].MergeStatus);
            Assert.Equal(27, pullRequests[23].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[23].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[23].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[23].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[23].Status);
            Assert.Equal("refs/heads/master", pullRequests[23].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[23].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/27"), pullRequests[23].Url);

            Assert.Equal(new DateTime(2014, 09, 30, 18, 58, 04, 369, DateTimeKind.Utc).ToLocalTime(), pullRequests[24].ClosedDate);
            Assert.Equal("Normal Paulk", pullRequests[24].CreatedBy.DisplayName);
            Assert.Equal(new Guid("d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[24].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[24].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber16@hotmail.com", pullRequests[24].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[24].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 09, 30, 18, 58, 01, 281, DateTimeKind.Utc).ToLocalTime(), pullRequests[24].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[24].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[24].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[24].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[24].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[24].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[24].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[24].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("0f85a75c-0541-4868-a4c6-e7fd9e524374"), pullRequests[24].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[24].MergeStatus);
            Assert.Equal(26, pullRequests[24].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[24].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[24].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[24].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[24].Status);
            Assert.Equal("refs/heads/master", pullRequests[24].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[24].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/26"), pullRequests[24].Url);

            Assert.Equal(new DateTime(2014, 09, 30, 18, 57, 22, 872, DateTimeKind.Utc).ToLocalTime(), pullRequests[25].ClosedDate);
            Assert.Equal("Normal Paulk", pullRequests[25].CreatedBy.DisplayName);
            Assert.Equal(new Guid("d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[25].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[25].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber16@hotmail.com", pullRequests[25].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[25].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 09, 30, 18, 57, 20, 466, DateTimeKind.Utc).ToLocalTime(), pullRequests[25].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[25].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[25].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[25].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[25].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[25].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[25].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[25].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("4db38225-9b2f-4828-ba6d-527ce025f944"), pullRequests[25].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[25].MergeStatus);
            Assert.Equal(25, pullRequests[25].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[25].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[25].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[25].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[25].Status);
            Assert.Equal("refs/heads/master", pullRequests[25].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[25].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/25"), pullRequests[25].Url);

            Assert.Equal(new DateTime(2014, 09, 30, 18, 56, 51, 456, DateTimeKind.Utc).ToLocalTime(), pullRequests[26].ClosedDate);
            Assert.Equal("Normal Paulk", pullRequests[26].CreatedBy.DisplayName);
            Assert.Equal(new Guid("d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[26].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[26].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber16@hotmail.com", pullRequests[26].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[26].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 09, 30, 18, 56, 49, 221, DateTimeKind.Utc).ToLocalTime(), pullRequests[26].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[26].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[26].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[26].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[26].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[26].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[26].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[26].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("4f705dcf-a786-45d4-851f-07081a0e2e77"), pullRequests[26].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[26].MergeStatus);
            Assert.Equal(24, pullRequests[26].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[26].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[26].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[26].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[26].Status);
            Assert.Equal("refs/heads/master", pullRequests[26].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[26].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/24"), pullRequests[26].Url);

            Assert.Equal(new DateTime(2014, 09, 30, 18, 55, 28, 009, DateTimeKind.Utc).ToLocalTime(), pullRequests[27].ClosedDate);
            Assert.Equal("Normal Paulk", pullRequests[27].CreatedBy.DisplayName);
            Assert.Equal(new Guid("d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[27].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[27].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber16@hotmail.com", pullRequests[27].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[27].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 09, 30, 18, 55, 24, 822, DateTimeKind.Utc).ToLocalTime(), pullRequests[27].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[27].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[27].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[27].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[27].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[27].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[27].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[27].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("106e5b55-6f02-46f2-988a-78419330d1d7"), pullRequests[27].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[27].MergeStatus);
            Assert.Equal(23, pullRequests[27].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[27].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[27].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[27].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[27].Status);
            Assert.Equal("refs/heads/master", pullRequests[27].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[27].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/23"), pullRequests[27].Url);

            Assert.Equal(new DateTime(2014, 09, 30, 18, 53, 44, 996, DateTimeKind.Utc).ToLocalTime(), pullRequests[28].ClosedDate);
            Assert.Equal("Normal Paulk", pullRequests[28].CreatedBy.DisplayName);
            Assert.Equal(new Guid("d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[28].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[28].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber16@hotmail.com", pullRequests[28].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[28].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 09, 30, 18, 53, 39, 816, DateTimeKind.Utc).ToLocalTime(), pullRequests[28].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[28].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[28].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[28].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[28].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[28].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[28].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[28].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("358f0b6f-f7c1-41b4-b158-900ff55b6775"), pullRequests[28].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[28].MergeStatus);
            Assert.Equal(22, pullRequests[28].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[28].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[28].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[28].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[28].Status);
            Assert.Equal("refs/heads/master", pullRequests[28].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[28].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/22"), pullRequests[28].Url);

            Assert.Equal(new DateTime(2014, 09, 30, 18, 46, 58, 642, DateTimeKind.Utc).ToLocalTime(), pullRequests[29].ClosedDate);
            Assert.Equal("Normal Paulk", pullRequests[29].CreatedBy.DisplayName);
            Assert.Equal(new Guid("d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[29].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[29].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber16@hotmail.com", pullRequests[29].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[29].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 09, 30, 18, 46, 50, 774, DateTimeKind.Utc).ToLocalTime(), pullRequests[29].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[29].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[29].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[29].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[29].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[29].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[29].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[29].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("73c4c912-e557-446f-8030-f9572380bf16"), pullRequests[29].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[29].MergeStatus);
            Assert.Equal(21, pullRequests[29].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[29].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[29].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[29].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[29].Status);
            Assert.Equal("refs/heads/master", pullRequests[29].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[29].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/21"), pullRequests[29].Url);

            Assert.Equal(new DateTime(2014, 09, 25, 17, 41, 08, 430, DateTimeKind.Utc).ToLocalTime(), pullRequests[30].ClosedDate);
            Assert.Equal("Chuck Reinhart", pullRequests[30].CreatedBy.DisplayName);
            Assert.Equal(new Guid("8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[30].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[30].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber3@hotmail.com", pullRequests[30].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), pullRequests[30].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 09, 25, 17, 41, 01, 945, DateTimeKind.Utc).ToLocalTime(), pullRequests[30].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[30].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[30].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[30].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[30].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[30].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[30].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[30].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("e02914de-e59a-481e-9609-dad2ed3b6d9c"), pullRequests[30].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[30].MergeStatus);
            Assert.Equal(20, pullRequests[30].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[30].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[30].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[30].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[30].Status);
            Assert.Equal("refs/heads/master", pullRequests[30].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[30].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/20"), pullRequests[30].Url);

            Assert.Equal(new DateTime(2014, 06, 30, 18, 11, 18, 108, DateTimeKind.Utc).ToLocalTime(), pullRequests[31].ClosedDate);
            Assert.Equal("Normal Paulk", pullRequests[31].CreatedBy.DisplayName);
            Assert.Equal(new Guid("d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[31].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[31].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber16@hotmail.com", pullRequests[31].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[31].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 06, 30, 18, 11, 15, 249, DateTimeKind.Utc).ToLocalTime(), pullRequests[31].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[31].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[31].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[31].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[31].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[31].LastMergeSourceCommit.Url);
            Assert.Equal("fe17a84cc2dfe0ea3a2202ab4dbac0706058e41f", pullRequests[31].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/fe17a84cc2dfe0ea3a2202ab4dbac0706058e41f"), pullRequests[31].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("4d45d7fd-4c4d-4966-829e-6ccce4f057d9"), pullRequests[31].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[31].MergeStatus);
            Assert.Equal(19, pullRequests[31].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[31].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[31].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[31].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[31].Status);
            Assert.Equal("refs/heads/master", pullRequests[31].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[31].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/19"), pullRequests[31].Url);

            Assert.Equal(new DateTime(2014, 06, 30, 17, 58, 34, 176, DateTimeKind.Utc).ToLocalTime(), pullRequests[32].ClosedDate);
            Assert.Equal("Normal Paulk", pullRequests[32].CreatedBy.DisplayName);
            Assert.Equal(new Guid("d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[32].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[32].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber16@hotmail.com", pullRequests[32].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[32].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 06, 30, 17, 58, 32, 34, DateTimeKind.Utc).ToLocalTime(), pullRequests[32].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[32].Description);
            Assert.Equal("fe17a84cc2dfe0ea3a2202ab4dbac0706058e41f", pullRequests[32].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/fe17a84cc2dfe0ea3a2202ab4dbac0706058e41f"), pullRequests[32].LastMergeCommit.Url);
            Assert.Equal("fe17a84cc2dfe0ea3a2202ab4dbac0706058e41f", pullRequests[32].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/fe17a84cc2dfe0ea3a2202ab4dbac0706058e41f"), pullRequests[32].LastMergeSourceCommit.Url);
            Assert.Equal("0360c963d7d86d040e9c33bba836feab14da4ad3", pullRequests[32].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/0360c963d7d86d040e9c33bba836feab14da4ad3"), pullRequests[32].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("20d1a573-cb72-40d8-a6bc-8365912d5821"), pullRequests[32].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[32].MergeStatus);
            Assert.Equal(18, pullRequests[32].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[32].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[32].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[32].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[32].Status);
            Assert.Equal("refs/heads/master", pullRequests[32].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[32].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/18"), pullRequests[32].Url);

            Assert.Equal(new DateTime(2014, 06, 30, 17, 48, 43, 184, DateTimeKind.Utc).ToLocalTime(), pullRequests[33].ClosedDate);
            Assert.Equal("Normal Paulk", pullRequests[33].CreatedBy.DisplayName);
            Assert.Equal(new Guid("d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[33].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[33].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber16@hotmail.com", pullRequests[33].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[33].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 06, 30, 17, 29, 24, 685, DateTimeKind.Utc).ToLocalTime(), pullRequests[33].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[33].Description);
            Assert.Equal("0360c963d7d86d040e9c33bba836feab14da4ad3", pullRequests[33].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/0360c963d7d86d040e9c33bba836feab14da4ad3"), pullRequests[33].LastMergeCommit.Url);
            Assert.Equal("0360c963d7d86d040e9c33bba836feab14da4ad3", pullRequests[33].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/0360c963d7d86d040e9c33bba836feab14da4ad3"), pullRequests[33].LastMergeSourceCommit.Url);
            Assert.Equal("097d82b8aeabe493bf4c3553d320ae2529bba591", pullRequests[33].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/097d82b8aeabe493bf4c3553d320ae2529bba591"), pullRequests[33].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("356016f4-9e81-44e6-82cc-c3d2e9fe4566"), pullRequests[33].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[33].MergeStatus);
            Assert.Equal(14, pullRequests[33].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[33].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[33].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[33].SourceRefName);
            Assert.Equal(PullRequestStatus.Completed, pullRequests[33].Status);
            Assert.Equal("refs/heads/master", pullRequests[33].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[33].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/14"), pullRequests[33].Url);
        }

        [Fact]
        public void CanGetPullRequestsByTargetBranch()
        {
            TfsClient client = NewMockClient(
                new MockRequestConfiguration
                {
                    Uri = "/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests?api-version=1.0&targetRefName=refs/heads/master",
                    ResponseResource = "Git.GetPullRequestsByTargetBranch",
                });

            IList<PullRequest> pullRequests = base.ExecuteSync<IEnumerable<PullRequest>>(
                () =>
                {
                    return client.Git.GetPullRequests(
                        new Guid("278d5cd2-584d-4b63-824a-2ba458937249"),
                        new PullRequestFilters { TargetRefName = "refs/heads/master" }
                        );
                }).ToList();

            Assert.Equal(1, pullRequests.Count);

            Assert.Equal("Normal Paulk", pullRequests[0].CreatedBy.DisplayName);
            Assert.Equal(new Guid("d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[0].CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[0].CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber16@hotmail.com", pullRequests[0].CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequests[0].CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 10, 28, 01, 54, 43, 248, DateTimeKind.Utc).ToLocalTime(), pullRequests[0].CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequests[0].Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[0].LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[0].LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[0].LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[0].LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequests[0].LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequests[0].LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("bdd92391-1291-45dd-b4bf-6b7e6270e8d0"), pullRequests[0].MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequests[0].MergeStatus);
            Assert.Equal(50, pullRequests[0].PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[0].Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequests[0].Repository.Url);
            Assert.Equal("refs/heads/npaulk/feature", pullRequests[0].SourceRefName);
            Assert.Equal(PullRequestStatus.Active, pullRequests[0].Status);
            Assert.Equal("refs/heads/master", pullRequests[0].TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequests[0].Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/50"), pullRequests[0].Url);
        }

        [Fact]
        public void CanCreatePullRequest()
        {
            TfsClient client = NewMockClient(
                new MockRequestConfiguration
                {
                    Uri = "/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests?api-version=1.0",
                    Method = RestSharp.Method.POST,
                    RequestObject = new
                    {
                        sourceRefName = "refs/heads/npaulk/feature",
                        targetRefName = "refs/heads/master",
                        title = "New fix for hello world class",
                        description = "Example pull request showing review and integration of a simple change.",
                        reviewers = new[] {
                            new { id = "3b5f0c34-4aec-4bf4-8708-1d36f0dbc468" },
                        },
                    },
                    ResponseResource = "Git.CreatePullRequest",
                });

            PullRequest pullRequest = base.ExecuteSync<PullRequest>(
                () =>
                {
                    return client.Git.CreatePullRequest(
                        new Guid("278d5cd2-584d-4b63-824a-2ba458937249"),
                        "refs/heads/npaulk/feature",
                        "refs/heads/master",
                        "New fix for hello world class",
                        "Example pull request showing review and integration of a simple change.",
                        new Guid[] { new Guid("3b5f0c34-4aec-4bf4-8708-1d36f0dbc468") });
                });

            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequest.Links.CreatedBy.Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequest.Links.Repository.Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/50"), pullRequest.Links.Self.Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/refs/refs/heads/npaulk/feature"), pullRequest.Links.SourceBranch.Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequest.Links.SourceCommit.Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/refs/refs/heads/master"), pullRequest.Links.TargetBranch.Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequest.Links.TargetCommit.Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/50/workitems"), pullRequest.Links.WorkItems.Url);
            Assert.Equal("Normal Paulk", pullRequest.CreatedBy.DisplayName);
            Assert.Equal(new Guid("d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequest.CreatedBy.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequest.CreatedBy.ImageUrl);
            Assert.Equal("fabrikamfiber16@hotmail.com", pullRequest.CreatedBy.UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/d6245f20-2af8-44f4-9451-8107cb2767db"), pullRequest.CreatedBy.Url);
            Assert.Equal(new DateTime(2014, 10, 28, 01, 54, 43, 248, DateTimeKind.Utc).ToLocalTime(), pullRequest.CreationDate);
            Assert.Equal("Example pull request showing review and integration of a simple change.", pullRequest.Description);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequest.LastMergeCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequest.LastMergeCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequest.LastMergeSourceCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequest.LastMergeSourceCommit.Url);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", pullRequest.LastMergeTargetCommit.CommitId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/commits/23d0bc5b128a10056dc68afece360d8a0fabb014"), pullRequest.LastMergeTargetCommit.Url);
            Assert.Equal(new Guid("bdd92391-1291-45dd-b4bf-6b7e6270e8d0"), pullRequest.MergeId);
            Assert.Equal(PullRequestMergeStatus.Succeeded, pullRequest.MergeStatus);
            Assert.Equal(50, pullRequest.PullRequestId);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), pullRequest.Repository.Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), pullRequest.Repository.Url);
            Assert.Equal(1, pullRequest.Reviewers.Count);

            Assert.Equal("Christie Church", pullRequest.Reviewers[0].DisplayName);
            Assert.Equal(new Guid("3b5f0c34-4aec-4bf4-8708-1d36f0dbc468"), pullRequest.Reviewers[0].Id);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_api/_common/identityImage?id=3b5f0c34-4aec-4bf4-8708-1d36f0dbc468"), pullRequest.Reviewers[0].ImageUrl);
            Assert.Null(pullRequest.Reviewers[0].ReviewerUrl);
            Assert.Equal("fabrikamfiber1@hotmail.com", pullRequest.Reviewers[0].UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/3b5f0c34-4aec-4bf4-8708-1d36f0dbc468"), pullRequest.Reviewers[0].Url);
            Assert.Equal(0, pullRequest.Reviewers[0].Vote);

            Assert.Equal("refs/heads/npaulk/feature", pullRequest.SourceRefName);
            Assert.Equal(PullRequestStatus.Active, pullRequest.Status);
            Assert.Equal("refs/heads/master", pullRequest.TargetRefName);
            Assert.Equal("New fix for hello world class", pullRequest.Title);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/pullRequests/50"), pullRequest.Url);
        }

        #endregion

        #region Repositories

        [Fact]
        public void CanGetRepositories()
        {
            TfsClient client = NewMockClient(
                new MockRequestConfiguration
                {
                    Uri = "/_apis/git/repositories?api-version=1.0",
                    ResponseResource = "Git.GetRepositories",
                });

            IList<Repository> repositories = base.ExecuteSync<IEnumerable<Repository>>(
                () => { return client.Git.GetRepositories(); }).ToList();

            Assert.Equal(3, repositories.Count);

            Assert.Equal("refs/heads/master", repositories[0].DefaultBranch);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), repositories[0].Id);
            Assert.Equal("Fabrikam-Fiber-Git", repositories[0].Name);
            Assert.Equal(new Guid("6ce954b1-ce1f-45d1-b94d-e6bf2464ba2c"), repositories[0].Project.Id);
            Assert.Equal("Fabrikam-Fiber-Git", repositories[0].Project.Name);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/projects/6ce954b1-ce1f-45d1-b94d-e6bf2464ba2c"), repositories[0].Project.Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_git/Fabrikam-Fiber-Git"), repositories[0].RemoteUrl);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), repositories[0].Url);

            Assert.Equal("refs/heads/master", repositories[1].DefaultBranch);
            Assert.Equal(new Guid("66efb083-777a-4cac-a350-a24b046be6be"), repositories[1].Id);
            Assert.Equal("TestGit", repositories[1].Name);
            Assert.Equal(new Guid("281f9a5b-af0d-49b4-a1df-fe6f5e5f84d0"), repositories[1].Project.Id);
            Assert.Equal("TestGit", repositories[1].Project.Name);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/projects/281f9a5b-af0d-49b4-a1df-fe6f5e5f84d0"), repositories[1].Project.Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_git/TestGit"), repositories[1].RemoteUrl);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/66efb083-777a-4cac-a350-a24b046be6be"), repositories[1].Url);

            Assert.Equal(new Guid("17c3a073-1785-4f51-ba0a-a877bba5f5c7"), repositories[2].Id);
            Assert.Equal("AnotherRepository", repositories[2].Name);
            Assert.Equal(new Guid("6ce954b1-ce1f-45d1-b94d-e6bf2464ba2c"), repositories[2].Project.Id);
            Assert.Equal("Fabrikam-Fiber-Git", repositories[2].Project.Name);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/projects/6ce954b1-ce1f-45d1-b94d-e6bf2464ba2c"), repositories[2].Project.Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/Fabrikam-Fiber-Git/_git/AnotherRepository"), repositories[2].RemoteUrl);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/17c3a073-1785-4f51-ba0a-a877bba5f5c7"), repositories[2].Url);
        }

        [Fact]
        public void CanGetRepositoriesForTeamProject()
        {
            TfsClient client = NewMockClient(
                new MockRequestConfiguration
                {
                    Uri = "/_apis/git/6ce954b1-ce1f-45d1-b94d-e6bf2464ba2c/repositories?api-version=1.0",
                    ResponseResource = "Git.GetRepositoriesForTeamProject",
                });

            IList<Repository> repositories = base.ExecuteSync<IEnumerable<Repository>>(
                () => { return client.Git.GetRepositories(new Guid("6ce954b1-ce1f-45d1-b94d-e6bf2464ba2c")); }).ToList();

            Assert.Equal(2, repositories.Count);

            Assert.Equal("refs/heads/master", repositories[0].DefaultBranch);
            Assert.Equal(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), repositories[0].Id);
            Assert.Equal("Fabrikam-Fiber-Git", repositories[0].Name);
            Assert.Equal(new Guid("6ce954b1-ce1f-45d1-b94d-e6bf2464ba2c"), repositories[0].Project.Id);
            Assert.Equal("Fabrikam-Fiber-Git", repositories[0].Project.Name);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/projects/6ce954b1-ce1f-45d1-b94d-e6bf2464ba2c"), repositories[0].Project.Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_git/Fabrikam-Fiber-Git"), repositories[0].RemoteUrl);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), repositories[0].Url);

            Assert.Equal(new Guid("17c3a073-1785-4f51-ba0a-a877bba5f5c7"), repositories[1].Id);
            Assert.Equal("AnotherRepository", repositories[1].Name);
            Assert.Equal(new Guid("6ce954b1-ce1f-45d1-b94d-e6bf2464ba2c"), repositories[1].Project.Id);
            Assert.Equal("Fabrikam-Fiber-Git", repositories[1].Project.Name);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/projects/6ce954b1-ce1f-45d1-b94d-e6bf2464ba2c"), repositories[1].Project.Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/Fabrikam-Fiber-Git/_git/AnotherRepository"), repositories[1].RemoteUrl);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/17c3a073-1785-4f51-ba0a-a877bba5f5c7"), repositories[1].Url);
        }

        [Fact]
        public void CanGetRepositoryById()
        {
            TfsClient client = NewMockClient(
                new MockRequestConfiguration
                {
                    Uri = "/_apis/git/repositories/17c3a073-1785-4f51-ba0a-a877bba5f5c7?api-version=1.0",
                    ResponseResource = "Git.GetRepository",
                });

            Repository repository = base.ExecuteSync<Repository>(
                () => { return client.Git.GetRepository(new Guid("17c3a073-1785-4f51-ba0a-a877bba5f5c7")); });

            Assert.Equal(new Guid("17c3a073-1785-4f51-ba0a-a877bba5f5c7"), repository.Id);
            Assert.Equal("AnotherRepository", repository.Name);
            Assert.Equal(new Guid("6ce954b1-ce1f-45d1-b94d-e6bf2464ba2c"), repository.Project.Id);
            Assert.Equal("Fabrikam-Fiber-Git", repository.Project.Name);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/projects/6ce954b1-ce1f-45d1-b94d-e6bf2464ba2c"), repository.Project.Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/Fabrikam-Fiber-Git/_git/AnotherRepository"), repository.RemoteUrl);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/17c3a073-1785-4f51-ba0a-a877bba5f5c7"), repository.Url);
        }

        [Fact]
        public void CanGetRepositoryByName()
        {
            TfsClient client = NewMockClient(
                new MockRequestConfiguration
                {
                    Uri = "/_apis/git/6ce954b1-ce1f-45d1-b94d-e6bf2464ba2c/repositories/anotherrepository?api-version=1.0",
                    ResponseResource = "Git.GetRepository",
                });

            Repository repository = base.ExecuteSync<Repository>(
                () => { return client.Git.GetRepository(new Guid("6ce954b1-ce1f-45d1-b94d-e6bf2464ba2c"), "anotherrepository"); });

            Assert.Equal(new Guid("17c3a073-1785-4f51-ba0a-a877bba5f5c7"), repository.Id);
            Assert.Equal("AnotherRepository", repository.Name);
            Assert.Equal(new Guid("6ce954b1-ce1f-45d1-b94d-e6bf2464ba2c"), repository.Project.Id);
            Assert.Equal("Fabrikam-Fiber-Git", repository.Project.Name);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/projects/6ce954b1-ce1f-45d1-b94d-e6bf2464ba2c"), repository.Project.Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/Fabrikam-Fiber-Git/_git/AnotherRepository"), repository.RemoteUrl);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/17c3a073-1785-4f51-ba0a-a877bba5f5c7"), repository.Url);
        }

        [Fact]
        public void CanCreateRepository()
        {
            TfsClient client = NewMockClient(
                new MockRequestConfiguration
                {
                    Uri = "/_apis/git/repositories?api-version=1.0",
                    Method = RestSharp.Method.POST,
                    RequestObject = new
                    {
                        name = "AnotherRepository",
                        project = new {
                            id = "6ce954b1-ce1f-45d1-b94d-e6bf2464ba2c",
                        },
                    },
                    ResponseResource = "Git.CreateRepository",
                });

            Repository repository = base.ExecuteSync<Repository>(
                () => { return client.Git.CreateRepository(new Guid("6ce954b1-ce1f-45d1-b94d-e6bf2464ba2c"), "AnotherRepository"); });
            
            Assert.Equal(new Guid("17c3a073-1785-4f51-ba0a-a877bba5f5c7"), repository.Id);
            Assert.Equal("AnotherRepository", repository.Name);
            Assert.Equal(new Guid("6ce954b1-ce1f-45d1-b94d-e6bf2464ba2c"), repository.Project.Id);
            Assert.Equal("Fabrikam-Fiber-Git", repository.Project.Name);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/projects/6ce954b1-ce1f-45d1-b94d-e6bf2464ba2c"), repository.Project.Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/Fabrikam-Fiber-Git/_git/AnotherRepository"), repository.RemoteUrl);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/17c3a073-1785-4f51-ba0a-a877bba5f5c7"), repository.Url);
        }

        [Fact]
        public void CanRenameRepository()
        {
            TfsClient client = NewMockClient(
                new MockRequestConfiguration
                {
                    Uri = "/_apis/git/repositories/17c3a073-1785-4f51-ba0a-a877bba5f5c7?api-version=1.0",
                    Method = RestSharp.Method.PATCH,
                    RequestObject = new
                    {
                        name = "RenamedRepository"
                    },
                    ResponseResource = "Git.RenameRepository",
                });

            Repository repository = base.ExecuteSync<Repository>(
                () => { return client.Git.RenameRepository(new Guid("17c3a073-1785-4f51-ba0a-a877bba5f5c7"), "RenamedRepository"); });

            Assert.Equal(new Guid("17c3a073-1785-4f51-ba0a-a877bba5f5c7"), repository.Id);
            Assert.Equal("RenamedRepository", repository.Name);
            Assert.Equal(new Guid("6ce954b1-ce1f-45d1-b94d-e6bf2464ba2c"), repository.Project.Id);
            Assert.Equal("Fabrikam-Fiber-Git", repository.Project.Name);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/projects/6ce954b1-ce1f-45d1-b94d-e6bf2464ba2c"), repository.Project.Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/Fabrikam-Fiber-Git/_git/RenamedRepository"), repository.RemoteUrl);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/17c3a073-1785-4f51-ba0a-a877bba5f5c7"), repository.Url);
        }

        [Fact]
        public void CanDeleteRepository()
        {
            TfsClient client = NewMockClient(
                new MockRequestConfiguration
                {
                    Uri = "/_apis/git/repositories/17c3a073-1785-4f51-ba0a-a877bba5f5c7?api-version=1.0",
                    Method = RestSharp.Method.DELETE,
                });

            base.ExecuteSync(
                () => { return client.Git.DeleteRepository(new Guid("17c3a073-1785-4f51-ba0a-a877bba5f5c7")); });
        }

        #endregion

        #region References

        [Fact]
        public void CanGetReferences()
        {
            TfsClient client = NewMockClient(
                new MockRequestConfiguration
                {
                    Uri = "/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/refs?api-version=1.0",
                    ResponseResource = "Git.GetReferences",
                });

            IList<Reference> references = base.ExecuteSync<IEnumerable<Reference>>(
                () => { return client.Git.GetReferences(new Guid("278d5cd2-584d-4b63-824a-2ba458937249")); }).ToList();

            Assert.Equal(3, references.Count);

            Assert.Equal("refs/heads/develop", references[0].Name);
            Assert.Equal("67cae2b029dff7eb3dc062b49403aaedca5bad8d", references[0].ObjectId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/refs/heads/develop"), references[0].Url);

            Assert.Equal("refs/heads/master", references[1].Name);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", references[1].ObjectId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/refs/heads/master"), references[1].Url);

            Assert.Equal("refs/heads/npaulk/feature", references[2].Name);
            Assert.Equal("23d0bc5b128a10056dc68afece360d8a0fabb014", references[2].ObjectId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/refs/heads/npaulk/feature"), references[2].Url);
        }

        [Fact]
        public void CanGetReferencesWithFilter()
        {
            TfsClient client = NewMockClient(
                new MockRequestConfiguration
                {
                    Uri = "/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/refs/heads/develop?api-version=1.0",
                    ResponseResource = "Git.GetReferencesWithFilter",
                });

            IList<Reference> references = base.ExecuteSync<IEnumerable<Reference>>(
                () => { return client.Git.GetReferences(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), "refs/heads/develop"); }).ToList();

            Assert.Equal(1, references.Count);

            Assert.Equal("refs/heads/develop", references[0].Name);
            Assert.Equal("67cae2b029dff7eb3dc062b49403aaedca5bad8d", references[0].ObjectId);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/refs/heads/develop"), references[0].Url);
        }

        #endregion

        #region Trees

        [Fact]
        public void CanGetTree()
        {
            TfsClient client = NewMockClient(
                new MockRequestConfiguration
                {
                    Uri = "/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/trees/d1d5c2d49045d52bba6419652d6ecb2cd560dc29?api-version=1.0",
                    ResponseResource = "Git.GetTree",
                });

            Tree tree = base.ExecuteSync<Tree>(
                () => { return client.Git.GetTree(new Guid("278d5cd2-584d-4b63-824a-2ba458937249"), "d1d5c2d49045d52bba6419652d6ecb2cd560dc29"); });

            Assert.Equal("d1d5c2d49045d52bba6419652d6ecb2cd560dc29", tree.ObjectId);
            Assert.Equal(147, tree.Size);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/trees/d1d5c2d49045d52bba6419652d6ecb2cd560dc29"), tree.Url);

            Assert.Equal(4, tree.TreeEntries.Count);

            Assert.Equal(ObjectType.Tree, tree.TreeEntries[0].Type);
            Assert.Equal(40000, tree.TreeEntries[0].Mode);
            Assert.Equal("ea6765e1976b9e8a6d4981fd8febebd574a91571", tree.TreeEntries[0].ObjectId);
            Assert.Equal("Home", tree.TreeEntries[0].RelativePath);
            Assert.Equal(259, tree.TreeEntries[0].Size);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/trees/ea6765e1976b9e8a6d4981fd8febebd574a91571"), tree.TreeEntries[0].Url);

            Assert.Equal(ObjectType.Tree, tree.TreeEntries[1].Type);
            Assert.Equal(40000, tree.TreeEntries[1].Mode);
            Assert.Equal("d1c521e3b401b314d4f9ff17f6cad4652c6a4d14", tree.TreeEntries[1].ObjectId);
            Assert.Equal("Shared", tree.TreeEntries[1].RelativePath);
            Assert.Equal(82, tree.TreeEntries[1].Size);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/trees/d1c521e3b401b314d4f9ff17f6cad4652c6a4d14"), tree.TreeEntries[1].Url);

            Assert.Equal(ObjectType.Blob, tree.TreeEntries[2].Type);
            Assert.Equal(100644, tree.TreeEntries[2].Mode);
            Assert.Equal("f5dd7df5872eae8c39c9491f67d856dafd609683", tree.TreeEntries[2].ObjectId);
            Assert.Equal("Web.config", tree.TreeEntries[2].RelativePath);
            Assert.Equal(1670, tree.TreeEntries[2].Size);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/blobs/f5dd7df5872eae8c39c9491f67d856dafd609683"), tree.TreeEntries[2].Url);

            Assert.Equal(ObjectType.Blob, tree.TreeEntries[3].Type);
            Assert.Equal(100644, tree.TreeEntries[3].Mode);
            Assert.Equal("2de62418c07c3ffa833543f484445dbfd0fe68d8", tree.TreeEntries[3].ObjectId);
            Assert.Equal("_ViewStart.cshtml", tree.TreeEntries[3].RelativePath);
            Assert.Equal(54, tree.TreeEntries[3].Size);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/blobs/2de62418c07c3ffa833543f484445dbfd0fe68d8"), tree.TreeEntries[3].Url);

            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249"), tree.Links.Repository.Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/trees/d1d5c2d49045d52bba6419652d6ecb2cd560dc29"), tree.Links.Self.Url);

            Assert.Equal(4, tree.Links.TreeEntries.Count);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/trees/ea6765e1976b9e8a6d4981fd8febebd574a91571"), tree.Links.TreeEntries[0].Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/trees/d1c521e3b401b314d4f9ff17f6cad4652c6a4d14"), tree.Links.TreeEntries[1].Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/blobs/f5dd7df5872eae8c39c9491f67d856dafd609683"), tree.Links.TreeEntries[2].Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/git/repositories/278d5cd2-584d-4b63-824a-2ba458937249/blobs/2de62418c07c3ffa833543f484445dbfd0fe68d8"), tree.Links.TreeEntries[3].Url);
        }

        #endregion
    }
}
