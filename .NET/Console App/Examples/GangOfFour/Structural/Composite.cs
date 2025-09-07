namespace GangOfFour.Structural
{
    public interface ITreeElement
    {
        void Invoke();
    }

    public class Composite : ITreeElement
    {
        private readonly List<ITreeElement> children = [];


        public void Add(ITreeElement element) => children.Add(element);
        public void Remove(ITreeElement element) => children.Remove(element);
        public void Invoke()
        {
            foreach (var child in children)
            {
                child.Invoke();
            }
            // Do Something
        }
    }

    public class Leaf : ITreeElement
    {
        public void Invoke()
        {
            // Do Something
        }
    }
}
