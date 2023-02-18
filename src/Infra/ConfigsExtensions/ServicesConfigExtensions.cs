using Domain.Contracts.Services;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.ConfigsExtensions;

public static class ServicesConfigExtensions
{
    public static void AddDomainServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IAccountPlanService, AccountPlanService>();
    }
}