using QuizApp.Repositories.Interfaces;

namespace QuizApp.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public QuizRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public void CreateQuiz(Quiz quiz)
        {
            using (var context = new QuizContext())
            {
                context.Quizzes.Add(quiz);
                context.SaveChanges();
            }
        }

        public List<Quiz> GetQuizzes()
        {
            using (var context = new QuizContext())
            {
                return context.Quizzes.ToList();
            }
        }

        public Quiz GetQuizById(int id)
        {
            using (var context = new QuizContext())
            {
                return context.Quizzes.Find(id);
            }
        }

        public void SaveAttempt(QuizAttempt attempt)
        {
            using (var context = new QuizContext())
            {
                context.QuizAttempts.Add(attempt);
                context.SaveChanges();
            }
        }

        public List<QuizAttempt> GetQuizAttempts()
        {
            using (var context = new QuizContext())
            {
                return context.QuizAttempts.ToList();
            }
        }
    }
}
