using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS04.Models
{
    internal class Mammal
    {
        private List<MammalCLient> _mammalCLients = new List<MammalCLient>();
        public string Name { get; private set; } = null!;
        public string Species { get; private set; } = null!;

        public Mammal(string name, string species)
        {
            Name = name;
            Species = species;
        }

        public void SetClientInteraction(CLient cLient, DateTime Interaction)
        {
            new MammalCLient(cLient, this, Interaction);
        }
        public void SetClientInteraction(MammalCLient instance)
        {
            if (!_mammalCLients.Contains(instance)) { _mammalCLients.Add(instance); }
        }
        public List<MammalCLient> GetMammalCLients() => _mammalCLients;

        public override string ToString()
        {
            return $"Mammal: {Name} - {Species}";
        }
    }

    class MammalCLient
    {
        public CLient Client { get; private set; } = null!;
        public Mammal Mammal { get; private set; } = null!;
        public DateTime Interaction { get; private set; }

        public MammalCLient(CLient client, Mammal mammal, DateTime interaction)
        {
            Client = client;
            Mammal = mammal;
            Interaction = interaction;
            client.SetMammalInteraction(this);
            mammal.SetClientInteraction(this);
        }

        public override string ToString()
        {
            return $"Connection Bag: \nClient: {Client},\n Mammal: {Mammal},\n Interaction: {Interaction}\n";
        }
    }

    class CLient
    {
        private List<MammalCLient> _mammalCLients = new List<MammalCLient>();
        public string Name { get; private set; } = null!;
        public string Surname { get; private set; } = null!;

        public CLient(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
        public void SetMammalInteraction(Mammal mammal, DateTime Interaction)
        {
            new MammalCLient(this, mammal, Interaction);
        }
        public void SetMammalInteraction(MammalCLient instance)
        {
            if (!_mammalCLients.Contains(instance)) { _mammalCLients.Add(instance); }
        }
        public List<MammalCLient> GetMammalCLients() => _mammalCLients;

        public override string ToString()
        {
            return $"Client: {Name} {Surname}";
        }
    }
}
