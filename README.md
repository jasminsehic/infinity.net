# Infinity.NET

Infinity.NET is a .NET client library for the [Visual Studio REST API][0],
providing access to Visual Studio Online and Team Foundation Server 14.0
servers.

[0]: http://www.visualstudio.com/en-us/integrate/reference/reference-vso-overview-vsi.aspx

## Example

    var client = new TfsClient(new TfsClientConfiguration
    {
        Url = new Uri("https://my-account.visualstudio.com/DefaultCollection"),
        Username = "my-username",
        Password = "my-password",
    });
    
    IEnumerable<Project> projects = new List<Project>();
    Task.Run(async () =>
    {
        projects = await client.Project.GetProjects();
    }).Wait();

## License

Copyright (c) Edward Thomson.  All rights reserved.

Available under the MIT license (refer to the [LICENSE][1] file).

[1]: https://github.com/ethomson/infinity.net/blob/master/LICENSE

