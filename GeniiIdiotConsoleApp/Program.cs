namespace GeniiIdiotConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ваше имя пожалуйста.");
            var name = Console.ReadLine();
            do
            {
                var questions = ShuffleQuestion();
                var rightAnswersCount = 0;// переменные с маленькой буквы
                for (int i = 0; i < questions.Count; i++)
                {
                    Console.WriteLine("Номер вопроса: " + (i + 1));
                    foreach (var dict in questions[i])
                    {
                        Console.WriteLine(dict.Key);
                        var userAnswer = GetAnswer();
                        var rightAnswer = dict.Value;
                        if (userAnswer == rightAnswer)
                        {
                            rightAnswersCount++;
                        }
                    }
                }
                Console.WriteLine($"Количество правильных ответов: {rightAnswersCount}{Environment.NewLine}Ваш диагноз {name}: " + GetDiagnose(rightAnswersCount) + $"{Environment.NewLine}" + $"{name} не хотите ли вы сыграть снова? Ответьте да или нет?");// /n в некоторых системах

            }
            while (IsContinue());
        }
        public static List<Dictionary<string, int>> GetQA()//  теперь это метод с вопросами и ответами)))) может быть переименуем?)
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
        public static string GetDiagnose(int countRightAnswers)
        {
            var questions = GetQA();// зачем здесь снеова вытаскивать вопросы, это тарта памяти. В метода надо сразу передавать данные о количестве вопросов для расчета диагноза
            var percentage = (double)countRightAnswers * 100 / questions.Count;
            var diagnose = new string[6];
            diagnose[0] = "Идиот";
            diagnose[1] = "Кретин";
            diagnose[2] = "Дурак";
            diagnose[3] = "Нормально";
            diagnose[4] = "Талант";
            diagnose[5] = "Гений";

            // вот этот блок кода в отдельный метода расчета CalculateDiagnose, как пример
            switch (percentage)// не надо смешивать в одном методе диагнозы и рассчет диагноза. Это разные вещи, надо разделить и подумать как еще можной упростить расчет диагноза. ИИ лучше не использовать, она оставляет метки))))
            {
                case < 20: return diagnose[0];
                case >= 20 and < 40: return diagnose[1];
                case >= 40 and < 60: return diagnose[2];
                case >= 60 and < 80: return diagnose[3];
                case >= 80 and < 100: return diagnose[4];
                case >= 100: return diagnose[5];
                default:
                    return "Mistake";// это слов здесь не очень. Как минимум оно должно быть на русском и чтот обозначать при дефолтном значении
            }
            ;
            //
        }
        public static List<Dictionary<string, int>> ShuffleQuestion()
        {
            Random rand = new Random();
            var result = GetQA();
            for (int i = result.Count - 1; i >= 0; i--)
            {
                int j = rand.Next(0, i);// var
                var temp = result[j];
                result[j] = result[i];
                result[i] = temp;
            }
            return result;
        }
        public static bool IsContinue()
        {
            while (true)
            {
                string answer = Console.ReadLine().ToLower().Trim();
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
            while (true)
            {
                string answer = Console.ReadLine();
                if (int.TryParse(answer, out int result))
                {
                    return result;
                }
                Console.WriteLine("Некорректный ввод. Введите число.");
            }
        }

    }
}