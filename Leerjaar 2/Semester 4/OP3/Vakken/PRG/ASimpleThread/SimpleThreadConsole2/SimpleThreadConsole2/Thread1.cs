using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleThreadConsole2
{
    class Thread1
    {
        //constructor
        public Thread1()
        {
            Thread t = new Thread(WriteY);          // Kick off a new thread
            t.Start();                              // running WriteY()
            t.Join();                               // Wait until finished

            

            // Simultaneously, do something on the main thread.
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("x");
                Thread.Sleep(5);
            }
        }

        
        static void WriteY()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("y");
                Thread.Sleep(5);
            }
        }
    }
}
