using CluedIn.Core.Crawling;

namespace CluedIn.Crawling.ModulusAPI.Core
{
    public class ModulusAPICrawlJobData : CrawlJobData
    {
        public string ApiKey { get; set; }
        public string Url { get; set; }

    }
}
