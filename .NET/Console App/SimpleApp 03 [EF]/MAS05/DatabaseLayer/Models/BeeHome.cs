namespace MAS05.DatabaseLayer.Models
{
    internal class BeeHome
    {
        public int IdBeeHome { get; set; }
        public string Name { get; set; } = null!;
        public int MaxSize { get; set; }

        public virtual ICollection<BeeHomeAndBee> BeeHomeAndBees { get; set; } = new List<BeeHomeAndBee>();

    }
}
