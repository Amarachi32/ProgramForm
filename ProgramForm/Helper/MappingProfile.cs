using AutoMapper;
using ProgramFormCore.Models;
using ProgramFormInfrastructure.DTOs.Request;
using ProgramFormInfrastructure.DTOs.Response;

namespace ProgramForm.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationFormDto, ApplicationForm>().ReverseMap();
            CreateMap<WorkFlowDto, WorkFlow>().ReverseMap();
            CreateMap<ProgramDetailsDto, ProgramDetails>().ReverseMap();
            CreateMap<PreviewDto, Preview>().ReverseMap();
            CreateMap<SkillDto, Skill>().ReverseMap();
            CreateMap<ProgramInformationDto, ProgramInformation>().ReverseMap();


            CreateMap<PreviewDto, Preview>()
                .AfterMap((src, dest) => dest.ProgramDetails.Description = src.Description).ReverseMap();
             
        }
    }
}
