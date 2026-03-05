using System.Reflection.Metadata;
using System;

namespace Gyakorlas_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Expeditioners> karakterek = Expeditioners.LoadFromTXT("expeditioners.txt");

            // 1. Írasd ki azokat a karaktereket, akiknek a neve 5 karakternél hosszabb!
            Console.WriteLine("5 karakternél hosszabb nevű karakterek:");
            foreach (var k in karakterek)
            {
                if (k.Nev.Length > 5)
                {
                    Console.WriteLine(k.Nev);
                }
            }

            // 2. Írasd ki azokat a karaktereket, akiknek a fegyvere "Penge" vagy "Kard"!
            Console.WriteLine("\nPenge vagy Kard fegyverű karakterek:");
            Console.WriteLine(
                string.Join("\n", karakterek.Where(k => k.Fegyver.Contains("Penge") || k.Fegyver.Contains("Kard")).Select(k => k.Nev))
            );

            //  3. Írasd ki azokat a karaktereket, akiknek az élete 1000-nél több!
            Console.WriteLine("\n1000-nél több életű karakterek:");
            foreach (var k in karakterek)
            {
                if (k.Eletpont > 1000)
                {
                    Console.WriteLine(k.Nev);
                }
            }

            // 4. Írasd ki azokat a karaktereket, akiknek a támadása 150-nél több!

            Console.WriteLine("\n150-nél több támadású karakterek:");
            foreach (var k in karakterek)
            {
                if (k.Tamadas > 150)
                {
                    Console.WriteLine(k.Nev);
                }
            }

            // 5.Írasd ki azokat a karaktereket, akiknek a védelme 150 - nél több!

            Console.WriteLine("\n150-nél több védelmi értékű karakterek:");
            foreach (var k in karakterek)
            {
                if (k.Vedelem > 150)
                {
                    Console.WriteLine(k.Nev);
                }
            }

            // 6.Írasd ki azokat a karaktereket, akiknek az élete 1000 - nél több és a támadása 150 - nél több!

            Console.WriteLine("\n1000-nél több életű és 150-nél több támadású karakterek:");
            foreach (var k in karakterek)
            {
                if (k.Eletpont > 1000 && k.Tamadas > 150)
                {
                    Console.WriteLine(k.Nev);
                }
            }

            // 7.Írasd ki azokat a karaktereket, akiknek az élete 1000 - nél több és a védelme 150 - nél több!

            Console.WriteLine(
                "\n1000-nél több életű és 150-nél több védelmi értékű karakterek:"
            );
            foreach (var k in karakterek)
            {
                if (k.Eletpont > 1000 && k.Vedelem > 150)
                {
                    Console.WriteLine(k.Nev);
                }
            }

            // 8.Metódus segítségével kérd be a felhasználótól a karakterek adatait és add hozzá a listához!

            Console.WriteLine(
                "\nÚj karakter hozzáadása:"
            );

            Expeditioners ujKarakter = new Expeditioners("0; ; ;0;0;0; ;0;false");
            // + Hibakezelés
            while (true)
            {
                try
                {
                    Console.Write("Név: ");
                    ujKarakter.Nev = Console.ReadLine();

                    Console.Write("Fegyver: ");
                    ujKarakter.Fegyver = Console.ReadLine();

                    Console.Write("Életpont: ");
                    ujKarakter.Eletpont = int.Parse(Console.ReadLine());

                    Console.Write("Támadás: ");
                    ujKarakter.Tamadas = int.Parse(Console.ReadLine());

                    Console.Write("Védelem: ");
                    ujKarakter.Vedelem = int.Parse(Console.ReadLine());

                    Console.Write("Elem: ");
                    ujKarakter.Elem = Console.ReadLine();

                    Console.Write("Életkor: ");
                    ujKarakter.Eletkor = int.Parse(Console.ReadLine());

                    Console.Write("Expedíció tag (true/false): ");
                    ujKarakter.ExpedicioTag = bool.Parse(Console.ReadLine());

                    break; // Sikeres adatbevitel, kilépünk a ciklusból
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hibás adat, próbáld újra! " + ex.Message);
                }
            }

            karakterek.Add(ujKarakter);

            if (karakterek.Contains(ujKarakter))
            {
                Console.WriteLine("\nÚj karakter hozzáadva: " + ujKarakter.Nev);
            }
            else
            {
                Console.WriteLine("\nHiba történt az új karakter hozzáadásakor.");
            }

            // 9.Átlag életkor

            double atlagEletkor = karakterek.Average(k => k.Eletkor);
            Console.WriteLine("\nÁtlag életkor: " + atlagEletkor);

            // 10.Kik azok akiknek "Tuz" az eleme!

            Console.WriteLine("\n'Tuz' elemű karakterek:");
            foreach (var k in karakterek)
            {
                if (k.Elem == "Tuz")
                {
                    Console.WriteLine(k.Nev);
                }
            }
        }
    }
}
