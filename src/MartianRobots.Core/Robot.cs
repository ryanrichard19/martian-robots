namespace MartianRobots.Core;

public class Robot
{
    public int X { get; }
    public int Y { get; }
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
}