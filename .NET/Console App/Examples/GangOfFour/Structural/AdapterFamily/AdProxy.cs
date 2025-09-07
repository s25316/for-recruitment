namespace GangOfFour.Structural.AdapterFamily
{
    public interface ITransactionService
    {
        void Send(string item);
        string Get(string id);
    }

    public interface ICacheMemoryService
    {
        void Send(string item);
        string Get(string id);
    }

    public class ProxyService(
        ITransactionService transactionService,
        ICacheMemoryService memoryService
        ) : ITransactionService
    {
        public string Get(string id)
        {
            var item = memoryService.Get(id);
            if (!string.IsNullOrWhiteSpace(item))
            {
                return item;
            }

            item = transactionService.Get(id);
            memoryService.Send(item);
            return item;
        }

        public void Send(string item)
        {
            memoryService.Send(item);
            transactionService.Send(item);
        }
    }

    // =======================================================================================================
    // =======================================================================================================
    // Lazy loading example
    public interface IFileService
    {
        string Get(int id);
    }

    public class FileService(string path) : IFileService
    {
        public string Get(int id) => "";
    }

    public class FileLazyLoadingProxyService(string path) : IFileService
    {
        public string Get(int id) => new FileService(path).Get(id);
    }
}
