using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIGCollector;

namespace WIGCollectorView
{
    class Program
    {
        static void Main(string[] args)
        {
            WIGCollector.WIGCollector brain = new WIGCollector.WIGCollector();
            brain.Run();
            Console.WriteLine("WIGCollector start with default collection interval 1 minute.");
            Console.WriteLine("Enter number of seconds and press Enter to change collection interval.");
            uint number = 60;
            while (!Console.KeyAvailable)
            {
                string a = Console.ReadLine();
                bool bWriteNumber = false;
                try
                {
                    number = uint.Parse(a);
                    bWriteNumber = true;
                }
                catch
                {
                    Console.WriteLine("Only uint");
                }
                finally
                {
                    if (bWriteNumber)
                    {
                        if (brain.ChangeInterval(number))
                        {
                            Console.WriteLine("Interval changed to " + number + " seconds");
                        }
                    }
                            
                }
            }
        }
    }
}
