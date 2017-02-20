using System;
using System.Collections.Generic;
using System.Linq;
//using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleThreadConsole
{
    public class MyLoops
    {
        public void FirstLoop()
        {
            for (int i = 0; i < 10; i++)
            {                
                Console.WriteLine("Thread 1: {0}", i);
                Thread.Sleep(500);
            }
        }

        public void SecondLoop()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Thread 2: {0}", i);
                Thread.Sleep(50);
            }
        }
    }
}
