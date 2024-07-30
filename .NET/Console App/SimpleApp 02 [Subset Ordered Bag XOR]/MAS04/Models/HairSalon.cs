using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS04.Models
{
    public enum Status { Add, Exist, NotExistInListsHairDressers }
    internal class HairSalon
    {
        private Dictionary<int, HairDresser> _hairDressers = new Dictionary<int, HairDresser>();
        private Dictionary<int, MaangerSalon> _managers = new Dictionary<int, MaangerSalon>();
        
        public int IdHairSalon { get; private set; }
        public string NameHairSalon { get; private set; } = null!;

        public HairSalon (int id, string name) 
        { 
            IdHairSalon = id;
            NameHairSalon = name;
        }
        public Dictionary<int, HairDresser> GetHairDressers () => _hairDressers;
        private Dictionary<int, MaangerSalon> GetManagers () => _managers;

        public Status SetHairDresser(HairDresser hairDresser) 
        {
            if (_hairDressers.ContainsKey(hairDresser.Id)) { return Status.Exist; }
            
            _hairDressers.Add(hairDresser.Id, hairDresser);
            hairDresser.SetSalon(this);
            return Status.Add;
        }

        public Status SetManager(MaangerSalon maangerSalon) 
        {
            if (_managers.ContainsKey(maangerSalon.Manager.Id)) { return Status.Exist; }
            if (!_hairDressers.ContainsKey(maangerSalon.Manager.Id)) 
            {  return Status.NotExistInListsHairDressers; }
            
            _managers.Add(maangerSalon.Manager.Id, maangerSalon);
            maangerSalon.SetSalon(this);
            return Status.Add;           
        }

    }
    class HairDresser 
    {
        private Dictionary<int, HairSalon> _salons = new Dictionary<int, HairSalon>();

        public int Id { get; private set; }
        public string Name { get; private set; } = null!;

        public HairDresser ( int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Status SetSalon(HairSalon salon) 
        {
            if (_salons.ContainsKey(salon.IdHairSalon)) { return Status.Exist; }
            
            _salons.Add(salon.IdHairSalon, salon);
            salon.SetHairDresser(this);
            return Status.Add;
        }
    }
    class MaangerSalon
    {
        private Dictionary<int, HairSalon> _salons = new Dictionary<int, HairSalon>();
        public HairDresser Manager { get; private set; } = null!;
        public string TitleManager { get; private set; } = null!;

        public MaangerSalon (HairDresser hairDresser, string title) 
        { 
            Manager = hairDresser;
            TitleManager = title;
        }
        public Status SetSalon(HairSalon salon)
        {
            if (_salons.ContainsKey(salon.IdHairSalon)) { return Status.Exist; }
            if (!salon.GetHairDressers().ContainsKey(Manager.Id)) 
            { return Status.NotExistInListsHairDressers; }
            
            _salons.Add(salon.IdHairSalon, salon);
            salon.SetManager(this);
            return Status.Add;
        }
    }
}
