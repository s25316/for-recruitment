

namespace MAS04.Models
{
    internal class ServiceAgent
    {
        private static List<ServiceAgentType> _servicesXOR = new List<ServiceAgentType>()
        { ServiceAgentType.CIA, ServiceAgentType.FBI, ServiceAgentType.SecretService};
        private List<ServiceAgentType> _typesOfAgent = new List<ServiceAgentType>();

        public string Name { get; private set; } = null!;
        public ServiceAgent(string name) { Name = name; }
        public override string ToString() => $"Agent {Name}";
        //========================================

        private FBI? _FBI;
        public FBI? FBI { get { return _FBI; } }
        public Comment SetFBIDepartament(FBI? fbiDepartament)
        {
            if (fbiDepartament == _FBI) { return Comment.UnableExist; }
            else if (fbiDepartament == null)
            {
                //null -> add value add type
                if (_FBI != null) _FBI.DeleteAgent(this);
                _FBI = fbiDepartament;
                _typesOfAgent.Remove(ServiceAgentType.FBI);
                return Comment.Add;
            }
            else
            {
                if (_typesOfAgent.Contains(ServiceAgentType.FBI))
                {
                    if (_FBI != null) _FBI.DeleteAgent(this);
                    _FBI = fbiDepartament;
                    fbiDepartament.SetAgentWithoutVerefication(this);
                    return Comment.Add;
                }
                else
                {
                    var isExist = IsContainsXORRole();
                    if (isExist) return Comment.UnableCollision;

                    _FBI = fbiDepartament;
                    _typesOfAgent.Add(ServiceAgentType.FBI);
                    fbiDepartament.SetAgentWithoutVerefication(this);
                    return Comment.Add;
                    //value => contains lint into list if exist Error if not Approve
                }
            }
        }
        //========================================

        private CIA? _CIA;
        public CIA? CIA { get { return _CIA; } }
        public Comment SetCIADepartament(CIA? ciaiDepartament)
        {
            if (ciaiDepartament == _CIA) { return Comment.UnableExist; }
            else if (ciaiDepartament == null)
            {
                //null -> add value add type
                if (_CIA != null) _CIA.DeleteAgent(this);
                _CIA = ciaiDepartament;
                _typesOfAgent.Remove(ServiceAgentType.CIA);
                return Comment.Add;
            }
            else
            {
                if (_typesOfAgent.Contains(ServiceAgentType.CIA))
                {
                    if (_CIA != null) _CIA.DeleteAgent(this);
                    _CIA = ciaiDepartament;
                    ciaiDepartament.SetAgentWithoutVerefication(this);
                    return Comment.Add;
                }
                else
                {
                    var isExist = IsContainsXORRole();
                    if (isExist) return Comment.UnableCollision;

                    _CIA = ciaiDepartament;
                    _typesOfAgent.Add(ServiceAgentType.CIA);
                    ciaiDepartament.SetAgentWithoutVerefication(this);
                    return Comment.Add;
                    //value => contains lint into list if exist Error if not Approve
                }
            }
        }
        public bool IsContainsXORRole()
        {
            foreach (var item in _typesOfAgent)
            {
                var isContain = _servicesXOR.Contains(item);
                if (isContain) return true;
            }
            return false;
        }

    }
    public enum Comment { Add, UnableCollision, UnableExist, Null }
    public enum ServiceAgentType { FBI, CIA, SecretService, Agent, Oficer, Director }

    abstract class Service
    {
        protected string DepartamentName { get; private set; } = null!;
        protected List<ServiceAgent> _serviceAgents = new List<ServiceAgent>();

        public Service(string departamentName) { DepartamentName = departamentName; }

        public abstract Comment SetAgent(ServiceAgent agent);
        public List<ServiceAgent> ServiceAgents() => _serviceAgents;
        public override string ToString() => $"FBI Depratament: {DepartamentName}";
    }

    class FBI : Service
    {
        public FBI(string departamentName) : base(departamentName) { }

        public override Comment SetAgent(ServiceAgent agent)
        {
            if (_serviceAgents.Contains(agent)) { return Comment.UnableExist; }
            _serviceAgents.Add(agent);

            var message = agent.SetFBIDepartament(this);

            if (message != Comment.Add)
            {
                _serviceAgents.Remove(agent);
                return message;
            }
            return message;
        }
        public Comment SetAgentWithoutVerefication(ServiceAgent agent)
        {
            if (_serviceAgents.Contains(agent)) { return Comment.UnableExist; }
            _serviceAgents.Add(agent);
            return Comment.Add;
        }

        public bool DeleteAgent(ServiceAgent agent)
        {
            if (!_serviceAgents.Contains(agent)) return false;
            _serviceAgents.Remove(agent);
            return true;
        }
    }
    class CIA : Service
    {
        public CIA(string departamentName) : base(departamentName) { }

        public override Comment SetAgent(ServiceAgent agent)
        {
            if (_serviceAgents.Contains(agent)) { return Comment.UnableExist; }
            _serviceAgents.Add(agent);

            var message = agent.SetCIADepartament(this);

            if (message != Comment.Add)
            {
                _serviceAgents.Remove(agent);
                return message;
            }
            return message;
        }
        public Comment SetAgentWithoutVerefication(ServiceAgent agent)
        {
            if (_serviceAgents.Contains(agent)) { return Comment.UnableExist; }
            _serviceAgents.Add(agent);
            return Comment.Add;
        }

        public bool DeleteAgent(ServiceAgent agent)
        {
            if (!_serviceAgents.Contains(agent)) return false;
            _serviceAgents.Remove(agent);
            return true;
        }
    }
}
