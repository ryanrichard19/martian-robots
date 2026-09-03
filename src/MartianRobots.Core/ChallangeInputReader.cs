namespace MartianRobots.Core;

public sealed record RobotInput(
    int X,
    int Y,
    Orientation Orientation,
    string Instructions);

public sealed record ProblemInput(
    int MaxX,
    int MaxY,
    IReadOnlyList<RobotInput> Robots);

public class ChallangeInputReader
{
    public ProblemInput Parse(IEnumerable<string> lines)
    {
        var input = lines
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToList();

        var worldParts = input[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var maxX = int.Parse(worldParts[0]);
        var maxY = int.Parse(worldParts[1]);

        var robots = new List<RobotInput>();

        for (var i = 1; i < input.Count; i += 2)
        {
            var positionParts = input[i]
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            robots.Add(new RobotInput(
                int.Parse(positionParts[0]),
                int.Parse(positionParts[1]),
                ParseOrientation(positionParts[2]),
                input[i + 1]));
        }

        return new ProblemInput(maxX, maxY, robots);
    }

    private static Orientation ParseOrientation(string value)
    {
        return value switch
        {
            "N" => Orientation.North,
            "E" => Orientation.East,
            "S" => Orientation.South,
            "W" => Orientation.West,
            _ => throw new ArgumentException($"Unknown orientation: {value}")
        };
    }
}