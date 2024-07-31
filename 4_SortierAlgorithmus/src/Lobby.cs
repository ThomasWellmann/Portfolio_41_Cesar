namespace Sortier_Algorithmen
{
    internal class Lobby : Screen
    {
        public override Screen Start()
        {
            list = new List<int>();
            ResizeWindow();
            SetDefaultColors();
            ClearConsole();
            Console.CursorVisible = false;

            Print($"Welcome to the Algorithm-Sorting-System!\n");
            GetWishedStartingList(); //Random or Input

            Print("Press ", "Enter", " to continue or ", "ESC", " restart the program.");

            while (true)
            {
                var key = ReadKey(true);
                if (key.Key == ConsoleKey.Escape) return new Lobby(); //Restart
                else if (key.Key == ConsoleKey.Enter) return new Sorting(list); //Continue
            }
        }

        void GetWishedStartingList()
        {
            Print("To get started, first select a list of numbers:\n");
            Print("(", "1", ") Get random");
            Print("(", "2", ") Set own");
            GetTextSpacements();

            while (true)
            {
                var key = ReadKey(true);
                if (key.Key == ConsoleKey.D1) GetRandomStartList();
                else if (key.Key == ConsoleKey.D2) GetInputStartList();
                else continue;
                break;
            }
        }

        void GetRandomStartList()
        {
            Print("(1) Choose the size of your random list (3 - 75):");
            while (true)
            {
                var input = ReadLine();
                input = Check0Value(input) ? "0" : input; //Field empty -> value = 0
                if (int.TryParse(input, out int listSize) && listSize >= 0)
                {
                    if (listSize < 3) //Min size = 3
                    {
                        Print($"\n   You chose {listSize}, wich is too low, so it got changed to 3:");
                        listSize = 3;
                    }
                    else if (listSize > 75) //Max size = 75
                    {
                        Print($"\n   You chose {listSize}, wich is too high, so it got changed to 75:");
                        listSize = 75;
                    }
                    else Print($"\n   You now have a list with {listSize} numbers:");

                    for (int i = 0; i < listSize; i++)
                        list.Add(rnd.Next(1000)); //Min number 0 //Max number 999 

                    PrintList(list);
                    break;
                }
                else ClearLine(input.Length);
            }
        }

        void GetInputStartList()
        {
            int intsAdded = 0;
            Print($"(2) Press ", "Enter", " start typing the wanted numbers (0-999).");
            Print($"Once you have at least 3 numbers, press ", "Space", " to finish this process.");
            while (true)
            {
                var key = ReadKey(true);
                if (key.Key == ConsoleKey.Enter) //Add more
                {
                    while (true)
                    {
                        var input = ReadLine();
                        input = Check0Value(input) ? "0" : input; //Field empty -> value = 0
                        if (int.TryParse(input, out int toAdd) && toAdd >= 0 && toAdd < 1000) //Min number 0 //Max number 999 
                        {
                            intsAdded++;
                            list.Add(toAdd);
                            Print($"{intsAdded}: You added {toAdd} to the list:");
                            PrintList(list);
                            Print("------------------------------\n");
                            break;
                        }
                        ClearLine(input.Length);
                    }

                    if (intsAdded < 75) //Max StartList size = 75
                    {
                        if (intsAdded >= 3) Print("Press ", "Space", " to confirm your list and get started.\n");
                        Print($"Press ", "Enter", " to enter your next number.");
                        continue;
                    }
                    else break;
                }
                else if (key.Key == ConsoleKey.Spacebar) //Exit input intake
                {
                    if (intsAdded < 3) continue; //Min StartList size = 3 
                    else
                    {
                        Console.WriteLine("\n");
                        break;
                    }
                }
            }
        }
    }
}
