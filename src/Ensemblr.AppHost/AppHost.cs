internal class Program
{
    private static void Main(string[] args)
    {
        IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

        builder.AddProject<Projects.Ensemblr_Api>("ensemblr-api");

        builder.Build().Run();
    }
}