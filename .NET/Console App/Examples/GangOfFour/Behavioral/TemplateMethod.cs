namespace GangOfFour.Behavioral
{
    // ========================================================================================================
    // ========================================================================================================
    // Classic version
    public abstract class TemplateMethodHandler1
    {
        public void Handle()
        {
            DoSomething1();
            DoSomething2();
            DoSomething3();
        }

        protected static void DoSomething1() => Console.WriteLine("Shared action 1");

        // Here Logic changed
        protected abstract void DoSomething2();

        protected static void DoSomething3() => Console.WriteLine("Shared action 3");
    }

    public class TemplateMethod1 : TemplateMethodHandler1
    {
        protected override void DoSomething2() => Console.WriteLine($"Make individual action for {nameof(TemplateMethod1)}");
    }

    public class TemplateMethod2 : TemplateMethodHandler1
    {
        protected override void DoSomething2() => Console.WriteLine($"Make individual action for {nameof(TemplateMethod2)}");
    }

    // ========================================================================================================
    // ========================================================================================================
    // Common version
    public static class TemplateMethodHandler2
    {
        public static void Handle(Action action)
        {
            DoSomething1();
            action();
            DoSomething3();
        }

        private static void DoSomething1() => Console.WriteLine("Shared action 1");
        private static void DoSomething3() => Console.WriteLine("Shared action 3");
    }
}
