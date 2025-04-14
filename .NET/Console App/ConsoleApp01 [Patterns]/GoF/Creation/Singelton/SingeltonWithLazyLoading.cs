// Ignore Spelling: Singelton
namespace GoF.Creation.Singelton
{
    public class SingeltonWithLazyLoading
    {
        // Properties
        private static readonly Lazy<SingeltonWithLazyLoading> _singelton = new Lazy<SingeltonWithLazyLoading>(() => new SingeltonWithLazyLoading());
        public string Text { get; set; } = string.Empty;


        // Constructor
        private SingeltonWithLazyLoading() { }


        // Methods
        public static SingeltonWithLazyLoading GetSingelton() => _singelton.Value;
    }
}
