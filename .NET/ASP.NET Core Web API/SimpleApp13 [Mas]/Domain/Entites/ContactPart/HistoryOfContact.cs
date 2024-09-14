namespace Domain.Entites.ContactPart
{
    public class HistoryOfContact
    {
        public Guid? Id { get; set; }
        public DateTime DateTime { get; private set; } = DateTime.Now;
        public bool IsReaded { get; private set; } = false;
        public EnumContactStatus Status { get; private set; } = EnumContactStatus.Utworzone;
        public string FirstMessage { get; private set; } = null!;
        public string? ClientMessage { get; private set; } = null;
        public string? LastMessage { get; private set; } = null;

        //Constructor
        public HistoryOfContact(string firstMessage)
        {
            FirstMessage = firstMessage;
        }

        //Methods
        public bool SendFirst()
        {
            if (Status == EnumContactStatus.Utworzone)
            {
                Status = EnumContactStatus.WyslaneNieOdczytane;
                return true;
            }
            return false;
        }

        public bool Cancel()
        {
            if (Status == EnumContactStatus.Utworzone || Status == EnumContactStatus.WyslaneNieOdczytane)
            {
                Status = EnumContactStatus.Anulowane;
                return true;
            }
            return false;
        }

        public bool HasReaded()
        {
            if (Status == EnumContactStatus.WyslaneNieOdczytane)
            {
                Status = EnumContactStatus.Odzczytane;
                IsReaded = true;
                return true;
            }
            return false;
        }

        public bool ApprovedByClient(bool approve)
        {
            if (Status == EnumContactStatus.Odzczytane)
            {
                Status = (approve) ?
                    EnumContactStatus.OdzczytaneZaakceptowane :
                    EnumContactStatus.OdzczytaneNieZaakaceptowane;
                return true;
            }
            return false;
        }

        public bool SendMessageByClient(string clientMessage)
        {
            if (
                Status == EnumContactStatus.OdzczytaneZaakceptowane ||
                Status == EnumContactStatus.OdzczytaneNieZaakaceptowane
                )
            {
                ClientMessage = clientMessage;

                Status = (Status == EnumContactStatus.OdzczytaneZaakceptowane) ?
                    EnumContactStatus.ZwroconeZaakceptowane :
                    EnumContactStatus.ZwroconeNieZaakaceptowane;
                return true;
            }
            return false;
        }

        public bool SendEnd(string lastMessage)
        {
            if (
                Status == EnumContactStatus.ZwroconeZaakceptowane ||
                Status == EnumContactStatus.ZwroconeNieZaakaceptowane
                )
            {
                LastMessage = lastMessage;
                Status = EnumContactStatus.Zakonczone;
                return true;
            }
            return false;
        }
    }
}
