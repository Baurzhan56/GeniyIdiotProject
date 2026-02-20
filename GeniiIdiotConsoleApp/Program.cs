namespace GeniiIdiotConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // radipraktiki
            var diagnoses = GetDiagnose();
            var questions = GetQA();
            var userAnswer = 0;
            var rightAnswersCount = 0;
            var rightAnswer = 0;
            var each = new KeyValuePair<string, int>();
            Console.WriteLine("Введите ваше имя пожалуйста.");
            var name = Console.ReadLine();
            do
            {
                ShuffleQuestion(questions);
                rightAnswersCount = 0;// переменные с маленькой буквы
                for (int i = 0; i < questions.Count; i++)
                {
                    Console.WriteLine("Номер вопроса: " + (i + 1));
                    each = questions[i].Single();
                    Console.WriteLine(each.Key);
                    userAnswer = GetAnswer();
                    rightAnswer = each.Value;
                    if (userAnswer == rightAnswer)
                    {
                        rightAnswersCount++;
                    }
                }
                Console.WriteLine($"Количество правильных ответов: {rightAnswersCount}{Environment.NewLine}Ваш диагноз {name}: " + diagnoses[CalculateDiagnose(rightAnswersCount, questions.Count)] + $"{Environment.NewLine}" + $"{name} не хотите ли вы сыграть снова? Ответьте да или нет?");

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
        public static string[] GetDiagnose()
        {
            // зачем здесь снеова вытаскивать вопросы, это тарта памяти. В метода надо сразу передавать данные о количестве вопросов для расчета диагноза
            var diagnose = new string[6];
            diagnose[0] = "Идиот";
            diagnose[1] = "Кретин";
            diagnose[2] = "Дурак";
            diagnose[3] = "Нормально";
            diagnose[4] = "Талант";
            diagnose[5] = "Гений";
            return diagnose;
        }
        public static int CalculateDiagnose(int countRightAnswers, int overall)
        {
            // вот этот блок кода в отдельный метода расчета CalculateDiagnose, как пример
            var percentage =(double)countRightAnswers * 100 / overall;
            switch (percentage)// не надо смешивать в одном методе диагнозы и рассчет диагноза. Это разные вещи, надо разделить и подумать как еще можной упростить расчет диагноза. ИИ лучше не использовать, она оставляет метки))))
            {
                case < 20: return 0;
                case >= 20 and < 40: return 1;
                case >= 40 and < 60: return 2;
                case >= 60 and < 80: return 3;
                case >= 80 and < 100: return 4;
                case >= 100: return 5;
                default:
                    throw new Exception("Ошибка в расчетах процентажа.");// это слов здесь не очень. Как минимум оно должно быть на русском и чтот обозначать при дефолтном значении
            }
        }
        public static List<Dictionary<string, int>> ShuffleQuestion(List<Dictionary<string,int>> result)
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