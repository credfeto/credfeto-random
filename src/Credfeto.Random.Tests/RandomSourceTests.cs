using System;
using Credfeto.Random.Interfaces;
using FunFair.Test.Common;
using Xunit;

namespace Credfeto.Random.Tests;

public sealed class RandomSourceTests : TestBase
{
    private readonly IRandomSource _randomSource;

    public RandomSourceTests()
    {
        this._randomSource = new RandomSource();
    }

    [Fact]
    public void GeneratesDifferent()
    {
        Span<byte> first = stackalloc byte[100];
        this._randomSource.Generate(first);

        Span<byte> second = stackalloc byte[100];
        this._randomSource.Generate(second);

        Assert.False(first.SequenceEqual(second), userMessage: "Should generate different values");
    }
}
