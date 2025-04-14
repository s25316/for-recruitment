// Ignore Spelling: Creational
using GoF.Creation.AbstractFactory;
using GoF.Creation.Builder.Option1;
using GoF.Creation.Builder.Option2;
using GoF.Creation.FactoryMethod;
using GoF.Creation.Prototype;
using GoF.Creation.Singelton;
using GoF.Structural.AdapterFamily.Adapter;
using GoF.Structural.AdapterFamily.Decorator;
using GoF.Structural.AdapterFamily.Facade;
using GoF.Structural.AdapterFamily.Proxy;
using GoF.Structural.Bridge;
using GoF.Structural.Composite;
using GoF.Structural.Flyweight;

namespace GoF
{
    public static class Presenter
    {
        public static void Present()
        {
            /*
             * Creational Patterns
             */
            FactoryMethodPresenter.Present();
            Console.WriteLine("\n===============================");

            AbstractFactoryPresenter.Present();
            Console.WriteLine("\n===============================");

            SingeltonPresenter.Present();
            Console.WriteLine("\n===============================");

            BuilderOption1Presenter.Present();
            Console.WriteLine();
            BuilderOption2Presenter.Present();
            Console.WriteLine("\n===============================");

            PrototypePresenter.Present();
            Console.WriteLine("\n===============================");

            /*
             * Structural Patterns
             */
            AdapterPresenter.Present();
            Console.WriteLine("\n===============================");

            ProxyPresenter.Present();
            Console.WriteLine("\n===============================");

            DecoratorPresenter.Present();
            Console.WriteLine("\n===============================");

            FacadePresenter.Present();
            Console.WriteLine("\n===============================");

            // Always 3 part: Interface/Abstraction + Leaf + Composite/Node
            CompositePresenter.Present();
            Console.WriteLine("\n===============================");

            BridgePresenter.Present();
            Console.WriteLine("\n===============================");

            FlyweightPresenter.Present();
            Console.WriteLine("\n===============================");
        }
    }
}
