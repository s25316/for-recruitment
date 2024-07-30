using DataAdapter.FileUniversities.Models;

namespace DataAdapter.FileUniversities
{
    public class Universities
    {
        private readonly string _path;
        private readonly Dictionary<Guid, University> _dictionary = new ();

        public Universities(string path) { _path = path; }

        public bool IsFileExist() => File.Exists(_path);

        public async Task<Dictionary<Guid, University>> GetDictionaryAsync()
        {
            if (_dictionary.Count != 0) 
            { 
                return _dictionary;
            } 

            if (IsFileExist())
            {
                await using (FileStream fs = File.Open(
                       _path,
                       FileMode.Open,
                       FileAccess.Read,
                       FileShare.ReadWrite
               ))
                {
                    await using (BufferedStream bs = new BufferedStream(fs))
                    {
                        using (StreamReader sr = new StreamReader(bs))
                        {
                            string? str = sr.ReadLine();
                            while ((str = sr.ReadLine()) != null)
                            {
                                var university = (Models.University)str;
                                if (!_dictionary.ContainsKey(university.Id))
                                {
                                    _dictionary.Add(university.Id, university);
                                }
                            }
                        }
                    }
                }
            }
            return _dictionary;
        }
    }
}