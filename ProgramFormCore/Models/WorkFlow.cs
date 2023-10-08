using Newtonsoft.Json;

namespace ProgramFormCore.Models
{
    public class WorkFlow : BaseEntity
    {
        [JsonProperty("programDetail")]
        public ProgramDetails ProgramDetail { get; set; }
        [JsonProperty("workStages")]
        public List<WorkStage> Stages { get; set; } = new List<WorkStage>();
    }

    public class WorkStage : BaseEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public StageType Type { get; set; }
    }

    public class StageType : BaseEntity
    {
        [JsonProperty("shortListing")]
        public string ShortListing { get; set; }
        [JsonProperty("videoInterview")]
        public VideoInterview VideoInterview { get; set; }
        [JsonProperty("placement")]
        public string Placement { get; set; }
    }

    public class VideoInterview : BaseEntity
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("duration")]
        public DateTime Duration { get; set; }
        [JsonProperty("submission")]
        public DateTime Submission { get; set; }
    }

}
