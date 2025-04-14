// Ignore Spelling: Singelton

namespace GoF.Creation.Singelton
{
    public class SingeltonWithLock
    {
        /*
         * _lock    - objekt blokujacy
         * volatile - w kontekscie wielowątkowosci dla zapisu/odczytu, synchroniuzacja danych medzy watkami
         *          - zapobieganie optymalizacjom kompilatora, np. 1-wszy watek zmieni a 2-gi przez optymalizacje C# pokazuje stara wartosc
         */
        // Properties
        private static readonly object _lock = new object();
        private static volatile SingeltonWithLock? _singelton = null;
        public string Text { get; set; } = string.Empty;


        // Constructor
        private SingeltonWithLock() { }


        // Methods
        public static SingeltonWithLock GetSingelton()
        {
            if (_singelton == null)
            {
                lock (_lock)
                {
                    if (_singelton == null)
                    {
                        _singelton = new SingeltonWithLock();
                    }
                }
            }

            return _singelton;
        }
    }
}
