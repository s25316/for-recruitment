DROP TABLE Rezerwacja;
DROP TABLE Pokoj;
DROP TABLE Gosc;
DROP TABLE Kategoria;

CREATE TABLE Gosc (IdGosc INTEGER PRIMARY KEY, Imie VARCHAR2(20) NOT NULL, Nazwisko VARCHAR2(30) NOT NULL, Procent_rabatu INTEGER NULL);
CREATE TABLE Kategoria (IdKategoria INTEGER PRIMARY KEY, Nazwa VARCHAR2(20) NOT NULL, Cena NUMERIC(8,2) NOT NULL);
CREATE TABLE Pokoj (NrPokoju INTEGER PRIMARY KEY, IdKategoria INTEGER NOT NULL REFERENCES Kategoria, Liczba_miejsc INTEGER NOT NULL);
CREATE TABLE Rezerwacja (IdRezerwacja INTEGER PRIMARY KEY, DataOd DATE NOT NULL, DataDo DATE NOT NULL, IdGosc INTEGER NOT NULL REFERENCES Gosc, NrPokoju INTEGER NOT NULL REFERENCES Pokoj, Zaplacona INTEGER NOT NULL);

INSERT INTO Gosc (IdGosc, Imie, Nazwisko, Procent_rabatu) VALUES (1, 'Paweł', 'Lenkiewicz', 20);
INSERT INTO Gosc (IdGosc, Imie, Nazwisko, Procent_rabatu) VALUES (2, 'Jan', 'Kowalski', NULL);
INSERT INTO Gosc (IdGosc, Imie, Nazwisko, Procent_rabatu) VALUES (3, 'Andrzej', 'Nowak', 10);
INSERT INTO Gosc (IdGosc, Imie, Nazwisko, Procent_rabatu) VALUES (4, 'Ferdynand', 'Kiepski', 30);
INSERT INTO Gosc (IdGosc, Imie, Nazwisko, Procent_rabatu) VALUES (5, 'Arnold', 'Boczek', NULL);
INSERT INTO Gosc (IdGosc, Imie, Nazwisko, Procent_rabatu) VALUES (6, 'Marian', 'Paździoch', 5);
INSERT INTO Gosc (IdGosc, Imie, Nazwisko, Procent_rabatu) VALUES (7, 'Halina', 'Kiepska', 15);
INSERT INTO Gosc (IdGosc, Imie, Nazwisko, Procent_rabatu) VALUES (8, 'Edward', 'Listonosz', 20);
INSERT INTO Gosc (IdGosc, Imie, Nazwisko, Procent_rabatu) VALUES (9, 'Helena', 'Paździoch', NULL);
INSERT INTO Gosc (IdGosc, Imie, Nazwisko, Procent_rabatu) VALUES (10, 'Alfred', 'Iksiński', 20);

INSERT INTO Kategoria (IdKategoria, Nazwa, Cena) VALUES (1, 'Turystyczny', 30);
INSERT INTO Kategoria (IdKategoria, Nazwa, Cena) VALUES (2, 'Standardowy', 60);
INSERT INTO Kategoria (IdKategoria, Nazwa, Cena) VALUES (3, 'Luksusowy', 120);

INSERT INTO Pokoj (NrPokoju, IdKategoria, Liczba_miejsc) VALUES (101, 1, 2);
INSERT INTO Pokoj (NrPokoju, IdKategoria, Liczba_miejsc) VALUES (102, 1, 2);
INSERT INTO Pokoj (NrPokoju, IdKategoria, Liczba_miejsc) VALUES (103, 1, 3);
INSERT INTO Pokoj (NrPokoju, IdKategoria, Liczba_miejsc) VALUES (104, 2, 2);
INSERT INTO Pokoj (NrPokoju, IdKategoria, Liczba_miejsc) VALUES (105, 2, 2);
INSERT INTO Pokoj (NrPokoju, IdKategoria, Liczba_miejsc) VALUES (201, 1, 2);
INSERT INTO Pokoj (NrPokoju, IdKategoria, Liczba_miejsc) VALUES (202, 3, 4);
INSERT INTO Pokoj (NrPokoju, IdKategoria, Liczba_miejsc) VALUES (203, 3, 2);
INSERT INTO Pokoj (NrPokoju, IdKategoria, Liczba_miejsc) VALUES (204, 3, 2);
INSERT INTO Pokoj (NrPokoju, IdKategoria, Liczba_miejsc) VALUES (205, 2, 3);

INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (1, to_date('2009-07-01','yyyy-mm-dd'), to_date('2009-07-05','yyyy-mm-dd'), 1, 101, 1);
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (2, to_date('2008-01-03','yyyy-mm-dd'), to_date('2008-01-15','yyyy-mm-dd'), 1, 102, 1);
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (3, to_date('2009-07-15','yyyy-mm-dd'), to_date('2009-08-02','yyyy-mm-dd'), 2, 101, 1);
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (4, to_date('2008-12-12','yyyy-mm-dd'), to_date('2008-12-14','yyyy-mm-dd'), 3, 103, 1);
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (5, to_date('2009-05-01','yyyy-mm-dd'), to_date('2009-05-05','yyyy-mm-dd'), 3, 201, 1);
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (6, to_date('2009-04-01','yyyy-mm-dd'), to_date('2009-05-01','yyyy-mm-dd'), 4, 201, 0);
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (7, to_date('2008-11-15','yyyy-mm-dd'), to_date('2008-11-20','yyyy-mm-dd'), 4, 105, 0);
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (8, to_date('2009-10-01','yyyy-mm-dd'), to_date('2009-10-07','yyyy-mm-dd'), 10, 104, 1);
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (9, to_date('2009-07-03','yyyy-mm-dd'), to_date('2009-07-20','yyyy-mm-dd'), 10, 204, 1);
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (10, to_date('2009-03-12','yyyy-mm-dd'), to_date('2009-03-20','yyyy-mm-dd'), 9, 201, 1);
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (11, to_date('2009-12-01','yyyy-mm-dd'), to_date('2009-12-02','yyyy-mm-dd'), 9, 202, 1);
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (12, to_date('2009-12-01','yyyy-mm-dd'), to_date('2009-12-10','yyyy-mm-dd'), 8, 202, 1);
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (13, to_date('2008-03-03','yyyy-mm-dd'), to_date('2008-03-12','yyyy-mm-dd'), 1, 203, 0);
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (14, to_date('2009-08-25','yyyy-mm-dd'), to_date('2009-09-01','yyyy-mm-dd'), 6, 205, 1);
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (15, to_date('2009-04-16','yyyy-mm-dd'), to_date('2009-04-21','yyyy-mm-dd'), 6, 101, 0);
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (16, to_date('2009-04-17','yyyy-mm-dd'), to_date('2009-04-20','yyyy-mm-dd'), 6, 105, 1);
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (17, to_date('2009-02-12','yyyy-mm-dd'), to_date('2009-02-14','yyyy-mm-dd'), 5, 104, 1);
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (18, to_date('2008-11-10','yyyy-mm-dd'), to_date('2008-11-20','yyyy-mm-dd'), 1, 103, 1);
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (19, to_date('2009-06-07','yyyy-mm-dd'), to_date('2009-06-15','yyyy-mm-dd'), 2, 101, 1);
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (20, to_date('2009-07-01','yyyy-mm-dd'), to_date('2009-07-05','yyyy-mm-dd'), 3, 101, 1);

COMMIT