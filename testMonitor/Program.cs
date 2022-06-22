using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace testMonitor
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Process[] processes = Process.GetProcesses();
            ConsoleKeyInfo key;
            try
            {
                do
                {
                    key = Console.ReadKey();
                    for (int i = 0; ; i--)
                    {
                        Process[] process1 = Process.GetProcessesByName("notepad");
                        TimeSpan lifetime = DateTime.Now - process1[0].StartTime;
                        Console.WriteLine(lifetime);
                        int lifetimeInMinutes = lifetime.Minutes;
                        Console.WriteLine(lifetimeInMinutes);

                        if (lifetimeInMinutes >= 5)
                        {
                            process1[0].Kill();
                        }

                        Thread.Sleep(60000);
                    }
                } while (key.Key != ConsoleKey.Q);
            }
            catch (Exception ex) 
            {
                Console.WriteLine("The program is not working"+ex);
            }
            
        }
    }
}
