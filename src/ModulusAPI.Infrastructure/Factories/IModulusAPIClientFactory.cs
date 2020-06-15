using CluedIn.Crawling.ModulusAPI.Core;

namespace CluedIn.Crawling.ModulusAPI.Infrastructure.Factories
{
    public interface IModulusAPIClientFactory
    {
        ModulusAPIClient CreateNew(ModulusAPICrawlJobData modulusapiCrawlJobData);
    }
}
