using DataAdapter.FileAdministrativeDivisions.AsInFile.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAdapter.FileAdministrativeDivisions.AsInFile.Repositories
{
    public class TercReader
    {
        private readonly string _path;
        private readonly List<Terc> _list = new List<Terc>();

        public TercReader(string path ) { _path = path; }

        public bool IsFileExist() => File.Exists(_path);

        public async Task<List<Terc>> GetListAsync()
        {
            if (_list.Count() != 0) { return _list; }

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
                                    var terc = (Terc)(str);
                                    _list.Add(terc);
                                }
                            }
                        }
                    }
                }
            }
            return _list;
        }
    }
}