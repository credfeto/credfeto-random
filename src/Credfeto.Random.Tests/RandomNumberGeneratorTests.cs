using System;
using Credfeto.Random.Interfaces;
using FunFair.Test.Common;
using Xunit;

namespace Credfeto.Random.Tests;

public sealed class RandomNumberGeneratorTests : TestBase
{
    private readonly IRandomNumberGenerator _randomNumberGenerator;

    public RandomNumberGeneratorTests()
    {
        IRandomSource randomSource = new MockGenerator();

        this._randomNumberGenerator = new RandomNumberGenerator(randomSource);
    }

    [Fact]
    public void GeneratesInt32Between0And10()
    {
        int result = this._randomNumberGenerator.Next(maxValue: 10);
        Assert.True(result is >= 0 and <= 10, userMessage: "Must be in range");
    }

    [Fact]
    public void GeneratesInt32Between10And20()
    {
        int result = this._randomNumberGenerator.Next(minValue: 10, maxValue: 20);
        Assert.True(result is >= 10 and <= 20, userMessage: "Must be in range");
    }

    private sealed class MockGenerator : IRandomSource
    {
        private static byte _sequence;

        public void Generate(in Span<byte> buffer)
        {
            foreach (ref byte b in buffer)
            {
                b = ++_sequence;
            }
        }
    }
}
