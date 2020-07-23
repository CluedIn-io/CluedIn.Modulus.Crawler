using System.Collections.Generic;

using CluedIn.Core.Crawling;
using CluedIn.Crawling.ModulusAPI.Core;
using CluedIn.Crawling.ModulusAPI.Infrastructure.Factories;

namespace CluedIn.Crawling.ModulusAPI
{
    public class ModulusAPICrawler : ICrawlerDataGenerator
    {
        private readonly IModulusAPIClientFactory clientFactory;
        public ModulusAPICrawler(IModulusAPIClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public IEnumerable<object> GetData(CrawlJobData jobData)
        {
            if (!(jobData is ModulusAPICrawlJobData modulusapicrawlJobData))
            {
                yield break;
            }

            var client = clientFactory.CreateNew(modulusapicrawlJobData);

            //retrieve data from provider and yield objects
            foreach (var item in client.GetResponse(modulusapicrawlJobData.Url))
            {
                yield return item;
            }
            
        }       
    }
}
