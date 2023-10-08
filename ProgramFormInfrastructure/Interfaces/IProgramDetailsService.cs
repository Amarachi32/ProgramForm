using ProgramFormCore.Models;

namespace ProgramFormInfrastructure.Interfaces
{
    public interface IProgramDetailsService
    {
        Task<ProgramDetails> CreateProgramDetailsAsync(ProgramDetails programDetails);
        Task<ProgramDetails> GetProgramDetailsByIdAsync(string id);
        Task<IEnumerable<ProgramDetails>> GetAllProgramDetailsAsync();
        Task<ProgramDetails> UpdateProgramDetailsAsync(string id, ProgramDetails programDetails);
        Task DeleteProgramDetailsAsync(string id);
    }
}
