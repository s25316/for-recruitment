using Regon.ValueObjectsAndTheirExceptions.UserKeyValue;

namespace Regon.ValueObjectsAndTheirExceptions.SessionIdValue
{
    /// <summary>
    /// Dwudziestoznakowy identyfikator sesji, który należy 
    /// przekazywać jako dodatkowy nagłówek żądania http o nazwie sid
    /// </summary>
    public record Sid
    {
        public string Id { get; private set; }

        public Sid(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new UserKeyException("Probably you have incorrect User Key");
            }
            else if (id.Length != 20)
            {
                throw new SidException("Session Id Should be 20 signs");
            }
            Id = id;
        }
    }
}
