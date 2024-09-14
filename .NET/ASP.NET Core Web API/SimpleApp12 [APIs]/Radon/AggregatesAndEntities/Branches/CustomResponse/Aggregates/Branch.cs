using Radon.AggregatesAndEntities.Branches.CoreResponse.Level2;

namespace Radon.AggregatesAndEntities.Branches.CustomResponse.Aggregates
{
    public class Branch
    {
        public Guid BranchUuid { get; set; }
        public string Regon { get; set; } = null!;
        public string Nip { get; set; } = null!;
        public string? Krs { get; set; } = null;


        public string Name { get; set; } = null!;
        public string Status { get; set; } = null!;

        public string? Www { get; set; } = null;
        public string? EMail { get; set; } = null;
        public string? Phone { get; set; } = null;

        public DateOnly? CreationDate { get; set; }
        public DateOnly? LiquidationStartDate { get; set; } = null;
        public DateOnly? LiquidationDate { get; set; } = null;

        public Shared.Address Address { get; set; } = null!;

        public List<Name> Names { get; set; } = new();
        public List<Status> Statuses { get; set; } = new();
        public List<Address> Addresses { get; set; } = new();

        public Branch(CoreResponse.Level1.Branch branch)
        {
            Address = (Shared.Address)branch;
            BranchUuid = branch.BranchUuid;
            Regon = branch.Regon;
            Nip = branch.Nip;
            Krs = branch.Krs;

            Name = branch.Name;
            Status = branch.Status;
            CreationDate = branch.CreationDate;
            LiquidationStartDate = branch.LiquidationStartDate;
            LiquidationDate = branch.LiquidationDate;
            Www = branch.Www;
            EMail = branch.EMail;
            Phone = branch.Phone;

            Names = branch.Names;
            Statuses = branch.Statuses;
            Addresses = branch.Addresses;
        }


    }
}
