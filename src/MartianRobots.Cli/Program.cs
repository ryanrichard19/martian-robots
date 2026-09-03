using MartianRobots.Core;

if (args.Length > 1)
{
    Console.Error.WriteLine("Usage: MartianRobots.Cli [input-file]");
    Console.Error.WriteLine("Reads stdin when no file is given.");
    return 1;
}

if (args.Length == 1 && !File.Exists(args[0]))
{
    Console.Error.WriteLine($"Input file not found: {args[0]}");
    return 1;
}

var lines = args.Length == 1
    ? File.ReadLines(args[0])
    : ReadFromStdin();

var reader = new ChallengeInputReader();
var input = reader.Parse(lines);

var simulator = new Simulator();
var robots = simulator.Run(input);

foreach (var robot in robots)
{
    var orientation = robot.Orientation switch
    {
        Orientation.North => "N",
        Orientation.East => "E",
        Orientation.South => "S",
        Orientation.West => "W",
        _ => throw new InvalidOperationException()
    };

    Console.WriteLine(
        $"{robot.X} {robot.Y} {orientation}{(robot.Lost ? " LOST" : "")}");
}

return 0;

static IEnumerable<string> ReadFromStdin()
{
    string? line;

    while ((line = Console.ReadLine()) != null)
        yield return line;
}