namespace GangOfFour.Structural.AdapterFamily
{
    public interface IGodObject
    {
        void CreateUser(string item);
        void UpdateUser(string item);
        void DeleteUser(string item);
        string GetUser(string id);

        void CreateCompany(string item);
        void UpdateCompany(string item);
        void DeleteCompany(string item);
        string GetCompany(string id);
    }

    public interface IFacade
    {
        void Create(string item);
        void Update(string item);
        void Delete(string item);
        string Get(string id);
    }

    public class UserRepository(IGodObject godObject) : IFacade
    {
        public void Create(string item) => godObject.CreateUser(item);
        public void Update(string item) => godObject.UpdateUser(item);
        public void Delete(string item) => godObject.DeleteUser(item);
        public string Get(string id) => godObject.GetUser(id);
    }
}
