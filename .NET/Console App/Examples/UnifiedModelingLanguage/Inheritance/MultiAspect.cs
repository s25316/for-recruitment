namespace UnifiedModelingLanguage.Inheritance
{
    public class MultiAspectObject
    {
        public HandAspect? HandAspect { get; set; }


        public virtual void DoSomething() => Console.WriteLine(nameof(MultiAspectObject));
    }

    public class FirstAspectObject1 : MultiAspectObject
    {
        public override void DoSomething() => Console.WriteLine(nameof(FirstAspectObject1));
        public virtual void DoSomething1() => Console.WriteLine(nameof(FirstAspectObject1));
    }

    public class FirstAspectObject2 : MultiAspectObject
    {
        public override void DoSomething() => Console.WriteLine(nameof(FirstAspectObject2));
        public virtual void DoSomething2() => Console.WriteLine(nameof(FirstAspectObject2));
    }

    public abstract class HandAspect
    {
        public abstract void DoSomething3();


        public class Object1 : HandAspect
        {
            public override void DoSomething3() => Console.WriteLine(nameof(Object1));
        }

        public class Object2 : HandAspect
        {
            public override void DoSomething3() => Console.WriteLine(nameof(Object2));
        }
    }
}
