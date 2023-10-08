using Newtonsoft.Json;

namespace ProgramFormCore.Models
{
    public class Skill : BaseEntity
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set; }
    }
}
