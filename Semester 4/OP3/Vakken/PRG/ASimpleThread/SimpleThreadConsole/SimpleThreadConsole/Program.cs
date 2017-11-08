using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SimpleThreadConsole
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Before start thread");

            MyLoops thr = new MyLoops();
            
            Thread tid1 = new Thread(new ThreadStart(thr.FirstLoop));
            Thread tid2 = new Thread(new ThreadStart(thr.SecondLoop));
            tid1.Start();
            tid1.Join();
            tid2.Start();
            tid2.Join();
            Console.WriteLine("End threads");
            Console.ReadLine();

          
        }        
    }
}
