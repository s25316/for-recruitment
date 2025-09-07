namespace GangOfFour.Templates
{
    public interface IRepository { }
    public class MsSqlRepository(string ConnectionString) : IRepository { }
    public class MongoDbRepository(string ConnectionString, string Collection) : IRepository { }


    public interface IConfiguration<in TRepository> where TRepository : IRepository;
    public record MsSqlConfiguration(string ConnectionString) : IConfiguration<MsSqlRepository>;
    public record MongoDbConfiguration(string ConnectionString, string Collection) : IConfiguration<MongoDbRepository>;


    public static class Factory
    {
        public static IRepository Create(IConfiguration<IRepository> configuration)
        {
            return configuration switch
            {
                MsSqlConfiguration config => new MsSqlRepository(config.ConnectionString),
                MongoDbConfiguration config => new MongoDbRepository(config.ConnectionString, config.Collection),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
