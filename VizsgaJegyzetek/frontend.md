# Frontend – React + Vite + Tailwind + React Router

---

## 1. Projekt létrehozása

```bash
npm create vite@latest              # interaktív, nevet is megad
```

Ezután:

```bash
cd Vezeteknev_Keresztnev_frontend
npm install
```

---

## 2. Tailwind telepítése

```bash
npm install tailwindcss @tailwindcss/vite
```

### `vite.config.js` módosítása:

```js
import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import tailwindcss from '@tailwindcss/vite'   // !

export default defineConfig({
  plugins: [
    react(),
    tailwindcss(),   // !
  ],
})
```

### `src/index.css` elejére:

```css
@import "tailwindcss";
```

---

## 3. React Router telepítése és setup

```bash
npm i react-router
```

### `src/main.jsx`:

```jsx
import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.jsx'
import { BrowserRouter } from 'react-router'   // !

createRoot(document.getElementById('root')).render(
  <BrowserRouter>
    <App />
  </BrowserRouter>,
)
```

---

## 4. Oldalak (komponensek) létrehozása

Mappa: `src/pages/` → fájlok: `Home.jsx`, `Hosok.jsx`, `UjHos.jsx`

Sablon gyorsbillentyű: **`rafce`** (ES7+ React Snippets extension kell!)

```jsx
// pl. src/pages/Home.jsx
import React from 'react'

const Home = () => {
  return (
    <div>
      Home oldal
    </div>
  )
}

export default Home
```

---

## 5. `App.jsx` – Routing és navigáció

```jsx
import './App.css'
import { Routes, Route } from 'react-router'
import Home from './pages/Home'
import Hosok from './pages/Hosok'
import UjHos from './pages/UjHos'

function App() {
  return (
    <>
      {/* Navigáció */}
      <nav>
        <a href="/">Főoldal</a>
        <a href="/hosok">Hősök</a>
        <a href="/uj-hos">Új Hős</a>
      </nav>

      {/* Routing */}
      <Routes>
        <Route path="/"        element={<Home />} />
        <Route path="/hosok"   element={<Hosok />} />
        <Route path="/uj-hos"  element={<UjHos />} />
      </Routes>
    </>
  )
}

export default App
```

> Navigációban: `<Link to="/hosok">` komponens (react-router), nem csak `<a href>` jó.

---

## 6. GET – adatok lekérése és megjelenítése - MAP használata

```jsx
import { useState, useEffect } from 'react'

const Hosok = () => {
  const [hosok, setHosok] = useState([])    // üres tömbből indul

  const getData = async () => {
    const res = await fetch('http://localhost:3080/api/hosok')
    const data = await res.json()
    setHosok(data)
  }

  useEffect(() => {
    getData()    // oldal betöltésekor egyszer lefut
  }, [])

  return (
    <div>
      {hosok.map((hos) => (
        <div key={hos.id}>
          <p>{hos.nev}</p>
          <p>{hos.szarmazas}</p>
          <p>Szint: {hos.szint}</p>
          <p>Kaszt: {hos.kaszt?.nev}</p>   {/* kapcsolt adat */}
        </div>
      ))}
    </div>
  )
}

export default Hosok
```

> `key={hos.id}` – mindig kötelező `.map()`-nél!
> `hos.kaszt?.nev` – opcionális láncolás, ha a kapcsolt obj. null lehet

---

## 7. POST – adatok elküldése + legördülő lista + navigáció

