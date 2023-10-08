using ProgramFormCore.Interfaces;
using ProgramFormCore.Models;
using ProgramFormInfrastructure.Interfaces;

namespace ProgramFormInfrastructure.Services
{
    public class ProgramDetailsService : IProgramDetailsService
    {
        private readonly IRepository<ProgramDetails> _programDetailsRepository;

        public ProgramDetailsService(IRepository<ProgramDetails> programDetailsRepository)
        {
            _programDetailsRepository = programDetailsRepository ?? throw new ArgumentNullException(nameof(programDetailsRepository));
        }
        public async Task<ProgramDetails> CreateProgramDetailsAsync(ProgramDetails programDetails)
        {
            return await _programDetailsRepository.CreateAsync(programDetails);
        }
        public async Task<ProgramDetails> GetProgramDetailsByIdAsync(string id)
        {
            return await _programDetailsRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ProgramDetails>> GetAllProgramDetailsAsync()
        {
            return await _programDetailsRepository.GetAllAsync();
        }

        public async Task<ProgramDetails> UpdateProgramDetailsAsync(string id, ProgramDetails programDetails)
        {
            return await _programDetailsRepository.UpdateAsync(id, programDetails);
        }

        public async Task DeleteProgramDetailsAsync(string id)
        {
            await _programDetailsRepository.DeleteAsync(id);
        }
    }

}
