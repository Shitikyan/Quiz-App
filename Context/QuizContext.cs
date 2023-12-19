using Microsoft.EntityFrameworkCore;

namespace QuizApp
{
    public class QuizContext : DbContext
    {
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<QuizAttempt> QuizAttempts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=password;Database=QuizAppDb");
        }
    }
}
