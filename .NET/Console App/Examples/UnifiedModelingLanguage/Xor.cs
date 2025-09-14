namespace UnifiedModelingLanguage
{
    public enum XorRole
    {
        First, Hand, Third, Foth, Fifth
    }

    public class Xor
    {
        private static readonly List<XorRole> xorRoles = [XorRole.First, XorRole.Fifth];

        private readonly List<XorRole> roles = [];

        private IXorItem1? item1;
        private IXorItem2? item2;
        private IXorItem3? item3;
        private IXorItem4? item4;
        private IXorItem5? item5;

        public IXorItem1? Item1
        {
            get => item1;
            set
            {
                AddRole(XorRole.First);
                item1 = value;
            }
        }

        public IXorItem2? Item2
        {
            get => item2;
            set
            {
                AddRole(XorRole.Hand);
                item2 = value;
            }
        }

        public IXorItem3? Item3
        {
            get => item3;
            set
            {
                AddRole(XorRole.Third);
                item3 = value;
            }
        }

        public IXorItem4? Item4
        {
            get => item4;
            set
            {
                AddRole(XorRole.Foth);
                item4 = value;
            }
        }

        public IXorItem5? Item5
        {
            get => item5;
            set
            {
                AddRole(XorRole.Fifth);
                item5 = value;
            }
        }


        private void AddRole(XorRole role)
        {
            var existingXorRoles = roles.Intersect(xorRoles);
            if (existingXorRoles.Any())
            {
                throw new InvalidOperationException($"Can not input exist {existingXorRoles.First()}");
            }

            roles.Add(role);
        }
    }

    public record IXorItem1;
    public record IXorItem2;
    public record IXorItem3;
    public record IXorItem4;
    public record IXorItem5;
}
