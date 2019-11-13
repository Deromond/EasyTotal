using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Homework_3
{
     class Functional
    {
        private string way;
        string[] ex = new string[1];
        public string GoTo(string way)
        {
            return way;
        }
        public string Go(string way,string fullway)
        {
            this.way = fullway + @"\" + way;
            return this.way;
        }
        public string Extention(string fullway)
        {
            var ext = new FileInfo(fullway);
            return ext.Extension.Trim('.');
            
        }
        public string Return(string fullway)
        {
            return way = Directory.GetParent(fullway).ToString();

        }
        public string[] Files(string way) //Возвращает все файлы в текущей директории
        {
            try
            {
                string[] files = Directory.GetFiles(way);
                return files;
            }
            catch(DirectoryNotFoundException w)
            {
                ex[0] = w.ToString();
                return ex;
            }
        }
        public  string[] Directories(string way)//Возвращает все папки в текущей директории
        {
            try
            {
                string[] dir = Directory.GetDirectories(way);
                return dir;
            }
            catch(DirectoryNotFoundException w)
            {
                ex[0] = w.ToString();
                return ex;
            }
        }
        public string Move (string newway,string fullway)//Перемещает каталог, по идеи с его содержимым 
        {
            try
            {
                Directory.Move(fullway, newway);
                return "0";
            }
            catch (DirectoryNotFoundException w)
            {
                return w.ToString();
            }
            
        }
        public void Copy(string name,string newway,string fullway)//Копирует все файлы в текущей папке
        {
            string[] file = Directory.GetFiles(fullway);
            string sourceFile = Path.Combine(fullway, name);
            string destFile = Path.Combine(newway, name);
            if (!Directory.Exists(newway))
            {
                Directory.CreateDirectory(newway);
            }
            File.Copy(sourceFile, destFile, true);
            if (Directory.Exists(fullway))
            {
                file = Directory.GetFiles(fullway);
                foreach (string s in file)
                {
                    name = Path.GetFileName(s);
                    destFile = Path.Combine(newway, name);
                    File.Copy(s, destFile, true);
                }
            }
            else
            {
                Console.WriteLine("Can't find a road");
            }
        }
        public void CreateFile(string filename,string fullway)//Создаем файл и открываем его
        {
            FileStream file = new FileStream(fullway + @"\" + filename + ".txt", FileMode.Append);
            Process.Start(fullway + @"\" + filename + ".txt");
        }
        public string Time ()
        {
            return DateTime.Now.ToString();
        }
        public void Clean()// Очищает окно и выводит текущую директорию
        {
            Console.ResetColor();
            Console.Clear();
        }
        public FileAttributes GetAtrib(string filename,string fullway)// Хз что это, но по идеи выводит атрибуты файлов ... надо будет потом узнать что такое атрибуты ...
        {
            try
            {
                return File.GetAttributes(fullway + @"\" + filename);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public string DateChange(string waytofile)
        {
            return File.GetLastWriteTime(waytofile).ToString();
        }
        
        public void ChangeName(string fullway)//груповое изменение имени файлов, перебирает каждый файл и изменяет его имя
        {
            string newname;
            try
            {
                var files = Directory.EnumerateFiles(fullway, "*.*", SearchOption.TopDirectoryOnly);
                foreach (string s in files)
                {
                    Console.WriteLine("New name:");
                    newname = Console.ReadLine();
                    string r = s;
                    string d = fullway + @"\" + newname;
                    File.Move(r, d);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void CreateDir(string name,string fullway)//создание директории
        {
            Directory.CreateDirectory(fullway + @"\" + name);
        }
        public string DeleteDir(string name,string fullway)//удаление директории
        {
            try
            {
                Directory.Delete(fullway + @"\" + name);
                return "0";
            }
            catch(DirectoryNotFoundException w)
            {
                return w.ToString();
            }
        }
        public string[] Search(string name,string fullway)//поиск, по идеи ищет любой формат файла
        {
            try
            {
                string[] find = Directory.GetFiles(fullway, name + "*", SearchOption.TopDirectoryOnly);
                return find;
            }
            catch(DirectoryNotFoundException w)
            {
                ex[0] = w.ToString();
                return ex;
            }
        }
        public long DirSize(DirectoryInfo d)
        {
            long Size = 0;
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                Size += fi.Length;
            }
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                Size += DirSize(di);
            }
            return (Size);
        }

    }
}
