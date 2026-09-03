namespace Assignments
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string mainMenu = $@"
1. TASK 1
2. TASK 2
3. TASK 3
4. TASK 4
5. Exit
Enter Choice: ";
                Console.Write(mainMenu);
                int.TryParse(Console.ReadLine(), out int userChoice);
                switch (userChoice)
                {
                    case 1:
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        break;
                    case 4:
                        Console.Clear();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invaild Choice\n");
                        break;
                }
            }
        }
    }
}