using System.Collections.Generic;
using CluedIn.Crawling.ModulusAPI.Core;

namespace CluedIn.Crawling.ModulusAPI.Integration.Test
{
  public static class ModulusAPIConfiguration
  {
    public static Dictionary<string, object> Create()
    {
      return new Dictionary<string, object>
            {
                { ModulusAPIConstants.KeyName.ApiKey, "demo" }
            };
    }
  }
}
