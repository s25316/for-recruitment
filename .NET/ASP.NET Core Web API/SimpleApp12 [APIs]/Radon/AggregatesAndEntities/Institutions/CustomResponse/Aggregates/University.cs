using Radon.AggregatesAndEntities.Institutions.CoreResponse.Level2;
using Radon.AggregatesAndEntities.Institutions.CustomResponse.Entities;
using Radon.AggregatesAndEntities.Shared;

namespace Radon.AggregatesAndEntities.Institutions.CustomResponse.Aggregates
{
    public class University
    {
        public Guid? InstitutionUuid { get; private set; } = null;
        public string? Regon { get; private set; } = null;
        public string? Nip { get; private set; } = null;
        public string? Krs { get; private set; } = null;
        //============================================
        public string? Name { get; private set; } = null;
        public string? KindName { get; private set; } = null; //Uczelnioa publicna
        public string? TypeName { get; private set; } = null; //akademicka
        public string? SiTypeName { get; private set; } = null; // Typ instytucji naukowej ??
        public string? Status { get; private set; } = null;
        //============================================
        public string? Www { get; private set; } = null;
        public string? EMail { get; private set; } = null;
        public string? Phone { get; private set; } = null;
        //============================================
        public DateOnly? StartDT { get; private set; } = null;
        public DateOnly? LiqStartDT { get; private set; } = null;
        public DateOnly? LiqDT { get; private set; } = null;
        //============================================
        public Manager Manager { get; private set; } = null!;
        public Shared.Address Address { get; private set; } = null!;
        //============================================
        public List<Branch> Branches { get; private set; } = new();
        public List<TransformedInstitution> TransformedInstitutions { get; private set; } = new();
        public List<TransformedInstitution> TargetInstitutions { get; private set; } = new();
        public List<Name> Names { get; private set; } = new();
        public List<Status> Statuses { get; private set; } = new();
        public List<ResultType> Types { get; private set; } = new();
        public List<CoreResponse.Level2.Address> Addresses { get; private set; } = new();


        public University(CoreResponse.Level1.University university)
        {
            InstitutionUuid = university.InstitutionUuid;
            Regon = university.Regon;
            Nip = university.Nip;
            Krs = university.Krs;
            //============================================
            Name = university.Name;
            KindName = university.IKindName;
            TypeName = university.UTypeName;
            SiTypeName = university.SiTypeName;
            Status = university.Status;
            //============================================
            StartDT = university.IStartDT;
            LiqStartDT = university.ILiqStartDT;
            LiqDT = university.ILiqDT;
            //============================================
            Www = university.Www;
            EMail = university.EMail;
            Phone = university.Phone;
            //============================================
            Manager = (Manager)university;
            Address = (Shared.Address)university;
            //============================================
            Branches = university.Branches;
            TransformedInstitutions = university.TransformedInstitutions;
            TargetInstitutions = university.TargetInstitutions;
            Names = university.Names;
            Statuses = university.Statuses;
            Types = university.Types;
            Addresses = university.Addresses;
        }

        public static implicit operator University(CoreResponse.Level1.University university)
        {
            return new University(university);
        }
    }
}
