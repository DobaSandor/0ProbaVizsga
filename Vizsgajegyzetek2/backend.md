# Backend – Prisma + Express (Szuperhősök példa)

---

## 1. Adatbázis sémák (`schema.prisma`)

```prisma
model kepessegek {
  id            Int          @id @default(autoincrement())
  hos_id        Int?
  kepesseg_neve String       @db.VarChar(100)
  leiras        String?      @db.Text
  ero_szint     Int?
  szuperhosok   szuperhosok? @relation(fields: [hos_id], references: [id], onDelete: Cascade)

  @@index([hos_id], map: "hos_id")
}

model szuperhosok {
  id              Int          @id @default(autoincrement())
  szuperhos_nev   String       @db.VarChar(100)
  valodi_nev      String?      @db.VarChar(100)
  kiado           String?      @db.VarChar(50)
  szekhely        String?      @db.VarChar(100)
  elso_megjelenes Int?
  kepessegek      kepessegek[]
}
```

---

## 2. Szerver alapbeállítás (`server.js`)

```js
import express from 'express';
import { PrismaClient } from './generated/prisma/client.js';
import cors from 'cors';

const app = express();
const prisma = new PrismaClient();
const port = 3080;

app.use(cors());
app.use(express.json());
```

---

## 3. Végpontok (CRUD)

### GET – Összes adat kapcsolattal (`include`)
```js
app.get('/api/szuperhosok', async (req, res) => {
  try {
    const szuperhosok = await prisma.szuperhosok.findMany({
      include: { kepessegek: true },
    });
    res.status(200).json(szuperhosok);
  } catch (error) {
    res.status(500).json({ error: 'Szerverhiba.' });
  }
});
```

### POST – Új rekord (Szám konverzió!)
```js
app.post('/api/szuperhosok', async (req, res) => {
  const { szuperhos_nev, valodi_nev, kiado, szekhely, elso_megjelenes } = req.body;

  if (!szuperhos_nev || !valodi_nev || !kiado || !szekhely || elso_megjelenes === undefined) {
    return res.status(400).json({ error: 'Hiányzó adatok!' });
  }

  try {
    const uj = await prisma.szuperhosok.create({
      data: {
        szuperhos_nev,
        valodi_nev,
        kiado,
        szekhely,
        elso_megjelenes: Number(elso_megjelenes), // Fontos a konverzió!
      },
    });
    res.status(201).json({ message: 'Sikeresen hozzáadva' });
  } catch (error) {
    res.status(500).json({ error: 'Szerverhiba.' });
  }
});
```

### PUT – Rekord módosítása (teljes)
```js
app.put('/api/szuperhosok/:id', async (req, res) => {
  const id = Number(req.params.id);
  try {
    const updated = await prisma.szuperhosok.update({
      where: { id },
      data: req.body,
    });
    res.status(200).json(updated);
  } catch (error) {
    res.status(500).json({ error: 'Szerverhiba.' });
  }
});
```

### PATCH – Részleges módosítás (pl. csak egy mező)
```js
app.patch('/api/szuperhosok/:id', async (req, res) => {
  const id = Number(req.params.id);
  try {
    const updated = await prisma.szuperhosok.update({
      where: { id },
      data: req.body, // Csak a küldött mezőket frissíti!
    });
    res.status(200).json(updated);
  } catch (error) {
    res.status(500).json({ error: 'Szerverhiba vagy nem létező ID.' });
  }
});
```

---

## 4. Gyorslista parancsok (npm & npx)
```bash
npm init -y
npm install express cors nodemon
npm install -D prisma@6
npx prisma init --datasource-provider mysql --output ../generated/prisma
npx prisma migrate dev
npx prisma generate
```

---

## 5. Státuszkódok összefoglaló

| Kód | Jelentés | Mikor használd |
|-----|----------|----------------|
| `200` | OK | Sikeres GET, PUT |
| `201` | Created | Sikeres POST (új adat) |
| `204` | No Content | Sikeres DELETE (ne küldj body-t!) |
| `400` | Bad Request | Hiányzó/hibás adat a body-ban |
| `404` | Not Found | Az ID nem létezik |
| `500` | Internal Server Error | Szerverhiba (catch blokk) |

---

## 6. Prisma műveletek gyorslista

```js
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

## 7. Teljes projekt felállítás (Checklist)

### 1. Terminál parancsok (Másold ki egyszerre):
```bash
npm init -y
npm install express cors nodemon
npm install -D prisma@6
npx prisma init --datasource-provider mysql --output ../generated/prisma
```

### 2. További lépések:
1. `prisma.config.ts` TÖRLÉSE (ha van)
2. `schema.prisma` modellek megírása
3. `.env` -> `DATABASE_URL` beállítása
4. **Adatbázis létrehozása & Generálás:**
```bash
npx prisma migrate dev --name init
npx prisma generate
```
5. `server.js` megírása
6. `package.json` -> `"type": "module"` + `"dev": "nodemon server.js"`
7. `npm run dev`

---

## 8. Exportok (Postman & SQL)

- **Postman:** Kollekció -> `Export` -> Collection v2.1
- **SQL:** phpMyAdmin -> `Export` -> `Custom` -> `Add CREATE DATABASE`
