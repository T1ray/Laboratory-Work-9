namespace Lab9_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            void TextSeparator() => UserInterface.TextSeparator();
            while (true)
            {
                Console.WriteLine("Выберите часть, которую хотите вывести\n" +
                                  "1. Часть 1\n" +
                                  "2. Часть 2\n" +
                                  "3. Часть 3");
                input = Console.ReadLine();
                Console.Clear();
                switch (input)
                {
                    case "1":
                    {
                        UserInterface.Part1();
                        break;
                    }
                    case "2":
                    {
                        UserInterface.Part2();
                        break;
                    }
                    case "3":
                    {
                        UserInterface.Part3();
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Команда не найдена!");
                        break;
                    }
                }
                TextSeparator();
            }
        }
    }
}