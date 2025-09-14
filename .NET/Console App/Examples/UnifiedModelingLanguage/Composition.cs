namespace UnifiedModelingLanguage
{
    public partial record BaseObject
    {
        private readonly IList<CompositionObject> compositions = new List<CompositionObject>();


        public void AddComposition(CompositionObject composition) => compositions.Add(composition);
    }

    // Good version of Composition Object
    public partial record BaseObject
    {
        public record CompositionObject
        {
            private readonly BaseObject baseObject;


            protected CompositionObject(BaseObject baseObject)
            {
                this.baseObject = baseObject;
            }


            public static CompositionObject Create(BaseObject baseObject) => new(baseObject);
        }
    }
}
