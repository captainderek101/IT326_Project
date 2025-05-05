using Microsoft.AspNetCore.Components;
using Projects;
using System.Net.Http;
using System.Net.Http.Json;
using static System.Formats.Asn1.AsnWriter;

namespace Ups_Downs_API.Tests;

[TestClass]
public class CreatePostTests
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

    // Test case: If all required fields (content and day type) are left empty
    [TestMethod]
    public async Task CreatePost_MissingRequiredFields_ReturnsBadRequest()
    {
        // Act
        var response = await _client.PostAsJsonAsync("/creatingPost/Creation", new { });

        // Assert
        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    // Test case: If content field is left empty
    [TestMethod]
    public async Task CreatePost_MissingContentField_ReturnsBadRequest()
    {
        //Arrange
        var post = new 
        {
            postId = 0,
            postDayType = "Good",
            postTimestamp = @DateTime.Now.ToString("HH:mm"),
            userID = 1,
            content = "",
            sentimentScore = 0
        };

        // Act
        var response = await _client.PostAsJsonAsync("/creatingPost/Creation", post);

        // Assert
        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    // Test case: If day type field is left empty
    [TestMethod]
    public async Task CreatePost_MissingDayTypeField_ReturnsBadRequest()
    {
        //Arrange
        var post = new
        {
            postId = 0,
            postDayType = "",
            postTimestamp = @DateTime.Now.ToString("HH:mm"),
            userID = 1,
            content = "This is a test case",
            sentimentScore = 0
        };

        // Act
        var response = await _client.PostAsJsonAsync("/creatingPost/Creation", post);

        // Assert
        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    // Test case: If all fields have valid entries
    [TestMethod]
    public async Task CreatePost_SentimentScoreHappy_ReturnsBadRequest()
    {
        //Arrange
        var post = new
        {
            postId = 0,
            postDayType = "Good",
            postTimestamp = @DateTime.Now.ToString("HH:mm"),
            userID = 1,
            content = "I am having a good day!",
            sentimentScore = .80
        };

        // Act
        var response = await _client.PostAsJsonAsync("/creatingPost/Creation", post);

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
