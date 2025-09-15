

internal class Program
{
    private static void Main(string[] args)
    {
        IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

        IResourceBuilder<SqlServerServerResource> sql = builder
            .AddSqlServer("sql-server").WithLifetime(ContainerLifetime.Persistent)
            .WithDataVolume()
            .WithHostPort(1433);

        IResourceBuilder<SqlServerDatabaseResource> db = sql.AddDatabase("ensemblr-db");

        IResourceBuilder<ProjectResource> apiProject = builder.AddProject<Projects.Ensemblr_Api>("ensemblr-api")
            .WithReference(db)
            .WaitFor(db);

        IResourceBuilder<NodeAppResource> webProject = builder.AddNpmApp("ensemblr-react", "../Ensemblr.Web")
            .WithHttpsEndpoint(port: 5173, env: "VITE_PORT")
            .WaitFor(apiProject)
            .WithReference(apiProject);

        builder.Build().Run();
    }
}