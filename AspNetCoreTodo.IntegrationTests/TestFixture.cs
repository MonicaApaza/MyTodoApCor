using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using AspNetCoreTodo;

namespace AspNetCoreTodo.IntegrationTests;

public class TestFixture 
{
    // private readonly TestServer _server;

    // public HttpClient Client { get; }

    // public TestFixture()
    // {
        
    //     var builder = new WebHostBuilder()
    //         .UseStartup<AspNetCoreTodo>()
    //         .ConfigureAppConfiguration((context, config) =>
    //         {
    //             config.SetBasePath(Path.Combine(
    //                 Directory.GetCurrentDirectory(),
    //                 "..\\..\\..\\..\\AspNetCoreTodo"));

    //             config.AddJsonFile("appsettings.json");
    //         });

    //     _server = new TestServer(builder);

    //     Client = _server.CreateClient();
    //     Client.BaseAddress = new Uri("http://localhost:8888");
    // }

    // public void Dispose()
    // {
    //     Client.Dispose();
    //     _server.Dispose();
    // }
}