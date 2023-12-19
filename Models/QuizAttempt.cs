namespace QuizApp
{
    public class QuizAttempt
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public string UserAnswer { get; set; }
        public int Score { get; set; }
    }
}
