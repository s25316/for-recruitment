using Regon.Factories;
using Regon.ValueObjectsAndTheirExceptions.UserKeyValue;

namespace Regon.ValueObjectsAndTheirExceptions.SessionIdValue
{
    /// <summary>
    /// Dwudziestoznakowy identyfikator sesji, który należy 
    /// przekazywać jako dodatkowy nagłówek żądania http o nazwie sid
    /// </summary>
    public record SesionId
    {
        public string Id { get; private set; }

        public SesionId(string? id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new UserKeyException(MessagesFactory.GenerateExeptionMessageUserKeyInvalid());
            }
            Id = id;
        }
    }
}
