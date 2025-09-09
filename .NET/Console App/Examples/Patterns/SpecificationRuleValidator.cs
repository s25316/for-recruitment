// Ignore Spelling: Validator
namespace Patterns
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T item);
    }

    public abstract class Specification<T> : ISpecification<T>
    {
        public abstract bool IsSatisfiedBy(T item);
        public ISpecification<T> And(ISpecification<T> specification) => new AndSpecification<T>(this, specification);
        public ISpecification<T> Or(ISpecification<T> specification) => new OrSpecification<T>(this, specification);
    }

    public class AndSpecification<T>(ISpecification<T> right, ISpecification<T> left) : ISpecification<T>
    {
        public bool IsSatisfiedBy(T item) => right.IsSatisfiedBy(item) && left.IsSatisfiedBy(item);
    }

    public class OrSpecification<T>(ISpecification<T> right, ISpecification<T> left) : ISpecification<T>
    {
        public bool IsSatisfiedBy(T item) => right.IsSatisfiedBy(item) || left.IsSatisfiedBy(item);
    }

    public class Rule<T>(ISpecification<T> specification) : ISpecification<T>
    {
        public bool IsSatisfiedBy(T item) => specification.IsSatisfiedBy(item);
    }

    public class Validator<T>
    {
        protected List<Rule<T>> rules = [];


        public void Add(Rule<T> rule) => rules.Add(rule);
        public bool IsValidAll(T item)
        {
            foreach (var rule in rules)
            {
                if (!rule.IsSatisfiedBy(item)) return false;
            }
            return true;
        }

        public bool IsValidAny(T item)
        {
            foreach (var rule in rules)
            {
                if (rule.IsSatisfiedBy(item)) return true;
            }
            return false;
        }
    }
}
