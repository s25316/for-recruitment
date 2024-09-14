using Regon.Factories;
using Regon.ValueObjectsAndTheirExceptions.SilosIdValue;
using Regon.ValueObjectsAndTheirExceptions.TypJednostkiValue;
using System.Reflection;

namespace Regon.ValueObjectsAndTheirExceptions.NazwaRaportuValue
{
    /// <summary>
    /// Nazwa komunikatu służonca dla metody DanePobierzPelnyRaport celem pobrania pełnej informacji o Dizałalności
    /// </summary>
    /// <exception cref="NazwaRaportuException"></exception>
    public record NazwaRaportu
    {
        public NazwaRaportuEnum Name { get; private set; }

        public NazwaRaportu(TypJednostki typ, SilosId silosId)
        {
            Name = GetNazwaRaportu(typ, silosId);
        }

        //===========================================================================================================
        //===========================================================================================================
        //Private Methods
        //===========================================================================================================
        private NazwaRaportuEnum GetNazwaRaportu(TypJednostki typ, SilosId silosId)
        {
            if (typ.Value == "F") //Jeśli podmiot to osoba fizyczna 
            {
                var fizycznaRaportDictionary = new Dictionary<int, NazwaRaportuEnum>
                {
                    //jeśli podmiot prowadzi działalność zarejestrowaną w CEIDG 
                    { 1, NazwaRaportuEnum.PublDaneRaportDzialalnoscFizycznejCeidg }, 
                    //jeśli podmiot jest rolnikiem 
                    { 2, NazwaRaportuEnum.PublDaneRaportDzialalnoscFizycznejRolnicza },
                    //jeśli podmiot prowadzi działalność inną niż 1) i 2)  
                    { 3, NazwaRaportuEnum.PublDaneRaportDzialalnoscFizycznejPozostala },
                    
                    /*
                    jeśli działalność osoby fizycznej została skreślona z rejestru REGON w poprzednim systemie 
                    informatycznym (w którym nie było rozróżnienia typów działalności), tj. przed datą 08.11.2014 

                    (Uwaga: dana osoba fizyczna mogła w międzyczasie założyć nową działalność gospodarczą, wtedy 
                    odpowiedź będzie wg punktów 1-3)
                     */
                    { 4, NazwaRaportuEnum.PublDaneRaportDzialalnoscFizycznejWKrupgn },
                };
                if (fizycznaRaportDictionary.TryGetValue(silosId.Value, out var raportNameFizyczna))
                {
                    return raportNameFizyczna;
                }
            }

            var nieFizycznaRaportDictionary = new Dictionary<string, NazwaRaportuEnum>
            {
                { "P", NazwaRaportuEnum.PublDaneRaportPrawna }, //Jeśli podmiot to osoba prawna 
                { "LP", NazwaRaportuEnum.PublDaneRaportLokalnaPrawnej },//Jeśli podmiot to jednostka lokalna osoby prawnej 
                { "LF", NazwaRaportuEnum.PublDaneRaportLokalnaFizycznej } //
            };
            if (nieFizycznaRaportDictionary.TryGetValue(typ.Value, out var raportNameNieFizyczna))
            {
                return raportNameNieFizyczna;
            }
            throw new NazwaRaportuException(MessagesFactory.GenerateExeptionMessageNazwaRaportuNotImplementedValue
                (
                this.GetType(),
                MethodBase.GetCurrentMethod(),
                typ,
                silosId
                ));
        }

    }
}
