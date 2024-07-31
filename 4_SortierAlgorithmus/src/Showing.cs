using System.Security.Authentication.ExtendedProtection;

namespace Sortier_Algorithmen
{
    internal class Showing : Screen
    {
        SortingAlgorithm algorithm;
        string shownAs = "sorted";
        int sortAlgorithm;

        public Showing(SortingAlgorithm _algorithm)
        {
            algorithm = _algorithm;
        }

        public override Screen Start()
        {
            ClearConsole();
            Print($"Your List (size: {list.Count}):");
            PrintList(algorithm.list);
            GetTextSpacements();

            return GetWishedShowMethod();
        }

        Screen GetWishedShowMethod()
        {
            Print($"Your list is shown as {shownAs}.");
            Print($"Your can change how your list is shown, add another number as it is or shuffle it.");

            Print("(", "1", ") Add new number (max list size: 75)");
            Print("(", "2", ") Increscent");
            Print("(", "3", ") Decrescent");
            Print("(", "4", ") Zig-Zag");
            Print("(", "5", "/", "ESC", ") Shuffle and re-sort\n\n");

            while (true)
            {
                var toAdd = -1;
                var key = ReadKey(true);
                if (key.Key == ConsoleKey.D1)
                {
                    if (algorithm.list.Count < 75)
                    {
                        Print("Type below the number you want to add (0-999).");
                        while (true)
                        {
                            var input = ReadLine();
                            input = Check0Value(input) ? "0" : input; //Field empty -> value = 0
                            if (int.TryParse(input, out toAdd) && toAdd >= 0 && toAdd < 1000) //Min number 0 //Max number 999 
                            {
                                Console.WriteLine();
                                algorithm.Add(toAdd, shownAs);
                                break;
                            }
                            ClearLine(input.Length);
                        }
                    }
                    else
                    {
                        Print("This action is not possible because your list is already too long!");
                        break;
                    }
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    shownAs = "increscent";
                    algorithm.Increscent();
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    shownAs = "decrescent";
                    algorithm.Decrescent();
                }
                else if (key.Key == ConsoleKey.D4)
                {
                    shownAs = "zig-zag'ed";
                    algorithm.ZigZag();
                }
                else if (key.Key == ConsoleKey.D5 || key.Key == ConsoleKey.Escape)
                {
                    shownAs = "shuffled";
                    algorithm.Shuffle();
                    return new Sorting(algorithm.list);
                }
                else continue;
                Print((key.Key != ConsoleKey.D1) ? $"Your list got sorted and the numbers on it are {shownAs}:" : $"{toAdd} got added and your list now look like this:");
                PrintList(algorithm.list);
                break;
            }
            Print("Press ", "Enter", " to continue or ", "ESC", " restart the program.");

            while (true)
            {
                var key = ReadKey(true);
                if (key.Key == ConsoleKey.Enter) return this;
                else if (key.Key == ConsoleKey.Escape) return new Lobby();
            }
        }
    }
}
