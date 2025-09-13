namespace UnifiedModelingLanguage.Inheritance
{
    // Inherence: complete, incomplete (...)
    public class BaseOverlappingObject
    {
        /// IList<Enum>  roles = [ Enum.Object1, Enum.Object2 ]; Add, Remove
        public virtual OverlappingObject1? Object1 { get; set; }
        public virtual OverlappingObject2? Object2 { get; set; }


        public virtual void DoSomething() => Console.WriteLine(nameof(BaseOverlappingObject));
    }

    public class OverlappingObject1 : BaseOverlappingObject
    {
        public OverlappingObject1(BaseOverlappingObject baseObject)
        {
            baseObject.Object1 = this;
        }


        public override void DoSomething() => Console.WriteLine(nameof(OverlappingObject1));
    }

    public class OverlappingObject2 : BaseOverlappingObject
    {
        public OverlappingObject2(BaseOverlappingObject baseObject)
        {
            baseObject.Object2 = this;
        }


        public override void DoSomething() => Console.WriteLine(nameof(OverlappingObject2));
    }
}
