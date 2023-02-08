using Newtonsoft.Json;

namespace Практ_8
{
    internal class ScoreTable
    {
        public static void Add(User user)
        {
            List<User> users = null;
            if (File.Exists("D:\\scoretable.txt"))
            {
                string json = File.ReadAllText("D:\\scoretable.txt");
                users = JsonConvert.DeserializeObject<List<User>>(json);
            }
            if (users != null)
            {
                foreach(User u in users)
                {
                    if (u.name == user.name)
                    {
                        users.Remove(u);
                        break;
                    }
                }
                users.Add(user);
            }
            else
            {
                users = new List<User>();
                users.Add(user);
            }
            string newJson = JsonConvert.SerializeObject(users);
            File.WriteAllText("D:\\scoretable.txt", newJson);
        }

        public static void Show()
        {
            Console.Clear();
            string json = File.ReadAllText("D:\\scoretable.txt");
            var users = JsonConvert.DeserializeObject<List<User>>(json);
            if (users == null)
            {
                users = new List<User>();
            }
            Console.WriteLine("Таблица рекордов");
            foreach (User user in users)
            {
                double perMinute = Math.Round(user.symbolsPerMinute, 2);
                double perSecond = Math.Round(user.symbolsPerSecond, 2);
                Console.WriteLine($"{user.name} | В минуту: {perMinute} | В секунду: {perSecond}");
            }
        }
    }
}
