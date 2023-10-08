using Newtonsoft.Json;

namespace ProgramFormCore.Models
{
    public class ProgramInformation : BaseEntity
    {
        [JsonProperty("programType")]
        public ProgramType ProgramType { get; set; } = ProgramType.FullTime;
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
        public MinQualifications MinQualifications { get; set; } = MinQualifications.HighSchool;
        [JsonProperty("maxNumberOfApplication")]
        public int? MaxNumberOfApplication { get; set; }
    }

    public enum ProgramType
    {
        FullTime,
        PartTime,
        Contract
    }

    public enum MinQualifications
    {
        HighSchool,
        Degree,
        Masters
    }

}
