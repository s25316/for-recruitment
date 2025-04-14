using GoF.Creation.Prototype.Entities;

namespace GoF.Creation.Prototype.Factories
{
    public class TextDocumentFactory
    {
        // Properties
        public TextDocument Document { get; set; }


        // Constructor
        public TextDocumentFactory(TextDocument document)
        {
            Document = document;
        }


        // Methods
        public TextDocument Copy() => (TextDocument)Document.Copy();
    }
}
