/*CREATE TABLE proizvod (
    SkladisniBroj INT PRIMARY KEY,  -- Primarni ključ, jedinstven i ne null
    ImeProizvoda VARCHAR(30) NOT NULL,  -- Ograničena duljina s minimalnim i maksimalnim brojem znakova
    BojaProizvoda VARCHAR(30) NOT NULL,  -- Kao i kod ImeProizvoda, zahtijeva se vrijednost
    Ostecen CHAR(1),  -- Može biti 'D' ili 'N', pa samo jedan znak
    KontrolniBroj VARCHAR(30) DEFAULT NULL,  -- Može biti niz znakova, ali može biti i null
    DatumProizvodnje DATE DEFAULT NULL,  -- Pohranjuje samo datum, može biti null
    GodinaModela ENUM('DvijeTisucePetnaesta', 'DvijeTisuceSedamnaesta', 'DvijeTisuceDevetnaesta', 'DvijeTisuceDvadesetDruga') NOT NULL,  -- Enum s definisanim vrijednostima
    Dostupnost BIT(1) DEFAULT 0,  -- Istina ili laž, zadan je kao lažna vrijednost (FALSE)
    DanaZaNabavu INT  -- Cjelobrojna vrijednost, može biti null
);*/

#drop table Proizvod



INSERT INTO Proizvod (SkladisniBroj, ImeProizvoda, BojaProizvoda, Ostecen, KontrolniBroj, DatumProizvodnje, GodinaModela, Dostupnost, DanaZaNabavu)
VALUES 
(1, 'Stalak za jakne', 'Crna', 'N', '12345678901', '2022-12-03', 'DvijeTisuceDevetnaesta', 1, 3),
(2, 'Šalica', 'Plava', 'N', '12345678902', '2021-11-04', 'DvijeTisuceSedamnaesta', 1, 5),
(3, 'Svijećnjak', 'Bijela', 'D', '12345678903', '2020-07-21', 'DvijeTisucePetnaesta', 1, 7),
(4, 'Termo boca', 'Crvena', 'D', '78956734521', '2023-01-01', 'DvijeTisuceDvadesetDruga', 0, 1),
(5, 'Posuda za cvijeće', 'Zelena', 'N', '12345678905', '2019-03-15', 'DvijeTisuceDevetnaesta', 1, 4),
(6, 'Stolna lampa', 'Žuta', 'N', '12345678906', '2018-08-27', 'DvijeTisuceSedamnaesta', 0, 6),
(7, 'Vaza', 'Plava', 'D', '12345678907', '2017-06-14', 'DvijeTisucePetnaesta', 1, 8),
(8, 'Fotografija', 'Smeđa', 'N', '12345678908', '2016-12-31', 'DvijeTisuceSedamnaesta', 1, 10),
(9, 'Plakat', 'Siva', 'N', '12345678909', '2015-10-02', 'DvijeTisuceDevetnaesta', 1, 2),
(10, 'Čaša', 'Prozirna', 'D', '12345678910', '2014-05-19', 'DvijeTisucePetnaesta', 0, 7);

