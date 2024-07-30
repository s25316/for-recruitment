-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2022-06-23 10:02:38.496

-- tables
-- Table: Adres
CREATE TABLE Adres (
    id integer  NOT NULL,
    Ulica varchar2(30)  NOT NULL,
    NrDomu varchar2(10)  NOT NULL,
    NumerMieszkania varchar2(10)  NULL,
    Miejscowosc_id integer  NOT NULL,
    CONSTRAINT Adres_pk PRIMARY KEY (id)
) ;

-- Table: Dizalanie_Interakcja
CREATE TABLE Dizalanie_Interakcja (
    Interakcje_z_Bankiem_id integer  NOT NULL,
    Dzialanie_id integer  NOT NULL,
    CONSTRAINT Dizalanie_Interakcja_pk PRIMARY KEY (Interakcje_z_Bankiem_id)
) ;

-- Table: Dokumenty
CREATE TABLE Dokumenty (
    Osoba_id integer  NOT NULL,
    TypDokumentu_id integer  NOT NULL,
    Numer_Seryjny varchar2(30)  NOT NULL,
    Data_Wydania date  NOT NULL,
    Data_Waznosci date  NULL,
    Panstwo_id_Wydania integer  NOT NULL,
    CONSTRAINT Dokumenty_pk PRIMARY KEY (TypDokumentu_id,Osoba_id)
) ;

-- Table: Dzialanie
CREATE TABLE Dzialanie (
    id integer  NOT NULL,
    Nazwa varchar2(50)  NOT NULL,
    CONSTRAINT Dzialanie_pk PRIMARY KEY (id)
) ;

-- Table: Historia_Zatrudnien
CREATE TABLE Historia_Zatrudnien (
    id integer  NOT NULL,
    Pracownicy_Osoba_id integer  NOT NULL,
    Struktura_Firmy_id_Depatamentu integer  NOT NULL,
    Stanowisko_id integer  NOT NULL,
    Data_Zatrudnienia date  NOT NULL,
    Data_Zwolnienia date  NULL,
    CONSTRAINT Historia_Zatrudnien_pk PRIMARY KEY (id,Pracownicy_Osoba_id)
) ;

-- Table: Interakcje_z_Bankiem
CREATE TABLE Interakcje_z_Bankiem (
    id integer  NOT NULL,
    TypKontaktu_id integer  NOT NULL,
    Czas_Startu timestamp  NOT NULL,
    Czas_Konca timestamp  NOT NULL,
    Pracownicy_Osoba_id integer  NOT NULL,
    Klient_Osoba_id integer  NOT NULL,
    CONSTRAINT Interakcje_z_Bankiem_pk PRIMARY KEY (id)
) ;

-- Table: Klient
CREATE TABLE Klient (
    Osoba_id integer  NOT NULL,
    Pracownicy_Osoba_id integer  NOT NULL,
    CONSTRAINT Klient_pk PRIMARY KEY (Osoba_id)
) ;

-- Table: Klient_Rachunek
CREATE TABLE Klient_Rachunek (
    Klient_Osoba_id integer  NOT NULL,
    Rachunek_Numer char(28)  NOT NULL,
    Status_Klient_id integer  NOT NULL,
    CONSTRAINT Klient_Rachunek_pk PRIMARY KEY (Rachunek_Numer,Klient_Osoba_id)
) ;

-- Table: Kompetecje_Departament
CREATE TABLE Kompetecje_Departament (
    id_Depatamentu integer  NOT NULL,
    Kompetencje_id integer  NOT NULL,
    CONSTRAINT Kompetecje_Departament_pk PRIMARY KEY (id_Depatamentu,Kompetencje_id)
) ;

-- Table: Kompetencje
CREATE TABLE Kompetencje (
    id integer  NOT NULL,
    Nazwa varchar2(50)  NOT NULL,
    Opis varchar2(1000)  NOT NULL,
    CONSTRAINT Kompetencje_pk PRIMARY KEY (id)
) ;

-- Table: Miejscowosc
CREATE TABLE Miejscowosc (
    id integer  NOT NULL,
    Nazwa varchar2(30)  NOT NULL,
    Kod_Pocztowy varchar2(7)  NOT NULL,
    Panstwo_id integer  NOT NULL,
    CONSTRAINT Miejscowosc_pk PRIMARY KEY (id)
) ;

-- Table: Oprocentowanie
CREATE TABLE Oprocentowanie (
    id integer  NOT NULL,
    Wysokosc number(5,10)  NOT NULL,
    Opis varchar2(250)  NOT NULL,
    CONSTRAINT Oprocentowanie_pk PRIMARY KEY (id)
) ;

