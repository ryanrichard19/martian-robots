using MartianRobots.Core;

namespace MartianRobots.Tests;

public class SimulatorTests
{
    [Fact]
    public void ProcessesRobotsSequentially()
    {
        var input = new ProblemInput(
            5,
            3,
            new[]
            {
                new RobotInput(1, 1, Orientation.East, "F"),
                new RobotInput(3, 2, Orientation.North, "F")
            });

        var simulator = new Simulator();

        var result = simulator.Run(input);

        Assert.Equal(2, result.Count);

        Assert.Equal(2, result[0].X);
        Assert.Equal(1, result[0].Y);
        Assert.Equal(Orientation.East, result[0].Orientation);

        Assert.Equal(3, result[1].X);
        Assert.Equal(3, result[1].Y);
        Assert.Equal(Orientation.North, result[1].Orientation);
    }

    [Fact]
    public void StopsProcessingInstructionsWhenRobotIsLost()
    {
        var input = new ProblemInput(
            1,
            1,
            new[]
            {
            new RobotInput(1, 1, Orientation.North, "FRR")
            });

        var simulator = new Simulator();

        var result = simulator.Run(input);

        var robot = Assert.Single(result);

        Assert.True(robot.Lost);
        Assert.Equal(Orientation.North, robot.Orientation);
    }

    [Fact]
public void ScentFromLostRobotAffectsNextRobot()
{
    var input = new ProblemInput(
        1,
        1,
        new[]
        {
            new RobotInput(1, 1, Orientation.North, "F"),
            new RobotInput(1, 1, Orientation.North, "F")
        });

    var simulator = new Simulator();

    var result = simulator.Run(input);

    Assert.True(result[0].Lost);
    Assert.False(result[1].Lost);

    Assert.Equal(1, result[1].X);
    Assert.Equal(1, result[1].Y);
}
}