```jsx
import { useState, useEffect } from 'react'
import { useNavigate } from 'react-router'

const UjHos = () => {
  const navigate = useNavigate()

  // Form mezők állapota
  const [formData, setFormData] = useState({
    nev: '',
    szarmazas: '',
    szint: '',
    kasztId: '',
  })

  // Legördülő lista adatai
  const [kasztok, setKasztok] = useState([])

  // Hibaüzenet megjelenítéséhez
  const [showError, setShowError] = useState(false)

  // Kasztok lekérése betöltéskor
  useEffect(() => {
    fetch('http://localhost:3080/api/kasztok')
      .then(res => res.json())
      .then(data => setKasztok(data))
  }, [])

  // Input változás kezelése (minden mezőhöz egységesen)
  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value })
  }

  // Form elküldése
  const handleSubmit = async (e) => {
    e.preventDefault()    // oldal ne töltődjön újra!

    const res = await fetch('http://localhost:3080/api/hosok', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (res.status === 201) {
      navigate('/hosok')      // sikeres → átnavigál
    } else {
      setShowError(true)      // sikertelen → hibaüzenet
    }
  }

  return (
    <div>
      <h1>Új Hős felvétele</h1>

      {/* Hibaüzenet – NEM alert()! */}
      {showError && (
        <div className="error-modal">
          Sikertelen adatküldés
          <button onClick={() => setShowError(false)}>×</button>
        </div>
      )}

      <form onSubmit={handleSubmit}>
        <input
          name="nev"
          value={formData.nev}
          onChange={handleChange}
          placeholder="Hős neve"
        />
        <input
          name="szarmazas"
          value={formData.szarmazas}
          onChange={handleChange}
          placeholder="Származás"
        />
        <input
          name="szint"
          type="number"
          value={formData.szint}
          onChange={handleChange}
          placeholder="Szint"
        />

        {/* Legördülő lista – /api/kasztok végpontból */}
        <select name="kasztId" value={formData.kasztId} onChange={handleChange}>
          <option value="">-- Válassz kasztot --</option>
          {kasztok.map((kaszt) => (
            <option key={kaszt.id} value={kaszt.id}>
              {kaszt.nev}
            </option>
          ))}
        </select>

        <button type="submit">Hozzáadás</button>
      </form>
    </div>
  )
}

export default UjHos
```

---

## 8. Navigálás gombra kattintva

Component: `Navbar.jsx`
```jsx
import { useNavigate } from 'react-router'

const Navbar = () => {
  const navigate = useNavigate()

  return (
    <nav>
      <button onClick={() => navigate('/')}>Főoldal</button>
      <button onClick={() => navigate('/hosok')}>Hősök</button>
      <button onClick={() => navigate('/uj-hos')}>Új Hős</button>
    </nav>
  )
}

export default Navbar
```

Main.jsx:
```jsx
import Navbar from './components/Navbar'
import { Routes, Route } from 'react-router'

function App() {
  return (
    <>
      <Navbar />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/hosok" element={<Hosok />} />
        <Route path="/uj-hos" element={<UjHos />} />
      </Routes>
    </>
  )
}
```

---

## 9. Háttérkép beállítása CSS-sel

```jsx
// inline style-al:
<div style={{ backgroundImage: `url('/castle_bg.jpg')`, backgroundSize: 'cover' }}>

// VAGY Tailwind-del (ha a kép a public/ mappában van):
<div className="bg-cover bg-center" style={{ backgroundImage: "url('/castle_bg.jpg')" }}>
```

> A képeket a `public/` mappába kell másolni, hogy elérhetők legyenek!

---

## 10. Teljes projekt felállítás – lépések sorban

```
1.  Mappa létrehozása / npm create vite@latest --template react
2.  npm install
3.  npm install tailwindcss @tailwindcss/vite
4.  vite.config.js módosítása (tailwindcss plugin)
5.  index.css elejére: @import "tailwindcss";
6.  npm i react-router
7.  main.jsx → BrowserRouter wrap
8.  src/pages/ mappa létrehozása
9.  Komponensek létrehozása (rafce)
10. App.jsx → Routes + Route-ok + navigáció
11. GET végpontok: useState + useEffect + fetch
12. POST végpont: formData state + handleChange + handleSubmit + navigate
13. npm run dev
```

---

## 11. Gyorslista – import-ok

```jsx
import { useState, useEffect } from 'react'       // állapot + betöltés
import { useNavigate } from 'react-router'         // programozott navigáció
import { Routes, Route } from 'react-router'       // routing (App.jsx-ben)
import { Link } from 'react-router'                // navigációs link
import { BrowserRouter } from 'react-router'       // Router wrap (main.jsx-ben)
```

---

## 12. Fetch – módszerek összefoglaló

```js
// GET
const res = await fetch('http://localhost:3080/api/hosok')
const data = await res.json()

// POST
const res = await fetch('http://localhost:3080/api/hosok', {
  method: 'POST',
  headers: { 'Content-Type': 'application/json' },
  body: JSON.stringify({ nev, szarmazas, szint, kasztId }),
})

// Státuszkód ellenőrzése
if (res.status === 201) { /* sikeres */ }
if (res.ok) { /* 200–299 */ }
```