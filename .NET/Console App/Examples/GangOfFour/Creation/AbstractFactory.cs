namespace GangOfFour.Creation
{
    /*
     * PROBLEMS:
     * 
     */
    public interface IBoundedItem1 { }
    public interface IBoundedItem2 { }
    public interface IBoundedItem3 { }

    public class BoundedItem1 : IBoundedItem1 { }
    public class BoundedItem2 : IBoundedItem2 { }
    public class BoundedItem3 : IBoundedItem3 { }

    public sealed class AbstractFactoryBatch
    {
        public IEnumerable<IBoundedItem1> BoundedItems1 { get; init; } = [];
        public IEnumerable<IBoundedItem2> IBoundedItems2 { get; init; } = [];
        public IEnumerable<IBoundedItem3> IBoundedItems3 { get; init; } = [];
    }

    public interface IAbstractFactory
    {
        AbstractFactoryBatch Create();
    }
}
