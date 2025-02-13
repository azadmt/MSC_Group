using System;

namespace Framework.Domain.Application;

public interface ICommandBus
{
   void Send<TCommand>( TCommand command)
    where TCommand :ICommand;
}
