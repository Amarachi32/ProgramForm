using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProgramFormCore.Models;
using ProgramFormInfrastructure.DTOs.Request;
using ProgramFormInfrastructure.Interfaces;

namespace ProgramForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramDetailsController : ControllerBase
    {
        private readonly IProgramDetailsService _programDetailsService;
        private readonly IApplicationFormService _applicationFormService;
        private readonly IWorkFlowService _workService;
        private readonly IFileUploadService _fileUploadServices;
        private readonly IMapper _mapper;

        public ProgramDetailsController(IProgramDetailsService programDetailsService, IApplicationFormService applicationFormService, IWorkFlowService workService, IFileUploadService fileUploadServices, IMapper mapper)
        {
            _programDetailsService = programDetailsService;
            _applicationFormService = applicationFormService;
            _fileUploadServices = fileUploadServices;
            _mapper = mapper;
            _workService = workService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProgramDetailsDto>))]
        public async Task<ActionResult<IEnumerable<ProgramDetailsDto>>> Get()
        {
            var programDetails = await _programDetailsService.GetAllProgramDetailsAsync();
            var programDetailsDto = _mapper.Map<IEnumerable<ProgramDetails>, IEnumerable<ProgramDetailsDto>>(programDetails);

            return Ok(programDetailsDto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProgramDetailsDto))]
        public async Task<ActionResult<ProgramDetailsDto>> GetById(string id)
        {
            var programDetail = await _programDetailsService.GetProgramDetailsByIdAsync(id);
            if (programDetail == null)
            {
                return NotFound();
            }
            var programDetailDto = _mapper.Map<ProgramDetails, ProgramDetailsDto>(programDetail);

            return Ok(programDetailDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProgramDetailsDto))]
        public async Task<ActionResult<ProgramDetailsDto>> PostProgramDetails(ProgramDetailsDto programDetailsDto)
        {
            if (programDetailsDto == null)
            {
                return BadRequest("ProgramDetails object is null");
            }
            var programDetailsEntity = _mapper.Map<ProgramDetailsDto, ProgramDetails>(programDetailsDto);
            var createdProgramDetails = await _programDetailsService.CreateProgramDetailsAsync(programDetailsEntity);
            var createdProgramDetailsDto = _mapper.Map<ProgramDetails, ProgramDetailsDto>(createdProgramDetails);
            return CreatedAtAction(nameof(GetById), new { id = createdProgramDetails.Id }, createdProgramDetails);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<ProgramDetailsDto>> PutProgramDetails(string id, [FromBody] ProgramDetailsDto programDetailsDto)
        {
            if (programDetailsDto == null)
            {
                return BadRequest("ProgramDetails object is null");
            }

            var existingProgramDetail = await _programDetailsService.GetProgramDetailsByIdAsync(id);
            if (existingProgramDetail == null)
            {
                return NotFound();
            }
            var updatedProgramDetail = _mapper.Map(programDetailsDto, existingProgramDetail);
            await _programDetailsService.UpdateProgramDetailsAsync(id, updatedProgramDetail);

            var updatedProgramDetailsDto = _mapper.Map<ProgramDetails, ProgramDetailsDto>(updatedProgramDetail);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(string id)
        {
            var programDetail = await _programDetailsService.GetProgramDetailsByIdAsync(id);
            if (programDetail == null)
            {
                return NotFound();
            }

            await _programDetailsService.DeleteProgramDetailsAsync(id);
            return NoContent();
        }


        [HttpPost("application")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProgramDetails))]
        public async Task<ActionResult<ProgramDetails>> CreateApplicationForm([FromForm] ApplicationFormDto applicationFormDto)
        {
            if (applicationFormDto == null)
            {
                return BadRequest("ProgramDetails object is null");
            }

            // var userId = HttpContext.User.RetrieveUserIdFromPrincipal();
            var imageUrl = await _fileUploadServices.AddFileAsync(applicationFormDto.CoverImage);
            var fileUrl = await _fileUploadServices.AddFileAsync(applicationFormDto.ProfileDto.Resume);
            var applicationForm = _mapper.Map<ApplicationFormDto, ApplicationForm>(applicationFormDto);
            applicationForm.ImageUrl = imageUrl;
            applicationForm.Profile.Resume = fileUrl;


            var createdProgramDetails = await _applicationFormService.CreateApplicationFormAsync(applicationForm);

            return CreatedAtAction(nameof(GetById), new { id = createdProgramDetails.Id }, createdProgramDetails);
        }


        [HttpPost("workflow")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(WorkFlowDto))]
        public async Task<ActionResult<WorkFlowDto>> CreateWorkflow([FromBody] WorkFlowDto workFlowDto)
        {
            if (workFlowDto == null)
            {
                return BadRequest("ProgramDetails object is null");
            }
            var createdWorkflowForm = await _workService.CreateWorkFlowAsync(_mapper.Map<WorkFlowDto, WorkFlow>(workFlowDto));
            return CreatedAtAction(nameof(GetById), new { id = createdWorkflowForm.Id }, createdWorkflowForm);
        }
    }
}
