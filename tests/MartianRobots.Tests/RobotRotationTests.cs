using MartianRobots.Core;

namespace MartianRobots.Tests;

public class RobotRotationTests
{
    [Theory]
    [InlineData(Orientation.North, Orientation.West)]
    [InlineData(Orientation.West, Orientation.South)]
    [InlineData(Orientation.South, Orientation.East)]
    [InlineData(Orientation.East, Orientation.North)]
    public void TurnLeft_ChangesOrientationCorrectly(
        Orientation startingOrientation,
        Orientation expectedOrientation)
    {
        var robot = new Robot(0, 0, startingOrientation);

        robot.TurnLeft();

        Assert.Equal(expectedOrientation, robot.Orientation);
    }

    [Theory]
    [InlineData(Orientation.North, Orientation.East)]
    [InlineData(Orientation.East, Orientation.South)]
    [InlineData(Orientation.South, Orientation.West)]
    [InlineData(Orientation.West, Orientation.North)]
    public void TurnRight_ChangesOrientationCorrectly(
        Orientation startingOrientation,
        Orientation expectedOrientation)
    {
        var robot = new Robot(0, 0, startingOrientation);

        robot.TurnRight();

        Assert.Equal(expectedOrientation, robot.Orientation);
    }

}