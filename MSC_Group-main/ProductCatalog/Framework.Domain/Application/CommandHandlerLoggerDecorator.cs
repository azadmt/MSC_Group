using System.Text.Json;
using System.Text.Json.Serialization;

namespace Framework.Domain.Application;

public class CommandHandlerLoggerDecorator<TCommand> : ICommandHandler<TCommand>
where TCommand : ICommand
{
    ICommandHandler<TCommand> commandHandler;

    public CommandHandlerLoggerDecorator(ICommandHandler<TCommand> commandHandler)
    {
        this.commandHandler = commandHandler;
    }

    public void Handle(TCommand command)
    {
        Console.WriteLine($"{DateTime.Now} : {JsonSerializer.Serialize(command)}");
        commandHandler.Handle(command);

    }
}
