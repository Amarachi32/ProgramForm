using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProgramFormCore.Models;
using ProgramFormInfrastructure.DTOs.Response;
using ProgramFormInfrastructure.Interfaces;

namespace ProgramForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreviewController : ControllerBase
    {
        private readonly IPreviewService _previewService;
        private readonly IProgramDetailsService _programService;
        private readonly IMapper _mapper;

        public PreviewController(IPreviewService previewService, IProgramDetailsService programService, IMapper mapper)
        {
            _previewService = previewService;
            _programService = programService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreviewDto>>> Get()
        {
            var previews = await _previewService.GetAllPreviewAsync();
            var previewDtos = _mapper.Map<IEnumerable<Preview>, IEnumerable<PreviewDto>>(previews);

            return Ok(previewDtos);
        }
    }
}
