using MartianRobots.Core;

namespace MartianRobots.Tests;

public class SampleDataTests
{
    [Fact]
    public void SuppliedSampleInput_ProducesExpectedResult()
    {
        var lines = new[]
        {
            "5 3",
            "1 1 E",
            "RFRFRFRF",
            "3 2 N",
            "FRRFLLFFRRFLL",
            "0 3 W",
            "LLFFFLFLFL"
        };

        var reader = new ChallengeInputReader();
        var input = reader.Parse(lines);

        var simulator = new Simulator();
        var robots = simulator.Run(input);

        Assert.Equal(3, robots.Count);

        Assert.Equal(1, robots[0].X);
        Assert.Equal(1, robots[0].Y);
        Assert.Equal(Orientation.East, robots[0].Orientation);
        Assert.False(robots[0].Lost);

        Assert.Equal(3, robots[1].X);
        Assert.Equal(3, robots[1].Y);
        Assert.Equal(Orientation.North, robots[1].Orientation);
        Assert.True(robots[1].Lost);

        Assert.Equal(2, robots[2].X);
        Assert.Equal(3, robots[2].Y);
        Assert.Equal(Orientation.South, robots[2].Orientation);
        Assert.False(robots[2].Lost);
    }
}