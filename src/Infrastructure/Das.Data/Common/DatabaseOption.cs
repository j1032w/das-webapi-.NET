namespace Das.Data.Common
{
    public class DatabaseOption
    {
        public const string DatabaseConfigureSection = "Database";

        public string ConnectionString { get; set; } = "";
        public string DatabaseType { get; set; } = "Oracle";
    }
}
