namespace MartianRobots.Core;

public class World
{
    public int MaxX { get; }
    public int MaxY { get; }

    public World(int maxX, int maxY)
    {
        MaxX = maxX;
        MaxY = maxY;
    }

    public bool Contains(int x, int y)
    {
        return x >= 0 && x <= MaxX &&
        y >= 0 && y <= MaxY;
    }
}