namespace MartianRobots.Core;

public class Simulator
{
    private readonly CommandFactory _commandFactory = new();

    public IReadOnlyList<Robot> Run(ProblemInput input)
    {
        var world = new World(input.MaxX, input.MaxY);
        var robots = new List<Robot>();

        foreach (var robotInput in input.Robots)
        {
            var robot = new Robot(
                robotInput.X,
                robotInput.Y,
                robotInput.Orientation);

            foreach (var instruction in robotInput.Instructions)
            {
                var command = _commandFactory.Create(instruction);
                command.Execute(robot, world);

                if (robot.Lost)
                    break;
            }

            robots.Add(robot);
        }

        return robots;
    }
}