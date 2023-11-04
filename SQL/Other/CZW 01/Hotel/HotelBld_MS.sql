DROP TABLE Rezerwacja
DROP TABLE Pokoj
DROP TABLE Gosc
DROP TABLE Kategoria
GO

CREATE TABLE Gosc (IdGosc INT PRIMARY KEY, Imie VARCHAR(20) NOT NULL, Nazwisko VARCHAR(30) NOT NULL, Procent_rabatu INT NULL)
GO

CREATE TABLE Kategoria (IdKategoria INT PRIMARY KEY, Nazwa VARCHAR(20) NOT NULL, Cena NUMERIC(8,2) NOT NULL)
GO

CREATE TABLE Pokoj (NrPokoju INT PRIMARY KEY, IdKategoria INT NOT NULL REFERENCES Kategoria, Liczba_miejsc INT NOT NULL)
GO

CREATE TABLE Rezerwacja (IdRezerwacja INT PRIMARY KEY, DataOd DATETIME NOT NULL, DataDo DATETIME NOT NULL, IdGosc INT NOT NULL REFERENCES Gosc, NrPokoju INT NOT NULL REFERENCES Pokoj, Zaplacona BIT NOT NULL)
GO

INSERT INTO Gosc (IdGosc, Imie, Nazwisko, Procent_rabatu) VALUES (1, 'Paweł', 'Lenkiewicz', 20)
INSERT INTO Gosc (IdGosc, Imie, Nazwisko, Procent_rabatu) VALUES (2, 'Jan', 'Kowalski', NULL)
INSERT INTO Gosc (IdGosc, Imie, Nazwisko, Procent_rabatu) VALUES (3, 'Andrzej', 'Nowak', 10)
INSERT INTO Gosc (IdGosc, Imie, Nazwisko, Procent_rabatu) VALUES (4, 'Ferdynand', 'Kiepski', 30)
INSERT INTO Gosc (IdGosc, Imie, Nazwisko, Procent_rabatu) VALUES (5, 'Arnold', 'Boczek', NULL)
INSERT INTO Gosc (IdGosc, Imie, Nazwisko, Procent_rabatu) VALUES (6, 'Marian', 'Paździoch', 5)
INSERT INTO Gosc (IdGosc, Imie, Nazwisko, Procent_rabatu) VALUES (7, 'Halina', 'Kiepska', 15)
INSERT INTO Gosc (IdGosc, Imie, Nazwisko, Procent_rabatu) VALUES (8, 'Edward', 'Listonosz', 20)
INSERT INTO Gosc (IdGosc, Imie, Nazwisko, Procent_rabatu) VALUES (9, 'Helena', 'Paździoch', NULL)
INSERT INTO Gosc (IdGosc, Imie, Nazwisko, Procent_rabatu) VALUES (10, 'Alfred', 'Iksiński', 20)
GO

INSERT INTO Kategoria (IdKategoria, Nazwa, Cena) VALUES (1, 'Turystyczny', 30)
INSERT INTO Kategoria (IdKategoria, Nazwa, Cena) VALUES (2, 'Standardowy', 60)
INSERT INTO Kategoria (IdKategoria, Nazwa, Cena) VALUES (3, 'Luksusowy', 120)
GO

INSERT INTO Pokoj (NrPokoju, IdKategoria, Liczba_miejsc) VALUES (101, 1, 2)
INSERT INTO Pokoj (NrPokoju, IdKategoria, Liczba_miejsc) VALUES (102, 1, 2)
INSERT INTO Pokoj (NrPokoju, IdKategoria, Liczba_miejsc) VALUES (103, 1, 3)
INSERT INTO Pokoj (NrPokoju, IdKategoria, Liczba_miejsc) VALUES (104, 2, 2)
INSERT INTO Pokoj (NrPokoju, IdKategoria, Liczba_miejsc) VALUES (105, 2, 2)
INSERT INTO Pokoj (NrPokoju, IdKategoria, Liczba_miejsc) VALUES (201, 1, 2)
INSERT INTO Pokoj (NrPokoju, IdKategoria, Liczba_miejsc) VALUES (202, 3, 4)
INSERT INTO Pokoj (NrPokoju, IdKategoria, Liczba_miejsc) VALUES (203, 3, 2)
INSERT INTO Pokoj (NrPokoju, IdKategoria, Liczba_miejsc) VALUES (204, 3, 2)
INSERT INTO Pokoj (NrPokoju, IdKategoria, Liczba_miejsc) VALUES (205, 2, 3)
GO

INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (1, '2009-07-01', '2009-07-05', 1, 101, 1)
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (2, '2008-01-03', '2008-01-15', 1, 102, 1)
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (3, '2009-07-15', '2009-08-02', 2, 101, 1)
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (4, '2008-12-12', '2008-12-14', 3, 103, 1)
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (5, '2009-05-01', '2009-05-05', 3, 201, 1)
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (6, '2009-04-01', '2009-05-01', 4, 201, 0)
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (7, '2008-11-15', '2008-11-20', 4, 105, 0)
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (8, '2009-10-01', '2009-10-07', 10, 104, 1)
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (9, '2009-07-03', '2009-07-20', 10, 204, 1)
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (10, '2009-03-12', '2009-03-20', 9, 201, 1)
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (11, '2009-12-01', '2009-12-02', 9, 202, 1)
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (12, '2009-12-01', '2009-12-10', 8, 202, 1)
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (13, '2008-03-03', '2008-03-12', 1, 203, 0)
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (14, '2009-08-25', '2009-09-01', 6, 205, 1)
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (15, '2009-04-16', '2009-04-21', 6, 101, 0)
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (16, '2009-04-17', '2009-04-20', 6, 105, 1)
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (17, '2009-02-12', '2009-02-14', 5, 104, 1)
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (18, '2008-11-10', '2008-11-20', 1, 103, 1)
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (19, '2009-06-07', '2009-06-15', 2, 101, 1)
INSERT INTO Rezerwacja (IdRezerwacja, DataOd, DataDo, IdGosc, NrPokoju, Zaplacona) VALUES (20, '2009-07-01', '2009-07-05', 3, 101, 1)
GO
