using QuizApp.Services.Interfaces;
using QuizApp.Repositories.Interfaces;

namespace QuizApp.Services
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;

        public QuizService(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public void CreateQuiz()
        {
            Console.Write("Enter the question: ");
            string question = Console.ReadLine();

            Console.Write("Enter the number of options: ");
            int numOptions = int.Parse(Console.ReadLine());

            List<string> options = new List<string>();
            for (int i = 1; i <= numOptions; i++)
            {
                Console.Write($"Enter option {i}: ");
                options.Add(Console.ReadLine());
            }

            Console.Write("Enter the correct answer: ");
            string correctAnswer = Console.ReadLine();

            var quiz = new Quiz { Question = question, Options = options, CorrectAnswer = correctAnswer };

            _quizRepository.CreateQuiz(quiz);

            Console.WriteLine("Quiz created successfully!");
        }

        public void TakeQuiz()
        {
            Console.WriteLine("Available Quizzes:");

            var quizzes = _quizRepository.GetQuizzes();

            foreach (var quiz in quizzes)
            {
                Console.WriteLine($"ID: {quiz.Id}, Question: {quiz.Question}");
            }

            Console.Write("Enter the quiz ID: ");
            int quizId = int.Parse(Console.ReadLine());

            var selectedQuiz = _quizRepository.GetQuizById(quizId);

            if (selectedQuiz != null)
            {
                Console.WriteLine($"Question: {selectedQuiz.Question}");

                foreach (var option in selectedQuiz.Options)
                {
                    Console.WriteLine(option);
                }

                Console.Write("Your answer: ");
                string userAnswer = Console.ReadLine();

                var attempt = new QuizAttempt { QuizId = quizId, UserAnswer = userAnswer, Score = (userAnswer == selectedQuiz.CorrectAnswer) ? 1 : 0 };

                _quizRepository.SaveAttempt(attempt);

                Console.WriteLine($"Your score: {attempt.Score}");
            }
            else
            {
                Console.WriteLine("Quiz not found.");
            }
        }

        public void ViewScores()
        {
            Console.WriteLine("Quiz Scores:");

            var quizAttempts = _quizRepository.GetQuizAttempts();

            foreach (var attempt in quizAttempts)
            {
                Console.WriteLine($"Attempt ID: {attempt.Id}, Quiz ID: {attempt.QuizId}, User Answer: {attempt.UserAnswer}, Score: {attempt.Score}");
            }
        }
    }
}
