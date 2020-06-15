using Castle.Windsor;
using CluedIn.Core;
using CluedIn.Core.Providers;
using CluedIn.Crawling.ModulusAPI.Infrastructure.Factories;
using Moq;

namespace CluedIn.Provider.ModulusAPI.Unit.Test.ModulusAPIProvider
{
    public abstract class ModulusAPIProviderTest
    {
        protected readonly ProviderBase Sut;

        protected Mock<IModulusAPIClientFactory> NameClientFactory;
        protected Mock<IWindsorContainer> Container;

        protected ModulusAPIProviderTest()
        {
            Container = new Mock<IWindsorContainer>();
            NameClientFactory = new Mock<IModulusAPIClientFactory>();
            var applicationContext = new ApplicationContext(Container.Object);
            Sut = new ModulusAPI.ModulusAPIProvider(applicationContext, NameClientFactory.Object);
        }
    }
}
