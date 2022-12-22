using Credfeto.Random.Interfaces;
using FunFair.Test.Common;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace Credfeto.Random.Tests;

public sealed class DependencyInjectionTests : DependencyInjectionTestsBase
{
    public DependencyInjectionTests(ITestOutputHelper output)
        : base(output: output, dependencyInjectionRegistration: Configure)
    {
    }

    private static IServiceCollection Configure(IServiceCollection arg)
    {
        return arg.AddRandomNumbers();
    }

    [Fact]
    public void RandomSourceIsRegistered()
    {
        this.RequireService<IRandomSource>();
    }

    [Fact]
    public void RandomNumberGeneratorIsRegistered()
    {
        this.RequireService<IRandomNumberGenerator>();
    }
}