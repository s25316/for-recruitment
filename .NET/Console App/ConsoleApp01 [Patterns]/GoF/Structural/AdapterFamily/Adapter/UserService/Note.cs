namespace GoF.Structural.AdapterFamily.Adapter.UserService
{
    public class Note
    {
        public int? Id { get; set; } = null;
        public string Text { get; set; } = null!;

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}\t\t{nameof(Text)}: {Text}";
        }
    }
}
