using GoF.Creation.Prototype.Entities;
using GoF.Creation.Prototype.Factories;

namespace GoF.Creation.Prototype
{
    public static class PrototypePresenter
    {
        public static void Present()
        {
            var baseDocument = new TextDocument
            {
                Header = "Dear Mr/Mrs",
                Name = "Recruitment",
                Description = "I`m happy to ...",
                Footer = "Kind Regards, A.Y.",
            };
            var factory = new TextDocumentFactory(baseDocument);
            var copy1 = factory.Copy();
            copy1.Description = "I`m happy to apply on your offer ...";

            Console.WriteLine(nameof(baseDocument));
            Console.WriteLine(baseDocument);
            Console.WriteLine(nameof(copy1));
            Console.WriteLine(copy1);
        }
    }
}
