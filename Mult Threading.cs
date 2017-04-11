using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Data;
using System.Drawing;


namespace Thread
{
    class Program
    {
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern int GetAsyncKeyState(int vKey);

        static bool f1 = false;
        

        public static void metodo2()
        {
            while (true)
            {
                if (f1 == true)
                {
                    Console.WriteLine("Sim");
                }
                else
                {

                    Console.Clear();
                    Console.WriteLine("Precione F1 para ativar", Console.ForegroundColor = ConsoleColor.Green);

                }
                Thread.Sleep(100);
            }
        }
        
        public static void metodo1()
        {
            while(true){
                if ((GetAsyncKeyState(112) != 0))
                {
                    f1 = !f1;
                }
                Thread.Sleep(100);
            }   
        }
        
        static public void Tick(Object stateInfo)
        {
            metodo2();
        }
        static public void Tick1(object stateInfo)
        {
            metodo1();
        }
        static void Main(string[] args)
        {

            //TimerCallback callback = new TimerCallback(Tick);
            //TimerCallback callback1 = new TimerCallback(Tick1);
           
            // create a one second timer tick
            //Timer stateTimer = new Timer(callback, null, 0, 100);
            //Timer stateTimer1 = new Timer(callback1, null, 0, 120);
            Thread t1 = new Thread(new ThreadStart(metodo2));
            Thread t2 = new Thread(new ThreadStart(metodo1));
            t1.Start();
            t2.Start();
            
            
            // loop here forever
            for (; ; )
            {
                
                // add a sleep for 100 mSec to reduce CPU usage
                Thread.Sleep(100);
               // Console.ReadKey();
            }
        }
    }
}
