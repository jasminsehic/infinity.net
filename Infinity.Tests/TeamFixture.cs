using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Infinity.Models;

namespace Infinity.Tests.Models
{
    public class TeamFixture : MockClientFixture
    {
        [Fact]
        public void Team_GetTeams()
        {
            MessageHandler.AddConfiguration(
                new MockHttpMessageConfiguration
                {
                    Uri = "/_apis/projects/eb6e4656-77fc-42a1-9181-4c6d8e9da5d1/teams?api-version=1.0",
                    ResponseResource = "Team.GetTeams",
                });

            IList<Team> teams = ExecuteSync<IEnumerable<Team>>(
                () => { return NewMockClient().Team.GetTeams(new Guid("eb6e4656-77fc-42a1-9181-4c6d8e9da5d1")); }).ToList();

            Assert.Equal(2, teams.Count);

            Assert.Equal(new Guid("564e8204-a90b-4432-883b-d4363c6125ca"), teams[0].Id);
            Assert.Equal("Quality assurance", teams[0].Name);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/projects/eb6e4656-77fc-42a1-9181-4c6d8e9da5d1/teams/564e8204-a90b-4432-883b-d4363c6125ca"), teams[0].Url);
            Assert.Equal("Testing staff", teams[0].Description);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/564e8204-a90b-4432-883b-d4363c6125ca"), teams[0].IdentityUrl);

            Assert.Equal(new Guid("66df9be7-3586-467b-9c5f-425b29afedfd"), teams[1].Id);
            Assert.Equal("Fabrikam-Fiber-TFVC Team", teams[1].Name);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/projects/eb6e4656-77fc-42a1-9181-4c6d8e9da5d1/teams/66df9be7-3586-467b-9c5f-425b29afedfd"), teams[1].Url);
            Assert.Equal("The default project team.", teams[1].Description);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/66df9be7-3586-467b-9c5f-425b29afedfd"), teams[1].IdentityUrl);
        }

        [Fact]
        public void Team_GetTeam()
        {
            MessageHandler.AddConfiguration(
                new MockHttpMessageConfiguration
                {
                    Uri = "/_apis/projects/eb6e4656-77fc-42a1-9181-4c6d8e9da5d1/teams/564e8204-a90b-4432-883b-d4363c6125ca?api-version=1.0",
                    ResponseResource = "Team.GetTeam",
                });

            Team team = base.ExecuteSync<Team>(
                () => { return NewMockClient().Team.GetTeam(new Guid("eb6e4656-77fc-42a1-9181-4c6d8e9da5d1"), new Guid("564e8204-a90b-4432-883b-d4363c6125ca")); });

            Assert.Equal(new Guid("564e8204-a90b-4432-883b-d4363c6125ca"), team.Id);
            Assert.Equal("Quality assurance", team.Name);
            Assert.Equal(new Uri("https://fabrikam.visualstudio.com/DefaultCollection/_apis/projects/eb6e4656-77fc-42a1-9181-4c6d8e9da5d1/teams/564e8204-a90b-4432-883b-d4363c6125ca"), team.Url);
            Assert.Equal("Testing staff", team.Description);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/564e8204-a90b-4432-883b-d4363c6125ca"), team.IdentityUrl);
        }

        [Fact]
        public void Team_GetTeamMembers()
        {
            MessageHandler.AddConfiguration(
                new MockHttpMessageConfiguration
                {
                    Uri = "/_apis/projects/eb6e4656-77fc-42a1-9181-4c6d8e9da5d1/teams/564e8204-a90b-4432-883b-d4363c6125ca/members?api-version=1.0",
                    ResponseResource = "Team.GetTeamMembers",
                });

            IList<Identity> members = base.ExecuteSync<IEnumerable<Identity>>(
                () => { return NewMockClient().Team.GetTeamMembers(new Guid("eb6e4656-77fc-42a1-9181-4c6d8e9da5d1"), new Guid("564e8204-a90b-4432-883b-d4363c6125ca")); }).ToList();

            Assert.Equal(3, members.Count);

            Assert.Equal(new Guid("3b5f0c34-4aec-4bf4-8708-1d36f0dbc468"), members[0].Id);
            Assert.Equal("Christie Church", members[0].DisplayName);
            Assert.Equal("fabrikamfiber1@hotmail.com", members[0].UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/3b5f0c34-4aec-4bf4-8708-1d36f0dbc468"), members[0].Url);

            Assert.Equal(new Guid("8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), members[1].Id);
            Assert.Equal("Chuck Reinhart", members[1].DisplayName);
            Assert.Equal("fabrikamfiber3@hotmail.com", members[1].UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/8c8c7d32-6b1b-47f4-b2e9-30b477b5ab3d"), members[1].Url);

            Assert.Equal(new Guid("19d9411e-9a34-45bb-b985-d24d9d87c0c9"), members[2].Id);
            Assert.Equal("Johnnie McLeod", members[2].DisplayName);
            Assert.Equal("fabrikamfiber2@hotmail.com", members[2].UniqueName);
            Assert.Equal(new Uri("https://fabrikam-fiber-inc.vssps.visualstudio.com/_apis/Identities/19d9411e-9a34-45bb-b985-d24d9d87c0c9"), members[2].Url);
        }
    }
}