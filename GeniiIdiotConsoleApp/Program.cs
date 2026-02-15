using System.Data;
using System.Security.Cryptography;

namespace GeniiIdiotConsoleApp
{
    class Program
    {
        static string[] GetQuestions(int countQuestion)
        {
            string[] questions = new string[countQuestion];
            questions[0] = "Сколько будет два плюс два умноженное на два?";
            questions[1] = "Бревно нужно распилить на 10 частей , сколько надо сделать надпилов?";
            questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса, сколько нужно минут для трёх уколов?";
            questions[4] = "Пять свечей горело, две потухли. Сколько свечей осталось?";
            return questions;
        }
        static int[] GetAnswers(int countQuestion)
        {   
            int[] answers = new int[countQuestion];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;
            return answers;
        }
        static string GetDiagnose(int countRightAnswers)
        {

            string[] diagnose = new string[6];
            diagnose[0] = "Идиот";
            diagnose[1] = "Кретин";
            diagnose[2] = "Дурак";
            diagnose[3] = "Нормально";
            diagnose[4] = "Талант";
            diagnose[5] = "Гений";
            return diagnose[countRightAnswers];
        }
        public class RandomClass
        {
            public static Random rand = new Random();
            public static List<int> List = new List<int>();
            public static int RandomNumb(int count)
            {
                int random = 0;
                do
                {
                    random = rand.Next(0, count);
                }
                while (List.Contains(random));
                List.Add(random);
                return random;
            }
            public static void Clear()
            {
                List.Clear();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ваше имя пожалуйста.");
            string name = Console.ReadLine();
            int countQuestion = 5;
            string[] questions = GetQuestions(countQuestion);
            int[] answers = GetAnswers(countQuestion);
            RandomClass randomClass = new RandomClass();
            string Repeat = string.Empty;
            do
            {
                int countRightAnswers = 0;
                RandomClass.Clear();
                for (int i = 0; i < countQuestion; i++)
                {
                    int random = RandomClass.RandomNumb(countQuestion);
                    Console.WriteLine("Номер вопроса: " + (i + 1));
                    Console.WriteLine(questions[random]);
                    int userAnswer = Convert.ToInt32(Console.ReadLine());
                    int rightAnswer = answers[random];
                    if (userAnswer == rightAnswer)
                    {
                        countRightAnswers++;
                    }

                }
                Console.WriteLine($"Количество правильных ответов: {countRightAnswers}\nВаш диагноз {name}: " + GetDiagnose(countRightAnswers));
                Console.WriteLine($"{name} не хотите ли вы сыграть снова? Ответьте да или нет.");
                Repeat = Console.ReadLine();
            } while (Repeat.ToLower() == "да");
        }
    }
}