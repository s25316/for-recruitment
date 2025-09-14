namespace UnifiedModelingLanguage
{
    public record SubsetObject1
    {
        /// <summary>
        /// {ordered} - if items in list (collection) is ordered
        /// </summary>
        public readonly List<SubsetObject2> list = [];

        /// <summary>
        /// {subset} - if all items from subsetList contains in list;
        /// Example: Employees in group and Managers in Group 
        /// </summary>
        public readonly List<SubsetObject2> subsetList = [];


        public void Add(SubsetObject2 subset) => list.Add(subset);
        public void AddSubset(SubsetObject2 subset)
        {
            if (!list.Contains(subset)) throw new InvalidOperationException("Should be contains in list");
            subsetList.Add(subset);
        }
    }

    public record SubsetObject2;
}
