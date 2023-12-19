namespace QuizApp.Repositories.Interfaces
{
    public interface IQuizRepository
    {
        void CreateQuiz(Quiz quiz);
        List<Quiz> GetQuizzes();
        Quiz GetQuizById(int id);
        void SaveAttempt(QuizAttempt attempt);
        List<QuizAttempt> GetQuizAttempts();
    }
}
