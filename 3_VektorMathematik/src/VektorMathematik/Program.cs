namespace VektorMathematik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Screen screen = new Lobby();
            do
            {
                screen = screen.Start();
            } while (screen != null);
        }
    }
}
