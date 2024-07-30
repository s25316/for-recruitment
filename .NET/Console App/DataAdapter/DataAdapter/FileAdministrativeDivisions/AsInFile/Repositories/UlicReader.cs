using DataAdapter.FileAdministrativeDivisions.AsInFile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAdapter.FileAdministrativeDivisions.AsInFile.Repositories
{
    public class UlicReader
    {
        private readonly string _path;
        private readonly Dictionary<int, Ulic> _dictionary = new();

        public UlicReader(string path) { _path = path; }

        public bool IsFileExist() => File.Exists(_path);

        public async Task<Dictionary<int, Ulic>> GetDictionaryAsync()
        {
            if (_dictionary.Count() != 0)
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
                                if (!string.IsNullOrEmpty(str))
                                {
                                    var ulica = (Ulic)(str);
                                    if (!_dictionary.ContainsKey(ulica.SymUl))
                                    {
                                        _dictionary.Add(ulica.SymUl, ulica);
                                    }
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
