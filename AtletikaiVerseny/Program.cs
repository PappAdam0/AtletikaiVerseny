using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AtletikaiVerseny
{
    class Program
    {
        static List<Atleta> lista = new List<Atleta>();
        static List<string> egyesulet = new List<string>();
        static Dictionary<string, int> nevugras = new Dictionary<string, int>();
        static void Beolvas()
        {
            Console.WriteLine("1. Feladat: adatok beolvasása");
            StreamReader be = new StreamReader("tavol.csv");
            while (!be.EndOfStream)
            {
                lista.Add(new Atleta(be.ReadLine()));
            }
            be.Close();

            
        }

        static void NevUgras()
        {
            Console.WriteLine("\n2. Feladat: Nevek és ugrások");
            foreach (var i in lista)
            {
                nevugras.Add($"{i.VezNev} {i.KerNev}", i.Ugras);
            }
            foreach (var n in nevugras)
            {
                Console.WriteLine($"{n.Key} \t{n.Value}");
            }
        }
        static void Egyesuletek()
        {
            Console.WriteLine("\n3. Feladat: Egyesületek");

            foreach (var i in lista)
            {
                if (!egyesulet.Contains(i.Egyesulet))
                {
                    egyesulet.Add(i.Egyesulet);
                }
            }
            foreach (var i in egyesulet)
            {
                Console.WriteLine(i);
            }
        }

        static void LegnagyobbUgras()
        {
            Console.WriteLine("\n4. Feladat: Legnagyobb ugrás");
            int max = 0;
            string nev = "";
            foreach (var i in lista)
            {
                if (max < i.Ugras)
                {
                    max = i.Ugras;
                    nev = $"{i.VezNev} {i.KerNev}";
                }
            }
            Console.WriteLine($"{nev}: {max} cm");
        }
        static void AtlagUgras()
        {
            double atlag = 0;
            double s = 0;
            int atlagalatt = 0;

            foreach (var i in lista)
            {
                s = s + i.Ugras;
            }

            atlag = s / lista.Count;

            foreach (var i in lista)
            {
                if (i.Ugras < atlag)
                {
                    atlagalatt++;
                }
            }
            Console.WriteLine("\n5. Feladat: Átlag alatt lévő ugrások száma: {0}",atlagalatt);
        }
        static void Kiiratas()
        {
            Console.WriteLine("\n6. Feladat: Adatok fájlba írása");
            StreamWriter ki = new StreamWriter("versenyzok.txt");
            foreach (var l in lista)
            {
                ki.WriteLine($"{l.Rajtszam};{l.VezNev} {l.KerNev}");
            }
            ki.Close();
        }
        static void Main(string[] args)
        {
            Beolvas();
            NevUgras();
            Egyesuletek();
            LegnagyobbUgras();
            AtlagUgras();
            Kiiratas();

            Console.ReadKey();
        }
    }
}
