using GoF.Structural.AdapterFamily.Decorator.Interfaces;

namespace GoF.Structural.AdapterFamily.Decorator.Entities
{
    public class MiddleAccountantDecorator : AccountantDecorator
    {
        // Constructor
        public MiddleAccountantDecorator(IAccountant accountant)
            : base(accountant)
        {
        }

        // Methods
        public override IReadOnlyCollection<string> GetCompetences()
        {
            var baseCompetences = base.GetCompetences().ToList();
            baseCompetences.AddRange(GetAdditionalCompetences());
            return baseCompetences;
        }

        public IReadOnlyCollection<string> GetAdditionalCompetences()
        {
            return [
                "Create reports",
                "Create contracts",
                "Create bills",
                ];
        }
    }
}
