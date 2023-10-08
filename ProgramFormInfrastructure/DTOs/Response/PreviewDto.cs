using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramFormInfrastructure.DTOs.Response
{
    public class PreviewDto
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("benefits")]
        public string? Benefits { get; set; }
        [JsonProperty("criteria")]
        public string? Criteria { get; set; }
    }
}
