using Microsoft.Extensions.DependencyInjection;
using QuizApp.Services;
using QuizApp.Services.Interfaces;
using QuizApp.Repositories;
using QuizApp.Repositories.Interfaces;

namespace QuizApp
{
    public class Program
    {
        static void Main()
        {
            var serviceProvider = ConfigureServices();
            var quizService = serviceProvider.GetService<IQuizService>();

            while (true)
            {
                Console.WriteLine("1. Create Quiz");
                Console.WriteLine("2. Take Quiz");
                Console.WriteLine("3. View Scores");
                Console.WriteLine("4. Exit");

                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        quizService.CreateQuiz();
                        break;

                    case "2":
                        quizService.TakeQuiz();
                        break;

                    case "3":
                        quizService.ViewScores();
                        break;

                    case "4":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IDbConnectionFactory, DbConnectionFactory>()
                .AddSingleton<IQuizRepository, QuizRepository>()
                .AddSingleton<IQuizService, QuizService>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
