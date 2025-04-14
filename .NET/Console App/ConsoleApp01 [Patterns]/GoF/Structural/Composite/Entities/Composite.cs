namespace GoF.Structural.Composite.Entities
{
    public class Composite : TreeElement
    {
        // Properties
        private readonly List<TreeElement> _children = new();


        // Methods
        public void Add(TreeElement element) => _children.Add(element);
        public void Remove(TreeElement element) => _children.Remove(element);
        public IEnumerable<TreeElement> GetChildren() => _children.AsReadOnly();

        public override int GetChildrenCount()
        {
            return _children.Sum(c => c.GetChildrenCount())
                + _children.Count;
        }

        public override void Increment()
        {
            foreach (var element in _children)
            {
                element.Increment();
            }
        }
    }
}
