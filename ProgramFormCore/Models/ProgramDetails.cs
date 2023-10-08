using Newtonsoft.Json;

namespace ProgramFormCore.Models
{

    public class ProgramDetails : BaseEntity
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("summary")]
        public string? Summary { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        //make it a list of skills
        [JsonProperty("skills")]
        public List<Skill>? Skills { get; set; }
        [JsonProperty("benefits")]
        public string? Benefits { get; set; }
        [JsonProperty("criteria")]
        public string? Criteria { get; set; }
        [JsonProperty("programInfo")]
        public ProgramInformation programInfo { get; set; }
    }

}
