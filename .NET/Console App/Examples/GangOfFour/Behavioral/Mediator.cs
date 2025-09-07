namespace GangOfFour.Behavioral
{
    public interface IMediatorData { }

    public interface IMediator
    {
        void AddClient(IMediatorClient client);
        void Send(IMediatorData data, IMediatorClient sender);
    }

    public interface IMediatorClient
    {
        void Send(IMediatorData data);
        void Receive(IMediatorData data, IMediatorClient sender);
    }

    public class Mediator : IMediator
    {
        private readonly IList<IMediatorClient> clients = [];

        public void AddClient(IMediatorClient client) => clients.Add(client);
        public void Send(IMediatorData data, IMediatorClient sender)
        {
            foreach (var client in clients)
            {
                if (client == sender)
                {
                    continue;
                }

                client.Receive(data, sender);
            }
        }
    }

    // Can separate clients: Admin, Premium ...
    public class MediatorClient : IMediatorClient
    {
        private readonly IMediator mediator;

        public MediatorClient(IMediator mediator)
        {
            this.mediator = mediator;
            mediator.AddClient(this);
        }

        public void Send(IMediatorData data) => mediator.Send(data, this);
        public void Receive(IMediatorData data, IMediatorClient sender)
        {
            // Business logic 
        }
    }
}
