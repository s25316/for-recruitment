using Domain.Entites.CompanyPart;
using Domain.Entites.UniversityPart;

namespace Domain.Entites.PersonPart
{
    public class Employee
    {
        public Person Person { get; private set; } = null!;
        public string Position { get; private set; } = null!;
        public List<string> Competences { get; private set; } = new List<string>();

        //Refences
        public List<Client> Clients { get; private set; } = new List<Client>();
        public List<EmploymentHistory> EmploymentHistory { get; private set; } = new List<EmploymentHistory>();
        public List<EducationHistory> EducationHistory { get; private set; } = new List<EducationHistory>();

        //Subset
        public List<Depratment> WorkingInDepratments { get; private set; } = new List<Depratment>();
        public List<Depratment> ManageInDepratments { get; private set; } = new List<Depratment>();

        //Constructors
        public Employee(Person p, string postition, List<string> competences)
        {
            Person = p;
            Position = postition;
            Competences = competences;

            //Throw if Client not null
            if (p.Employee != null)
            {
                throw new Exception("Unable Create new Employee, Employee Person exist");
            }
            p.Employee = this;
        }

        //Methods
        //CreateProfile

        public bool SetClientToEmploee(Client client)
        {
            Clients.Add(client);
            client.Employee = this;
            return true;
        }

        //========================================================================================================
        //Subset Implementation
        public bool SetEmploeeToDepartment(Depratment depratment)
        {
            if (!WorkingInDepratments.Contains(depratment))
            {
                WorkingInDepratments.Add(depratment);
                depratment.Employees.Add(this);
                return true;
            }
            return false;
        }

        public bool SetManagerToDepartment(Depratment depratment)
        {
            if (WorkingInDepratments.Contains(depratment))
            {
                ManageInDepratments.Add(depratment);
                depratment.Managers.Add(this);
                return true;
            }
            return false;
        }
        //========================================================================================================
        public bool SetEducationHistory(EducationHistory educationHistory)
        {
            EducationHistory.Add(educationHistory);
            return true;
        }

        public bool SetEmploymentHistory(EmploymentHistory employmentHistory)
        {
            EmploymentHistory.Add(employmentHistory);
            return true;
        }

        public bool IsNoCollisionsWithOtherInstitutions()
        {
            foreach (var history in EmploymentHistory)
            {
                if (history.IsColision() == true)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
