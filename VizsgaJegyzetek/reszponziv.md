# Reszponzív – HTML + CSS + Bootstrap 5

---

## 1. `<head>` sablon – Bootstrap + saját CSS sorrendje

```html
<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>[Oldal cím]</title>
    <!-- 1. Bootstrap ELŐBB -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- 2. Saját CSS UTÁNA (hogy felülírja a Bootstrap-et) -->
    <link rel="stylesheet" href="./[fantasy_style.css]">
</head>
```

---

## 2. `fantasy_style.css` – Háttérkép + `!important`

```css
body {
    background-image: url('./[castle_bg.jpg]') !important;
    background-repeat: no-repeat !important;
    background-size: cover !important;
}

nav {
    padding: 14px !important;
}
```

> **`!important` kötelező!** mert ha nincs ott akkor a bootstrap felülírja

---

## 3. Navigáció (Bootstrap navbar)

```html
<nav class="navbar navbar-expand-lg navbar-dark bg-dark">
    <div class="container-fluid">
        <a class="navbar-brand" href="index.html">[Weboldal neve]</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link active" href="index.html">Főoldal</a>  <!-- active = aktuális oldal -->
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="heroes.html">Hősök</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="newrecruit.html">Új toborzás</a>
                </li>
            </ul>
        </div>
    </div>
</nav>
```

---

## 4. Kártya (card) átlátszó sötét háttérrel

```html
<div class="container mt-5 card bg-dark">
    <div class="p-5 text-center">
        <h1 class="display-4 text-white">[Cím]</h1>
        <p class="lead text-white">[Alcím]</p>
        <hr class="my-4 bg-white">
        <p class="text-white">[Szöveg]</p>

        <a class="btn btn-primary btn-lg" href="./heroes.html" role="button">Belépés a Csarnokba</a>
        <a class="btn btn-success btn-lg" href="./newrecruit.html" role="button">Új Hős</a>
    </div>
</div>
```

> Vagy CSS-ből átlátszó háttér:
> ```css
> .card { background-color: rgba(0, 0, 0, 0.6) !important; }
> ```

---

## 5. Kétoszlopos űrlap (Bootstrap grid – reszponzív)

```html
<div class="container mt-5">
    <div class="card">
        <div class="card-header bg-primary text-white">
            <h3>Új elem felvétele</h3>
        </div>
        <div class="card-body container">
            <form action="#" method="post" class="row">

                <!-- Oszlop 1 -->
                <div class="mb-3 col-sm">
                    <label for="nev" class="form-label">Név</label>
                    <input type="text" class="form-control" id="nev" placeholder="Hős neve">
                </div>

                <!-- Oszlop 2 -->
                <div class="mb-3 col-sm">
                    <label for="szarmazas" class="form-label">Származás</label>
                    <input type="text" class="form-control" id="szarmazas" placeholder="Származási hely">
                </div>

                <!-- Legördülő (select) – Kaszt -->
                <div class="mb-3 col-sm">
                    <label for="kaszt" class="form-label">Kaszt</label>
                    <select class="form-select" id="kaszt" required>
                        <option value="" disabled selected>Válassz kasztot...</option>
                        <option value="harcos">Harcos</option>
                        <option value="magus">Mágus</option>
                        <option value="ijasz">Íjász</option>
                        <option value="tolvaj">Tolvaj</option>
                        <option value="pap">Pap</option>
                        <option value="barbar">Barbár</option>
                    </select>
                </div>

                <!-- Szám mező -->
                <div class="mb-3">
                    <label for="szint" class="form-label">Kezdő Szint</label>
                    <input type="number" class="form-control" id="szint" placeholder="Kezdő szint">
                </div>

                <!-- Submit gomb -->
                <button type="submit" class="btn btn-primary mt-3 w-100">Toborzás</button>

            </form>
        </div>
    </div>
</div>
```

---

## 6. Legördülő lista (select) – helyes Bootstrap módja

```html
<!-- form-select a Bootstrap-es stílushoz -->
<select class="form-select" id="[kaszt]" required>
    <option value="" disabled selected>Válassz kasztot...</option>   <!-- disabled + selected = alapértelmezett -->
    <option value="[harcos]">[Harcos]</option>
    <option value="[magus]">[Mágus]</option>
</select>
```

> `disabled` = nem választható  
> `selected` = ez jelenik meg alapból  
> `required` = kötelező kitölteni

---

## 7. Összefoglalás

| Feladat | Megoldás |
|---|---|
| CSS felülírja Bootstrap-et | Saját `<link>` Bootstrap link **után**, + `!important` a CSS-ben |
| Háttérkép, ne ismétlődjön | `background-repeat: no-repeat !important` |
| Háttérkép töltse ki | `background-size: cover !important` |
| Nav padding | `nav { padding: 14px !important; }` |
| Aktív nav elem | `class="nav-link active"` az adott oldalon |
| Kártya sötét háttér | `class="card bg-dark"` vagy RGBA CSS |
| Fehér szöveg | `class="text-white"` |
| Kétoszlopos form | `<form class="row">` + `<div class="col-sm">` |
| Default select opció | `<option disabled selected>` |
| Szám input | `type="number"` |
| Submit gomb | `type="submit"` |