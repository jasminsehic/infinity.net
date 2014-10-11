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

## Testing

The REST APIs are tested by mocking them, using the [Visual Studio
Online REST API Reference][1] examples.  To add a new test:

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

## License

Copyright (c) Edward Thomson.  All rights reserved.

Available under the MIT license (refer to the [LICENSE][2] file).

[1]: http://www.visualstudio.com/integrate/reference/reference-vso-overview-vsi
[2]: https://github.com/ethomson/infinity.net/blob/master/LICENSE

