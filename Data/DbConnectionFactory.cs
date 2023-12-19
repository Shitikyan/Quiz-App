using Npgsql;

namespace QuizApp
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private const string ConnectionString = "Host=localhost;Port=5432;Username=postgres;Password=password;Database=QuizAppDb";

        public NpgsqlConnection CreateConnection()
        {
            return new NpgsqlConnection(ConnectionString);
        }
    }
}
