namespace GoF.Structural.Composite.Entities
{
    public abstract class TreeElement
    {
        // Properties
        private static int _counter = 0;
        public static int Counter { get { return _counter; } }
        public int Id { get; } = _counter++;


        // Methods
        public abstract int GetChildrenCount();
        public abstract void Increment();

        public override string ToString()
        {
            return $"{nameof(TreeElement)} Id: {Id}";
        }
    }
}
