using System.Collections.Generic;
using System.Threading;

namespace Karakterek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Karakter> karakterek = Karakter.LoadFromCSV("characters.txt");

            // Hány karakter adatait tároljuk a fájlban?
            Console.WriteLine("Karakterek száma: " + karakterek.Count + "\n");

            // 4. Kasztonkénti darakszám
            Console.WriteLine("Kasztonkénti darabszám:");

            var csoportositas = karakterek.GroupBy(k => k.Kaszt);
            Console.WriteLine(
                string.Join("\n", csoportositas.Select(g => $"{g.Key}: {g.Count()} fő"))
            );

            // 5. 75 feletti tudásszintű karakterek:
            // Nev - KlanNeve - Tudasszint

            Console.WriteLine("\n75 feletti tudásszintű karakterek:");
            var magasTudasszint = karakterek.Where(k => k.Tudasszint > 75);
            Console.WriteLine(
                string.Join(
                    "\n",
                    magasTudasszint.Select(
                        k => $"{k.Nev} - {k.KlanNeve} - Tudásszint: {k.Tudasszint}"
                    )
                )
            );

            // 6. Főnix Rendje átlag tudásszint
            Console.WriteLine(
                "\nFőnix Rendje átlag tudásszint: " +
                    karakterek
                        .Where(k => k.KlanNeve == "Főnix Rendje")
                        .Average(k => k.Tudasszint)
            );

            // 7. Legkevesebb XP-s Harcos: Nev - XP: XP
            var harcosok = karakterek.Where(k => k.Kaszt == "Harcos");
            var legkevesebbXP = harcosok.Min(k => k.XP);
            var legkevesebbXPHarcos = harcosok.First(k => k.XP == legkevesebbXP);
            Console.WriteLine(
                "\nLegkevesebb XP-s Harcos: " +
                    $"{legkevesebbXPHarcos.Nev} - XP: {legkevesebbXPHarcos.XP}"
            );

            // 8. Klán lekérdezése név alapján:
            // Adj meg egy karakter nevet: [INPUT]
            // [Nev] klánja: [KlanNeve]

            Console.WriteLine("Adj meg egy karakter nevet: ");
            var karakterNeve = Console.ReadLine();

            if ( karakterNeve != "" )
            {
                Console.WriteLine($"{karakterNeve} klánja: ");
            }
            else
            {
                Console.WriteLine("Nem adott meg nevet");
            }

        }
    }
}

