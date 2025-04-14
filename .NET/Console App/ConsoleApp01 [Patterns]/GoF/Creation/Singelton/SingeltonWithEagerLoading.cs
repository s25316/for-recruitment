// Ignore Spelling: Singelton
namespace GoF.Creation.Singelton
{
    public class SingeltonWithEagerLoading
    {
        // Properties
        private static volatile SingeltonWithEagerLoading _singelton = new SingeltonWithEagerLoading();
        public string Text { get; set; } = string.Empty;


        // Constructor
        private SingeltonWithEagerLoading() { }


        // Methods
        public static SingeltonWithEagerLoading GetSingelton() => _singelton;
    }
}
