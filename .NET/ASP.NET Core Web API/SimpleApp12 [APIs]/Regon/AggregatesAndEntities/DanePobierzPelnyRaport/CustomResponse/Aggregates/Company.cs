using Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CoreResponse.Level5DaneClasses;
using Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CustomResponse.Entities;
using Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CustomResponse.Entities.Adress;
using Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CustomResponse.Entities.Kontaktowe;
using Regon.CustomExceptions;
using Regon.Factories;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Regon.AggregatesAndEntities.DanePobierzPelnyRaport.CustomResponse.Aggregates
{
    public class Company
    {
        private string _regon = null!;
        public string Regon
        {
            get { return _regon; }
            private set
            {
                var regex = new Regex(@"^\d{9}00000$");
                if (regex.IsMatch(value))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        value = value.Remove(value.Length - 1);
                    }
                }
                _regon = value;
            }
        }
        public string? Nip { get; private set; } = null;
        public string Nazwa { get; private set; }
        public string? NazwaSkrocona { get; private set; } = null;
        public Daty Daty { get; private set; } = null!;

        public ICollection<KontaktoweInformacje> DaneKontaktowe { get; private set; } = new List<KontaktoweInformacje>();
        public ICollection<Adres> DaneAdresowe { get; private set; } = new List<Adres>();

        //==============================================================================
        public string? NumerwRejestrzeEwidencji { get; set; } = null; //CEIDG FP
        public string? OrganRejestrowyNazwa { get; set; } = null; //CEIDG FP P
        public string? RodzajRejestruNazwa { get; set; } = null; //CEIDG FP

        //====================================================== P LF
        public string? PodstawowaFormaPrawnaNazwa { get; set; } = null;
        public string? SzczegolnaFormaPrawnaNazwa { get; set; } = null;
        public string? FormaFinansowaniaNazwa { get; set; } = null;
        public string? FormaWlasnosciNazwa { get; set; } = null;
        public string? OrganZalozycielskiNazwa { get; set; } = null;
        public string? RodzajRejestruEwidencjiNazwa { get; set; } = null;


        public Company(DanePelne pelne)
        {
            if (pelne is DaneJednostkiFizycznejCeidg fizycznaCeidg)
            {
                DaneJednostkiFizycznejCeidg(fizycznaCeidg);
            }
            else if (pelne is DaneJednostkiFizycznejPozostala fizycznaPozostala)
            {
                DaneJednostkiFizycznejPozostala(fizycznaPozostala);
            }
            else if (pelne is DaneJednostkiFizycznejRolnicza fizycznaRolnicza)
            {
                DaneJednostkiFizycznejRolnicza(fizycznaRolnicza);
            }
            else if (pelne is DaneJednostkiFizycznejWKrupgn fizycznaWKrupgn)
            {
                DaneJednostkiFizycznejWKrupgn(fizycznaWKrupgn);
            }
            else if (pelne is DaneJednostkiPrawnej prawna)
            {
                DaneJednostkiPrawnej(prawna);
            }
            else if (pelne is DaneJednostkiLokalnaFizycznej lokalnaFizycznej)
            {
                DaneJednostkiLokalnaFizycznej(lokalnaFizycznej);
            }
            else if (pelne is DaneJednostkiLokalnaPrawnej lokalnaPrawnej)
            {
                DaneJednostkiLokalnaPrawnej(lokalnaPrawnej);
            }
            else
            {
                throw new AppException(MessagesFactory.GenerateExeptionMessageDanePelneNewClass
                    (
                    this.GetType(),
                    MethodBase.GetCurrentMethod(),
                    pelne.GetType()
                    ));
            }
        }

        private void DaneJednostkiFizycznejCeidg(DaneJednostkiFizycznejCeidg dane)
        {
            Regon = dane.FizRegon9;

            Nazwa = dane.FizNazwa;
            NazwaSkrocona = ReturnStringOrNull(dane.FizNazwaSkrocona);

            Daty = (Daty)dane;
            AddDaneAdresoweIfIsNotNull(Adres.Siedziba(dane));
            AddDaneKontaktoweIfIsNotNull(KontaktoweInformacje.DaneKontaktoweOgolne(dane));
            AddDaneKontaktoweIfIsNotNull(KontaktoweInformacje.DaneKontaktoweDodatkowe(dane));

            NumerwRejestrzeEwidencji = ReturnStringOrNull(dane.FizCNumerwRejestrzeEwidencji);
            OrganRejestrowyNazwa = ReturnStringOrNull(dane.FizCOrganRejestrowyNazwa);
            RodzajRejestruNazwa = ReturnStringOrNull(dane.FizCRodzajRejestruNazwa);
        }

        private void DaneJednostkiFizycznejPozostala(DaneJednostkiFizycznejPozostala dane)
        {
            Regon = dane.FizRegon9;

            Nazwa = dane.FizNazwa;
            NazwaSkrocona = ReturnStringOrNull(dane.FizNazwaSkrocona);

            Daty = (Daty)dane;
            AddDaneAdresoweIfIsNotNull(Adres.Siedziba(dane));
            AddDaneKontaktoweIfIsNotNull(KontaktoweInformacje.DaneKontaktoweOgolne(dane));

            NumerwRejestrzeEwidencji = ReturnStringOrNull(dane.FizPNumerwRejestrzeEwidencji);
            OrganRejestrowyNazwa = ReturnStringOrNull(dane.FizPOrganRejestrowyNazwa);
            RodzajRejestruNazwa = ReturnStringOrNull(dane.FizPRodzajRejestruNazwa);
        }

        private void DaneJednostkiFizycznejRolnicza(DaneJednostkiFizycznejRolnicza dane)
        {
            Regon = dane.FizRegon9;

            Nazwa = dane.FizNazwa;
            NazwaSkrocona = ReturnStringOrNull(dane.FizNazwaSkrocona);

            Daty = (Daty)dane;
            AddDaneAdresoweIfIsNotNull(Adres.Siedziba(dane));
            AddDaneKontaktoweIfIsNotNull(KontaktoweInformacje.DaneKontaktoweOgolne(dane));
        }

        private void DaneJednostkiFizycznejWKrupgn(DaneJednostkiFizycznejWKrupgn dane)
        {
            Regon = dane.FizRegon9;

            Nazwa = dane.FizNazwa;
            NazwaSkrocona = ReturnStringOrNull(dane.FizNazwaSkrocona);

            Daty = (Daty)dane;
            AddDaneAdresoweIfIsNotNull(Adres.Siedziba(dane));
            AddDaneKontaktoweIfIsNotNull(KontaktoweInformacje.DaneKontaktoweOgolne(dane));
        }

        private void DaneJednostkiPrawnej(DaneJednostkiPrawnej dane)
        {
            Regon = dane.PrawRegon14;
            Nip = dane.PrawNip;

            Nazwa = dane.PrawNazwa;
            NazwaSkrocona = ReturnStringOrNull(dane.PrawNazwaSkrocona);

            Daty = (Daty)dane;
            AddDaneAdresoweIfIsNotNull(Adres.Siedziba(dane));
            AddDaneAdresoweIfIsNotNull(Adres.Korespondencja(dane));
            AddDaneKontaktoweIfIsNotNull(KontaktoweInformacje.DaneKontaktoweOgolne(dane));

            OrganRejestrowyNazwa = ReturnStringOrNull(dane.PrawOrganRejestrowyNazwa);
            PodstawowaFormaPrawnaNazwa = ReturnStringOrNull(dane.PrawPodstawowaFormaPrawnaNazwa);
            SzczegolnaFormaPrawnaNazwa = ReturnStringOrNull(dane.PrawSzczegolnaFormaPrawnaNazwa);
            FormaFinansowaniaNazwa = ReturnStringOrNull(dane.PrawFormaFinansowaniaNazwa);
            FormaWlasnosciNazwa = ReturnStringOrNull(dane.PrawFormaWlasnosciNazwa);
            OrganZalozycielskiNazwa = ReturnStringOrNull(dane.PrawOrganZalozycielskiNazwa);
            RodzajRejestruEwidencjiNazwa = ReturnStringOrNull(dane.PrawRodzajRejestruEwidencjiNazwa);
            NumerwRejestrzeEwidencji = ReturnStringOrNull(dane.PrawNumerWrejestrzeEwidencji);
        }

        private void DaneJednostkiLokalnaFizycznej(DaneJednostkiLokalnaFizycznej dane)
        {
            Regon = string.IsNullOrEmpty(dane.Lokfiz_regon14) ? dane.Lokfiz_regon9 : dane.Lokfiz_regon14;

            Nazwa = dane.Lokfiz_nazwa;

            Daty = (Daty)dane;
            AddDaneAdresoweIfIsNotNull(Adres.Siedziba(dane));

            FormaFinansowaniaNazwa = ReturnStringOrNull(dane.Lokfiz_formaFinansowania_Nazwa);
            NumerwRejestrzeEwidencji = ReturnStringOrNull(dane.Lokfiz_numerwRejestrzeEwidencji);
            OrganRejestrowyNazwa = ReturnStringOrNull(dane.Lokfiz_organRejestrowy_Nazwa);
            RodzajRejestruNazwa = ReturnStringOrNull(dane.Lokfiz_rodzajRejestru_Nazwa);
        }

        private void DaneJednostkiLokalnaPrawnej(DaneJednostkiLokalnaPrawnej dane)
        {
            Regon = dane.LokprawRegon14;
            Nip = dane.LokprawNip;

            Nazwa = dane.LokprawNazwa;

            Daty = (Daty)dane;
            AddDaneAdresoweIfIsNotNull(Adres.Siedziba(dane));

            PodstawowaFormaPrawnaNazwa = ReturnStringOrNull(dane.LokprawPodstawowaFormaPrawnaNazwa);
            SzczegolnaFormaPrawnaNazwa = ReturnStringOrNull(dane.LokprawSzczegolnaFormaPrawnaNazwa);
            FormaFinansowaniaNazwa = ReturnStringOrNull(dane.LokprawFormaFinansowaniaNazwa);
            FormaWlasnosciNazwa = ReturnStringOrNull(dane.LokprawFormaWlasnosciNazwa);
            OrganZalozycielskiNazwa = ReturnStringOrNull(dane.LokprawOrganZalozycielskiNazwa);

            NumerwRejestrzeEwidencji = ReturnStringOrNull(dane.LokprawNumerWrejestrzeEwidencji);
            OrganRejestrowyNazwa = ReturnStringOrNull(dane.LokprawOrganRejestrowyNazwa);
            RodzajRejestruEwidencjiNazwa = ReturnStringOrNull(dane.LokprawRodzajRejestruEwidencjiNazwa);
        }
        //==============================================================================================
        //==============================================================================================
        //Private methods
        //==============================================================================================
        private string? ReturnStringOrNull(string? value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            return value;
        }

        private void AddDaneAdresoweIfIsNotNull(Adres adres)
        {
            if (adres != null && !adres.IsNull())
            {
                DaneAdresowe.Add(adres);
            }
        }

        private void AddDaneKontaktoweIfIsNotNull(KontaktoweInformacje dane)
        {
            if (dane != null && !dane.IsNull())
            {
                DaneKontaktowe.Add(dane);
            }
        }
    }
}
