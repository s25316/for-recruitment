namespace Patterns
{
    public record Maybe1<T>(T? Value = default)
    {
        public bool HasValue => Value is not null;


        public static Maybe1<T> None => new Maybe1<T>();
        public static Maybe1<T> From(T value) => value is null
            ? None
            : new Maybe1<T>(value);
    }

    public abstract record Maybe2
    {
        public record None : Maybe2;
        public record Some<T>(T Value) : Maybe2;
    }
}
