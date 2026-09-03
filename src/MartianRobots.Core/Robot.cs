namespace MartianRobots.Core;

public class Robot
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public Orientation Orientation { get; private set; }

    public Robot(int x, int y, Orientation orientation)
    {
        X = x;
        Y = y;
        Orientation = orientation;
    }

    public void TurnLeft()
    {
        Orientation = Orientation switch
        {
            Orientation.North => Orientation.West,
            Orientation.West => Orientation.South,
            Orientation.South => Orientation.East,
            Orientation.East => Orientation.North,
            _ => throw new InvalidOperationException()
        };
    }

    public void TurnRight()
    {
        Orientation = Orientation switch
        {
            Orientation.North => Orientation.East,
            Orientation.East => Orientation.South,
            Orientation.South => Orientation.West,
            Orientation.West => Orientation.North,
            _ => throw new InvalidOperationException()
        };
    }

    public void MoveForward(World world)
    {
        var (nextX, nextY) = Orientation switch
        {
            Orientation.North => (X, Y + 1),
            Orientation.East => (X + 1, Y),
            Orientation.South => (X, Y - 1),
            Orientation.West => (X - 1, Y),
            _ => throw new InvalidOperationException()
        };

        if (world.Contains(nextX, nextY))
        {
            X = nextX;
            Y = nextY;
        }
    }
}