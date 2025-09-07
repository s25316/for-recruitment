namespace GangOfFour.Structural.AdapterFamily
{
    public interface IRepository1
    {
        void Stworz(string item);
        void Zaktualizuj(string item);
        void Usun(string item);
        string Pobierz(string id);
    }

    public interface IRepository2
    {
        void Add(string item);
        void Refresh(string item);
        void Remove(string item);
        string Get(string id);
    }

    public interface IAdapterRepository
    {
        void Create(string item);
        void Update(string item);
        void Delete(string item);
        string Select(string id);
    }

    public class AdapterRepository1(IRepository1 repository) : IAdapterRepository
    {
        public void Create(string item) => repository.Stworz(item);
        public void Update(string item) => repository.Zaktualizuj(item);
        public void Delete(string item) => repository.Usun(item);
        public string Select(string id) => repository.Pobierz(id);
    }

    public class AdapterRepository2(IRepository2 repository) : IAdapterRepository
    {
        public void Create(string item) => repository.Add(item);
        public void Update(string item) => repository.Refresh(item);
        public void Delete(string item) => repository.Remove(item);
        public string Select(string id) => repository.Get(id);
    }

    public class AdapterRepository3(IRepository2 repository) : AdapterRepository2(repository), IRepository2
    {
        public void Add(string item) => Create(item);
        public void Refresh(string item) => Update(item);
        public void Remove(string item) => Delete(item);
        public string Get(string id) => Select(id);
    }
}
