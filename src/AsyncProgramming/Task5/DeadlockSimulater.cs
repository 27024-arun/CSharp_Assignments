namespace AsyncProgramming.Task5
{
    internal class DeadlockSimulater
    {
        private readonly object _lockObject1 = new object();

        private readonly object _lockObject2 = new object();

        public void DeadlockPerformer()
        {
            string header = $@"
=====================================
            DeadLock
=====================================
[D]eadlock code output
[S]olved Deadlock code output

Enter choice: ";
            Console.Write(header);
            ConsoleKey userChoice = Console.ReadKey().Key;
            if (userChoice == ConsoleKey.D)
            {
                this.SimulateDeadLock();
            }
            else if (userChoice == ConsoleKey.S)
            {
                this.PeformWithoutDeadlock();
            }
            else
            {
                ConsoleHelper.CleanConsole();
            }
        }

        private void PeformWithoutDeadlock()
        {
            Thread firstThread = new Thread(this.CorrectedObjectHolder1);
            Thread secondThread = new Thread(this.CorrectedObjectHolder2);
            firstThread.Start();
            secondThread.Start();
            firstThread.Join();
            secondThread.Join();
            ConsoleHelper.CleanConsole();
        }

        private void SimulateDeadLock()
        {
            Thread firstThread = new Thread(this.FirstObjectHolder);
            Thread secondThread = new Thread(this.SecondObjectHolder);
            firstThread.Start();
            secondThread.Start();
            firstThread.Join();
            secondThread.Join();
            ConsoleHelper.CleanConsole();
        }

        private void FirstObjectHolder()
        {
            lock (this._lockObject1)
            {
                Console.WriteLine($"\nThread 1 got lock object 1");
                Thread.Sleep(1000);
                lock (this._lockObject2)
                {
                    Console.WriteLine("Thread 1 got lock object 2");
                }
            }
        }

        private void SecondObjectHolder()
        {
            lock (this._lockObject2)
            {
                Console.WriteLine($"Thread 2 got lock object 2");
                Thread.Sleep(1000);
                lock (this._lockObject1)
                {
                    Console.WriteLine("Thread 2 got lock object 1");
                }
            }
        }

        private void CorrectedObjectHolder1()
        {
            lock (this._lockObject1)
            {
                Console.WriteLine($"\nThread 1 got lock object 1");
                Thread.Sleep(1000);
                lock (this._lockObject2)
                {
                    Console.WriteLine("Thread 1 got lock object 2");
                }
            }
        }

        private void CorrectedObjectHolder2()
        {
            lock (this._lockObject1)
            {
                Console.WriteLine($"Thread 2 got lock object 1");
                Thread.Sleep(1000);
                lock (this._lockObject2)
                {
                    Console.WriteLine("Thread 2 got lock object 2");
                }
            }
        }
    }
}
