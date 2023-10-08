using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProgramFormCore.Models;
using ProgramFormInfrastructure.DTOs.Request;
using ProgramFormInfrastructure.Interfaces;

namespace ProgramForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkFlowController : ControllerBase
    {
        private readonly IWorkFlowService _workService;
        private readonly IProgramDetailsService _programService;
        private readonly IMapper _mapper;

        public WorkFlowController(IWorkFlowService workService, IProgramDetailsService programService, IMapper mapper)
        {
            _workService = workService;
            _programService = programService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationForm>>> Get()
        {
            var programdetail = _programService.GetAllProgramDetailsAsync();
            var appForms = await _workService.GetAllWorkFlowAsync();
            return Ok(appForms);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WorkFlowDto>> UpdateWorkFlow(string id, [FromBody] WorkFlowDto workFlowDto)
        {
            if (workFlowDto == null)
            {
                return BadRequest("ProgramDetails object is null");
            }

            var existingWorkFlow = await _workService.GetWorkFlowByIdAsync(id);
            if (existingWorkFlow == null)
            {
                return NotFound();
            }
            var updatedWorkFlow = _mapper.Map(workFlowDto, existingWorkFlow);
            await _workService.UpdateWorkFlowAsync(id, updatedWorkFlow);

            var updatedProgramDetailsDto = _mapper.Map<WorkFlow, WorkFlowDto>(updatedWorkFlow);
            return Ok(updatedProgramDetailsDto);
        }
    }
}