-- Table: Osoba
CREATE TABLE Osoba (
    id integer  NOT NULL,
    Imie varchar2(30)  NOT NULL,
    Nazwisko varchar2(30)  NOT NULL,
    PESEL char(11)  NULL,
    NazwiskoPanMat varchar2(30)  NOT NULL,
    Num_Tel varchar2(15)  NOT NULL,
    Imie_Ojca varchar2(30)  NOT NULL,
    Imie_Matki varchar2(30)  NOT NULL,
    Dzien_Urodzenia date  NOT NULL,
    Miejscowosc_id_Urodzenia integer  NOT NULL,
    Data_Rozpoczencia_Relacji date  NOT NULL,
    Data_Konca_Relacji date  NULL,
    Adres_Korespondencji integer  NOT NULL,
    Adres_Zamieszkania integer  NOT NULL,
    CONSTRAINT Osoba_pk PRIMARY KEY (id)
) ;

-- Table: Panstwo
CREATE TABLE Panstwo (
    id integer  NOT NULL,
    Nazwa varchar2(30)  NOT NULL,
    CONSTRAINT Panstwo_pk PRIMARY KEY (id)
) ;

-- Table: Pracownicy
CREATE TABLE Pracownicy (
    Osoba_id integer  NOT NULL,
    Osoba_id_Szef integer  NULL,
    CONSTRAINT Pracownicy_pk PRIMARY KEY (Osoba_id)
) ;

-- Table: Rachunek
CREATE TABLE Rachunek (
    Numer char(28)  NOT NULL,
    Waluta_id char(3)  NOT NULL,
    Data_Utworzenia date  NOT NULL,
    Data_Zamknecia date  NULL,
    TypRachunku_id integer  NOT NULL,
    Oprocentowanie_id integer  NOT NULL,
    CONSTRAINT Rachunek_pk PRIMARY KEY (Numer)
) ;

-- Table: Stanowisko
CREATE TABLE Stanowisko (
    id integer  NOT NULL,
    Nazwa varchar2(30)  NOT NULL,
    CONSTRAINT Stanowisko_pk PRIMARY KEY (id)
) ;

-- Table: Status_Klient
CREATE TABLE Status_Klient (
    id integer  NOT NULL,
    Name varchar2(30)  NOT NULL,
    CONSTRAINT Status_Klient_pk PRIMARY KEY (id)
) ;

-- Table: Struktura_Firmy
CREATE TABLE Struktura_Firmy (
    id_Depatamentu integer  NOT NULL,
    id_Depatamentu_Nad integer  NULL,
    Nazwa varchar2(30)  NOT NULL,
    Data_Utworzenia date  NOT NULL,
    Data_Zamkniencia date  NULL,
    Adres_id_Departamentu integer  NOT NULL,
    CONSTRAINT Struktura_Firmy_pk PRIMARY KEY (id_Depatamentu)
) ;

-- Table: TypDokumentu
CREATE TABLE TypDokumentu (
    id integer  NOT NULL,
    Typ varchar2(15)  NOT NULL,
    CONSTRAINT TypDokumentu_pk PRIMARY KEY (id)
) ;

-- Table: TypKontaktu
CREATE TABLE TypKontaktu (
    id integer  NOT NULL,
    Nazwa varchar2(30)  NOT NULL,
    CONSTRAINT TypKontaktu_pk PRIMARY KEY (id)
) ;

-- Table: TypRachunku
CREATE TABLE TypRachunku (
    id integer  NOT NULL,
    Typ varchar2(30)  NOT NULL,
    CONSTRAINT TypRachunku_pk PRIMARY KEY (id)
) ;

-- Table: Waluta
CREATE TABLE Waluta (
    id char(3)  NOT NULL,
    Nazwa varchar2(30)  NOT NULL,
    CONSTRAINT Waluta_pk PRIMARY KEY (id)
) ;

-- Table: Zgody
CREATE TABLE Zgody (
    id integer  NOT NULL,
    Nazwa varchar2(30)  NOT NULL,
    Tresc_Zgody varchar2(100)  NOT NULL,
    CONSTRAINT Zgody_pk PRIMARY KEY (id)
) ;

-- Table: Zgody_Osoba
CREATE TABLE Zgody_Osoba (
    Osoba_id integer  NOT NULL,
    Zgoda_id integer  NOT NULL,
    P_lub_F char(1)  NOT NULL,
    CONSTRAINT Zgody_Osoba_pk PRIMARY KEY (Zgoda_id,Osoba_id)
) ;

