namespace Music_Player
{
    internal class Program
    {
        private static double c = 261.63;

        private static double z = 277.18;

        private static double d = 293.66;

        private static double v = 311.13;

        private static double j = 329.63;

        private static double f = 349.23;

        private static double i = 369.99;

        private static double g = 392.00;

        private static double h = 415.30;

        private static double a = 440.00;

        private static double e = 466.16;

        private static double b = 493.88;

        /// <summary>
        /// Entry point of the application.
        /// </summary>
        private static void Main()
        {
            while (true)
            {
                Console.WriteLine("\nEnter keys to play musical notes\nTo Enter playback sequence press S\n");
                Console.WriteLine($"A = {a}\nB = {b}\nC = {c}\nD = {d}\nE = {e}\nF = {f}\nG = {g}\nH = {h}\nI = {i}\nJ = {j}\nV = {v}\nZ = {z}");
                ConsoleKey userChoice = Console.ReadKey().Key;
                switch (userChoice)
                {
                    case ConsoleKey.A:
                        Console.Beep((int)a, 1000);
                        break;
                    case ConsoleKey.B:
                        Console.Beep((int)b, 1000);
                        break;
                    case ConsoleKey.C:
                        Console.Beep((int)c, 1000);
                        break;
                    case ConsoleKey.D:
                        Console.Beep((int)d, 1000);
                        break;
                    case ConsoleKey.E:
                        Console.Beep((int)e, 1000);
                        break;
                    case ConsoleKey.F:
                        Console.Beep((int)f, 1000);
                        break;
                    case ConsoleKey.G:
                        Console.Beep((int)g, 1000);
                        break;
                    case ConsoleKey.H:
                        Console.Beep((int)h, 1000);
                        break;
                    case ConsoleKey.I:
                        Console.Beep((int)i, 1000);
                        break;
                    case ConsoleKey.J:
                        Console.Beep((int)j, 1000);
                        break;
                    case ConsoleKey.V:
                        Console.Beep((int)v, 1000);
                        break;
                    case ConsoleKey.Z:
                        Console.Beep((int)z, 1000);
                        break;
                    case ConsoleKey.S:
                        PlayBackSequence();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void PlayBackSequence()
        {
            Console.Clear();
            Console.WriteLine("Enter the playback sequence string: ");
            string sequence = Console.ReadLine().ToUpper();

            foreach (char note in sequence)
            {
                int freq = GetFrequency(note);
                if (freq > 0)
                {
                    Console.Beep(freq, 1000);
                }
                else
                {
                    Console.WriteLine("Unknown frequency");
                }
            }
            Console.Clear();
        }

        private static int GetFrequency(char note)
        {
            switch (note)
            {
                case 'A':
                    return (int)a;
                case 'B':
                    return (int)b;
                case 'C':
                    return (int)c;
                case 'D':
                    return (int)d;
                case 'E':
                    return (int)e;
                case 'F':
                    return (int)f;
                case 'G':
                    return (int)g;
                case 'H':
                    return (int)h;
                case 'I':
                    return (int)i;
                case 'J':
                    return (int)j;
                case 'V':
                    return (int)v;
                case 'Z':
                    return (int)z;
                default:
                    return 0;
            }
        }
    }
}
