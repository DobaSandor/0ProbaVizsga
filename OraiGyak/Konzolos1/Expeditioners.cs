using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyakorlas_1
{
    internal class Expeditioners
    {
        // Expeditioners.txt
        // Id;Nev;Fegyver;Eletpont;Tamadas;Vedelem;Elem;Eletkor;ExpedicioTag
        // 1;Gustave;Mernoki Penge;1200;150;200;Fold;35;true

        public int Id { get; set; }
        public string Nev { get; set; }
        public string Fegyver { get; set; }
        public int Eletpont { get; set; }
        public int Tamadas { get; set; }

        public int Vedelem { get; set; }
        public string Elem { get; set; }
        public int Eletkor { get; set; }
        public bool ExpedicioTag { get; set; }

        // Fájl beolvasása és objektumok létrehozása, első sort kihagyva

        public Expeditioners(string sor)
        {
            // split ;
            string[] s = sor.Split(';');
            try
            {
                Id = int.Parse(s[0]);
                Nev = s[1];
                Fegyver = s[2];
                Eletpont = int.Parse(s[3]);
                Tamadas = int.Parse(s[4]);
                Vedelem = int.Parse(s[5]);
                Elem = s[6];
                Eletkor = int.Parse(s[7]);
                ExpedicioTag = bool.Parse(s[8]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba beolvasáskor: " + ex.Message);
            }
        }

        public static List<Expeditioners> LoadFromTXT(string fajlnev)
        {
            List<Expeditioners> karakterek = new();

            try
            {
                string[] sorok = File.ReadAllLines(fajlnev);
                for (int i = 1; i < sorok.Length; i++)
                {
                    karakterek.Add(new Expeditioners(sorok[i]));
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
