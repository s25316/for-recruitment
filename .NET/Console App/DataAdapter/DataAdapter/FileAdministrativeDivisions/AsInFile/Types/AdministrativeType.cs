
namespace DataAdapter.FileAdministrativeDivisions.AsInFile.Types
{
    public class AdministrativeType
    {
        private static Dictionary<int, AdministrativeType> _dictionary = new ();
        private static int _idCounter = 1;

        public int Id { get; private set; }
        public string Name { get; set; } = null!;

        public AdministrativeType(string name)
        {
            bool isExistValueByThisName = false;
            foreach (var kvp in _dictionary) 
            {
                if (kvp.Value.Name == name) 
                { 
                    isExistValueByThisName = true; 
                    break;
                }
            }
            if (!isExistValueByThisName) 
            {
                Id = _idCounter++;
                Name = name;
                _dictionary.Add(Id, this);
            }            
        }
        public AdministrativeType() 
        {
            if (_dictionary.Count == 0) 
            {
                var list = new List<string>()
                    {
                         "województwo", "powiat", "miasto na prawach powiatu",
                         "gmina miejska", "gmina wiejska", "gmina miejsko-wiejska","obszar wiejski",

                         "miasto", "dzielnica", "delegatura",
                         "część miasta", "schronisko turystyczne", "osiedle"/*not exist*/,
                         "osada leśna", "osada", "przysiółek", "kolonia", "wieś", "część miejscowości",

                          "ul.", "pl.", "rondo","os.", "skwer", "al.", "park", "droga","rynek","bulw.",
                          "wyspa",  "wyb.","ogród"
                    };
                for (int i = 0; i < list.Count; i++)
                {
                    new AdministrativeType(list[i]);
                }
            }
        }

        public Dictionary<int, AdministrativeType> GetDictionary()
        {
            if (_dictionary.Count == 0) { new AdministrativeType(); }
            return _dictionary;
        }

        public AdministrativeType GetAdministrativeType(string name)
        {
            if (_dictionary.Count == 0) { new AdministrativeType(); }
            foreach (var item in _dictionary)
            {
                if (item.Value.Name == name)
                {
                    return item.Value;
                }
            }
            throw new NotImplementedException($"Not Implemented {name} in class AdministrativeTypeList");
        }
        public override string ToString() => $"[{Id}] {Name}";
    }
}
