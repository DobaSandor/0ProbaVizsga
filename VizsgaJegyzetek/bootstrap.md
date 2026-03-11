# Bootstrap 5 – Osztály Gyorslista

---

## Layout / Elrendezés

```html
<!-- Container -->
<div class="container">          <!-- fix szélesség, középre -->
<div class="container-fluid">    <!-- teljes szélesség -->

<!-- Grid: 12 oszlopos rendszer -->
<div class="row">
    <div class="col">...</div>           <!-- egyenlő széles -->
    <div class="col-sm">...</div>        <!-- kis képernyőtől -->
    <div class="col-md-6">...</div>      <!-- 12-ből 6 oszlop -->
    <div class="col-sm-6 col-md-4">...</div>  <!-- reszponzív -->
</div>
```

---

## Margó és Padding

```
m  = margin    |  p  = padding
t  = top       |  b  = bottom
s  = start(left)| e  = end(right)
x  = left+right|  y  = top+bottom

Méret: 0–5, auto

mt-3  = margin-top: 1rem
mb-3  = margin-bottom
mx-auto = vízszintes középre igazítás
p-3   = padding minden irányban
pt-5  = padding-top nagy
```

---

## Szín

```html
<!-- Szövegszín -->
<p class="text-white">...</p>
<p class="text-dark">...</p>
<p class="text-primary">...</p>     <!-- kék -->
<p class="text-success">...</p>     <!-- zöld -->
<p class="text-danger">...</p>      <!-- piros -->
<p class="text-muted">...</p>       <!-- szürke -->

<!-- Háttérszín -->
<div class="bg-dark">...</div>
<div class="bg-primary">...</div>
<div class="bg-light">...</div>
<div class="bg-white">...</div>
```

---

## Kártya (Card)

```html
<div class="card">
    <div class="card-header bg-primary text-white">
        <h5>Cím</h5>
    </div>
    <div class="card-body">
        <p class="card-text">Szöveg</p>
        <a href="#" class="btn btn-primary">Gomb</a>
    </div>
    <div class="card-footer text-muted">Lábléc</div>
</div>
```

---

## Gomb (Button)

```html
<button type="button" class="btn btn-primary">Kék</button>
<button type="button" class="btn btn-success">Zöld</button>
<button type="button" class="btn btn-danger">Piros</button>
<button type="button" class="btn btn-secondary">Szürke</button>
<button type="button" class="btn btn-outline-primary">Körvonal</button>
<button type="submit" class="btn btn-primary w-100">Teljes széles</button>

<!-- Méret -->
<button class="btn btn-primary btn-lg">Nagy</button>
<button class="btn btn-primary btn-sm">Kicsi</button>

<!-- Link-ként -->
<a href="oldal.html" class="btn btn-primary" role="button">Link gomb</a>
```

---

## Navigáció (Navbar)

```html
<nav class="navbar navbar-expand-lg navbar-dark bg-dark">
    <div class="container-fluid">
        <a class="navbar-brand" href="#">Brand</a>
        <div class="collapse navbar-collapse">
            <ul class="navbar-nav">
                <li class="nav-item">
                    <a class="nav-link active" href="index.html">Főoldal</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="masik.html">Másik oldal</a>
                </li>
            </ul>
        </div>
    </div>
</nav>
```

---

## Űrlap (Form)

```html
<form>
    <!-- Szöveges mező -->
    <div class="mb-3">
        <label for="nev" class="form-label">Név</label>
        <input type="text" class="form-control" id="nev" placeholder="Ide írj">
    </div>

    <!-- Szám mező -->
    <div class="mb-3">
        <label for="szam" class="form-label">Szám</label>
        <input type="number" class="form-control" id="szam">
    </div>

    <!-- Legördülő -->
    <div class="mb-3">
        <label for="valaszt" class="form-label">Válassz</label>
        <select class="form-select" id="valaszt" required>
            <option value="" disabled selected>-- Válassz --</option>
            <option value="1">Első</option>
            <option value="2">Második</option>
        </select>
    </div>

    <!-- Checkbox -->
    <div class="form-check mb-3">
        <input class="form-check-input" type="checkbox" id="check">
        <label class="form-check-label" for="check">Elfogadom</label>
    </div>

    <button type="submit" class="btn btn-primary">Küldés</button>
</form>
```

---

## Szöveg igazítás / formázás

```html
<p class="text-center">Középre</p>
<p class="text-start">Balra</p>
<p class="text-end">Jobbra</p>

<h1 class="display-1">Nagy főcím</h1>
<p class="lead">Kiemelt bevezető szöveg</p>
<strong>Félkövér</strong>
<em>Dőlt</em>
```

---

## Egyéb hasznos osztályok

```html
<!-- Szélesség -->
<div class="w-100">Teljes széles</div>
<div class="w-50">Fél széles</div>

<!-- Border -->
<div class="border">Keret</div>
<div class="border border-primary rounded">Lekerekített kék keret</div>

<!-- Láthatóság -->
<div class="d-none">Rejtett</div>
<div class="d-block">Látható</div>
<div class="d-flex justify-content-center align-items-center">Flex középre</div>

<!-- Shadow -->
<div class="shadow">Árnyék</div>
<div class="shadow-lg">Nagy árnyék</div>

<!-- Padding shorthand -->
<div class="p-5 text-center">Nagy padding, középre igazított szöveg</div>
```

---

## Alert (Hibaüzenet doboz)

```html
<div class="alert alert-danger" role="alert">Hiba történt!</div>
<div class="alert alert-success">Sikeres!!</div>
<div class="alert alert-warning">Figyelem!</div>
<div class="alert alert-info">Információ</div>
```

---

## Bootstrap CDN link (head-be)

```html
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
```