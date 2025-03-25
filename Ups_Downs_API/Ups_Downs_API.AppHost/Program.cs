var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Ups_Downs_API_ApiService>("apiservice");

builder.AddProject<Projects.Ups_Downs_API_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
