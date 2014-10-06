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
        [Fact]
        public void CanGetRepositories()
        {
            TfsClient client = NewMockClient(
                new MockRequestConfiguration
                {
                    Uri = "/_apis/git/repositories",
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
                    Uri = "/_apis/git/6ce954b1-ce1f-45d1-b94d-e6bf2464ba2c/repositories",
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
                    Uri = "/_apis/git/repositories/17c3a073-1785-4f51-ba0a-a877bba5f5c7",
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
                    Uri = "/_apis/git/6ce954b1-ce1f-45d1-b94d-e6bf2464ba2c/repositories/anotherrepository",
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
                    Uri = "/_apis/git/repositories",
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
                    Uri = "/_apis/git/repositories/17c3a073-1785-4f51-ba0a-a877bba5f5c7",
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
                    Uri = "/_apis/git/repositories/17c3a073-1785-4f51-ba0a-a877bba5f5c7",
                    Method = RestSharp.Method.DELETE,
                });

            base.ExecuteSync(
                () => { return client.Git.DeleteRepository(new Guid("17c3a073-1785-4f51-ba0a-a877bba5f5c7")); });
        }
    }
}