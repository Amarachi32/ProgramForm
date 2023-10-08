using ProgramFormCore.Interfaces;
using ProgramFormCore.Models;
using ProgramFormInfrastructure.Interfaces;

namespace ProgramFormInfrastructure.Services
{
    public class ApplicationFormService : IApplicationFormService
    {
        private readonly IRepository<ApplicationForm> _appFormService;
        public ApplicationFormService(IRepository<ApplicationForm> appFormService)
        {
            _appFormService = appFormService;
        }

        public async Task<ApplicationForm> CreateApplicationFormAsync(ApplicationForm appForm)
        {
            return await _appFormService.CreateAsync(appForm);
        }

        public async Task<IEnumerable<ApplicationForm>> GetAllApplicationAsync()
        {
            return await _appFormService.GetAllAsync();
        }

        public async Task<ApplicationForm> GetApplicationFormByIdAsync(string id)
        {
            return await _appFormService.GetByIdAsync(id);
        }

        public async Task<ApplicationForm> UpdateApplicationAsync(string id, ApplicationForm appForm)
        {
            return await _appFormService.UpdateAsync(id, appForm);
        }
    }
}
