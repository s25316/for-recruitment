using Domain.Entites.PersonPart;

namespace Domain.Entites.ContactPart
{
    public class HistoryOfContactClient : HistoryOfContact
    {
        public Depratment Depratment { get; private set; } = null!;
        public Client Client { get; private set; } = null!;

        //Constructor
        public HistoryOfContactClient
            (
            string firstMessage,
            Depratment depratment,
            Client client
            ) : base(firstMessage)
        {
            Depratment = depratment;
            Client = client;

            depratment.HistoryOfContactClient.Add(this);
            client.HistoryOfContactClient.Add(this);
        }
    }
}
