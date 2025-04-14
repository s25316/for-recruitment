using GoF.Structural.AdapterFamily.Decorator.Interfaces;

namespace GoF.Structural.AdapterFamily.Decorator.Entities
{
    public class AccountantDecorator : IAccountant
    {
        // Property
        private readonly IAccountant _accountant;

        // Constructor
        public AccountantDecorator(IAccountant accountant)
        {
            _accountant = accountant;
        }

        // Methods
        public virtual IReadOnlyCollection<string> GetCompetences()
        {
            return _accountant.GetCompetences();
        }
    }
}
