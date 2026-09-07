namespace Assignments
{
    internal class Program
    {
        private static void Main()
        {
            while (true)
            {
                string mainMenu = $@"
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
                        ListModifier.ModifyList();
                        break;
                    case 2:
                        StackModifier.ModifyStack();
                        break;
                    case 3:
                        QueueModifier.ModifyQueue();
                        break;
                    case 4:
                        DictionaryModifier.ModifyDictionary();
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        Thread.Sleep(1300);
                        return;
                    default:
                        Console.WriteLine("Invalid Choice\n");
                        break;
                }
            }
        }
    }
}