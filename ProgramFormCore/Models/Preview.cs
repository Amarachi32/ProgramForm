using Newtonsoft.Json;

namespace ProgramFormCore.Models
{
    public class Preview : BaseEntity
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("programDetails")]
        public ProgramDetails ProgramDetails { get; set; }
        public ProgramDetails GetProgramDetails()
        {
            return ProgramDetails;
        }
    }
}
