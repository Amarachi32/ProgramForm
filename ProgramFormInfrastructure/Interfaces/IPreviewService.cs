using ProgramFormCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramFormInfrastructure.Interfaces
{
    public interface IPreviewService
    {
        Task<IEnumerable<Preview>> GetAllPreviewAsync();
        Task<Preview> GetPreviewIdAsync(string id);
    }
}
