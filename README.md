# Infinity.NET

[![Build Status](https://dev.azure.com/jasminsehic/Infinity.NET/_apis/build/status/jasminsehic.infinity.net?branchName=master)](https://dev.azure.com/jasminsehic/Infinity.NET/_build/latest?definitionId=1&branchName=master) [![NuGet package](https://img.shields.io/nuget/dt/infinity.net.svg)](https://www.nuget.org/packages/Infinity.NET)

Infinity.NET is a .NET client library for the [Azure DevOps REST API][0],
providing access to Azure DevOps servers.

[0]: https://docs.microsoft.com/en-us/rest/api/azure/devops

## Example

    var client = new TfsClient(new TfsClientConfiguration
    {
        Url = new Uri("https://dev.azure.com/YourOrganization"),
        Credentials = new NetworkCredential("username", "password"),
    });
    
    var projects = client.Project.GetProjects().Result;

## Progress

Infinity.NET is a work in progress; it is not yet fully complete.
Here are the currently implemented client functions:

* Git: 100%
* Projects and Teams
  * Projects: 100%
  * Teams: 100%
* Team Rooms
  * Messages: 100%
  * Rooms: 100%
  * Users: 100%

## Unit Tests

The REST APIs are tested by mocking them, using the [Azure DevOps REST API Reference][1] examples.  To add a new test:

1. Add the expected JSON output from the REST method in the
   `Infinity.Tests/Resources` directory.  Ensure that the file is
   added to the `Infinity.Tests` project.
2. Add the file as a resource to the `Infinity.Tests` project.
3. Add a new unit test that expects the appropriate URL and (for `POST`
   or `PUT` methods) the appropriate JSON input and returns the given
   resource.  For example:

        TfsClient mockClient = NewMockClient(
            new MockRequestConfiguration
            {
                // The URI given in the API Reference
                Uri = "/_apis/model/action",

                // The name of the resource containing the JSON response
                ResponseResource = "Model.Action",
            });

        Model model = base.ExecuteSync<Model>(
            () => { return client.Model.Action(); });

4. Write the test assertions.  You can use the
   `Infinity.Tests/Resources/test_from_json.pl` script to generate
   assertions from the expected JSON output.

## Command-Line Interface

A simple command-line interface is available in the `Infinity.Clients`
project.  For example, to merge a pull request:

    Infinity.Client https://dev.azure.com/YourOrganization
    --username=username --password=password Git.UpdatePullRequest
    <RepositoryId> <PullRequestId> Completed <CommitId

This project is not made to be authoritative, but it may help in
development and debugging.

## License

Copyright (c) Edward Thomson.  All rights reserved.

Available under the MIT license (refer to the [LICENSE][2] file).

[1]: https://docs.microsoft.com/en-us/rest/api/azure/devops
[2]: https://github.com/jasminsehic/infinity.net/blob/master/LICENSE.txt

