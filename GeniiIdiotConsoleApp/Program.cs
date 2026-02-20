namespace GeniiIdiotConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var questions = GetQuestionAnswer();
            var userAnswer = 0;
            var rightAnswersCount = 0;
            var rightAnswer = 0;
            var questionAnswerPair = new KeyValuePair<string, int>();// название перменной совсем никуда, надо более понятное название дать
            // необходимо приучать себя давать навзания перменным правильные, даже самым незначительным, так лучше руку на этом нарабатыватьь
            Console.WriteLine("Введите ваше имя пожалуйста.");
            var name = Console.ReadLine();
            do
            {
                ShuffleQuestion(questions);
                rightAnswersCount = 0;
                for (int i = 0; i < questions.Count; i++)
                {
                    Console.WriteLine("Номер вопроса: " + (i + 1));
                    questionAnswerPair = questions[i].Single();
                    Console.WriteLine(questionAnswerPair.Key);
                    userAnswer = GetAnswer();
                    rightAnswer = questionAnswerPair.Value;
                    if (userAnswer == rightAnswer)
                    {
                        rightAnswersCount++;
                    }
                }
                Console.WriteLine($"Количество правильных ответов: {rightAnswersCount}{Environment.NewLine}Ваш диагноз {name}: " + CalculateDiagnose(rightAnswersCount, questions.Count) + $"{Environment.NewLine}" + $"{name} не хотите ли вы сыграть снова? Ответьте да или нет?");

            }
            while (IsContinue());
        }
        public static List<Dictionary<string, int>> GetQuestionAnswer()// GetQuestionAnaswer
        {
            var answer1 = new Dictionary<string, int> { { "Сколько будет два плюс два умноженное на два?", 6 } };
            var answer2 = new Dictionary<string, int> { { "Бревно нужно распилить на 10 частей , сколько надо сделать надпилов?", 9 } };
            var answer3 = new Dictionary<string, int> { { "На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25 } };
            var answer4 = new Dictionary<string, int> { { "Укол делают каждые полчаса, сколько нужно минут для трёх уколов?", 60 } };
            var answer5 = new Dictionary<string, int> { { "Пять свечей горело, две потухли. Сколько свечей осталось?", 2 } };
            var answers = new List<Dictionary<string, int>>{
            answer1,answer2,answer3,answer4,answer5};
            return answers;
        }
        public static string CalculateDiagnose(int countRightAnswers, int overall)
        {

            var percentage = (double)countRightAnswers * 100 / overall;
            switch (percentage)
            {
                case < 20: return "Идиот";
                case >= 20 and < 40: return "Кретин";// а если здесь вметос чисел возвращать сразу навзание диагноза, это же скоратит наш код и сделает его лаконичным и меньше на один метод))нет
                case >= 40 and < 60: return "Дурак";
                case >= 60 and < 80: return "Нормально";
                case >= 80 and < 100: return "Талант";
                case >= 100: return "Гений";
                default:
                    return "Гений";// не надо писать здесь исключение, это отрубит работу программы. Можен же просто написать 
                                                                         //case < 20: return 0;
                                                                         //case >= 20 and < 40: return 1;
                                                                         //case >= 40 and < 60: return 2;
                                                                         //case >= 60 and < 80: return 3;
                                                                         //case >= 80 and < 100: return 4;               
                                                                         //default: return 5;
            }
        }
        public static List<Dictionary<string, int>> ShuffleQuestion(List<Dictionary<string, int>> result)
        {
            Random rand = new Random();
            for (int i = result.Count - 1; i >= 0; i--)
            {
                var j = rand.Next(0, i);// var
                var temp = result[j];
                result[j] = result[i];
                result[i] = temp;
            }
            return result;
        }
        public static bool IsContinue()
        {
            var answer = "продолжаем?";
            while (true)
            {
                answer = Console.ReadLine().ToLower().Trim();
                switch (answer)
                {
                    case "да": return true;
                    case "нет": return false;
                    default:
                        Console.WriteLine("Некорректный ответ.Попробуйте ещё раз ввести ответ. Да или Нет?");
                        break;
                }
            }
        }
        public static int GetAnswer()
        {
            var answer = "должен ввести число";
            while (true)
            {
                answer = Console.ReadLine();
                if (int.TryParse(answer, out int result))
                {
                    return result;
                }
                Console.WriteLine("Некорректный ввод. Введите число.");
            }
        }

    }
}