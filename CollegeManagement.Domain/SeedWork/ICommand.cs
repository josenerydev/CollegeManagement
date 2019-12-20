using CSharpFunctionalExtensions;

namespace CollegeManagement.Domain.SeedWork
{
    public interface ICommand
    {
    }

    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Result Handle(TCommand command);
    }
}
