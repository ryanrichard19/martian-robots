namespace MartianRobots.Core;

public interface ICommand
{
    void Execute(Robot robot, World world);
}

public class LeftCommand : ICommand
{
    public void Execute(Robot robot, World world)
    {
        robot.TurnLeft();
    }
}

public class RightCommand : ICommand
{
    public void Execute(Robot robot, World world)
    {
        robot.TurnRight();
    }
}

public class ForwardCommand : ICommand
{
    public void Execute(Robot robot, World world)
    {
        robot.MoveForward(world);
    }
}

public class CommandFactory
{
    public ICommand Create(char instruction)
    {
        return instruction switch
        {
            'L' => new LeftCommand(),
            'R' => new RightCommand(),
            'F' => new ForwardCommand(),
            _ => throw new ArgumentException(
                $"Unknown instruction: {instruction}",
                nameof(instruction))
        };
    }
}