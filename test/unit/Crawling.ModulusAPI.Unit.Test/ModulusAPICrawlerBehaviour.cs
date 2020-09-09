using CluedIn.Core.Crawling;
using CluedIn.Crawling;
using CluedIn.Crawling.ModulusAPI;
using CluedIn.Crawling.ModulusAPI.Infrastructure.Factories;
using Moq;
using Shouldly;
using Xunit;

namespace Crawling.ModulusAPI.Unit.Test
{
    public class ModulusAPICrawlerBehaviour
    {
        private readonly ICrawlerDataGenerator _sut;

        public ModulusAPICrawlerBehaviour()
        {
            var nameClientFactory = new Mock<IModulusAPIClientFactory>();

            _sut = new ModulusAPICrawler(nameClientFactory.Object);
        }

        [Fact]
        public void GetDataReturnsData()
        {
            var jobData = new CrawlJobData();

            _sut.GetData(jobData)
                .ShouldNotBeNull();
        }
    }
}
