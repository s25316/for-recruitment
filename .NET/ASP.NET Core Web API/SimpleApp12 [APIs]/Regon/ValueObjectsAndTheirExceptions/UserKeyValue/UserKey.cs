using Regon.Factories;

namespace Regon.ValueObjectsAndTheirExceptions.UserKeyValue
{
    /// <summary>
    /// Klucz Użytkownika wydany przez REGON GUS
    /// </summary>
    /// <exception cref="UserKeyException"></exception>
    public record UserKey
    {
        public string Key { get; private set; }

        public UserKey(string key)
        {
            if (key != null)
            {
                key = key.Trim();
            }
            if (string.IsNullOrEmpty(key))
            {
                throw new UserKeyException(MessagesFactory.GenerateExeptionMessageUserKeyEmpty());
            }
            Key = key;
        }
    }
}
