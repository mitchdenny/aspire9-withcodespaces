var builder = DistributedApplication.CreateBuilder(args);\

var cache = builder.AddRedis("cache")
                   .WithRedisInsight();

var apiService = builder.AddProject<Projects.Aspire9Codespaces_ApiService>("apiservice")
                        .WithReference(cache);

builder.AddProject<Projects.Aspire9Codespaces_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
