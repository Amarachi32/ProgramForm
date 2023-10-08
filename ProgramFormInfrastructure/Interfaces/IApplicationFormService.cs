using ProgramFormCore.Models;

namespace ProgramFormInfrastructure.Interfaces
{
    public interface IApplicationFormService
    {
        Task<IEnumerable<ApplicationForm>> GetAllApplicationAsync();
        Task<ApplicationForm> GetApplicationFormByIdAsync(string id);
        Task<ApplicationForm> UpdateApplicationAsync(string id, ApplicationForm appForm);
        Task<ApplicationForm> CreateApplicationFormAsync(ApplicationForm appForm);
    }
}
