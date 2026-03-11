# Konzolos – C# Visual Studio

---

## 1. Projekt létrehozása

Visual Studio → **Console App** 
Projekt neve: `karakterek` (vagy amit a feladat kér)

---

## 2. Osztály létrehozása – `Karakter.cs`

> Jobb klikk a projektre → **Add → Class** → `Karakter.cs`

```csharp
using System;
using System.Collections.Generic;

namespace Karakterek
{
    internal class Karakter
    {
        // Adattagok (properties)
        public string Nev { get; set; }
        public string Kaszt { get; set; }
        public int Tudasszint { get; set; }
        public string KlanNeve { get; set; }
        public int XP { get; set; }

        // Konstruktor – egy sort kap paraméterként (pl. "Aragorn;Harcos;95;Kósza Klán;15000")
        public Karakter(string sor)
        {
            string[] s = sor.Split(';');   // pontosvesszővel szétválaszt
            try
            {
                Nev         = s[0];
                Kaszt       = s[1];
                Tudasszint  = int.Parse(s[2]);
                KlanNeve    = s[3];
                XP          = int.Parse(s[4]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba beolvasáskor: " + ex.Message);
            }
        }

        // Statikus metódus – beolvassa a fájlt és visszaadja a listát
        public static List<Karakter> LoadFromCSV(string fajlnev)
        {
            List<Karakter> karakterek = new();

            try
            {
                string[] sorok = File.ReadAllLines(fajlnev);
                for (int i = 0; i < sorok.Length; i++) // i = 1, ha a fájl első sorát nem akarjuk beolvasni
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

        // 8. feladat: metódus – nevet kap, visszaadja a klán nevét
        public static string GetKlan(List<Karakter> karakterek, string nev)
        {
            var karakter = karakterek.FirstOrDefault(k => k.Nev == nev);
            if (karakter != null)
                return karakter.KlanNeve;
            else
                return "Nem található!";
        }
    }
}
```

---

## 3. `Program.cs` – Főprogram sablon

```csharp
namespace Karakterek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Fájl beolvasása
            List<Karakter> karakterek = Karakter.LoadFromCSV("characters.txt");

            // === FELADATOK IDE JÖNNEK ===
        }
    }
}
```

> A `characters.txt` fájlt a bin mappába másoljuk át

---

## 4. LINQ műveletek – feladatonként

### Darabszám (Count)
```csharp
Console.WriteLine("Karakterek száma: " + karakterek.Count);
```

---

### Csoportosítás (GroupBy) – kasztonkénti darabszám, névsor szerint rendezve

```csharp
var csoportositas = karakterek
    .GroupBy(k => k.Kaszt)
    .OrderBy(g => g.Key);   // növekvő sorrend a kaszt neve szerint

foreach (var csoport in csoportositas)
{
    Console.WriteLine($"{csoport.Key}: {csoport.Count()} fő");
}
```

---

### Szűrés (Where) – feltétel alapján lista

```csharp
// 75-öt meghaladó tudásszintűek
var magasTudasszint = karakterek.Where(k => k.Tudasszint > 75);

foreach (var k in magasTudasszint)
{
    Console.WriteLine($"{k.Nev} - {k.KlanNeve} - Tudásszint: {k.Tudasszint}");
}
```

---

### Átlag (Average) – szűrés + átlag, kerekítve

```csharp
double atlag = karakterek
    .Where(k => k.KlanNeve == "Főnix Rendje")
    .Average(k => k.Tudasszint);

Console.WriteLine($"Főnix Rendje átlag tudásszint: {atlag:F2}");  // F2 = 2 tizedes
```

---

### Minimum érték keresése (Min + First) – legkisebb XP-s Harcos

```csharp
var harcosok = karakterek.Where(k => k.Kaszt == "Harcos");
var legkevesebbXP = harcosok.Min(k => k.XP);
var legkevesebbXPHarcos = harcosok.First(k => k.XP == legkevesebbXP);

Console.WriteLine($"Legkevesebb XP-s Harcos: {legkevesebbXPHarcos.Nev} - XP: {legkevesebbXPHarcos.XP}");
```

---

### Metódus hívása + felhasználói bevitel

```csharp
// 8. feladat: klán lekérdezése név alapján
Console.WriteLine("Adj meg egy karakter nevet:");
string karakterNeve = Console.ReadLine();

string klan = Karakter.GetKlan(karakterek, karakterNeve);
Console.WriteLine($"{karakterNeve} klánja: {klan}");
```

---

## 5. LINQ gyorslista

| Feladat | LINQ metódus |
|---|---|
| Darabszám | `.Count` vagy `.Count()` |
| Szűrés | `.Where(k => feltétel)` |
| Rendezés növekvő | `.OrderBy(k => k.Mezo)` |
| Rendezés csökkenő | `.OrderByDescending(k => k.Mezo)` |
| Átlag | `.Average(k => k.Mezo)` |
| Összeg | `.Sum(k => k.Mezo)` |
| Maximum | `.Max(k => k.Mezo)` |
| Minimum | `.Min(k => k.Mezo)` |
| Max elem | `.MaxBy(k => k.Mezo)` |
| Min elem | `.MinBy(k => k.Mezo)` |
| Csoportosítás | `.GroupBy(k => k.Mezo)` |
| Első találat | `.First(k => feltétel)` |
| Első v. null | `.FirstOrDefault(k => feltétel)` |
| Megtalálható-e? | `.Any(k => feltétel)` |

---

## 6. Kerekítés és formázás

```csharp
double atlag = 82.333;

// 2 tizedesre kerekítve szövegként:
Console.WriteLine($"{atlag:F2}");       // "82.33"

// Math.Round-al:
Console.WriteLine(Math.Round(atlag, 2));
```

---

## 7. String formázás

```csharp
string nev = "Aragorn";
int xp = 15000;

// String interpoláció (ajánlott):
Console.WriteLine($"{nev} XP-je: {xp}");

// Újsor karakter:
Console.WriteLine("Első sor\nMásodik sor");

// Üres sor:
Console.WriteLine();
```

---

## 8. Fájlbeolvasás

```csharp
List<Karakter> karakterek = Karakter.LoadFromCSV("characters.txt");
```

---

## 9. Teljes projekt felállítás

```
1.  Visual Studio → New Project → Console App
2.  Projekt neve: karakterek (amit kér a feladat)
3.  Add → Class → Karakter.cs (adattagok + konstruktor + LoadFromCSV)
4.  characters.txt → Properties → Copy to Output Directory: Copy always
5.  Program.cs → List<Karakter> karakterek = Karakter.LoadFromCSV("characters.txt")
6.  Feladatok megoldása LINQ-al
7.  Futtatás: Ctrl+F5
```