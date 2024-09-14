namespace Domain.ValueObjects
{
    public record DocumentNumber
    {
        public string Value { get; private set; } = null!;

        public DocumentNumber(string value)
        {
            Value = value;
        }

    }
}
