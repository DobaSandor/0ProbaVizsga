# Reszponziv Web – Bootstrap 5

---

## 1. Alap HTML szerkezet (Bootstrap CDN)

```html
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" href="./style.css">
</head>
```

---

## 2. Navbar (Bootstrap)

```html
<nav class="navbar navbar-expand-lg navbar-dark bg-dark">
    <div class="container-fluid">
        <a class="navbar-brand" href="index.html">Szuperhős Akadémia</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
            <ul class="navbar-nav">
                <li class="nav-item"><a class="nav-link active" href="index.html">Főoldal</a></li>
                <li class="nav-item"><a class="nav-link" href="heroes.html">Szuperhősök</a></li>
            </ul>
        </div>
    </div>
</nav>
```

---

## 3. Kártyák és rácsrendszer (`Cards` & `Grid`)

```html
<div class="row">
    <div class="col-md-4 mb-4">
        <div class="card h-100 bg-dark text-white">
            <div class="card-body text-center">
                <h5 class="card-title">⚡ Hősök</h5>
                <p class="card-text">Ismerd meg az akadémia szuperhőseit.</p>
                <a href="heroes.html" class="btn btn-success">Böngészés</a>
            </div>
        </div>
    </div>
</div>
```

---

## 4. Egyedi CSS (Háttérkép)

```css
body {
    background-image: url('./heroes_bg.png') !important;
    background-repeat: no-repeat !important;
    background-size: cover !important;
}

.card {
    background-color: rgb(32, 32, 32) !important;
    color: white !important;
}
```

> **FONTOS:** Használj `!important`-ot a Bootstrap alapértelmezett értékeinek felülírásához!
> A saját CSS-edet a Bootstrap linkje **után** kösd be a head-ben!

---

## 5. Összefoglaló táblázat

| Feladat | Megoldás |
|---|---|
| CSS felülírja Bootstrap-et | Saját `<link>` utána + `!important` |
| Háttérkép nem ismétlődik | `background-repeat: no-repeat !important` |
| Háttérkép kitölti a képernyőt | `background-size: cover !important` |
| Aktív menüpont | `class="nav-link active"` |
| Fehér szöveg | `class="text-white"` |
| Kétoszlopos form rács | `<form class="row">` + `<div class="col-sm">` |
| Kötelező mező | `required` attribútum |
