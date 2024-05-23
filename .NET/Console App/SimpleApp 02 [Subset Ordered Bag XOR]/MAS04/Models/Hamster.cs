using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS04.Models
{
    internal class Hamster
    {
        private List<Owner> _owners = new List<Owner>();
        public string Name { get; private set; } = null!;
        public DateOnly BirthDate { get; private set; }

        public Hamster(string name, DateOnly birthDate) 
        { 
            Name = name;
            BirthDate = birthDate;
        }

        public Status SetOwner(Owner owner) 
        {
            if (_owners.Contains(owner)) { return Status.Exist; }
            _owners.Add(owner);
            _owners.Sort( (s ,z ) => 
            { 
                if (s.BirthDate >= z.BirthDate) return 1;
                else return -1;
            } );
            owner.SetHamster(this);
            return Status.Add;
        }

        public override string ToString()
        {
            return $"Hamster: {Name}, Birth Date: {BirthDate.ToString()}";
        }

        public List<Owner> Owners () => _owners;
    }
    class Owner 
    {
        private List<Hamster> _hamsters = new List<Hamster>();
        public string Name { get; private set; } = null!;
        public string Surname { get; private set; } = null!;
        public DateOnly BirthDate { get; private set; }

        public Owner(string name, string surname, DateOnly birthDate)
        {
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
        }

        public Status SetHamster(Hamster hamster) 
        {
            if (_hamsters.Contains(hamster)) { return Status.Exist; }
            _hamsters.Add(hamster);
            _hamsters.Sort((s, z) =>
            {
                if (s.BirthDate >= z.BirthDate) return 1;
                else return -1;
            });
            hamster.SetOwner(this);
            return Status.Add;
        }

        public override string ToString()
        {
            return $"Owner: {Name} {Surname}, BirthDate: {BirthDate.ToString()}";
        }

        public List<Hamster> Hamsters () => _hamsters;
    }
}
