using System;
using Credfeto.Random.Interfaces;

namespace Credfeto.Random;

public sealed class RandomSource : IRandomSource
{
    public void Generate(in Span<byte> buffer)
    {
        using (
            System.Security.Cryptography.RandomNumberGenerator randomNumberGenerator =
                System.Security.Cryptography.RandomNumberGenerator.Create()
        )
        {
            randomNumberGenerator.GetBytes(buffer);
        }
    }
}
