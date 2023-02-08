namespace Практ_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo restartKey;
            do
            {
                Console.Clear();
                Console.WriteLine("Введите ваше имя:");
                string name = Console.ReadLine();
                User user = new User(name, 0, 0);

                InputTest test = new InputTest(user);
                test.ShowText();

                Console.SetCursorPosition(0, 4);
                Console.WriteLine("Нажмети Enter");
                ConsoleKeyInfo key = Console.ReadKey(true);
                while (key.Key != ConsoleKey.Enter)
                {
                    key = Console.ReadKey(true);
                }

                user = test.Test();
                ScoreTable.Add(user);
                ScoreTable.Show();
                Console.WriteLine("Чтобы начать заново нажмите Enter");
                restartKey = Console.ReadKey(true);
            } while (restartKey.Key == ConsoleKey.Enter);
        }
    }
}