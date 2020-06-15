using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using CluedIn.Core.Logging;
using CluedIn.Core.Providers;
using CluedIn.Crawling.ModulusAPI.Core;
using CluedIn.Crawling.ModulusAPI.Core.Models;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using RestSharp;

namespace CluedIn.Crawling.ModulusAPI.Infrastructure
{
    // TODO - This class should act as a client to retrieve the data to be crawled.
    // It should provide the appropriate methods to get the data
    // according to the type of data source (e.g. for AD, GetUsers, GetRoles, etc.)
    // It can receive a IRestClient as a dependency to talk to a RestAPI endpoint.
    // This class should not contain crawling logic (i.e. in which order things are retrieved)
    public class ModulusAPIClient
    {
        private const string BaseUri = "http://sample.com";

        private readonly ILogger log;

        private readonly IRestClient client;

        public ModulusAPIClient(ILogger log, ModulusAPICrawlJobData modulusapiCrawlJobData, IRestClient client) // TODO: pass on any extra dependencies
        {
            if (modulusapiCrawlJobData == null)
            {
                throw new ArgumentNullException(nameof(modulusapiCrawlJobData));
            }

            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            this.log = log ?? throw new ArgumentNullException(nameof(log));
            this.client = client ?? throw new ArgumentNullException(nameof(client));

            // TODO use info from modulusapiCrawlJobData to instantiate the connection
            client.BaseUrl = new Uri(BaseUri);
            client.AddDefaultParameter("api_key", modulusapiCrawlJobData.ApiKey, ParameterType.QueryString);
        }

        private async Task<T> GetAsync<T>(string url)
        {
            var request = new RestRequest(url, Method.GET);

            var response = await client.ExecuteTaskAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                var diagnosticMessage = $"Request to {client.BaseUrl}{url} failed, response {response.ErrorMessage} ({response.StatusCode})";
                log.Error(() => diagnosticMessage);
                throw new InvalidOperationException($"Communication to jsonplaceholder unavailable. {diagnosticMessage}");
            }

            var data = JsonConvert.DeserializeObject<T>(response.Content);

            return data;
        }

        public AccountInformation GetAccountInformation()
        {
            //TODO - return some unique information about the remote data source
            // that uniquely identifies the account
            return new AccountInformation("", "");
        }

        public IEnumerable<ModulusAPIResponse> GetResponse(string filepath, string url)
        {
            foreach (var item in Directory.GetFiles(filepath, "modulusAPIpeople.txt"))
            {
                using (var parser = new TextFieldParser(item))
                {
                    while (!parser.EndOfData)
                    {
                        var client = new RestClient(url);
                        var request = new RestRequest("persons/{individ_id}", Method.GET);
                        request.AddHeader("Content-type", "application/json");
                        request.AddParameter("individ_id", parser.ReadLine(), ParameterType.UrlSegment);
                        var response = client.ExecuteTaskAsync<ModulusAPIResponse>(request).Result.Data;
                        yield return response;
                    }
                }
            }
        }
    }
}
