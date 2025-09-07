namespace GangOfFour.Behavioral
{
    // =========================================================================================================
    // =========================================================================================================
    // Classic version => not in common use
    public interface ICommand
    {
        void Execute();
    }

    // =========================================================================================================
    // =========================================================================================================
    // Common use
    public interface ICommandHandler<in TInput>
    {
        Task HandleAsync(TInput input, CancellationToken cancellationToken = default);
    }

    public interface IQueryHandler<in TInput, TResult>
    {
        Task<TResult> HandleAsync(TInput input, CancellationToken cancellationToken = default);
    }
}
