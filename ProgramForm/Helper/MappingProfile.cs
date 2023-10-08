using AutoMapper;
using ProgramFormCore.Models;
using ProgramFormInfrastructure.DTOs.Request;
using ProgramFormInfrastructure.DTOs.Response;

namespace ProgramForm.Helper
{
    public class MappingProfile : Profile
    {
        protected MappingProfile()
        {
            CreateMap<ApplicationFormDto, ApplicationForm>().ReverseMap();
            CreateMap<WorkFlowDto, WorkFlow>().ReverseMap();
            CreateMap<ProgramDetailsDto, ProgramDetails>().ReverseMap();
            CreateMap<PreviewDto, Preview>().ReverseMap();
            CreateMap<SkillDto, Skill>().ReverseMap();
            CreateMap<ProgramInformationDto, ProgramInformation>().ReverseMap();


            CreateMap<PreviewDto, Preview>()
                .ForMember(dest => dest.ProgramDetails.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ProgramDetails.Benefits, opt => opt.MapFrom(src => src.Benefits))
                .ForMember(dest => dest.ProgramDetails.Criteria, opt => opt.MapFrom(src => src.Criteria))
                .ReverseMap();
        }
    }
}
