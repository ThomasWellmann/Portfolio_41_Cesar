namespace VektorMathematik
{
    internal abstract class Screen
    {
        private static readonly int textMargin = 3;

        public abstract Screen Start();

        protected void ResizeWindow(int _width = 100, int _height = 40)
        {
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(_width, _height);
            Console.SetBufferSize(_width, 1000);
        }

        protected static ConsoleKeyInfo ReadKey(bool _intercept = false)
        {
            TextMargin();
            var keyInput = Console.ReadKey(_intercept);
            return keyInput;
        }

        protected static string ReadLine()
        {
            TextMargin();
            var lineInput = Console.ReadLine();
            return lineInput;
        }

        protected static void TextMargin(int _offset = 0)
        {
            Console.SetCursorPosition(textMargin, Console.GetCursorPosition().Top + _offset);
        }
        protected static void PrintText(string _text, int _offSet = 0) //WriteLine with sidespace
        {
            TextMargin(_offSet);
            Console.WriteLine(_text);
        }

        protected static void GetTextSpacements()
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------------------------------------------------------");
            Console.WriteLine();
        }
    }
}
