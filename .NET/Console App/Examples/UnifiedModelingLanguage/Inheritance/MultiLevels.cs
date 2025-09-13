// Ignore Spelling: Muli-inherence
namespace UnifiedModelingLanguage.Inheritance
{
    // Muli-inherence
    public class FirstGenerationObject
    {
        public virtual void DoSomething() => Console.WriteLine(nameof(FirstGenerationObject));
    }

    public class HandGenerationObject1 : FirstGenerationObject
    {
        public override void DoSomething() => Console.WriteLine(nameof(HandGenerationObject1));
        public virtual void DoSomething2() => Console.WriteLine(nameof(HandGenerationObject1));
    }

    public interface IHandGenerationObject2
    {
        void DoSomething3();
    }

    public class HandGenerationObject2 : FirstGenerationObject, IHandGenerationObject2
    {
        public override void DoSomething() => Console.WriteLine(nameof(HandGenerationObject2));
        public virtual void DoSomething3() => Console.WriteLine(nameof(HandGenerationObject2));
    }

    public class ThirdGenerationObject1And2 : HandGenerationObject1, IHandGenerationObject2
    {
        private readonly HandGenerationObject2 object2;


        public ThirdGenerationObject1And2(/* here only parameters */)
        {
            // here inserting values from constructor to HandGenerationObject2, but only which needs in methods
            object2 = new HandGenerationObject2();
        }


        public override void DoSomething()
        {
            base.DoSomething();
            object2.DoSomething();
        }

        public override void DoSomething2() => Console.WriteLine(nameof(ThirdGenerationObject1And2));
        public virtual void DoSomething3() => object2.DoSomething3();
    }
}
