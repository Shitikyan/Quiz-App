using Npgsql;

namespace QuizApp
{
    public interface IDbConnectionFactory
    {
        NpgsqlConnection CreateConnection();
    }
}
