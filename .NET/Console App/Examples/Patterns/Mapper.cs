namespace Patterns
{
    public interface IMapper<in TIn, out TOut>
    {
        public TOut Map(TIn input);
    }
}
