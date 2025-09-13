namespace GangOfFour.Creation
{
    // ==========================================================================================================
    // ==========================================================================================================
    // Classic Version => not in common use
    public record Item1
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Description { get; set; } = null!;

        public Item1(string name, string surname, string description)
        {
            this.Name = name;
            this.Surname = surname;
            this.Description = description;
        }
    }

    public class Item1Builder
    {
        private string name { get; set; } = null!;
        private string surname { get; set; } = null!;
        private string description { get; set; } = null!;

        public Item1Builder SetName(string name)
        {
            this.name = name;
            return this;
        }

        public Item1Builder SetSurname(string surname)
        {
            this.surname = surname;
            return this;
        }

        public Item1Builder SetDescription(string description)
        {
            this.description = description;
            return this;
        }

        public Item1 Build() => new Item1(name, surname, description);
    }

    /// <summary>
    /// Director - is optional
    /// </summary>
    public static class BuilderDirector
    {
        public static Item1 Build() => new Item1Builder()
            .SetName("John")
            .SetSurname("Reese")
            .SetDescription("Person")
            .Build();

        public static Item1 BuildWithOutDescription() => new Item1Builder()
            .SetName("John")
            .SetSurname("Reese")
            .Build();
    }

    // ==========================================================================================================
    // ==========================================================================================================
    // Common Version
    public record Item2
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Description { get; set; } = null!;

        public Item2(string name, string surname, string Description)
        {
            this.Name = name;
            this.Surname = surname;
            this.Description = Description;
        }

        public class Builder
        {
            private string name { get; set; } = null!;
            private string surname { get; set; } = null!;
            private string description { get; set; } = null!;

            public Builder SetName(string name)
            {
                this.name = name;
                return this;
            }

            public Builder SetSurname(string surname)
            {
                this.surname = surname;
                return this;
            }

            public Builder SetDescription(string description)
            {
                this.description = description;
                return this;
            }

            // Can created by Policy
            public Item2 Build() => new Item2(name, surname, description);
        }
    }
}
