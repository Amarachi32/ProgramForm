﻿using AutoMapper;
using ProgramFormInfrastructure.DTOs.Request;
using ProgramFormInfrastructure.Interfaces;
            var appFormsDto = _mapper.Map<IEnumerable<ApplicationFormResponseDto>>(appForms);
            _mapper.Map(appFormDto, existingApplicationForm);
            return Ok(updatedProgramDetailsDto);