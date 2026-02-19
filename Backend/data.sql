-- 1. Először a KASZT tábla feltöltése (hogy a hősök tudjanak mire hivatkozni)
INSERT INTO kaszt (id, nev) VALUES
(1, 'Harcos'),
(2, 'Mágus'),
(3, 'Íjász'),
(4, 'Pap'),
(5, 'Zsivány');

-- 2. Ezután a HOS tábla feltöltése (a kasztId a fenti ID-kra mutat)
INSERT INTO hos (id, nev, szarmazas, szint, kasztId) VALUES
(1, 'Ríviai Geralt', 'Rívia', 35, 1),
(2, 'Gandalf', 'Középfölde', 99, 2),
(3, 'Legolas', 'Bakacsinerdő', 25, 3),
(4, 'Conan', 'Cimmeria', 18, 1),
(5, 'Jaina Proudmoore', 'Kul Tiras', 40, 2),
(6, 'Robin Hood', 'Sherwood', 12, 3),
(7, 'Anduin Wrynn', 'Stormwind', 20, 4),
(8, 'Garrett', 'A Város', 15, 5),
(9, 'Xéna', 'Amphipolis', 22, 1),
(10, 'Merlin', 'Camelot', 80, 2);