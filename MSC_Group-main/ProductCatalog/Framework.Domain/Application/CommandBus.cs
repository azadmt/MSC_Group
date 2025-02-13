using Microsoft.Extensions.DependencyInjection;

namespace Framework.Domain.Application;

public class CommandBus : ICommandBus
{

    IServiceProvider serviceProvider;

    public CommandBus(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public void Send<TCommand>( TCommand command)
    where TCommand :ICommand
    {
        var handler=   serviceProvider.GetService<ICommandHandler<TCommand>>();
        var decoretor=new CommandHandlerLoggerDecorator<TCommand>( handler);
        decoretor.Handle(command);
    }

    
}
