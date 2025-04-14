namespace GoF.Structural.AdapterFamily.Adapter.Database
{
    public class Note
    {
        public int IdNote { get; init; }
        public string Description { get; set; } = null!;


        public override string ToString()
        {
            return $"{nameof(IdNote)}: {IdNote}\t\t{nameof(Description)}: {Description}";
        }
    }
}
