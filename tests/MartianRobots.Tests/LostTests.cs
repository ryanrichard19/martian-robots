using MartianRobots.Core;

namespace MartianRobots.Tests;

public class LostTests
{
    [Theory]
    [InlineData(0, 3, Orientation.North)]
    [InlineData(5, 0, Orientation.East)]
    [InlineData(0, 0, Orientation.South)]
    [InlineData(0, 0, Orientation.West)]
    public void MoveForward_OutsideWorld_MarksRobotAsLost(
        int startX,
        int startY,
        Orientation orientation)
    {
        var world = new World(5, 3);
        var robot = new Robot(startX, startY, orientation);

        robot.MoveForward(world);

        Assert.True(robot.Lost);
    }

    [Fact]
    public void MoveForward_OutsideWorld_KeepsLastValidPosition()
    {
        var world = new World(5, 3);
        var robot = new Robot(5, 3, Orientation.North);

        robot.MoveForward(world);

        Assert.Equal(5, robot.X);
        Assert.Equal(3, robot.Y);
        Assert.True(robot.Lost);
    }

    [Fact]
    public void MoveForward_WithinWorld_DoesNotMarkRobotAsLost()
    {
        var world = new World(5, 3);
        var robot = new Robot(1, 1, Orientation.North);

        robot.MoveForward(world);

        Assert.False(robot.Lost);
    }
}