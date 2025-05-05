using Microsoft.AspNetCore.Components;
using Projects;
using System.Net.Http;
using System.Net.Http.Json;
using static System.Formats.Asn1.AsnWriter;

namespace Ups_Downs_API.Tests;

[TestClass]
public class CommentOnPostTests
{
    private IAsyncDisposable _app;
    private HttpClient _client;

    //
    [TestInitialize]
    public async Task InitializeAsync()
    {
        var appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.Ups_Downs_API_AppHost>();
        appHost.Services.ConfigureHttpClientDefaults(cb =>
            cb.AddStandardResilienceHandler());

        // Build and start the test host without disposing immediately
        var app = await appHost.BuildAsync();
        _app = app;
        await app.StartAsync();

        var notifier = app.Services.GetRequiredService<ResourceNotificationService>();
        await notifier
            .WaitForResourceAsync("apiService", KnownResourceStates.Running)
            .WaitAsync(TimeSpan.FromSeconds(30));

        _client = app.CreateHttpClient("apiService");
    }

    // Test case: If all required fields are left empty
    [TestMethod]
    public async Task CommentOnPost_MissingRequiredFields()
    {
        // Act
        var response = await _client.PostAsJsonAsync("/view/comment", new { });

        // Assert
        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    // Test case: Comment content is missing
    [TestMethod]
    public async Task CommentOnPost_MissingContent()
    {
        //Arrange
        var post = new 
        {
            postId = 1,
            userId = 1
        };

        // Act
        var response = await _client.PostAsJsonAsync("/view/comment", post);

        // Assert
        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    // Test case: Good request
    [TestMethod]
    public async Task CommentOnPost_GoodRequest()
    {
        //Arrange
        var post = new
        {
            postId = 1,
            userID = 1,
            content = "test"
        };

        // Act
        var response = await _client.PostAsJsonAsync("/view/comment", post);

        // Assert
        Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
    }

    [TestCleanup]
    public async Task CleanupAsync()
    {
        if (_app != null)
        {
            await _app.DisposeAsync();
        }
    }
}
