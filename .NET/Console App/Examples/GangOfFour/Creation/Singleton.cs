namespace GangOfFour.Creation
{
    // Problems: SRP (Creating && Business logic), Testing, Anti-pattern
    // sealed, private constructor, has method creating Object, Lazy loading

    // ==========================================================================================================
    // ==========================================================================================================
    public sealed class LockSingleton
    {
        private readonly static object lockObj = new object();
        private static volatile LockSingleton? singleton;


        private LockSingleton() { }


        public static LockSingleton Get()
        {
            if (singleton is not null)
            {
                return singleton;
            }

            lock (lockObj)
            {
                singleton = new LockSingleton();
            }
            return singleton;
        }
    }

    // ==========================================================================================================
    // ==========================================================================================================
    // Lazy, has inside lock
    public sealed class LazyLoadingSingleton
    {
        private static readonly Lazy<LazyLoadingSingleton> singleton = new Lazy<LazyLoadingSingleton>(() => new LazyLoadingSingleton());


        private LazyLoadingSingleton() { }


        public static LazyLoadingSingleton Get() => singleton.Value;
    }
}
