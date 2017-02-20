using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleThreadConsole2
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread1 clsThread1 = new Thread1(); 
            Thread2 clsThread2 = new Thread2();
            Console.WriteLine("End Threads");

            Thread.Sleep(5000);
        }

       
    }
}
