# Tailwind – className Gyorslista (React)

> Tailwind-ben CSS osztályokat a `className="..."` attribútumba kell írni JSX-ben

---

## Layout / Elrendezés

```jsx
// Flex
<div className="flex">...</div>
<div className="flex flex-col">...</div>          // oszlop irány
<div className="flex justify-center">...</div>     // vízszintes közép
<div className="flex justify-between">...</div>    // szétszórva
<div className="flex items-center">...</div>       // függőleges közép
<div className="flex gap-4">...</div>              // elemek közötti rés

// Grid
<div className="grid grid-cols-2 gap-4">...</div>  // 2 oszlop
<div className="grid grid-cols-3 gap-6">...</div>  // 3 oszlop

// Container
<div className="container mx-auto">...</div>       // középre igazított konténer
<div className="max-w-xl mx-auto">...</div>        // max szélesség + középre
```

---

## Margó és Padding

```
m = margin    p = padding
t = top       b = bottom
l = left      r = right
x = bal+jobb  y = fel+le

Méret: 0, 1(4px), 2(8px), 3(12px), 4(16px), 5(20px), 6(24px), 8(32px), 10, 12, 16...

mt-4  = margin-top: 1rem
mb-2  = margin-bottom: 0.5rem
mx-auto = vízszintes auto margin (középre)
px-6  = padding left + right
py-4  = padding top + bottom
p-5   = padding minden irányban
```

---

## Szín

```jsx
// Szövegszín
<p className="text-white">...</p>
<p className="text-gray-800">...</p>
<p className="text-blue-500">...</p>
<p className="text-red-600">...</p>
<p className="text-green-500">...</p>

// Háttérszín
<div className="bg-gray-900">...</div>    // sötétszürke
<div className="bg-blue-600">...</div>    // kék
<div className="bg-white">...</div>
<div className="bg-black">...</div>
<div className="bg-black/60">...</div>    // fekete 60% átlátszósággal
```

---

## Szöveg

```jsx
<h1 className="text-4xl font-bold">Nagy cím</h1>
<h2 className="text-2xl font-semibold">Alcím</h2>
<p className="text-lg">Nagy szöveg</p>
<p className="text-sm text-gray-500">Kis szürke</p>

// Igazítás
<p className="text-center">Középre</p>
<p className="text-left">Balra</p>
<p className="text-right">Jobbra</p>

// Vastagság
<p className="font-bold">Félkövér</p>
<p className="font-normal">Normál</p>
<p className="italic">Dőlt</p>
```

---

## Szélesség / Magasság

```jsx
<div className="w-full">...</div>        // 100%
<div className="w-1/2">...</div>         // 50%
<div className="w-64">...</div>          // 16rem (256px)
<div className="h-screen">...</div>      // 100vh
<div className="h-full">...</div>        // 100%
<div className="min-h-screen">...</div>  // min 100vh
```

---

## Border és Árnyék

```jsx
<div className="border border-gray-300 rounded">...</div>
<div className="border-2 border-blue-500 rounded-lg">...</div>
<div className="rounded-full">...</div>     // köralak (pl. avatar)
<div className="shadow-md">...</div>
<div className="shadow-xl">...</div>
```

---

## Gomb stílusok

```jsx
// Elsődleges
<button className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700">
  Küldés
</button>

// Másodlagos
<button className="bg-gray-200 text-gray-800 px-4 py-2 rounded hover:bg-gray-300">
  Mégse
</button>

// Veszélyes (törlés)
<button className="bg-red-500 text-white px-4 py-2 rounded hover:bg-red-600">
  Törlés
</button>

// Teljes széles
<button className="w-full bg-green-600 text-white py-2 rounded">
  Hozzáadás
</button>
```

---

## Input mező

```jsx
<input
  type="text"
  className="border border-gray-300 rounded px-3 py-2 w-full focus:outline-none focus:border-blue-500"
  placeholder="Ide írj..."
/>

<select className="border border-gray-300 rounded px-3 py-2 w-full">
  <option value="" disabled selected>-- Válassz --</option>
  <option value="1">Első</option>
</select>
```

---

## Kártya (card sablon)

```jsx
<div className="bg-white shadow-md rounded-lg p-6 max-w-md mx-auto mt-8">
  <h2 className="text-xl font-bold mb-4">Kártya cím</h2>
  <p className="text-gray-600">Tartalom</p>
</div>
```

---

## Navigáció sablon

```jsx
<nav className="bg-gray-900 text-white px-6 py-4 flex justify-between items-center">
  <span className="text-xl font-bold">Logo</span>
  <div className="flex gap-6">
    <a href="/" className="hover:text-blue-400">Főoldal</a>
    <a href="/hosok" className="hover:text-blue-400">Hősök</a>
    <a href="/uj-hos" className="hover:text-blue-400">Új Hős</a>
  </div>
</nav>
```

---

## Háttérkép (inline style Tailwind-del)

```jsx
// Kép a public/ mappában
<div
  className="bg-cover bg-center bg-no-repeat min-h-screen"
  style={{ backgroundImage: "url('/castle_bg.jpg')" }}
>
  ...tartalom...
</div>
```

---

## Hibaüzenet / Toast sablon (useState-el)

```jsx
{showError && (
  <div className="bg-red-100 border border-red-400 text-red-700 px-4 py-3 rounded relative mt-4">
    <span>Sikertelen adatküldés</span>
    <button className="absolute top-2 right-2" onClick={() => setShowError(false)}>×</button>
  </div>
)}
```

---

## Hover effektek

```jsx
className="hover:bg-blue-700"       // hover háttér
className="hover:text-white"        // hover szöveg
className="hover:shadow-lg"         // hover árnyék
className="transition duration-300" // animált átmenet
```

---

## Reszponzív (breakpoint prefix)

```
sm:  = 640px+
md:  = 768px+
lg:  = 1024px+
xl:  = 1280px+

Példa:
className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3"
className="text-sm md:text-base lg:text-lg"
className="hidden md:block"   // mobilon rejtett, tablettől látható
```