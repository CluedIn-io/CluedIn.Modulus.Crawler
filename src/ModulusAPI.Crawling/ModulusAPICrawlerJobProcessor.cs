using CluedIn.Crawling.ModulusAPI.Core;

namespace CluedIn.Crawling.ModulusAPI
{
    public class ModulusAPICrawlerJobProcessor : GenericCrawlerTemplateJobProcessor<ModulusAPICrawlJobData>
    {
        public ModulusAPICrawlerJobProcessor(ModulusAPICrawlerComponent component) : base(component)
        {
        }
    }
}
