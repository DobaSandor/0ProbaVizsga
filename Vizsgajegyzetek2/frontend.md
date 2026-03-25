# Frontend – React + Vite + Tailwind (Szuperhősök példa)

---

## 1. App.jsx – Router és Navigáció

```jsx
import { Routes, Route } from 'react-router'
import Home from './pages/Home'
import Hosok from './pages/Hosok'
import UjHos from './pages/UjHos'

function App() {
  return (
    <>
      <nav className='gap-6 flex justify-center pb-5 text-xl'>
        <a href="/">Főoldal</a>
        <a href="/hosok">Hősök</a>
        <a href="/uj-hos">Új Hős</a>
      </nav>

      <Routes>
        <Route path="/"        element={<Home />} />
        <Route path="/hosok"   element={<Hosok />} />
        <Route path="/uj-hos"  element={<UjHos />} />
      </Routes>
    </>
  )
}
```

---

## 2. Adatok lekérése (`fetch` + `useEffect`)

```jsx
import { useState, useEffect } from 'react'

const Hosok = () => {
  const [hosok, setHosok] = useState([])

  useEffect(() => {
    fetch('http://localhost:3080/api/szuperhosok')
      .then(res => res.json())
      .then(data => setHosok(data))
  }, [])

  return (
    <div className="grid grid-cols-3 gap-4">
      {hosok.map(hos => (
        <div key={hos.id} className="border p-4 rounded shadow">
          <h2 className="text-xl font-bold">{hos.szuperhos_nev}</h2>
          <p>Valódi név: {hos.valodi_nev}</p>
          <ul>
            {hos.kepessegek?.map(k => (
              <li key={k.id}>{k.kepesseg_neve} (Szint: {k.ero_szint})</li>
            ))}
          </ul>
        </div>
      ))}
    </div>
  )
}
```

---

## 3. Új adat felvétele (Form handling)

```jsx
const [formData, setFormData] = useState({
  szuperhos_nev: '',
  valodi_nev: '',
  kiado: '',
  szekhely: '',
  elso_megjelenes: ''
})

const handleSubmit = async (e) => {
  e.preventDefault();
  const res = await fetch('http://localhost:3080/api/szuperhosok', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData)
  });

  if (res.status === 201) {
    navigate('/hosok');
  }
}
```

---

## 4. Tailwind hasznos osztályok
- `flex justify-center`: középre rendezés
- `grid grid-cols-3`: 3 oszlopos elrendezés
- `gap-4`: távolság az elemek között
- `pb-5`: alsó padding

---

## 5. Teljes projekt felállítás (Checklist)

### 1. Projekt létrehozása (Terminál):
```bash
npm create vite@latest
# --- Lépj be a mappába, majd: ---
npm install
npm install tailwindcss @tailwindcss/vite
npm i react-router
```

### 2. Konfiguráció:
1. `vite.config.js` -> `plugins: [react(), tailwindcss()]`
2. `index.css` -> `@import "tailwindcss";`
3. `main.jsx` -> `BrowserRouter` wrap
4. `src/pages/` mappa + komponensek (rafce)
5. `App.jsx` -> `Routes` + `Route` + navigáció
6. `npm run dev`

---

## 6. Gyorslista – Import-ok

```jsx
import { useState, useEffect } from 'react'
import { useNavigate } from 'react-router'
import { Routes, Route } from 'react-router'
import { Link } from 'react-router'
import { BrowserRouter } from 'react-router'
```

---

## 7. Fetch összefoglaló

```js
// GET
const res = await fetch(url)
const data = await res.json()

// POST
const res = await fetch(url, {
  method: 'POST',
  headers: { 'Content-Type': 'application/json' },
  body: JSON.stringify(data),
})

// Ellenőrzés
if (res.status === 201) { /* Created */ }
if (res.ok) { /* 200-299 */ }
```
