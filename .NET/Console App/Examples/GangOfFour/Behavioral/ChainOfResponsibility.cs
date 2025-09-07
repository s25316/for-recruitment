namespace GangOfFour.Behavioral
{
    public interface IChainOfResponsibilityObject { }
    public interface IChainHandler<in T>
    {
        Task HandleAsync(T input, CancellationToken cancellationToken = default);
    }

    // =========================================================================================================
    // =========================================================================================================
    // Classic Version => not in common use
    public abstract class ChainOfResponsibility1 : IChainHandler<IChainOfResponsibilityObject>
    {
        private ChainOfResponsibility1? next = null;


        // This method difference
        public void SetNext(ChainOfResponsibility1 next) => this.next = next;
        protected abstract Task InvokeBusinessLogic(IChainOfResponsibilityObject input, CancellationToken cancellationToken = default);
        public async Task HandleAsync(IChainOfResponsibilityObject input, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            await InvokeBusinessLogic(input, cancellationToken);
            if (next is not null)
            {
                await next.HandleAsync(input, cancellationToken);
            }
        }
    }

    // =========================================================================================================
    // =========================================================================================================
    // Common use
    public abstract class ChainOfResponsibility2 : IChainHandler<IChainOfResponsibilityObject>
    {
        private readonly ChainOfResponsibility2? next = null;


        protected ChainOfResponsibility2(ChainOfResponsibility2? next = null) => this.next = next;


        protected abstract Task InvokeBusinessLogic(IChainOfResponsibilityObject input, CancellationToken cancellationToken = default);
        public async Task HandleAsync(IChainOfResponsibilityObject input, CancellationToken cancellationToken = default)
        {
            await InvokeBusinessLogic(input, cancellationToken);
            if (next is not null)
            {
                await next.HandleAsync(input, cancellationToken);
            }
        }
    }
}
