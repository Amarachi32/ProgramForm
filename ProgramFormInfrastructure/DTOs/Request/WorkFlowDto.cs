using Newtonsoft.Json;

namespace ProgramFormInfrastructure.DTOs.Request
{
    public class WorkFlowDto
    {
        [JsonProperty("programDetail")]
        public ProgramDetailsDto ProgramDetailDto { get; set; }
        [JsonProperty("workStages")]
        public List<WorkStageDto> Stages { get; set; } = new List<WorkStageDto>();
    }

    public class WorkStageDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public StageTypeDto Type { get; set; }
    }

    public class StageTypeDto
    {
        [JsonProperty("shortListing")]
        public string ShortListing { get; set; }
        [JsonProperty("videoInterview")]
        public VideoInterviewDto VideoInterviewDto { get; set; }
        [JsonProperty("placement")]
        public string Placement { get; set; }
    }

    public class VideoInterviewDto
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
