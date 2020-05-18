using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace L62
{
    interface Icourse
    {
        int Average(int number);
        void Find(string str);
    }
    class Program
    {
        public static Practice[] all = new Practice[100];
        public static bool[] delete = new bool[100];
        static void Main(string[] args)
        {
            PutKey.Key();
        }
    }
    abstract class Course : Icourse
    {
        public string Name;
        public string Avail;
        abstract public int Average(int Number);
        abstract public void Find(string str);
        public static void Add()
        {
            Console.WriteLine("Write data:");

            string str = Console.ReadLine();

            string[] elements = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            PutKey.P(elements, true);

            PutKey.Key();
        }

        public static void Remove()
        {
            Console.Write("\nName of course what you want to delete: ");

            string name = Console.ReadLine();

            bool[] write = new bool[Program.all.Length];

            for (int i = 0; i < Program.all.Length; ++i)
            {
                if (Program.all[i].Name != null)
                {
                    if (Program.all[i].Name == name)
                    {
                        Console.WriteLine("{0,-15} {1, -15} {2, -15} {3, -20} {4,-20} ", Program.all[i].Name, Program.all[i].Avail, Program.all[i].Data, Program.all[i].Theme, Program.all[i].Number);

                        Program.delete[i] = true;

                    }
                }
            }
            PutKey.Key();

        }
        public static void Write(Practice[] s)
        {
            Console.WriteLine("{0,-15} {1, -15}\t {2, -20} {3, -20} {4,-30} ", "Назва", "Наявнiсть iспиту", "Дата", "Тема", "Кiлькість студентiв");

            for (int i = 0; i < s.Length; ++i)
            {
                if (s[i] != null)
                {
                    Console.WriteLine("{0,-15} {1, -10}\t {2, -20} {3, -20} \t\t{4,-30} ", Program.all[i].Name, Program.all[i].Avail, Program.all[i].Data, Program.all[i].Theme, Program.all[i].Number);
                }
            }
            PutKey.Key();
        }

        public static void Write(Practice[] s, bool[] write)
        {
            Console.WriteLine("{0,-15} {1, -15} {2, -15} {3, -20} {4,-20} {5,-15} {6,-15} ", "Назва", "Наявнiсть iспиту", "Дата", "Тема", "Кiлькiсть студентiв");

            for (int i = 0; i < s.Length; ++i)
            {
                if ((write[i]) && (!Program.delete[i]))
                {
                    Console.WriteLine("{0,-15} {1, -15} {2, -15} {3, -20} {4,-20} ", Program.all[i].Name, Program.all[i].Avail, Program.all[i].Data, Program.all[i].Theme, Program.all[i].Number);
                }
            }
        }
        public static void Edit()
        {
            Console.Write("\nName of course: ");

            string name = Console.ReadLine();

            bool[] write = new bool[Program.all.Length];

            for (int i = 0; i < Program.all.Length; ++i)
            {
                if (Program.all[i] != null)
                {
                    if (Program.all[i].Name == name)
                    {

                        Console.WriteLine("\nEnter new info: ");

                        string str = Console.ReadLine();

                        string[] elements = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                        Program.all[i] = new Practice(elements[i], elements[i + 1], DateTime.Parse(elements[i + 2]), elements[i + 3], int.Parse(elements[i + 4]));
                    }
                }
            }
            PutKey.Key();
        }


    }
    class Practice : Course
    {
        public DateTime Data;
        public string Theme;
        public int Number;
        public Practice(string name, string avail, DateTime data, string theme, int number)
        {
            Name = name;
            Avail = avail;
            Data = data;
            Theme = theme;
            Number = number;
        }
        public override void Find(string str)
        {
            
            for (int i = 0; i < Program.all.Length; i++)
            {
                if (Program.all[i].Theme.Contains(str))
                {
                    Console.WriteLine(Program.all[i].Theme);
                }

            }
            
        }
        public override int Average(int s)
        {
            
            int k = 0;
            for (int i = 0; i < Program.all.Length; i++)
            {
                s += Program.all[i].Number;
                k++;
            }
            Console.WriteLine("\nAverage number of students: ");
            return s / k;
        }
        public static void Max()
        {
            int max = Program.all[0].Number;
            int k = 0;
            for (int i = 0; i < Program.all.Length; i++)
            {

                if (Program.all[i].Number >= max)
                {
                    max = Program.all[i].Number;
                    k = i;
                }
            }
            Console.WriteLine("\nMax number of students is " + max + "\nRelate to discipline " + Program.all[k].Name);
        }

    }
    class PutKey
    {
        public static void Key()
        {
            PutKey.P(PutKey.Read(), false);

            Console.WriteLine("Add note: +");
            Console.WriteLine("Edit note: E");
            Console.WriteLine("Remove note: R");
            Console.WriteLine("Show notes: Enter");
            Console.WriteLine("Find course with max number of students: K");
            Console.WriteLine("Average number of student: D ");
            Console.WriteLine("List of themes with one word: B ");
            Console.WriteLine("Exit: Esc");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.B:
                    Console.WriteLine("\nWrite the word: ");
                    string str = Console.ReadLine();
                    Program.all[0].Find(str);
                    break;

                case ConsoleKey.D:
                    Console.WriteLine(Program.all[0].Average(0));
                    break;

                case ConsoleKey.K:
                    Practice.Max();
                    break;

                case ConsoleKey.OemPlus:
                    Course.Add();
                    break;

                case ConsoleKey.Enter:
                    Course.Write(Program.all);
                    break;

                case ConsoleKey.Escape:
                    return;

                case ConsoleKey.E:
                    Course.Edit();
                    break;

                case ConsoleKey.R:
                    Course.Remove();
                    break;

            }

        }

        private static string[] Read()
        {
            StreamReader fromFile = new StreamReader("course.txt");

            return fromFile.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

        }
        private static void Save(Practice n)
        {
            StreamWriter save = new StreamWriter("course1.txt", true);

            save.WriteLine(n.Name);
            save.WriteLine(n.Avail);
            save.WriteLine(n.Data);
            save.WriteLine(n.Theme);
            save.WriteLine(n.Number);

            save.Close();
        }

        public static void P(string[] elements, bool save)
        {
            int counter = 0;

            while (Program.all[counter] != null)
            {
                ++counter;
            }

            for (int i = 0; i < elements.Length; i += 5)
            {
                Program.all[counter + i / 5] = new Practice(elements[i], elements[i + 1], DateTime.Parse(elements[i + 2]), elements[i + 3], int.Parse(elements[i + 4]));
                if (save)
                {
                    Save(Program.all[counter + i / 5]);
                }
            }
        }

    }
}