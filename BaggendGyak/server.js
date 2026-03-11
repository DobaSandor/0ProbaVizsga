import express from "express";
const app = express();
const port = 3090;
import cors from "cors";
import { PrismaClient } from "./generated/prisma/client.js";

const prisma = new PrismaClient();

app.use(cors());

app.get("/", (req, res) => {
  res.send("Hello World!");
});

app.listen(port, () => {
  console.log(`Example app listening on port http://localhost:${port}/`);
});

// CRUD: Create, Read, Update, Delete

// ADD
app.post("/api/diakok", async (req, res) => {
  const { nev, palca, eletpont, hazId } = req.body; //schema cucca
  try {
    const newDiak = await prisma.diak.create({
      data: { nev, palca, eletpont, hazId },
    });
    res.json(newDiak);
  } catch (error) {
    res.status(500).json({ error: "Internal Server Error" });
  }
});
//----------------------
app.get("/api/diakok", async (req, res) => {
  const diakok = await prisma.diak.findMany({
    include: {
      //masik table adatainak megejelenitesehez kell//
      haz: true,
    },
  });
  res.json(diakok);
});
//----------------------
app.get("/api/diakok/:id", async (req, res) => {
  const { id } = req.params;
  try {
    const diak = await prisma.diak.findUnique({
      where: { id: parseInt(id) },
      include: {
        haz: true,
      },
    });
    if (diak) {
      res.json(diak);
    } else {
      res.status(404).json({ error: "Diak Not Found" });
    }
  } catch (error) {
    res.status(500).json({ error: "Internal Server Error" });
  }
});
//----------------------
app.put("/api/diakok/:id", async (req, res) => { //Id alapján keresi a "régi" diákot
  const { id } = req.params;
  try {
    const updatedDiakok = await prisma.diak.update({ //update-ol egy diákot
      where: {
        id: parseInt(id), //enélkül stringnek érzékeli//},
        data: req.body,
      }, //schema cucca
    });
    res.json(updatedDiakok);
  } catch (error) {
    res.status(500).json({ error: "Internal Server Error" });
    console.error(error);
  }
});
//----------------------
app.delete("/api/diak/:id", async (req, res) => { // Id alapján töröl egy diákot
  const { id } = req.params;
  try {
    await prisma.diak.delete({
      where: { id: parseInt(id) },
    });
    res.json({ message: "Diak Purged" });
  } catch (error) {
    res.status(500).json({ error: "Internal Server Error" });
  }
});
//----------------------
app.get("/api/hazak", async (req, res) => { //Listázza a házakat, és megjeleníti a hozzájuk tartozó diákokat is
  const hazak = await prisma.haz.findMany({
    include: { // megjeleníti a Házakhoz kötött diákokat
      //masik table adatainak megejelenitesehez kell//
      diak: true,
    },
  });
  res.json(hazak);
});
//----------------------
app.get("/api/hazak/:id", async (req, res) => {
  const { id } = req.params;
  try {
    const haz = await prisma.haz.findUnique({
      where: { id: parseInt(id) },
      include: {
        diak: true,
      },
    });
    if (haz) {
      res.json(haz);
    } else {
      res.status(404).json({ error: "Haz Not Found" });
    }
  } catch (error) {
    res.status(500).json({ error: "Internal Server Error" });
  }
});
//----------------------
app.post("/api/hazak", async (req, res) => { //Uj haz hozzáadása
  const { megnevezes, leiras } = req.body; //schema cucca
  try {
    const newHaz = await prisma.haz.create({
      data: { megnevezes, leiras },
    });
    res.json(newHaz);
  } catch (error) {
    res.status(500).json({ error: "Internal Server Error" });
  }
});
//----------------------
app.put("/api/hazak/:id", async (req, res) => { //Id alapján keresi a "régi" házat
  const { id } = req.params;
  try {
    const updatedHaz = await prisma.haz.update({
      where: {
        id: parseInt(id), //enélkül stringnek érzékeli//},
        data: req.body,
      }, //schema cucca
    });
    res.json(updatedHaz); //kiad egy frissített házat
  } catch (error) {
    res.status(500).json({ error: "Internal Server Error" });
    console.error(error);
  }
});
//----------------------
app.delete("/api/haz/:id", async (req, res) => { //Id töröl egy házat
  const { id } = req.params;
  try {
    await prisma.haz.delete({    
      where: { id: parseInt(id) },
    });
    res.json({ message: "Haz Destroyed" }); //visszaad egy üzenetet, hogy a ház törölve lett
  } catch (error) {
    res.status(500).json({ error: "Internal Server Error" });
  }
});
//----------------------
