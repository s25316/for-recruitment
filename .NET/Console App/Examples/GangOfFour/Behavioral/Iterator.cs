namespace GangOfFour.Behavioral
{
    // Problem: Big collection
    public interface IIterator<out T> // Cursor
    {
        bool HaveNext();
        T Next();
    }

    public class Iterator<T>(T[] values) : IIterator<T>
    {
        private int index = 0;


        public bool HaveNext() => index < values.Length - 1;
        public T Next() => values[index++];
    }
}
