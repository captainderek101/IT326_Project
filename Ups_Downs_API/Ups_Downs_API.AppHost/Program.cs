Console.WriteLine("Hello From api host");
var builder = DistributedApplication.CreateBuilder(args);


var apiService = builder.AddProject<Projects.Ups_Downs_API_ApiService>("apiservice")
    .WithEnvironment("WorldNewsApi__ApiKey", builder.Configuration["WorldNewsApi:ApiKey"]);

builder.AddProject<Projects.Ups_Downs_API_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
