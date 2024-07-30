
namespace Regon.ValueObjectsAndTheirExceptions.UserKeyValue
{
    public record UserKey
    {
        public string Key { get; private set; }

        public UserKey(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new UserKeyException("User Key cannot  be null");
            }
            Key = key;
        }
    }
}
