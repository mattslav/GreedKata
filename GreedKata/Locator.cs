using Autofac;
using GreedKata.Interface;

namespace GreedKata
{
    public class Locator
    {
        private ContainerBuilder _containerBuilder;
        private IContainer _container;

        public Locator()
        {
            ContainerBuilder.Register(x => new Game(x.Resolve<IDiceCreator>(), x.Resolve<ICalculator>()));
            ContainerBuilder.RegisterType<DiceCreator>().As<IDiceCreator>();
            ContainerBuilder.RegisterType<Calculator>().As<ICalculator>();
        }

        private ContainerBuilder ContainerBuilder
        {
            get
            {
                return _containerBuilder ?? (_containerBuilder = new ContainerBuilder());
            }
        }

        private IContainer Container
        {
            get
            {
                return _container ?? (_container = ContainerBuilder.Build());
            }
        }

        public IGame Game
        {
            get
            {
                return Container.Resolve<Game>();
            }
        }

    }
}
