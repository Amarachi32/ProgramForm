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

            CreateMap<ApplicationFormDto, ApplicationForm>()
                .ForPath(dest => dest.Profile.Resume, opt => opt.MapFrom(src => src.ProfileDto.Resume))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.CoverImage))
                .ReverseMap();

            CreateMap<ApplicationForm, ApplicationFormResponseDto>().ReverseMap();


            CreateMap<WorkFlowDto, WorkFlow>().ReverseMap();
            CreateMap<ProgramDetailsDto, ProgramDetails>().ReverseMap();
            CreateMap<ProgramDetailsResponseDto, ProgramDetails>().ReverseMap();
            CreateMap<PreviewDto, Preview>().ReverseMap();
            CreateMap<SkillDto, Skill>().ReverseMap();
            CreateMap<ProgramInformationDto, ProgramInformation>().ReverseMap();

        }
    }
}
