using Newtonsoft.Json;

namespace ProgramFormCore.Models
{
    public class BaseEntity
    {
        [JsonProperty("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
