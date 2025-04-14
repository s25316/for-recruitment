using GoF.Creation.Prototype.Interfaces;

namespace GoF.Creation.Prototype.Entities
{
    public class TextDocument : ICopyable
    {
        // Properties
        public string Header { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Footer { get; set; } = null!;

        // Methods
        public object Copy()
        {
            return new TextDocument
            {
                Header = this.Header,
                Name = this.Name,
                Description = this.Description,
                Footer = this.Footer,
            };
        }

        public override string ToString()
        {
            return string.Format(
                "{0}\n{1}\n{2}\n{3}\n",
                $"{nameof(Header)}: {Header}",
                $"{nameof(Name)}: {Name}",
                $"{nameof(Description)}: {Description}",
                $"{nameof(Footer)}: {Footer}"
                );
        }
    }
}
