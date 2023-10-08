using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ProgramFormCore.Models;

namespace ProgramFormInfrastructure.DTOs.Request
{
    public class ApplicationFormDto
    {
        [JsonProperty("programDetails")]
        public ProgramDetailsDto ProgramDetailsDto { get; set; }
        [JsonProperty("coverImage")]
        public IFormFile CoverImage { get; set; }
        [JsonProperty("programInfo")]
        public PersonalInfoDto PersonalInfoDto { get; set; }
        [JsonProperty("profile")]
        public UserProfileDto ProfileDto { get; set; }
        [JsonProperty("AdditionalQuestion")]
        public ICollection<AdditionalQuestionDto> QuestionDtos { get; set; }

        public ProgramDetailsDto GetProgramDetails()
        {
            return ProgramDetailsDto;
        }
    }

    public class PersonalInfoDto
    {
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }
        [JsonProperty("lastName")]
        public string? LastName { get; set; }
        [JsonProperty("email")]
        public string? Email { get; set; }
        [JsonProperty("phoneNumber")]
        public int? PhoneNumber { get; set; }
        [JsonProperty("Nationality")]
        public string Nationality { get; set; }
        [JsonProperty("residenceCountry")]
        public string ResidenceCountry { get; set; }
        [JsonProperty("idNumber")]
        public string IdNumber { get; set; } = Guid.NewGuid().ToString();
        [JsonProperty("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        [JsonProperty("question")]
        public ICollection<QuestionDto> Questions { get; set; } = new List<QuestionDto>();

        public void AddQuestion(QuestionDto question)
        {
            Questions.Add(question);
        }

        public QuestionDto GetQuestionById(string id)
        {
            return Questions.FirstOrDefault(q => q.Id == id);
        }

        public T GetQuestionByType<T>(QuestionTypeDto type) where T : QuestionBaseDto
        {
            return Questions.OfType<T>().FirstOrDefault(q => q.Type == type);
        }
    }

    public class QuestionDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("QuestionType")]
        public QuestionTypeDto Type { get; set; }
    }

    public abstract class QuestionBaseDto
    {
        [JsonProperty("title")]
        public string YourQuestion { get; set; }
        [JsonProperty("QuestionType")]
        public QuestionTypeDto Type { get; set; }
    }
    public enum QuestionTypeDto
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

    public class Paragraph : QuestionBaseDto
    {
        public int MaxChoice { get; set; }
    }

    public class ShortAnswerQuestion : QuestionBaseDto
    {
        public bool EnableOtherQuestion { get; set; }
    }

    public class YesNoQuestion : QuestionBaseDto
    {
        public bool Answer { get; set; }

        public bool IsDisqualified { get; set; } = false;
    }

    public class DropdownQuestion : QuestionBaseDto
    {
        public List<string> Choice { get; set; }
        public bool IsEnabled { get; set; }
    }

    public class MultipleChoiceQuestion : QuestionBaseDto
    {
        public List<string> Choice { get; set; }
        public IEnumerable<string> Options { get; set; }
    }

    public class DateQuestion : QuestionBaseDto
    {
        public string Prompt { get; set; }
    }

    public class NumberQuestion : QuestionBaseDto
    {
        public int MaxChoiceAllowed { get; set; }
    }

    public class FileUploadQuestion : QuestionBaseDto
    {
        public string Questions { get; set; }
    }


    public class UserProfileDto
    {
        public ICollection<EducationDto> EducationDto { get; set; }
        public ICollection<ExperienceDto> ExperienceDto { get; set; }
        public IFormFile Resume { get; set; }
        public ICollection<QuestionDto> QuestionDtos { get; set; } = new List<QuestionDto>();
    }
    public class EducationDto
    {
        public string School { get; set; } = "Harvad University";
        public string Degree { get; set; } = " Master's Degree";
        public string CourseName { get; set; } = " BA History";
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool CurrentlyStuding { get; set; } = false;

    }


    public class ExperienceDto
    {
        public string Company { get; set; } = "Misk Foundation";
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool CurrentlyWorking { get; set; } = false;
    }

    public enum GenderDto
    {
        Female,
        Male,
        TransGender
    }

    public class AdditionalQuestionDto
    {
        public string Description { get; set; }
        public DateTime YearOfGraduation { get; set; }
        public string YourQuestion { get; set; }
        public List<string> Choice { get; set; }
        public bool IsRejected { get; set; }
        public ICollection<QuestionDto> Questions { get; set; } = new List<QuestionDto>();
    }

}
