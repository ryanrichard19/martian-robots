using MartianRobots.Core;

namespace MartianRobots.Tests;

public class CommandFactoryTests
{
    [Theory]
    [InlineData('L', typeof(LeftCommand))]
    [InlineData('R', typeof(RightCommand))]
    [InlineData('F', typeof(ForwardCommand))]
    public void Create_KnownInstruction_ReturnsCorrectCommand(
        char instruction,
        Type expectedType)
    {
        var factory = new CommandFactory();

        var command = factory.Create(instruction);

        Assert.IsType(expectedType, command);
    }

    [Fact]
    public void Create_UnknownInstruction_ThrowsException()
    {
        var factory = new CommandFactory();

        Assert.Throws<ArgumentException>(() => factory.Create('X'));
    }
}