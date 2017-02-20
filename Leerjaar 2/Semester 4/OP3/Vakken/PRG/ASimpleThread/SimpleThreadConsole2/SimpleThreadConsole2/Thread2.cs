using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleThreadConsole2
{


    public class Thread2
    {
        public Thread2()
        {
            Thread t = new Thread(() => WriteY(200));   // Kick off a new thread
            t.Start();                                  // running WriteY()
            t.Join();                                   // Wait until finished

            Thread.Sleep(50);
            // Simultaneously, do something on the main thread.
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("x");
                Thread.Sleep(5);
            }
        }

        
        static void WriteY(int multiply)
        {
            for (int i = 0; i < multiply; i++)
            {
                Console.Write("y");
                Thread.Sleep(5);
            }
        }
    }
}
