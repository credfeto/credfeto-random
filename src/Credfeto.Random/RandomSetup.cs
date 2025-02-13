using Credfeto.Random.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Credfeto.Random;

public static class RandomSetup
{
    public static IServiceCollection AddRandomNumbers(this IServiceCollection services)
    {
        return services
            .AddSingleton<IRandomNumberGenerator, RandomNumberGenerator>()
            .AddSingleton<IRandomSource, RandomSource>();
    }
}
