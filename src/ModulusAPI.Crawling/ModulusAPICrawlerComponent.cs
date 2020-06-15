using CluedIn.Core;
using CluedIn.Crawling.ModulusAPI.Core;

using ComponentHost;

namespace CluedIn.Crawling.ModulusAPI
{
    [Component(ModulusAPIConstants.CrawlerComponentName, "Crawlers", ComponentType.Service, Components.Server, Components.ContentExtractors, Isolation = ComponentIsolation.NotIsolated)]
    public class ModulusAPICrawlerComponent : CrawlerComponentBase
    {
        public ModulusAPICrawlerComponent([NotNull] ComponentInfo componentInfo)
            : base(componentInfo)
        {
        }
    }
}

