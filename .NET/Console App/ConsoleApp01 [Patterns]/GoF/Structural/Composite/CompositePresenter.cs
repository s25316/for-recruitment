using GoF.Structural.Composite.Entities;

namespace GoF.Structural.Composite
{
    public static class CompositePresenter
    {
        // Properties
        private static readonly Random _random = new Random();

        public static void Present()
        {
            var list = PrepareTree();
            var sum = 0;

            foreach (var item in list)
            {
                sum += item.GetChildrenCount();
            }
            sum += list.Count;

            Console.WriteLine($"{TreeElement.Counter} {sum} {TreeElement.Counter == sum}");
        }

        private static List<TreeElement> PrepareTree()
        {
            var list = new List<TreeElement>();

            var zeroLevelCount = Random(10, 50);
            for (int i = 0; i < zeroLevelCount; i++)
            {
                var composite0 = new Entities.Composite();
                list.Add(composite0);

                var firstLevelCount = Random(0, 50);
                for (int j = 0; j < firstLevelCount; j++)
                {
                    var composite1 = new Entities.Composite();
                    composite0.Add(composite1);

                    var handLevelCount = Random(0, 50);
                    for (int n = 0; n < handLevelCount; n++)
                    {
                        var composite2 = new Entities.Composite();
                        composite1.Add(composite2);

                        var thirdLevelCount = Random(0, 50);
                        for (int k = 0; k < thirdLevelCount; k++)
                        {
                            var composite3 = new Entities.Composite();
                            composite2.Add(composite3);
                            SetLeafs(composite3);
                        }
                        if (firstLevelCount == 0)
                        {
                            SetLeafs(composite2);
                        }
                    }
                    if (firstLevelCount == 0)
                    {
                        SetLeafs(composite1);
                    }
                }
                if (firstLevelCount == 0)
                {
                    SetLeafs(composite0);
                }
            }
            return list;
        }

        private static void SetLeafs(Entities.Composite composite)
        {
            var count = Random(10, 50);
            for (int i = 0; i < count; i++)
            {
                composite.Add(new Leaf());
            }
        }

        private static int Random(int start, int end) => _random.Next(start, end);
    }
}
