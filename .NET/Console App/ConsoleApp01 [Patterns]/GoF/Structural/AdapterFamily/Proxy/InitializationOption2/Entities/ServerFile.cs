using GoF.Structural.AdapterFamily.Proxy.InitializationOption2.Interfaces;

namespace GoF.Structural.AdapterFamily.Proxy.InitializationOption2.Entities
{
    public class ServerFile : IServerFile
    {
        // Properties
        private readonly string _path;


        // Constructor
        public ServerFile(string path)
        {
            _path = path;
            Load();
        }


        // Methods
        public void Load()
        {
            Console.WriteLine($"Loading file from server: {_path}");
        }

        public void GetFile()
        {
            Console.WriteLine($"Getting file: {_path}");
        }
    }
}
