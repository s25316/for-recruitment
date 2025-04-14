using GoF.Structural.AdapterFamily.Decorator.Interfaces;

namespace GoF.Structural.AdapterFamily.Decorator.Entities
{
    public class JuniorAccountant : IAccountant
    {
        public IReadOnlyCollection<string> GetCompetences()
        {
            return [
                "Analyze Incomes/Outcomes",
                "Analyze Contracts",
            ];
        }
    }
}
