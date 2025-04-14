namespace GoF.Structural.Composite.Entities
{
    public class Leaf : TreeElement
    {
        // Properties
        public int LocalCount { get; set; }


        // Methods
        public override int GetChildrenCount() => 0;

        public override void Increment() => LocalCount++;
    }
}
