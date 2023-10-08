using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ProgramFormCore.Models
{
    public class ApplicationForm : BaseEntity
    {
        [JsonProperty("programDetails")]
        public ProgramDetails ProgramDetails { get; set; }
        [JsonProperty("coverImage")]
        public IFormFile CoverImage { get; set; }
        [JsonProperty("programInfo")]
        public PersonalInfo PersonalInfo { get; set; }
        [JsonProperty("profile")]
        public UserProfile Profile { get; set; }
        [JsonProperty("AdditionalQuestion")]
        public ICollection<AdditionalQuestion> Questions { get; set; }

        public ProgramDetails GetProgramDetails()
        {
            return ProgramDetails;
        }
    }

    public class PersonalInfo : BaseEntity
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
        public ICollection<Question> Questions { get; set; } = new List<Question>();

        public void AddQuestion(Question question)
        {
            Questions.Add(question);
        }

        public Question GetQuestionById(string id)
        {
            return Questions.FirstOrDefault(q => q.Id == id);
        }

        public T GetQuestionByType<T>(QuestionType type) where T : QuestionBase
        {
            return Questions.OfType<T>().FirstOrDefault(q => q.Type == type);
        }
    }

    public class Question : BaseEntity
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("QuestionType")]
        public QuestionType Type { get; set; }
    }

    public abstract class QuestionBase : BaseEntity
    {
        [JsonProperty("title")]
        public string YourQuestion { get; set; }
        [JsonProperty("QuestionType")]
        public QuestionType Type { get; set; }
    }
    public enum QuestionType
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

    public class Paragraph : QuestionBase
    {
        public int MaxChoice { get; set; }
    }

    public class ShortAnswerQuestion : QuestionBase
    {
        public bool EnableOtherQuestion { get; set; }
    }

    public class YesNoQuestion : QuestionBase
    {
        public bool Answer { get; set; }

        public bool IsDisqualified { get; set; } = false;
    }

    public class DropdownQuestion : QuestionBase
    {
        public List<string> Choice { get; set; }
        public bool IsEnabled { get; set; }
    }

    public class MultipleChoiceQuestion : QuestionBase
    {
        public List<string> Choice { get; set; }
        public IEnumerable<string> Options { get; set; }
    }

    public class DateQuestion : QuestionBase
    {
        public string Prompt { get; set; }
    }

    public class NumberQuestion : QuestionBase
    {
        public int MaxChoiceAllowed { get; set; }
    }

    public class FileUploadQuestion : QuestionBase
    {
        public string Questions { get; set; }
    }


    public class UserProfile : BaseEntity
    {
        public ICollection<Education> Education { get; set; }
        public ICollection<Experience> Experience { get; set; }
        public IFormFile Resume { get; set; }
        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
    public class Education : BaseEntity
    {
        public string School { get; set; } = "Harvad University";
        public string Degree { get; set; } = " Master's Degree";
        public string CourseName { get; set; } = " BA History";
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool CurrentlyStuding { get; set; } = false;

    }


    public class Experience : BaseEntity
    {
        public string Company { get; set; } = "Misk Foundation";
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool CurrentlyWorking { get; set; } = false;
    }

    public enum Gender
    {
        Female,
        Male,
        TransGender
    }

    public class AdditionalQuestion: BaseEntity
    {
        public string Description { get; set; }
        public DateTime YearOfGraduation { get; set; }
        public string YourQuestion { get; set; }
        public List<string> Choice { get; set; }
        public bool IsRejected { get; set; }
        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }

}
