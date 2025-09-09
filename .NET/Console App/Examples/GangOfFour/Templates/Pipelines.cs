namespace GangOfFour.Templates
{
    public interface IOperation<in TIn, out TOut>
    {
        TOut Invoke(TIn input);
    }

    public static class PipelineBuilder
    {
        public static Pipeline<TIn, TIn> Create<TIn>()
        {
            return new Pipeline<TIn, TIn>(input => input);
        }

        public static Pipeline<TIn, TOut> Create<TIn, TOut>(IOperation<TIn, TOut> operation)
        {
            return new Pipeline<TIn, TOut>(input => operation.Invoke(input));
        }

        public static Pipeline<TIn, TOut> Create<TIn, TOut>(Func<TIn, TOut> func)
        {
            return new Pipeline<TIn, TOut>(input => func(input));
        }

        public static Pipeline<TIn, TIn> Create<TIn>(Action<TIn> action)
        {
            return new Pipeline<TIn, TIn>(input =>
            {
                action(input);
                return input;
            });
        }
    }

    public sealed class Pipeline<TIn, TOut>(Func<TIn, TOut> operation) : IOperation<TIn, TOut>
    {
        public Pipeline<TIn, TNewOut> Add<TNewOut>(IOperation<TOut, TNewOut> nextOperation)
        {
            return new Pipeline<TIn, TNewOut>(input =>
            {
                var baseOperaton = operation(input);
                return nextOperation.Invoke(baseOperaton);
            });
        }

        public Pipeline<TIn, TNewOut> Add<TNewOut>(Func<TOut, TNewOut> func)
        {
            return new Pipeline<TIn, TNewOut>(input =>
            {
                var baseOperaton = operation(input);
                return func(baseOperaton);
            });
        }

        public Pipeline<TIn, TIn> Add(Action<TIn> action)
        {
            return new Pipeline<TIn, TIn>(input =>
            {
                action(input);
                return input;
            });
        }

        public TOut Invoke(TIn input) => operation.Invoke(input);
    }

    // =========================================================================================================
    // =========================================================================================================
    // Examples
    public class AddFiveOperation : IOperation<int, int>
    {
        public int Invoke(int input) => input + 5;
    }

    public class IntToStringOperation : IOperation<int, string>
    {
        public string Invoke(int input) => $"Wynik to: {input}";
    }

    public class AddExclamationOperation : IOperation<string, string>
    {
        public string Invoke(string input) => $"{input}!";
    }

    public static class Runner
    {
        public static void Main()
        {
            var pipeline = PipelineBuilder
                .Create(new AddFiveOperation())
                .Add(x => Console.WriteLine(x))
                .Add(new IntToStringOperation())
                .Add(new AddExclamationOperation());

            string result = pipeline.Invoke(10);
            Console.WriteLine(result);
        }
    }
}
