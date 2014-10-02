using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RestSharp;
using Xunit;
using Moq;

using Infinity;
using Infinity.Models;

namespace Infinity.Tests.Models
{
    public class ProjectFixture : ModelFixture
    {
        [Fact]
        public void CanGetProjects()
        {
            IList<Project> projects = MockRequest<IEnumerable<Project>>("Project.GetProjects", null, null, null).ToList();

            Assert.Equal(3, projects.Count);

            Assert.Equal(new Guid("eb6e4656-77fc-42a1-9181-4c6d8e9da5d1"), projects[0].Id);
            Assert.Equal("Fabrikam-Fiber-TFVC", projects[0].Name);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/projects/eb6e4656-77fc-42a1-9181-4c6d8e9da5d1"), projects[0].Url);
            Assert.Equal(ProjectState.WellFormed, projects[0].State);

            Assert.Equal(new Guid("6ce954b1-ce1f-45d1-b94d-e6bf2464ba2c"), projects[1].Id);
            Assert.Equal("Fabrikam-Fiber-Git", projects[1].Name);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/projects/6ce954b1-ce1f-45d1-b94d-e6bf2464ba2c"), projects[1].Url);
            Assert.Equal(ProjectState.WellFormed, projects[1].State);

            Assert.Equal(new Guid("281f9a5b-af0d-49b4-a1df-fe6f5e5f84d0"), projects[2].Id);
            Assert.Equal("TestGit", projects[2].Name);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/projects/281f9a5b-af0d-49b4-a1df-fe6f5e5f84d0"), projects[2].Url);
            Assert.Equal(ProjectState.WellFormed, projects[2].State);
        }
    }
}