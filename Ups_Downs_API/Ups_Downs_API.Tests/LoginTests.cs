using System.Net.Http.Json;

namespace Ups_Downs_API.Tests;

[TestClass]
public class LoginTests
{
    private IAsyncDisposable _app;
    private HttpClient _client;

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

    // Test case: If all required fields (username and password) are left empty
    [TestMethod]
    public async Task Login_MissingRequiredFields_ReturnsBadRequest()
    {
        // Act
        var response = await _client.PostAsJsonAsync("/login", new { });

        // Assert
        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    // Test case: If username is empty
    [TestMethod]
    public async Task Login_MissingUsername_ReturnsBadRequest()
    {
        //Arrange
        var LoginAttempt = new
        {
            Username = "",
            Password = "test"
        };

        // Act
        var response = await _client.PostAsJsonAsync("/login", LoginAttempt);

        // Assert
        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    // Test case: password is empty
    [TestMethod]
    public async Task Login_MissingPassword_ReturnsBadRequest()
    {
        //Arrange
        var LoginAttempt = new
        {
            Username = "test",
            Password = ""
        };

        // Act
        var response = await _client.PostAsJsonAsync("/login", LoginAttempt);

        // Assert
        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    // Test case: incorrect username or password because there is no account associated with those credentials
    [TestMethod]
    public async Task Login_NoUserFound_ReturnsBadRequest()
    {
        //Arrange
        var LoginAttempt = new
        {
            Username = "test",
            Password = "test"
        };

        // Act
        var response = await _client.PostAsJsonAsync("/login", LoginAttempt);

        // Assert
        Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    // Test case: valid credentials in the database found 
    [TestMethod]
    public async Task Login_Valid_ReturnsBadRequest()
    {
        //Arrange
        var createAccount = new
        {
            Username = "validTest",
            Password = "validTest"
        };

        // Act
        await _client.PostAsJsonAsync("/login/create", createAccount);

        //Arrange
        var LoginAttempt = new
        {
            Username = "validTest",
            Password = "validTest"
        };

        // Act
        var response = await _client.PostAsJsonAsync("/login", LoginAttempt);

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
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

