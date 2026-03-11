# Backend – Prisma v6 + Express REST API

---

## 1. Projekt létrehozása

```bash
# Projekt mappa neve: Vezeteknev_Keresztnev_backend VAGY amit kérnek
npm init -y
npm install express cors nodemon
npm install -D prisma@6
npx prisma init --datasource-provider mysql --output ../generated/prisma
```

> `prisma.config.ts` fájlt **töröld ki** ha létrejött!

---

## 2. `package.json` – kötelező beállítások

```json
{
  "type": "module",
  "scripts": {
    "dev": "nodemon server.js"
  }
}
```

---

## 3. `prisma/schema.prisma` – adatbázis modellek

```prisma
generator client {
  provider = "prisma-client-js"
  output   = "../generated/prisma"
}

datasource db {
  provider = "mysql"
  url      = env("DATABASE_URL")
}

// --- Egy-a-többhöz kapcsolat példa ---

model Kaszt {
  id  Int    @id @default(autoincrement())
  nev String
  hos Hos[]
}

model Hos {
  id        Int    @id @default(autoincrement())
  nev       String
  szarmazas String
  szint     Int
  kasztId   Int
  kaszt     Kaszt  @relation(fields: [kasztId], references: [id])
}
```

> A kapcsolatnál: a **gyermek** táblán van az `@relation`, a **szülő** táblán a tömb (pl. `hos Hos[]`)
> Ha már megvan az adatbázis, akkor: `npx prisma db pull`

---

## 4. `.env` – adatbázis kapcsolat

```env
DATABASE_URL="mysql://root@localhost:3306/adatbazis_neve"
```

---

## 5. Prisma parancsok

```bash
npx prisma generate       # kliens generálása (schema után mindig!)
npx prisma migrate dev    # migráció futtatása (táblákat létrehozza)
```

---

## 6. `server.js` – alap sablon

```js
import express from 'express';
import { PrismaClient } from './generated/prisma/client.js'; // generated-ből!!!
import cors from 'cors';

const app = express();
const prisma = new PrismaClient();
const port = 3080; // ne legyen 3000, mert az általában foglalt

app.use(cors());
app.use(express.json());

// === VÉGPONTOK ===

app.listen(port, () => {
  console.log(`Szerver fut: http://localhost:${port}`);
});
```

> Import útvonal: `'./generated/prisma/client.js'` — **ne** `@prisma/client`!

---

## 7. CRUD végpontok

### GET – összes adat (kapcsolattal együtt) → 200

```js
app.get('/api/hosok', async (req, res) => {
  try {
    const hosok = await prisma.hos.findMany({
      include: { kaszt: true }, // kapcsolt tábla adatai is szerepeljenek
    });
    res.status(200).json(hosok);
  } catch (error) {
    res.status(500).json({ error: 'Szerverhiba.' });
  }
});
```

---

### GET – egyszerű lista (kapcsolat nélkül) → 200

```js
app.get('/api/kasztok', async (req, res) => {
  try {
    const kasztok = await prisma.kaszt.findMany();
    res.status(200).json(kasztok);
  } catch (error) {
    res.status(500).json({ error: 'Szerverhiba.' });
  }
});
```

---

### POST – új rekord felvétele → 201 / 400

```js
app.post('/api/hosok', async (req, res) => {
  const { nev, szarmazas, szint, kasztId } = req.body;

  // Kötelező mezők ellenőrzése
  if (!nev || !szarmazas || szint === undefined || !kasztId) {
    return res.status(400).json({
      error: 'Hiányzó adatok: nev, szarmazas, szint és kasztId megadása kötelező.',
    });
  }

  try {
    const ujHos = await prisma.hos.create({
      data: {
        nev,
        szarmazas,
        szint: Number(szint),     // stringből számmá konvertálás!
        kasztId: Number(kasztId),
      },
    });
    res.status(201).json({ message: 'Sikeresen hozzáadva' });
  } catch (error) {
    res.status(500).json({ error: 'Szerverhiba.' });
  }
});
```

---

### DELETE – törlés ID alapján → 204 / 404

```js
app.delete('/api/hosok/:id', async (req, res) => {
  const id = Number(req.params.id); // path param string → szám!

  try {
    const hos = await prisma.hos.findUnique({ where: { id } });
    if (!hos) {
      return res.status(404).json({ error: 'Nem található.' });
    }

    await prisma.hos.delete({ where: { id } });
    res.status(204).send(); // 204 = No Content, NINCS body!
  } catch (error) {
    res.status(500).json({ error: 'Szerverhiba.' });
  }
});
```

---

### PUT – meglévő rekord módosítása → 200 / 404

```js
app.put('/api/hosok/:id', async (req, res) => {
  const id = Number(req.params.id);
  try {
    const updated = await prisma.hos.update({
      where: { id },
      data: req.body,
    });
    res.status(200).json(updated);
  } catch (error) {
    res.status(500).json({ error: 'Szerverhiba.' });
  }
});
```

---

## 8. Státuszkódok összefoglaló

| Kód | Jelentés | Mikor használd |
|-----|----------|----------------|
| `200` | OK | Sikeres GET, PUT |
| `201` | Created | Sikeres POST (új adat) |
| `204` | No Content | Sikeres DELETE (ne küldj body-t!) |
| `400` | Bad Request | Hiányzó/hibás adat a body-ban |
| `404` | Not Found | Az ID nem létezik |
| `500` | Internal Server Error | Szerverhiba (catch blokk) |

---

## 9. Prisma műveletek gyorslista

```js
// Összes rekord
await prisma.model.findMany()

// Összes rekord + kapcsolt tábla
await prisma.model.findMany({ include: { masikModel: true } })

// Egy rekord ID alapján
await prisma.model.findUnique({ where: { id } })

// Létrehozás
await prisma.model.create({ data: { mezo1, mezo2 } })

// Módosítás
await prisma.model.update({ where: { id }, data: req.body })

// Törlés
await prisma.model.delete({ where: { id } })
```

---

## 10. Teljes projekt felállítás

```
1.  Mappa létrehozása: Vezeteknev_Keresztnev_backend
2.  npm init -y
3.  npm install express cors nodemon
4.  npm install -D prisma@6
5.  npx prisma init --datasource-provider mysql --output ../generated/prisma
6.  prisma.config.ts TÖRLÉSE (ha van)
7.  schema.prisma → provider: "prisma-client-js" ellenőrzése, modellek megírása
8.  .env → DATABASE_URL beállítása
9.  npx prisma migrate dev  (Laragon fusson!)
10. npx prisma generate
11. server.js megírása (import a ./generated/prisma/client.js-ből!)
12. package.json → "type": "module" + "dev": "nodemon server.js"
13. npm run dev
```

---

## 11. Postman – exportálás

1. Teszteld az összes végpontot
2. Mentsd el egy kollekcióba
3. **Kollekció neve:** `Mozik.postman_collection.json`
4. Export: Collection → `Export` → Collection v2.1

# Postman GET ALL hos példa

- GET http://localhost:3080/api/hosok
- body-ba json

```json
{
  "id": 1,
  "nev": "Hős neve",
  "szarmazas": "Hős származása",
  "szint": 1,
  "kasztId": 1
}
```

---

## 12. Adatbázis exportálás

- **Fájlnév:** `hosok_adatbazis.sql` / amit megad a feladat
- Tartalmazza az `CREATE DATABASE` / `CREATE TABLE` utasításokat is
- phpMyAdmin: `Export → Custom → Add CREATE DATABASE`