using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3
{
    class Info
    {
        string inform;

        public string Graph()
        {
            return inform = "graph - самое интересное работа с интерфейсом, в этом пункте есть подпункты\n 1. Стрелки Вверх, вниз выбор директории\n 2. Enter - вход в папку\n 3. Backspace - возврат в родительскую директорию\n 4. Space - выход из режима работы интерфейса";
        }
        public string Time()
        {
            return inform = "time - выводит текущее время и дату";
        }
        public string w1()
        {
            return inform = "w1 - переход на первое окно и работа с ним";
        }
        public string w2()
        {
            return inform = "w2 - переход на второе окно и работа с ним";
        }
        public string Dir()
        {
           return inform = "dir - выводит все файлы и папки в текущей директории";
        }
        public string Move()
        {
            return inform = "move - перемещает директорию в указаное место";
        }
        public string Copy()
        {
            return inform = "copy - выводит все файлы и папки в текущей директории";
        }
        public string Create()
        {
            return inform = "create - создание текстового файла";
        }
        public string Clc()
        {
            return inform = "clc - очищает окно";
        }
        public string Atrib()
        {
            return inform = "atrib - выводит атрибуты файла";
        }
        public string Allr()
        {
            return inform = "allr - груповое переименование файлов";
        }
        public string Dirc()
        {
            return inform = "dirс - создает директорию";
        }
        public string Dird()
        {
            return inform = "dird - удаляет директорию";
        }
        public string Find()
        {
            return inform = "find - находит указаный файл";
        }
        public string His()
        {
            return inform = "his - выводит все введеные ранее команды";
        }
        public string Goto()
        {
            return inform = "goto - переход в указаную директорию";
        }
        public string Wf()
        {
            return inform = "wf - выводит размер файла в байтах";
        }
        public string DW()
        {
            return inform = "df - выводит размер текущей директории";
        }
    }
}
