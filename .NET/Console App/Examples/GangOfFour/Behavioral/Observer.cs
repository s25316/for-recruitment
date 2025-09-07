namespace GangOfFour.Behavioral
{
    // =========================================================================================================
    // =========================================================================================================
    // Classic Version
    public interface IObserverData { }

    public interface IObserver // Subscriber
    {
        void Receive(IObserverData data);
    }

    public interface IPublisher
    {
        void Add(IObserver subscriber);
        void Remove(IObserver subscriber);
        void Send(IObserverData data);
    }

    public class ClassicSubscriber : IObserver
    {
        public void Receive(IObserverData data)
        {
            // Do something
        }
    }

    public class ClassicPublisher : IPublisher
    {
        private readonly IList<IObserver> subscribers = [];


        public void Add(IObserver subscriber) => subscribers.Add(subscriber);
        public void Remove(IObserver subscriber) => subscribers.Remove(subscriber);
        public void Send(IObserverData data)
        {
            foreach (IObserver subscriber in subscribers)
            {
                subscriber.Receive(data);
            }
        }
    }

    // =========================================================================================================
    // =========================================================================================================
    // Using .NET 
    public abstract class Publisher
    {
        public event EventHandler Handler;

        public void Publish(EventArgs args)
        {
            Handler?.Invoke(this, args);
        }
    }

    public abstract class Subscriber
    {
        public abstract void OnEventRaised(object sender, EventArgs args);
        public abstract void UnSubscribe(Publisher publisher);
        public void Subscribe(Publisher publisher)
        {
            publisher.Handler += OnEventRaised;
        }
    }
}
