namespace Collections
{
    /// <summary>
    /// Program is the entry class of the application.
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            while (true)
            {
                Console.Clear();
                string mainMenu = $@"
============Collections============
1. List Task
2. Stack Task
3. Queue Task
4. Dictionary Task
5. Exit

Enter Choice: ";
                Console.Write(mainMenu);
                int.TryParse(Console.ReadLine(), out int userChoice);
                Console.Clear();
                switch (userChoice)
                {
                    case 1:
                        ListModifier<string>.ModifyList();
                        break;
                    case 2:
                        StackModifier<char>.OperateStack();
                        break;
                    case 3:
                        QueueModifier<string>.ModifyQueue();
                        break;
                    case 4:
                        DictionaryModifier<string, int>.ModifyDictionary();
                        break;
                    case 5:
                        Helper.WriteColored("Exiting...", ConsoleColor.Cyan);
                        Thread.Sleep(1300);
                        Environment.Exit(0);
                        break;
                    default:
                        Helper.WriteColored("Invalid Choice", ConsoleColor.Red);
                        Thread.Sleep(1300);
                        break;
                }
            }
        }
    }
}