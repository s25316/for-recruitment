using GoF.Structural.AdapterFamily.Proxy.InitializationOption2.Interfaces;

namespace GoF.Structural.AdapterFamily.Proxy.InitializationOption2.Entities
{
    public class ServerFileProxy : IServerFile
    {
        // Properties
        private readonly string _path;
        private ServerFile? _file = null;

        // Constructor
        public ServerFileProxy(string path)
        {
            _path = path;
        }

        // Methods
        /// <summary>
        /// Get files with lazy Loading
        /// </summary>
        public void GetFile()
        {
            _file = new ServerFile(_path);
            _file.GetFile();
        }
    }
}
