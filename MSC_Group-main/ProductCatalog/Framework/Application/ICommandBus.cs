namespace Application;

public interface ICommandBus
{
    void Send(object command);
}

