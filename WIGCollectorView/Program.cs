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
            brain.ChangeInterval(10);
            brain.Run();
            Console.Read();
        }
    }
}
