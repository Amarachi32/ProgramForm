using ProgramFormCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
