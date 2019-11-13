using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3
{
   
    public class Graph
    {
        private int hWidth;
        private int hHieght;
        private Point hLocation;
        private ConsoleColor hBorderColor;

        public Graph(int width, int hieght, Point location, ConsoleColor borderColor)
        {
            hWidth = width;
            hHieght = hieght;
            hLocation = location;
            hBorderColor = borderColor;
        }

        public Point Location
        {
            get { return hLocation; }
            set { hLocation = value; }
        }

        public int Width
        {
            get { return hWidth; }
            set { hWidth = value; }
        }

        public int Hieght
        {
            get { return hHieght; }
            set { hHieght = value; }
        }

        public ConsoleColor BorderColor
        {
            get { return hBorderColor; }
            set { hBorderColor = value; }
        }

        public void Line(int b)
        {
            int a = 1;
            Console.SetCursorPosition(b, 0);
            Console.WriteLine("╦");
            for (int i = 0; i < Hieght; i++)
            {
                Console.SetCursorPosition(b, a);
                Console.WriteLine("║");
                a++;
            }
            Console.SetCursorPosition(b, a);
            Console.WriteLine("╩");
        }
        public void Darw()
        {
            string s = "╔";
            string space = "";
            string temp = "";
            int c = 0;
            for (int i = 0; i < Width-1; i++)
            {
                c++;
                if (c == 2)
                {
                    space += " ";
                    c = 0;
                }
                if (i == Width / 2 - 1)
                    s += "╦";
                else
                s += "═";
            }
            
            for (int j = 0; j < Location.X; j++)
                temp += " ";

            s += "╗" + "\n";
            
            for (int i = 0; i < Hieght; i++)
                s += temp + "║" + space + "║"+space + "║" + "\n";

            s += temp + "╚";
            for (int i = 0; i < Width - 1; i++)
            {
                if (i == Width / 2 - 1)
                    s += "╩";
                else
                s += "═";
            }
            s += "╝" + "\n";
            
            Console.ForegroundColor = BorderColor;
            Console.CursorTop = hLocation.Y;
            Console.CursorLeft = hLocation.X;
            Console.Write(s);
            Console.SetCursorPosition(0, 3);
            s = "╠";
            for (int j = 0; j < Width/2-1; j++)
                s += "═";
            s += "╬";
            for (int j = Width / 2; j < Width-1; j++)
                s += "═";
            s += "╣";
            Console.Write(s);
            Line(31);
            Line(101);
            Line(41);
            Line(111);
            Console.ResetColor();
        }
    }
}
