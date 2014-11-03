using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RestSharp;
using Xunit;

using Infinity;
using Infinity.Models;

namespace Infinity.Tests.Models
{
    public class GitFixture : MockClientFixture
    {
        #region Pull Requests

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
