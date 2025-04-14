// Ignore Spelling: Singelton

namespace GoF.Creation.Singelton
{
    public static class SingeltonPresenter
    {
        public static void Present()
        {
            Console.WriteLine(nameof(SingeltonWithLock));
            var singeltonWithLock1 = SingeltonWithLock.GetSingelton();
            var singeltonWithLock2 = SingeltonWithLock.GetSingelton();

            singeltonWithLock1.Text = "I`m The One";
            Console.WriteLine(singeltonWithLock1.Text);
            Console.WriteLine(singeltonWithLock2.Text);
            Console.WriteLine();

            Console.WriteLine(nameof(SingeltonWithEagerLoading));
            var singeltonWithEagerLoading1 = SingeltonWithEagerLoading.GetSingelton();
            var singeltonWithEagerLoading2 = SingeltonWithEagerLoading.GetSingelton();

            singeltonWithEagerLoading1.Text = "I`m The One";
            Console.WriteLine(singeltonWithEagerLoading1.Text);
            Console.WriteLine(singeltonWithEagerLoading2.Text);
            Console.WriteLine();

            Console.WriteLine(nameof(SingeltonWithLazyLoading));
            var singeltonWithLazyLoading1 = SingeltonWithLazyLoading.GetSingelton();
            var singeltonWithLazyLoading2 = SingeltonWithLazyLoading.GetSingelton();

            singeltonWithLazyLoading1.Text = "I`m The One";
            Console.WriteLine(singeltonWithLazyLoading1.Text);
            Console.WriteLine(singeltonWithLazyLoading2.Text);
            Console.WriteLine();
        }
    }
}
