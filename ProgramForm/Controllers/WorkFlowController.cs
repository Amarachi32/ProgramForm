using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProgramFormCore.Models;
using ProgramFormInfrastructure.DTOs.Request;
using ProgramFormInfrastructure.DTOs.Response;
using ProgramFormInfrastructure.Interfaces;

namespace ProgramForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkFlowController : ControllerBase
    {
        private readonly IWorkFlowService _workService;
        private readonly IMapper _mapper;

        public WorkFlowController(IWorkFlowService workService, IMapper mapper)
        {
            _workService = workService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<WorkFlowDto>))]

        public async Task<ActionResult<IEnumerable<WorkFlowDto>>> Get()
        {
            var workFlow = await _workService.GetAllWorkFlowAsync();
            var workFlowDto = _mapper.Map<IEnumerable<ApplicationFormResponseDto>>(workFlow);
            return Ok(workFlowDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WorkFlowDto))]
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
