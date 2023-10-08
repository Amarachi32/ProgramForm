using AutoMapper;
using Microsoft.AspNetCore.Http;
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
        private readonly IMapper _mapper;

        public ProgramDetailsController(IProgramDetailsService programDetailsService, IMapper mapper)
        {
            _programDetailsService = programDetailsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgramDetailsDto>>> Get()
        {
            var programDetails = await _programDetailsService.GetAllProgramDetailsAsync();
            var programDetailsDto = _mapper.Map<IEnumerable<ProgramDetails>, IEnumerable<ProgramDetailsDto>>(programDetails);

            return Ok(programDetailsDto);
        }

        [HttpGet("{id}")]
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

    }
}
