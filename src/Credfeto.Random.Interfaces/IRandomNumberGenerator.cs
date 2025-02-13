namespace Credfeto.Random.Interfaces;

public interface IRandomNumberGenerator
{
    int Next(int maxValue);

    int Next(int minValue, int maxValue);
}
