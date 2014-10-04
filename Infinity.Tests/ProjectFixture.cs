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
            TfsClient client = NewMockClient(
                new MockRequestConfiguration
                {
                    Uri = "/_apis/projects",
                    ResponseResource = "Project.GetProjects",
                });

            IList<Project> projects = base.ExecuteSync<IEnumerable<Project>>(
                () => { return client.Project.GetProjects(); }).ToList();

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

        [Fact]
        public void CanGetProject()
        {
            TfsClient client = NewMockClient(
                new MockRequestConfiguration
                {
                    Uri = "/_apis/projects/fabrikam-fiber-tfvc",
                    ResponseResource = "Project.GetProject",
                });

            Project project = base.ExecuteSync<Project>(
                () => { return client.Project.GetProject("fabrikam-fiber-tfvc"); });

            Assert.Equal(new Guid("eb6e4656-77fc-42a1-9181-4c6d8e9da5d1"), project.Id);
            Assert.Equal("Fabrikam-Fiber-TFVC", project.Name);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/projects/eb6e4656-77fc-42a1-9181-4c6d8e9da5d1"), project.Url);
            Assert.Equal("Team Foundation Version Control projects", project.Description);
            Assert.Equal(ProjectState.WellFormed, project.State);

            Assert.Equal(new Guid("66df9be7-3586-467b-9c5f-425b29afedfd"), project.DefaultTeam.Id);
            Assert.Equal("Fabrikam-Fiber-TFVC Team", project.DefaultTeam.Name);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/projects/eb6e4656-77fc-42a1-9181-4c6d8e9da5d1/teams/66df9be7-3586-467b-9c5f-425b29afedfd"), project.DefaultTeam.Url);

            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/projects/eb6e4656-77fc-42a1-9181-4c6d8e9da5d1"), project.Links.Self.Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/_apis/projectCollections/d81542e4-cdfa-4333-b082-1ae2d6c3ad16"), project.Links.Collection.Url);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/Fabrikam-Fiber-TFVC"), project.Links.Web.Url);
        }

        [Fact]
        public void CanGetProjectWithCapabilities()
        {
            TfsClient client = NewMockClient(
                new MockRequestConfiguration
                {
                    Uri = "/_apis/projects/fabrikam-fiber-tfvc",
                    ResponseResource = "Project.GetProjectWithCapabilities",
                });

            Project project = base.ExecuteSync<Project>(
                () => { return client.Project.GetProject("fabrikam-fiber-tfvc", true); });

            Assert.Equal(new Guid("98dd5ded-8110-459b-8241-3d12b2eeaf18"), project.Id);
            Assert.Equal("FabrikamWeather", project.Name);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/projects/98dd5ded-8110-459b-8241-3d12b2eeaf18"), project.Url);
            Assert.Equal("Fabrikam weather app for Windows Phone", project.Description);
            Assert.Equal(ProjectState.WellFormed, project.State);

            Assert.Equal(new Guid("66df9be7-3586-467b-9c5f-425b29afedfd"), project.DefaultTeam.Id);
            Assert.Equal("FabrikamWeather Team", project.DefaultTeam.Name);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/projects/98dd5ded-8110-459b-8241-3d12b2eeaf18/teams/66df9be7-3586-467b-9c5f-425b29afedfd"), project.DefaultTeam.Url);

            Assert.Equal(VersionControlType.TFVC, project.Capabilities.VersionControl.VersionControlType);
            Assert.Equal("MSF for Agile Software Development 2013.3", project.Capabilities.ProcessTemplate.TemplateName);
        }

        [Fact]
        public void CanUpdateProject()
        {
            TfsClient client = NewMockClient(
                new MockRequestConfiguration
                {
                    Method = RestSharp.Method.PATCH,
                    Uri = "/_apis/projects/eb6e4656-77fc-42a1-9181-4c6d8e9da5d1",
                    RequestObject = new { description = "Team Foundation Version Control projects." },
                    ResponseResource = "Project.UpdateProject",
                });

            Project project = base.ExecuteSync<Project>(
                () => { return client.Project.UpdateProject(new Guid("eb6e4656-77fc-42a1-9181-4c6d8e9da5d1"), "Team Foundation Version Control projects."); });

            Assert.Equal(new Guid("eb6e4656-77fc-42a1-9181-4c6d8e9da5d1"), project.Id);
            Assert.Equal("Fabrikam-Fiber-TFVC", project.Name);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/projects/eb6e4656-77fc-42a1-9181-4c6d8e9da5d1"), project.Url);
            Assert.Equal("Team Foundation Version Control projects.", project.Description);
            Assert.Equal(ProjectState.WellFormed, project.State);
        }
    }
}