-- foreign keys
-- Reference: Address_Town (table: Adres)
ALTER TABLE Adres ADD CONSTRAINT Address_Town
    FOREIGN KEY (Miejscowosc_id)
    REFERENCES Miejscowosc (id);

-- Reference: DOC_Country (table: Dokumenty)
ALTER TABLE Dokumenty ADD CONSTRAINT DOC_Country
    FOREIGN KEY (Panstwo_id_Wydania)
    REFERENCES Panstwo (id);

-- Reference: DOC_DOCtype (table: Dokumenty)
ALTER TABLE Dokumenty ADD CONSTRAINT DOC_DOCtype
    FOREIGN KEY (TypDokumentu_id)
    REFERENCES TypDokumentu (id);

-- Reference: Dokumenty_Osoba (table: Dokumenty)
ALTER TABLE Dokumenty ADD CONSTRAINT Dokumenty_Osoba
    FOREIGN KEY (Osoba_id)
    REFERENCES Osoba (id);

-- Reference: Dysp_Inte_Inter_z_Ban (table: Dizalanie_Interakcja)
ALTER TABLE Dizalanie_Interakcja ADD CONSTRAINT Dysp_Inte_Inter_z_Ban
    FOREIGN KEY (Interakcje_z_Bankiem_id)
    REFERENCES Interakcje_z_Bankiem (id);

-- Reference: Dyspoycje_Interakcja_Dzialanie (table: Dizalanie_Interakcja)
ALTER TABLE Dizalanie_Interakcja ADD CONSTRAINT Dyspoycje_Interakcja_Dzialanie
    FOREIGN KEY (Dzialanie_id)
    REFERENCES Dzialanie (id);

-- Reference: EMP_AGR_AGR (table: Zgody_Osoba)
ALTER TABLE Zgody_Osoba ADD CONSTRAINT EMP_AGR_AGR
    FOREIGN KEY (Zgoda_id)
    REFERENCES Zgody (id);

-- Reference: His_Zatru_Stru_Fir (table: Historia_Zatrudnien)
ALTER TABLE Historia_Zatrudnien ADD CONSTRAINT His_Zatru_Stru_Fir
    FOREIGN KEY (Struktura_Firmy_id_Depatamentu)
    REFERENCES Struktura_Firmy (id_Depatamentu);

-- Reference: Historia_Zatrudnien_Pracownicy (table: Historia_Zatrudnien)
ALTER TABLE Historia_Zatrudnien ADD CONSTRAINT Historia_Zatrudnien_Pracownicy
    FOREIGN KEY (Pracownicy_Osoba_id)
    REFERENCES Pracownicy (Osoba_id);

-- Reference: Historia_Zatrudnien_Stanowisko (table: Historia_Zatrudnien)
ALTER TABLE Historia_Zatrudnien ADD CONSTRAINT Historia_Zatrudnien_Stanowisko
    FOREIGN KEY (Stanowisko_id)
    REFERENCES Stanowisko (id);

-- Reference: Interakcje (table: Interakcje_z_Bankiem)
ALTER TABLE Interakcje_z_Bankiem ADD CONSTRAINT Interakcje
    FOREIGN KEY (Pracownicy_Osoba_id)
    REFERENCES Pracownicy (Osoba_id);

-- Reference: Interakcje_TypKontaktu (table: Interakcje_z_Bankiem)
ALTER TABLE Interakcje_z_Bankiem ADD CONSTRAINT Interakcje_TypKontaktu
    FOREIGN KEY (TypKontaktu_id)
    REFERENCES TypKontaktu (id);

-- Reference: Interakcje_z_Bankiem_Klient (table: Interakcje_z_Bankiem)
ALTER TABLE Interakcje_z_Bankiem ADD CONSTRAINT Interakcje_z_Bankiem_Klient
    FOREIGN KEY (Klient_Osoba_id)
    REFERENCES Klient (Osoba_id);

-- Reference: Klient_Osoba (table: Klient)
ALTER TABLE Klient ADD CONSTRAINT Klient_Osoba
    FOREIGN KEY (Osoba_id)
    REFERENCES Osoba (id);

-- Reference: Klient_Pracownicy (table: Klient)
ALTER TABLE Klient ADD CONSTRAINT Klient_Pracownicy
    FOREIGN KEY (Pracownicy_Osoba_id)
    REFERENCES Pracownicy (Osoba_id);

