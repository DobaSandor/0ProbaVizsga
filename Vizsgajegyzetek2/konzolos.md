# Konzolos alkalmazás – C# + LINQ

---

## 1. Adatosztály és betöltés (CSV)

```csharp
public class Szuperhos
{
    public string Nev { get; set; }
    public string Kepesseg { get; set; }
    public int Eroszint { get; set; }
    public string CsapatNeve { get; set; }
    public int KuldetesekSzama { get; set; }

    public Szuperhos(string sor)
    {
        string[] s = sor.Split(';');
        Nev = s[0];
        Kepesseg = s[1];
        Eroszint = int.Parse(s[2]);
        CsapatNeve = s[3];
        KuldetesekSzama = int.Parse(s[4]);
    }

    public static List<Szuperhos> LoadFromCSV(string fajlnev)
    {
        return File.ReadAllLines(fajlnev).Select(sor => new Szuperhos(sor)).ToList();
    }
}
```

---

## 2. LINQ lekérdezések (Példák)

### Megszámlálás (`Count`)
```csharp
int count = szuperhosok.Count(h => h.Kepesseg == "Viltrumite erő");
```

### Csoportosítás (`GroupBy`)
```csharp
var csapatok = szuperhosok.GroupBy(h => h.CsapatNeve)
    .Select(g => new { Csapat = g.Key, Szam = g.Count() })
    .OrderBy(c => c.Csapat);
```

### Szűrés és Átlag (`Where` + `Average`)
```csharp
double atlag = szuperhosok.Where(h => h.Kepesseg == "Mutáns").Average(h => h.Eroszint);
Console.WriteLine($"{atlag:F2}"); // 2 tizedesjegy!
```

### Rendezés és Első (`OrderBy` + `FirstOrDefault`)
```csharp
var leggyengebbMutans = szuperhosok
    .Where(h => h.Kepesseg == "Mutáns")
    .OrderBy(h => h.KuldetesekSzama)
    .FirstOrDefault();
```

---

## 3. Konzolos Input/Output
```csharp
Console.Write("Adj meg egy nevet: ");
string nev = Console.ReadLine();
Console.WriteLine($"Üdvözöllek, {nev}!");
```

---

## 4. LINQ gyorslista (Gyakori műveletek)

| Feladat | LINQ metódus |
|---|---|
| Darabszám | `.Count` vagy `.Count()` |
| Szűrés | `.Where(k => feltétel)` |
| Rendezés | `.OrderBy(k => k.Mezo)` / `.OrderByDescending()` |
| Átlag | `.Average(k => k.Mezo)` |
| Maximum / Minimum | `.Max()` / `.Min()` |
| Max / Min elem | `.MaxBy(k => k.Mezo)` / `.MinBy(k => k.Mezo)` |
| Csoportosítás | `.GroupBy(k => k.Mezo)` |
| Első találat | `.First()` / `.FirstOrDefault()` |
| Megtalálható-e? | `.Any(k => feltétel)` |

---

## 5. Kerekítés és formázás

```csharp
double atlag = 82.333;

// 2 tizedesre kerekítve szövegként (interpoláció):
Console.WriteLine($"{atlag:F2}");       // "82.33"

// Math.Round-al:
Console.WriteLine(Math.Round(atlag, 2));

// Újsor karakter:
Console.WriteLine("Első sor\nMásodik sor");
```

---

## 6. Teljes projekt felállítás (Checklist)

1. Visual Studio -> New Project -> **Console App**
2. Add -> Class -> `Szuperhos.cs` (adattagok + konstruktor + LoadFromCSV)
3. Adatfájl (txt/csv) -> Properties -> **Copy to Output Directory: Copy always**
4. `Program.cs` -> Lista betöltése -> Feladatok megoldása LINQ-val
5. Futtatás: `Ctrl+F5`
