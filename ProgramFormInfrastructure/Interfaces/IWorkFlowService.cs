using ProgramFormCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramFormInfrastructure.Interfaces
{
    public interface IWorkFlowService
    {
        Task<IEnumerable<WorkFlow>> GetAllWorkFlowAsync();
        Task<WorkFlow> GetWorkFlowByIdAsync(string id);
        Task<WorkFlow> UpdateWorkFlowAsync(string id, WorkFlow appForm);
        Task<WorkFlow> CreateWorkFlowAsync(WorkFlow appForm);
    }
}
