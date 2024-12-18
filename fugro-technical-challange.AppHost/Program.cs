var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.fugro_technical_challange_ApiService>("apiservice");

builder.AddProject<Projects.fugro_technical_challange_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
