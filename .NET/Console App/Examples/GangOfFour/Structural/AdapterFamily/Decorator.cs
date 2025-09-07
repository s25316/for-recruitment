namespace GangOfFour.Structural.AdapterFamily
{
    public interface IComponent
    {
        void Invoke();
    }

    public abstract class ComponentDecorator : IComponent
    {
        private IComponent? component;


        // Variant 1
        protected ComponentDecorator(IComponent component)
        {
            this.component = component;
        }
        // Variant 2
        protected ComponentDecorator() { }
        public virtual void Set(IComponent component) => this.component = component;


        protected abstract void InvokeBusinessLogic();
        public virtual void Invoke()
        {
            component?.Invoke();
            InvokeBusinessLogic();
        }
    }
}
