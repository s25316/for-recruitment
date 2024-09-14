using Domain.Entites.PersonPart;

namespace Domain.Entites.PriorityPart
{
    public class Priority
    {
        //XOR part
        private readonly List<PriorityRole> _priorityXorRoles = new List<PriorityRole>()
        {
            PriorityRole.NormalPerson ,PriorityRole.PEP
        };
        private List<PriorityRole> _currentRoles = new List<PriorityRole>();

        //Values Part
        public Person Person { get; set; } = null!;
        private NormalPerson? _normalPerson = null;
        private Pep? _pep = null;


        //Getters Setters
        public NormalPerson? CurrentNormalPerson
        {
            get { return _normalPerson; }
            set
            {
                //val = null not null 
                var intesectedRoles = _currentRoles.Intersect(_priorityXorRoles);
                if (
                    intesectedRoles.Count() == 0 ||
                    (intesectedRoles.Count() == 1 && intesectedRoles.Contains(PriorityRole.NormalPerson))
                    )
                {
                    if (value == null)
                    {
                        _currentRoles.Remove(PriorityRole.NormalPerson);
                        _normalPerson = null;
                    }
                    else
                    {
                        _currentRoles.Add(PriorityRole.NormalPerson);
                        _normalPerson = value;
                    }
                }
                else
                {
                    throw new Exception("Unable Set Value, You need Set null value into other status");
                }
            }
        }

        public Pep? CurrentPep
        {
            get { return _pep; }
            set
            {
                //val = null not null 
                var intesectedRoles = _currentRoles.Intersect(_priorityXorRoles);
                if (
                    intesectedRoles.Count() == 0 ||
                    (intesectedRoles.Count() == 1 && intesectedRoles.Contains(PriorityRole.PEP))
                    )
                {
                    if (value == null)
                    {
                        //Exeption
                        throw new Exception("Unable Set Null, Because status PEP can not be lost");
                    }
                    else
                    {
                        _currentRoles.Add(PriorityRole.PEP);
                        _pep = value;
                    }
                }
                else
                {
                    throw new Exception("Unable Set Value, You need Set null value into other status");
                }
            }
        }

    }
}
