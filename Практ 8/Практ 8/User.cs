namespace Практ_8
{
    internal class User
    {
        public string name;
        public double symbolsPerMinute;
        public double symbolsPerSecond;

        public User(string name, float symbolsPerMinute, float symbolsPerSecond)
        {
            this.name = name;
            this.symbolsPerMinute = symbolsPerMinute;
            this.symbolsPerSecond = symbolsPerSecond;
        }
    }
}
