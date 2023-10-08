﻿using AutoMapper;using Microsoft.AspNetCore.Mvc;using ProgramFormCore.Models;using ProgramFormInfrastructure.DTOs.Request;using ProgramFormInfrastructure.DTOs.Response;
using ProgramFormInfrastructure.Interfaces;namespace ProgramForm.Controllers{    [Route("api/[controller]")]    [ApiController]    public class ApplicationFormController : ControllerBase    {        private readonly IApplicationFormService _appFormService;        private readonly IProgramDetailsService _programService;        private readonly IMapper _mapper;        public ApplicationFormController(IApplicationFormService appFormService, IProgramDetailsService programService, IMapper mapper)        {            _appFormService = appFormService;            _programService = programService;            _mapper = mapper;        }        [HttpGet]        public async Task<ActionResult<IEnumerable<ApplicationFormResponseDto>>> Get()        {            var appForms = await _appFormService.GetAllApplicationAsync();
            var appFormsDto = _mapper.Map<IEnumerable<ApplicationFormResponseDto>>(appForms);            return Ok(appFormsDto);        }        [HttpPut("{id}")]        public async Task<IActionResult> Put(string id, [FromBody] ApplicationFormDto appFormDto)        {            if (appFormDto == null)            {                return BadRequest("ProgramDetails object is null");            }            var existingApplicationForm = await _appFormService.GetApplicationFormByIdAsync(id);            if (existingApplicationForm == null)            {                return NotFound();            }
            _mapper.Map(appFormDto, existingApplicationForm);            await _appFormService.UpdateApplicationAsync(id, existingApplicationForm);            return NoContent();        }    }}