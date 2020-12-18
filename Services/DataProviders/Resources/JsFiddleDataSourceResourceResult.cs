using Newtonsoft.Json;
using System.Collections.Generic;

namespace Services.DataProviders.Resources
{

    public class JsFiddleDataSourceResourceResult
    {

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("overallResultSetCount")]
        public int OverallResultSetCount { get; set; }

        [JsonProperty("list")]
        public List<FiddleProjectResourceResult> Fiddles { get; set; }


    }

    public class FiddleProjectResourceResult
    {
        [JsonProperty("framework")]
        public string Framework { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("latest_version")]
        public int LatestVersion { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

    }

}
