using Newtonsoft.Json;

namespace ProgramFormInfrastructure.DTOs.Response
{
    public class ProgramDetailsResponseDto
    {
        public class ProgramDetailsDto
        {
            [JsonProperty("title")]
            public string Title { get; set; }
            [JsonProperty("summary")]
            public string? Summary { get; set; }
            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("benefits")]
            public string? Benefits { get; set; }
            [JsonProperty("criteria")]
            public string? Criteria { get; set; }
        }

    }
    public class ApplicationFormResponseDto
    {
        [JsonProperty("programDetails")]
        public ProgramDetailsResponseDto ProgramDetailsDto { get; set; }
        [JsonProperty("coverImage")]
        public string ImageUrl { get; set; }
        [JsonProperty("programInfo")]
        public PersonalInfoResponseDto PersonalInfoDto { get; set; }
        [JsonProperty("profile")]
        public UserProfileResponseDto ProfileDto { get; set; }
        [JsonProperty("AdditionalQuestion")]
        public ICollection<AdditionalQuestionResponseDto> QuestionDtos { get; set; }

        public ProgramDetailsResponseDto GetProgramDetails()
        {
            return ProgramDetailsDto;
        }
    }

    public class PersonalInfoResponseDto
    {
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }
        [JsonProperty("lastName")]
        public string? LastName { get; set; }
        [JsonProperty("email")]
        public string? Email { get; set; }
        [JsonProperty("phoneNumber")]
        public string? PhoneNumber { get; set; }
        [JsonProperty("Nationality")]
        public string Nationality { get; set; }
        [JsonProperty("residenceCountry")]
        public string ResidenceCountry { get; set; }
        [JsonProperty("idNumber")]
        public string IdNumber { get; set; } = Guid.NewGuid().ToString();
        [JsonProperty("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        [JsonProperty("question")]
        public ICollection<QuestionResponseDto> Questions { get; set; } = new List<QuestionResponseDto>();

        public void AddQuestion(QuestionResponseDto question)
        {
            Questions.Add(question);
        }

        public QuestionResponseDto GetQuestionById(string id)
        {
            return Questions.FirstOrDefault(q => q.Id == id);
        }

        public T GetQuestionByType<T>(QuestionTypeResponseDto type) where T : QuestionBaseResponseDto
        {
            return Questions.OfType<T>().FirstOrDefault(q => q.Type == type);
        }
    }

    public class QuestionResponseDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("QuestionType")]
        public QuestionTypeResponseDto Type { get; set; }
    }

    public abstract class QuestionBaseResponseDto
    {
        [JsonProperty("title")]
        public string YourQuestion { get; set; }
        [JsonProperty("QuestionType")]
        public QuestionTypeResponseDto Type { get; set; }
    }
    public enum QuestionTypeResponseDto
    {
        Paragraph,
        ShortAnswer,
        YesNo,
        Dropdown,
        MultipleChoice,
        Date,
        Number,
        FileUpload,
        VideoQuestion
    }

    public class Paragraph : QuestionBaseResponseDto
    {
        public int MaxChoice { get; set; }
    }

    public class ShortAnswerQuestion : QuestionBaseResponseDto
    {
        public bool EnableOtherQuestion { get; set; }
    }

    public class YesNoQuestion : QuestionBaseResponseDto
    {
        public bool Answer { get; set; }

        public bool IsDisqualified { get; set; } = false;
    }

    public class DropdownQuestion : QuestionBaseResponseDto
    {
        public List<string> Choice { get; set; }
        public bool IsEnabled { get; set; }
    }

    public class MultipleChoiceQuestion : QuestionBaseResponseDto
    {
        public List<string> Choice { get; set; }
        public IEnumerable<string> Options { get; set; }
    }

    public class DateQuestion : QuestionBaseResponseDto
    {
        public string Prompt { get; set; }
    }

    public class NumberQuestion : QuestionBaseResponseDto
    {
        public int MaxChoiceAllowed { get; set; }
    }

    public class FileUploadQuestion : QuestionBaseResponseDto
    {
        public string Questions { get; set; }
    }


    public class UserProfileResponseDto
    {
        public ICollection<EducationResponseDto> EducationDto { get; set; }
        public ICollection<ExperienceResponseDto> ExperienceDto { get; set; }
        public string Resume { get; set; }
        public ICollection<QuestionResponseDto> QuestionDtos { get; set; } = new List<QuestionResponseDto>();
    }
    public class EducationResponseDto
    {
        public string School { get; set; } = "Harvad University";
        public string Degree { get; set; } = " Master's Degree";
        public string CourseName { get; set; } = " BA History";
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool CurrentlyStuding { get; set; } = false;

    }


    public class ExperienceResponseDto
    {
        public string Company { get; set; } = "Misk Foundation";
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool CurrentlyWorking { get; set; } = false;
    }

    public enum GenderResponseDto
    {
        Female,
        Male,
        TransGender
    }

    public class AdditionalQuestionResponseDto
    {
        public string Description { get; set; }
        public DateTime YearOfGraduation { get; set; }
        public string YourQuestion { get; set; }
        public List<string> Choice { get; set; }
        public bool IsRejected { get; set; }
        public ICollection<QuestionResponseDto> Questions { get; set; } = new List<QuestionResponseDto>();
    }

}
