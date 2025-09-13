namespace UnifiedModelingLanguage
{
    public abstract record BaseCompositionObject
    {
        public abstract record Composition(BaseCompositionObject Base);
    }
}
