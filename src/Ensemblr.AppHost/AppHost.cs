
internal class Program
{
    private static void Main(string[] args)
    {
        IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

        IResourceBuilder<ProjectResource> apiProject = builder.AddProject<Projects.Ensemblr_Api>("ensemblr-api");

        IResourceBuilder<NodeAppResource> webProject = builder.AddNpmApp("ensemblr-react", "../Ensemblr.Web")
            .WithHttpsEndpoint(env: "VITE_PORT")
            .WithReference(apiProject);

        builder.Build().Run();
    }
}