using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karakterek
{
    internal class Karakter
    {
        // Adattagok: Név, Kaszt, Tudásszint, Klán neve, XP

        public string Nev { get; set; }
        public string Kaszt { get; set; }
        public int Tudasszint { get; set; }
        public string KlanNeve { get; set; }
        public int XP {  get; set; }

        // Aragorn;Harcos;95;Kósza Klán;15000 (1. sor)

        public Karakter(string sor) {
            // split ;
            string[] s = sor.Split(';');
            try
            {
                Nev = s[0];
                Kaszt = s[1];
                Tudasszint = int.Parse(s[2]);
                KlanNeve = s[3];
                XP = int.Parse(s[4]);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Hiba beolvasáskor: " + ex.Message);
            }
        }
        // READ

        public static List<Karakter> LoadFromCSV(string fajlnev)
        {
            List<Karakter> karakterek = new();

            try
            {
                string[] sorok = File.ReadAllLines(fajlnev);
                for (int i = 0; i < sorok.Length; i++)
                {
                    karakterek.Add(new Karakter(sorok[i]));
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Olvasási hiba!");
            }

            return karakterek;
        }


    }
}
