using System;

namespace L61
{
    interface ILibrary
    {
        void Sort(int n, Library[]a);
        void Suma(int n, Library[] a);

    }
    public class Library : ILibrary
    {
        public string Author;
        public string Name;
        public string Publish;
        public int Year;
        public int Number;

        public Library(string Author, string Name, string Publish, int Year, int Number)
        {
            this.Author = Author;
            this.Name = Name;
            this.Publish = Publish;
            this.Year = Year;
            this.Number = Number;

        }
        public void Sort(int n, Library[]a)
        {
            
            int t;
            string k;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (a[i].Year > a[j].Year)
                    {
                        t = a[i].Year;
                        a[i].Year = a[j].Year;
                        a[j].Year = t;
                        k = a[i].Author;
                        a[i].Author = a[j].Author;
                        a[j].Author = k;
                        k = a[i].Name;
                        a[i].Name = a[j].Name;
                        a[j].Name = k;
                        k = a[i].Publish;
                        a[i].Publish = a[j].Publish;
                        a[j].Publish = k;
                        t = a[i].Number;
                        a[i].Number = a[j].Number;
                        a[j].Number = t;

                    }
                }
            }
            Console.WriteLine("Автор\t\tНазва книги\t\tВидавництво\t\tРiк\t\tКiлькiсть книг");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0,-15} {1, -25} {2, -20} {3, -20} {4, -20}",a[i].Author, a[i].Name,a[i].Publish , a[i].Year,a[i].Number);
            }
            
        }
        public void Suma(int n, Library[] a)
        {
            int s = 1, d = a[0].Year;
            int[] r = new int[n];
            for (int i = 0; i < n; i++)
            {

                if (d == a[i].Year)
                    s++;
                else
                {
                    s = 1;
                    d = a[i].Year;
                    r[i] = a[i].Year;
                }

            }
            r[0] = a[0].Year;
            int m = 0;
            for (int i = 0; i < n; i++)
            {
                if (r[i] == 0)
                    m++;
                else
                    r[i - m] = r[i];
            }
            for (int i = 0; i < n; i++)
            {
                if (r[i] == 0)
                {
                    m = i;
                    break;
                }
            }

            int suma = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (r[i] == a[j].Year)
                    {
                        suma += a[j].Number;
                    }
                }
                Console.WriteLine("Видано книг за " + r[i] + "рік: " + suma);
                suma = 0;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введiть кiлькiсть книг: ");
            int n = int.Parse(Console.ReadLine());
            Library[] a = new Library[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(i + 1 + " книга");

                Console.Write("Автор: ");
                string Author = Console.ReadLine();
                Console.Write("Назва книги: ");
                string Name = Console.ReadLine();
                Console.Write("Видавництво: ");
                string Publish = Console.ReadLine();
                Console.Write("Рiк видання: ");
                int Year = int.Parse(Console.ReadLine());
                while (Year>2020 || Year < 0)
                {
                    Console.Write("Введено неправильний рiк видання. Введiть ще раз: ");
                    Year = int.Parse(Console.ReadLine());
                }
                Console.Write("Кiлькiсть книг: ");
                int Number = int.Parse(Console.ReadLine());
                while (Number < 0)
                {
                    Console.Write("Введено неправильна кiлькiсть. Введiть ще раз: ");
                    Number = int.Parse(Console.ReadLine());
                }

                a[i] = new Library(Author, Name, Publish, Year, Number);

            }
            a[0].Sort(n, a);
            a[0].Suma(n, a);
        }
    }
}