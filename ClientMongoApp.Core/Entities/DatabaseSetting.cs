namespace ClientMongoApp.Core.Entities
{
    public record DatabaseSetting(string ConnectionString = null!, string DatabaseName = null!);
}
