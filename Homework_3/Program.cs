using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework_3
{
    class Program
    {
       static string allcomand = "";
       static string comand;
        static bool check = true;
        static int window = 1;
       static string[] info;
        static string[] all;
        static protected string way1 = Directory.GetDirectoryRoot(Directory.GetCurrentDirectory());
       static protected string way2 = Directory.GetDirectoryRoot(Directory.GetCurrentDirectory());
       static Functional fun = new Functional();
       static Draw p = new Draw();


        static void Dir(int a,int b,int c,string way)
        {
            
            int x=0;
            int f,r;
            if (a == 2)
                x = 35;
            else if (a == 72)
                x = 105;
            Console.SetCursorPosition(a, b);
            allcomand = allcomand + " " + comand;
            Console.WriteLine("Directories:");
            info = fun.Directories(way);
            if (check == true)
            {
                all = info;
                check = false;
            }
            foreach (string s in info)
            {
                Console.SetCursorPosition(a+43, c);
                Console.WriteLine(fun.DateChange(s)); 
                Console.SetCursorPosition(a, c);
                Console.WriteLine(Path.GetFileNameWithoutExtension(s));
                c++;
            }
            
            c++;
            Console.SetCursorPosition(a, c);
            Console.WriteLine("Files:");
            info = fun.Files(way);
            foreach (string s in info)
            {
                f = c;
                r = c+1;
                Console.SetCursorPosition(x, ++f);
                if (fun.Extention(s) == "exe")
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (fun.Extention(s) == "rar" || fun.Extention(s) == "zip")
                    Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(fun.Extention(s));
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(a + 43, r);
                Console.WriteLine(fun.DateChange(s));
                Console.SetCursorPosition(a, ++c);
                Console.WriteLine(Path.GetFileNameWithoutExtension(s));
            }
        }
        public static string GraphMove(int a, int b)
        {
            int len = all.Length;
            int z = 0;
            while (true)
            {
                
                var move = Console.ReadKey();
                if (move.Key == ConsoleKey.DownArrow)
                {
                    ++b;
                    if (b > len + 4)
                    {
                        b = 5;
                        z = 0;
                    }
                    z++;
                    fun.Clean();
                    p.Paint();
                    Dir(2, 4, 5, way1);
                    Dir(72, 4, 5, way2);

                    Console.SetCursorPosition(a, b);
                    Console.WriteLine("&");
                }
                else if (move.Key == ConsoleKey.UpArrow)
                {
                    --b;
                    if (b < 5)
                    {
                        b = len + 4;
                        z = len;
                    }
                    z--;
                    fun.Clean();
                    p.Paint();
                    Dir(2, 4, 5, way1);
                    Dir(72, 4, 5, way2);
                    Console.SetCursorPosition(a, b);
                    Console.WriteLine("&");
                }
                else if (move.Key == ConsoleKey.Enter)
                {
                    z = 0;
                    if (window == 1)
                    {
                        way1 = fun.GoTo(all[z]);
                        all = fun.Directories(way1);
                    }
                    else if (window == 2)
                    {
                        way2 = fun.GoTo(all[z]);
                        all = fun.Directories(way2);
                    }
                    fun.Clean();
                    p.Paint();
                    len = all.Length;
                    Dir(2, 4, 5, way1);
                    Dir(72, 4, 5, way2);

                }
                else if (move.Key == ConsoleKey.Backspace)
                {
                    z = 0;
                    if (window == 1)
                    {
                        way1 = fun.Return(way1);
                        all = fun.Directories(way1);
                    }
                    else if (window == 2)
                    {
                        way2 = fun.Return(way2);
                        all = fun.Directories(way1);
                    }
                    fun.Clean();
                    p.Paint();
                    len = all.Length;
                    Dir(2, 4, 5, way1);
                    Dir(72, 4, 5, way2);
                }
                else if(move.Key== ConsoleKey.F5)
                {
                    if (window == 1)
                    {
                        File.Copy(all[z], way2);
                    }
                    else if(window==2)
                        File.Copy(all[z], way1);
                }
                else if (move.Key == ConsoleKey.Spacebar)
                {
                    break;
                }
            }
            return all[z];
        }
        static void Main(string[] args)
        {
            p.Paint();
            do
            {   
                Dir(2, 4, 5,way1);
                Dir(72, 4, 5,way2);
                Console.SetCursorPosition(0, 48);
                if (window == 1)
                    Console.Write(way1 + ">");
                else if (window == 2)
                    Console.Write(way2 + ">");
                comand = Console.ReadLine();
                switch(comand)
                {
                    default:
                        {
                            fun.Clean();
                            p.Paint();
                            break;
                        }
                    case "Graph":
                        {
                            if (window ==1)
                                GraphMove(1, 5);
                            else if (window == 2)
                                GraphMove(71, 5);
                            break;
                        }
                    case "w1":
                        {
                            window = 1;
                            fun.Clean();
                            p.Paint();
                            break;
                        }
                    case "w2":
                        {
                            window = 2;
                            fun.Clean();
                            p.Paint();
                            break;
                        }
                    case "time":
                        {
                            fun.Clean();
                            p.Paint();
                            Console.SetCursorPosition(58, 1);
                            Console.WriteLine(fun.Time());
                            break;
                        }
                    case "..":
                        {
                            if (window == 1)
                               way1= fun.Return(way1);
                            else if (window == 2)
                               way2= fun.Return(way2);
                            fun.Clean();
                            p.Paint();
                            break;
                        }
                    case "dir":
                        {
                            Dir(2, 4, 5, way1);
                            Dir(72, 4, 5,way2);
                            fun.Clean();
                            p.Paint();
                            break;
                        }
                    case "move":
                        {
                            allcomand = allcomand + " " + comand;
                            Console.WriteLine("Input new way:");
                            if (window == 1)
                                fun.Move(Console.ReadLine(), way1);
                            else if (window == 2)
                                fun.Move(Console.ReadLine(), way2);
                            fun.Clean();
                            p.Paint();
                            break;
                        }
                    case "copy":
                        {
                            allcomand = allcomand + " " + comand;
                            Console.WriteLine("Input copy name:");
                            comand = Console.ReadLine();
                            if (window == 1)
                                fun.Copy(comand, Console.ReadLine(), way1);
                            else if (window == 1)
                                fun.Copy(comand, Console.ReadLine(), way2);
                                fun.Clean();
                            p.Paint();
                            break;
                        }
                    case "create":
                        {
                            allcomand = allcomand + " " + comand;
                            Console.WriteLine("Input file name:");
                            if (window == 1)
                                fun.CreateFile(Console.ReadLine(),way1);
                            else if (window == 2)
                                fun.CreateFile(Console.ReadLine(), way2);
                            fun.Clean();
                            p.Paint();
                            break;
                        }
                    case "clc":
                        {
                            allcomand = allcomand + " " + comand;
                            fun.Clean();
                            p.Paint();
                            break;
                        }
                    case "atrib":
                        {
                            allcomand = allcomand + " " + comand;
                            Console.WriteLine("Input file name:");
                            if (window == 1)
                                Console.WriteLine(fun.GetAtrib(Console.ReadLine(),way1));
                            else if (window == 2)
                                Console.WriteLine(fun.GetAtrib(Console.ReadLine(), way2));
                                break;
                        }
                    case "allr":
                        {
                            allcomand = allcomand + " " + comand;
                            if (window == 1)
                                fun.ChangeName(way1);
                            else if (window == 2)
                                fun.ChangeName(way2);
                            fun.Clean();
                            p.Paint();
                            break;
                        }
                    case "dirc":
                        {
                            allcomand = allcomand + " " + comand;
                            Console.WriteLine("Input name:");
                            if (window == 1)
                                fun.CreateDir(Console.ReadLine(),way1);
                           else if (window == 2)
                                fun.CreateDir(Console.ReadLine(),way2);
                            fun.Clean();
                            p.Paint();
                            break;
                        }
                    case "dird":
                        {
                            allcomand = allcomand + " " + comand;
                            Console.WriteLine("Input name:");
                            if (window == 1)
                                fun.DeleteDir(Console.ReadLine(),way1);
                            else if (window == 2)
                                fun.DeleteDir(Console.ReadLine(),way2);
                            fun.Clean();
                            p.Paint();
                            break;
                        }
                    case "find":
                        {
                            allcomand = allcomand + " " + comand;
                            Console.WriteLine("Input name:");
                            if (window == 1)
                                info = fun.Search(Console.ReadLine(),way1);
                            if (window == 2)
                                info = fun.Search(Console.ReadLine(),way2);
                            foreach (string s in info)
                                Console.WriteLine(s);
                            break;
                        }
                    case "his":
                        {
                            allcomand = allcomand + " " + comand;
                            Console.WriteLine("History:");
                            Console.Write(allcomand);
                            break;
                        }
                    case "goto":
                        {
                            allcomand = allcomand + " " + comand;
                            Console.WriteLine("Input new way:");
                            if (window ==1)
                            way1 = fun.GoTo(Console.ReadLine());
                            else if (window ==2)
                            way2 = fun.GoTo(Console.ReadLine());
                            fun.Clean();
                            p.Paint();
                            break;
                        }
                    case "go":
                        {
                            allcomand = allcomand + " " + comand;
                            Console.WriteLine("Input direct:");
                            if (window == 1)
                                way1 = fun.Go(Console.ReadLine(),way1);
                            else if (window == 2)
                                way2 = fun.Go(Console.ReadLine(),way2);
                            fun.Clean();
                            p.Paint();
                            break;
                        }
                    case "fw":
                        {
                            allcomand = allcomand + " " + comand;
                            Console.WriteLine("Input name:");
                            if (window == 1)
                            {
                                FileInfo file = new FileInfo(way1 + Console.ReadLine());
                                Console.WriteLine("{0} byte", file.Length);
                            }
                            else if (window == 2)
                            {
                                FileInfo file = new FileInfo(way2 + Console.ReadLine());
                                Console.WriteLine("{0} byte", file.Length);
                            }
                                break;
                        }
                    case "dw":
                        {
                            allcomand = allcomand + " " + comand;
                            if (window == 1)
                            {
                                DirectoryInfo d = new DirectoryInfo(way1);
                                Console.WriteLine("Weight this directory is: " + fun.DirSize(d) + " byte");
                            }
                            else if (window == 2)
                            {
                                DirectoryInfo d = new DirectoryInfo(way2);
                                Console.WriteLine("Weight this directory is: " + fun.DirSize(d) + " byte");
                            }
                                break;
                        }
                    case "help":
                        {
                            fun.Clean();
                            allcomand = allcomand + " "+ comand;
                            Info f = new Info();
                            Console.WriteLine(f.Dir()+"\n"+f.Dirc()+"\n"+f.Dird() + "\n" +f.DW() + "\n" +f.Wf());
                            Console.WriteLine(f.Move() + "\n" +f.His() + "\n" +f.Goto() + "\n" +f.Find() + "\n" +f.Allr());
                            Console.WriteLine(f.Atrib() + "\n" +f.Copy() + "\n" +f.Create() + "\n" +f.Clc());
                            Console.WriteLine(f.Time() + "\n" + f.w1() + "\n" + f.w2());
                            Console.ReadKey();
                            p.Paint();
                            break;
                        }
                }

            }
            while (comand != "exit");
        }
    }
}
