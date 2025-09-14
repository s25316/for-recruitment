namespace UnifiedModelingLanguage.Inheritance
{
    /// <summary>
    /// <<dynamic>> - dynamic changing entity;
    /// </summary>
    public partial class DynamicObject
    {
        public DynamicObject1? Object1 { get; set; }
        public DynamicObject2? Object2 { get; set; }



        public virtual void DoSomething() => Console.WriteLine(nameof(BaseOverlappingObject));
    }

    public partial class DynamicObject
    {
        public class DynamicObject1 : DynamicObject
        {
            public DynamicObject1(DynamicObject baseObject)
            {
                baseObject.Object1 = this;
                baseObject.Object2 = null;
            }


            public override void DoSomething() => Console.WriteLine(nameof(DynamicObject1));
            public virtual void DoSomething1() => Console.WriteLine(nameof(DynamicObject1));

        }

        public class DynamicObject2 : DynamicObject
        {
            public DynamicObject2(DynamicObject baseObject)
            {
                baseObject.Object1 = null;
                baseObject.Object2 = this;
            }


            public override void DoSomething() => Console.WriteLine(nameof(DynamicObject2));
            public virtual void DoSomething2() => Console.WriteLine(nameof(DynamicObject1));
        }
    }

    // Dynamic by copy
    public abstract record DynamicCopyObject(string Name, int Level)
    {
        public DynamicCopyObject SetKey(int level) => level switch
        {
            1 => new DynamicCopyObjectLevel1(this.Name),
            2 => new DynamicCopyObjectLevel2(this.Name),
            _ => throw new NotImplementedException(),
        };
    }

    public record DynamicCopyObjectLevel1(string Name) : DynamicCopyObject(Name, 1)
    {

    }

    public record DynamicCopyObjectLevel2(string Name) : DynamicCopyObject(Name, 2)
    {

    }
}
