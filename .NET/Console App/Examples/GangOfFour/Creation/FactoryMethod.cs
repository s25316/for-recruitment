namespace GangOfFour.Creation
{
    // ==========================================================================================================
    // ==========================================================================================================
    // Classic Version => unused
    public interface IFactoryItem { }
    public class FactoryItem1 : IFactoryItem { }
    public class FactoryItem2 : IFactoryItem { }


    public interface IFactory<out T>
    {
        T Create();
    }

    public interface IFactory : IFactory<IFactoryItem> { }
    public class Factory1 : IFactory
    {
        public IFactoryItem Create()
        {
            return new FactoryItem1();
        }
    }
    public class Factory2 : IFactory
    {
        public IFactoryItem Create()
        {
            return new FactoryItem2();
        }
    }

    // ==========================================================================================================
    // ==========================================================================================================
    // Common version => incorrect but simple
    public abstract class FactoryItem
    {
        public class FactoryItem1 : FactoryItem { }
        public class FactoryItem2 : FactoryItem { }
        public class FactoryItemDefault : FactoryItem { }


        public static FactoryItem Create(string input) => input switch
        {
            "3" => new FactoryItem1(),
            "4" => new FactoryItem2(),
            _ => new FactoryItemDefault()
        };
    }
}
