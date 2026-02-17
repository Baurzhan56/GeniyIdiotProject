namespace GeniiIdiotConsoleApp
{
    class Program// надо пока оставить название ка есть Program. Что выходит из текущего навзания, что класс содержит смешанные вопросы, а по факту...? А по факту,
                     // здесь вся логика игры. Такое название неверное.
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ваше имя пожалуйста.");
            var name = Console.ReadLine();
            do
            {
                ShuffleQuestion(out string[] questions, out int[] answers);
                var RightAnswersCount = 0;// в навзании перменной главное слово  в конце, здесь главное слово количество
                for (int i = 0; i < questions.Length; i++)
                {
                    Console.WriteLine("Номер вопроса: " + (i + 1));
                    Console.WriteLine(questions[i]);
                    var userAnswer = GetAnswer();
                    var rightAnswer = answers[i];
                    if (userAnswer == rightAnswer)
                    {
                        RightAnswersCount++;
                    }
                }
                Console.WriteLine($"Количество правильных ответов: {RightAnswersCount}{Environment.NewLine}Ваш диагноз {name}: " + GetDiagnose(RightAnswersCount) + $"{Environment.NewLine}" + $"{name} не хотите ли вы сыграть снова? Ответьте да или нет?");// /n в некоторых системах
                // работает некорректно. Как сделать более правильные перенос на новую строку.
            }
            while (IsContinue());
        }
        public static string[] GetQuestions()// все методы с модификаторами!!! Как думаете, если мы ответы привяжем к вопросам, нам уже не надо будет все пермешивать и ответы и вопросы? Это доп задание!
        {
            var questions = new string[5];
            questions[0] = "Сколько будет два плюс два умноженное на два?";
            questions[1] = "Бревно нужно распилить на 10 частей , сколько надо сделать надпилов?";
            questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые полчаса, сколько нужно минут для трёх уколов?";
            questions[4] = "Пять свечей горело, две потухли. Сколько свечей осталось?";
            return questions;
        }
        public static int[] GetAnswers()// все методы с модификаторами!!! Попробуем объединить с вопросами
        {
            var answers = new int[5];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;
            return answers;
        }
        public static string GetDiagnose(int countRightAnswers)// все методы с модификаторами!!!
        {
            var questions = GetQuestions();
            var percentage = (double)countRightAnswers * 100 / questions.Length;// var
            var diagnose = new string[6];
            diagnose[0] = "Идиот";
            diagnose[1] = "Кретин";
            diagnose[2] = "Дурак";
            diagnose[3] = "Нормально";
            diagnose[4] = "Талант";
            diagnose[5] = "Гений";
            switch (percentage)// не надо смешивать в одном методе диагнозы и рассчет диагноза. Это разные вещи, надо разделить и подумать как еще можной упростить расчет диагноза. ИИ лучше не использовать, она оставляет метки))))
            {
                case < 20: return diagnose[0];
                case >= 20 and < 40: return diagnose[1];
                case >= 40 and < 60: return diagnose[2];
                case >= 60 and < 80: return diagnose[3];
                case >= 80 and < 100: return diagnose[4];
                case >= 100: return diagnose[5];
                default:
                    return "Mistake";
            }
            ;
        }
        public static void ShuffleQuestion(out string[] questions, out int[] answers)// все методы с модификаторами!!! Название метода не очень ShuffleQuestions
        {
            Random rand = new Random();
            questions = GetQuestions();
            answers = GetAnswers();
            string temporaryString;
            int temporaryInt = 0;

            for (int i = questions.Length - 1; i > 0; i--)
            {
                int j = rand.Next(0, i);
                temporaryString = questions[j];
                questions[j] = questions[i];
                questions[i] = temporaryString;

                temporaryInt = answers[j];
                answers[j] = answers[i];
                answers[i] = temporaryInt;
            }
        }
        public static bool IsContinue()// все методы с модификаторами!!! Навзание метода не очень IsContinue. 
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
        public static int GetAnswer() // все методы с модификаторами!!! Мы же здесь GetAnswer делаем, просто пытаемся получить ответ
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