using Newtonsoft.Json;

namespace ProgramFormInfrastructure.DTOs.Request
{
    public class ProgramDetailsDto
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("summary")]
        public string? Summary { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("skills")]
        public List<SkillDto>? Skills { get; set; }
        [JsonProperty("benefits")]
        public string? Benefits { get; set; }
        [JsonProperty("criteria")]
        public string? Criteria { get; set; }
        [JsonProperty("programInfo")]
        public ProgramInformationDto programInfo { get; set; }
    }

    public class SkillDto
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set; }
    }

    public class ProgramInformationDto
    {
        [JsonProperty("programType")]
        public ProgramTypeDto ProgramType { get; set; } = ProgramTypeDto.FullTime;
        [JsonProperty("startDate")]
        public DateTime? StartDate { get; set; }
        [JsonProperty("openDate")]
        public DateTime OpenDate { get; set; }
        [JsonProperty("closeDate")]
        public DateTime CloseDate { get; set; }
        [JsonProperty("duration")]
        public string Duration { get; set; } = "6 Months";
        [JsonProperty("location")]
        public string Location { get; set; } = " London Uk";
        [JsonProperty("fullyRemote")]
        public bool FullyRemote { get; set; } = false;
        [JsonProperty("minQualifications")]
        public MinQualificationsDto MinQualifications { get; set; } = MinQualificationsDto.HighSchool;
        [JsonProperty("maxNumberOfApplication")]
        public int? MaxNumberOfApplication { get; set; }
    }

    public enum ProgramTypeDto
    {
        FullTime,
        PartTime,
        Contract
    }

    public enum MinQualificationsDto
    {
        HighSchool,
        Degree,
        Masters
    }
}
