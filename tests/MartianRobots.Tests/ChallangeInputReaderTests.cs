using MartianRobots.Core;

namespace MartianRobots.Tests;

public class ChallangeInputReaderTests
{
    [Fact]
    public void ReadsWorldDimensions()
    {
        var input = new[]
        {
            "5 3",
            "1 1 E",
            "RFRFRFRF"
        };

        var parser = new ChallangeInputReader();

        var result = parser.Parse(input);

        Assert.Equal(5, result.MaxX);
        Assert.Equal(3, result.MaxY);
    }

    [Fact]
    public void ReadsRobotPositionAndInstructions()
    {
        var input = new[]
        {
            "5 3",
            "1 1 E",
            "RFRFRFRF"
        };

        var parser = new ChallangeInputReader();

        var result = parser.Parse(input);

        var robot = Assert.Single(result.Robots);

        Assert.Equal(1, robot.X);
        Assert.Equal(1, robot.Y);
        Assert.Equal(Orientation.East, robot.Orientation);
        Assert.Equal("RFRFRFRF", robot.Instructions);
    }

    [Fact]
    public void Parse_ReadsMultipleRobots()
    {
        var input = new[]
        {
        "5 3",
        "1 1 E",
        "RFRFRFRF",
        "3 2 N",
        "FRRFLLFFRRFLL"
    };

        var parser = new ChallangeInputReader();

        var result = parser.Parse(input);

        Assert.Equal(2, result.Robots.Count);
    }
}