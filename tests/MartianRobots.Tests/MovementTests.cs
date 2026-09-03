using MartianRobots.Core;

namespace MartianRobots.Tests;

public class MovementTests
{
    [Theory]
    [InlineData(1, 1, Orientation.North, 1, 2)]
    [InlineData(1, 1, Orientation.East, 2, 1)]
    [InlineData(1, 1, Orientation.South, 1, 0)]
    [InlineData(1, 1, Orientation.West, 0, 1)]
    public void MoveForward_WithinWorldBounds_MovesOneGridPoint(
        int startX,
        int startY,
        Orientation orientation,
        int expectedX,
        int expectedY)
    {
        var world = new World(5, 3);
        var robot = new Robot(startX, startY, orientation);

        robot.MoveForward(world);

        Assert.Equal(expectedX, robot.X);
        Assert.Equal(expectedY, robot.Y);
    }
}