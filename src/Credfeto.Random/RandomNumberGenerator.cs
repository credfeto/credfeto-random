using System;
using Credfeto.Random.Interfaces;

namespace Credfeto.Random;

public sealed class RandomNumberGenerator : IRandomNumberGenerator
{
    private readonly IRandomSource _randomSource;

    public RandomNumberGenerator(IRandomSource randomSource)
    {
        this._randomSource = randomSource;
    }

    public int Next(int maxValue)
    {
        return this.Next(minValue: 0, maxValue: maxValue);
    }

    public int Next(int minValue, int maxValue)
    {
        Span<byte> bytes = stackalloc byte[sizeof(int)];
        this._randomSource.Generate(bytes);

        int range = maxValue - minValue;
        int rangeValue = Math.Abs(BitConverter.ToInt32(bytes)) % range;

        return minValue + rangeValue;
    }
}