-- Reference: Klient_Rachunek_Klient (table: Klient_Rachunek)
ALTER TABLE Klient_Rachunek ADD CONSTRAINT Klient_Rachunek_Klient
    FOREIGN KEY (Klient_Osoba_id)
    REFERENCES Klient (Osoba_id);

-- Reference: Klient_Rachunek_Rachunek (table: Klient_Rachunek)
ALTER TABLE Klient_Rachunek ADD CONSTRAINT Klient_Rachunek_Rachunek
    FOREIGN KEY (Rachunek_Numer)
    REFERENCES Rachunek (Numer);

-- Reference: Klient_Rachunek_Status_Klient (table: Klient_Rachunek)
ALTER TABLE Klient_Rachunek ADD CONSTRAINT Klient_Rachunek_Status_Klient
    FOREIGN KEY (Status_Klient_id)
    REFERENCES Status_Klient (id);

-- Reference: Kom_Dep_Kom (table: Kompetecje_Departament)
ALTER TABLE Kompetecje_Departament ADD CONSTRAINT Kom_Dep_Kom
    FOREIGN KEY (Kompetencje_id)
    REFERENCES Kompetencje (id);

-- Reference: Kom_Depa_Stru_Firmy (table: Kompetecje_Departament)
ALTER TABLE Kompetecje_Departament ADD CONSTRAINT Kom_Depa_Stru_Firmy
    FOREIGN KEY (id_Depatamentu)
    REFERENCES Struktura_Firmy (id_Depatamentu);

-- Reference: Osoba_Miejscowosc (table: Osoba)
ALTER TABLE Osoba ADD CONSTRAINT Osoba_Miejscowosc
    FOREIGN KEY (Miejscowosc_id_Urodzenia)
    REFERENCES Miejscowosc (id);

-- Reference: PEA_Address (table: Osoba)
ALTER TABLE Osoba ADD CONSTRAINT PEA_Address
    FOREIGN KEY (Adres_Korespondencji)
    REFERENCES Adres (id);

-- Reference: PEA_Address (table: Osoba)
ALTER TABLE Osoba ADD CONSTRAINT PEA_Address
    FOREIGN KEY (Adres_Zamieszkania)
    REFERENCES Adres (id);

-- Reference: Pracownicy_Osoba (table: Pracownicy)
ALTER TABLE Pracownicy ADD CONSTRAINT Pracownicy_Osoba
    FOREIGN KEY (Osoba_id)
    REFERENCES Osoba (id);

-- Reference: Pracownicy_Pracownicy (table: Pracownicy)
ALTER TABLE Pracownicy ADD CONSTRAINT Pracownicy_Pracownicy
    FOREIGN KEY (Osoba_id_Szef)
    REFERENCES Pracownicy (Osoba_id);

-- Reference: Rachunek_Oprocentowanie (table: Rachunek)
ALTER TABLE Rachunek ADD CONSTRAINT Rachunek_Oprocentowanie
    FOREIGN KEY (Oprocentowanie_id)
    REFERENCES Oprocentowanie (id);

-- Reference: Rachunek_TypRachunku (table: Rachunek)
ALTER TABLE Rachunek ADD CONSTRAINT Rachunek_TypRachunku
    FOREIGN KEY (TypRachunku_id)
    REFERENCES TypRachunku (id);

-- Reference: Rachunek_Waluta (table: Rachunek)
ALTER TABLE Rachunek ADD CONSTRAINT Rachunek_Waluta
    FOREIGN KEY (Waluta_id)
    REFERENCES Waluta (id);

-- Reference: STRU_Address (table: Struktura_Firmy)
ALTER TABLE Struktura_Firmy ADD CONSTRAINT STRU_Address
    FOREIGN KEY (Adres_id_Departamentu)
    REFERENCES Adres (id);

-- Reference: Struktura (table: Struktura_Firmy)
ALTER TABLE Struktura_Firmy ADD CONSTRAINT Struktura
    FOREIGN KEY (id_Depatamentu_Nad)
    REFERENCES Struktura_Firmy (id_Depatamentu);

-- Reference: Town_Country (table: Miejscowosc)
ALTER TABLE Miejscowosc ADD CONSTRAINT Town_Country
    FOREIGN KEY (Panstwo_id)
    REFERENCES Panstwo (id);

-- Reference: Zgody_Osoba_Osoba (table: Zgody_Osoba)
ALTER TABLE Zgody_Osoba ADD CONSTRAINT Zgody_Osoba_Osoba
    FOREIGN KEY (Osoba_id)
    REFERENCES Osoba (id);

-- End of file.

