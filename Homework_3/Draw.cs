using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Homework_3
{
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    class Draw:Program
    {
       public void Paint()
        {
            var width = Console.WindowWidth;
            var height = Console.WindowHeight;
            //Console.SetBufferSize(width, height);
            //Console.SetWindowSize(width, height);
            Console.SetWindowSize(138, 52);
            Point p = new Point();
            Console.BackgroundColor = ConsoleColor.Blue;
            Graph w = new Graph(136, 45, p, ConsoleColor.Cyan);
            w.Darw();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(15, 2);
            Console.WriteLine("NAME");
            Console.SetCursorPosition(85, 2);
            Console.WriteLine("NAME");
            Console.SetCursorPosition(32, 2);
            Console.WriteLine("EXEPTIONS");
            Console.SetCursorPosition(102, 2);
            Console.WriteLine("EXEPTIONS");
            Console.SetCursorPosition(50, 2);
            Console.WriteLine("DATE_CHANGE");
            Console.SetCursorPosition(120, 2);
            Console.WriteLine("DATE_CHANGE");
            Console.SetCursorPosition(3, 0);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(way1);
            Console.SetCursorPosition(73, 0);
            Console.WriteLine(way2);
            
            Console.BackgroundColor = ConsoleColor.Blue;


        }
      
    }
}
