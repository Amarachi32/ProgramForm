using ProgramFormCore.Interfaces;
using ProgramFormCore.Models;
using ProgramFormInfrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramFormInfrastructure.Services
{
    public class WorkFlowService : IWorkFlowService
    {
        private readonly IRepository<WorkFlow> _workService;

        public WorkFlowService(IRepository<WorkFlow> workService)
        {
            _workService = workService;
        }

        public async Task<WorkFlow> CreateWorkFlowAsync(WorkFlow workFlow)
        {
            return await _workService.CreateAsync(workFlow);
        }

        public async Task<IEnumerable<WorkFlow>> GetAllWorkFlowAsync()
        {
            return await _workService.GetAllAsync();
        }

        public async Task<WorkFlow> GetWorkFlowByIdAsync(string id)
        {
            return await _workService.GetByIdAsync(id);
        }

        public async Task<WorkFlow> UpdateWorkFlowAsync(string id, WorkFlow workFlow)
        {
            return await _workService.UpdateAsync(id, workFlow);
        }
    }
}
