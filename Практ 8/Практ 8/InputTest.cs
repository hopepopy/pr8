using System.Diagnostics;

namespace Практ_8
{
    internal class InputTest
    {
        private string text = "Это просто тестовый текст для проверки работы программы.";
        private User user;
        private int symbol;
        private Stopwatch timer;

        public InputTest(User user)
        {
            this.user = user;
            this.timer = new Stopwatch();
        }

        public void ShowText()
        {
            Console.Clear();
            Console.WriteLine(text);
        }

        public User Test()
        { 
            Thread timerThread = new Thread(_ => StartTimer());
            Console.SetCursorPosition(0, 4);
            Console.WriteLine("Осталось секунд:");

            symbol = 0;
            ConsoleKeyInfo key;
            Console.SetCursorPosition(0, 0);
            timerThread.Start();
            while (symbol != text.Length && timerThread.IsAlive)
            {
                key = Console.ReadKey(true);
                if (key.KeyChar == text[symbol])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(text[symbol]);
                    Console.ResetColor();
                    symbol++;
                }
            }
            timer.Stop();

            user.symbolsPerMinute = symbol / timer.Elapsed.TotalMinutes;
            user.symbolsPerSecond = symbol / timer.Elapsed.TotalSeconds;

            return user;
        }

        private void StartTimer()
        {
            timer.Start();
            while (timer.Elapsed.TotalSeconds < 60 && timer.IsRunning)
            {
                int left = Console.CursorLeft;
                int top = Console.CursorTop;
                Console.SetCursorPosition(0, 5);
                int remain = Convert.ToInt32(60 - timer.Elapsed.TotalSeconds);
                Console.WriteLine($"{remain}");
                Console.SetCursorPosition(left, top);
                Thread.Sleep(1000);
            }
            timer.Stop();
        }
    }
}
