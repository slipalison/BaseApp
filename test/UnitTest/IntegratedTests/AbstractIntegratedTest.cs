using Flurl.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using WebApi;

namespace UnitTest.IntegratedTests;

public abstract class AbstractIntegratedTest : IClassFixture<CustomWebApplicationFactory<Program>>
{
    protected readonly IFlurlClient Client;
    protected readonly CustomWebApplicationFactory<Program> Factory;

    protected AbstractIntegratedTest(
        CustomWebApplicationFactory<Program> factory)
    {
        Factory = factory;
        var client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });

        Client = new FlurlClient(client);
    }

    protected IFlurlRequest CallHttp(string uri)
    {
        return uri.WithClient(Client).AllowAnyHttpStatus();
    }
}