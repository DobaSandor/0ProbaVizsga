import express from 'express';
import { PrismaClient } from './generated/prisma/client.js';
import cors from 'cors';
const app = express()
const port = 3080
const prisma = new PrismaClient();

app.use(cors())


app.get('/', (req, res) => {
  res.send('Hello World!')
})

app.get('/api/hosok', async (req, res) => {
    const hosok = await prisma.hos.findMany();
    res.json(hosok);
    res.status(200);
})

app.get('/api/kasztok', async (req, res) => {
    const kasztok = await prisma.kaszt.findMany();
    res.json(kasztok);
    res.status(200);
})

app.post('/api/hosok', express.json(), async (req, res) => {
    const { nev, szarmazas, szint, kaszt_id} = req.body;
    try {
        const newHos = await prisma.hos.create({
            data: {
                nev,
                szarmazas,
                szint,
                kaszt_id
            }
        });
        res.status(201).json({message: 'Sikeresen hozzáadva'});
    } catch (error) {
        res.status(400).json({message: 'Hiányzó adatok', details: error.message });
    }
})

app.delete('/api/hosok/:id', async (req, res) => {
    const id = parseInt(req.params.id);
    try {
        await prisma.hos.delete({
            where: { id }
        });
        res.status(204).send({message: 'Sikeres törlés'});
    } catch (error) {
        res.status(404).json({ error: 'ID nem létezik', details: error.message });
    }
})


app.listen(port, () => {
  console.log(`Example app listening on port ${port}`)
})


