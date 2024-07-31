namespace Sortier_Algorithmen
{
    internal class Sorting : Screen
    {
        SortingAlgorithm algorithm;
        int deltaTime;
        string sorting;
        public int[] unsorted;

        public Sorting(List<int> _list)
        {
            unsorted = _list.ToArray();
            algorithm = new SortingAlgorithm(_list);
        }

        public override Screen Start()
        {
            ClearConsole();

            Print($"Your List (size: {algorithm.list.Count}):");
            PrintList(algorithm.list);
            GetTextSpacements();

            return GetWishedSortMethod();
        }

        void GetSortingTime(int _sort)
        {
            deltaTime = 0;
            int time1 = DateTime.Now.Millisecond * 1000 + DateTime.Now.Microsecond;
            algorithm.Sort(_sort);
            int time2 = DateTime.Now.Millisecond * 1000 + DateTime.Now.Microsecond;
            deltaTime = time2 - time1;
        }

        Screen GetWishedSortMethod()
        {
            Print("Now choose with wich algorithm you want to sort your list:");
            Print("(", "1", ") Sequential Sort");
            Print("(", "2", ") Bubble Sort");
            Print("(", "3", ") Insertion Sort");
            Print("(", "4", ") Heap Sort\n\n");

            while (true)
            {
                var key = ReadKey(true);
                if (key.Key == ConsoleKey.D1)
                {
                    sorting = "sequential-sorting";
                    GetSortingTime(1);
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    sorting = "bubble-sorting";
                    GetSortingTime(2);
                }
                else if (key.Key == ConsoleKey.D3)
                {
                    sorting = "insertion-sorting";
                    GetSortingTime(3);
                }
                else if (key.Key == ConsoleKey.D4)
                {
                    sorting = "heap-sorting";
                    GetSortingTime(4);
                }
                else continue;
                break;
            }
            Print($"Your list used the {sorting} algorithm (time to sort: {deltaTime}µs):");
            PrintList(algorithm.list);

            Print("Press ", "Enter", " to continue or ", "Space", " to try again.");
            Print("Press ", "ESC", " restart the program.");

            while (true)
            {
                var key = ReadKey(true);
                if (key.Key == ConsoleKey.Enter) return new Showing(algorithm);
                else if (key.Key == ConsoleKey.Spacebar) return new Sorting(unsorted.ToList());
                else if (key.Key == ConsoleKey.Escape) return new Lobby();
            }
        }
    }
}
