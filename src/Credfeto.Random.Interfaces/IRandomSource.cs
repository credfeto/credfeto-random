using System;

namespace Credfeto.Random.Interfaces;

public interface IRandomSource
{
    void Generate(in Span<byte> buffer);
}