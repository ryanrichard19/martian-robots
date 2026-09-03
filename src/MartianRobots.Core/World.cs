namespace MartianRobots.Core;

public class World
{
    private readonly HashSet<(int X, int Y)> _scents = [];
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

    public void LeaveScent(int x, int y)
    {
        _scents.Add((x,y));
    }

    public bool HasScent(int x, int y)
    {
        return _scents.Contains((x,y));
    }
}