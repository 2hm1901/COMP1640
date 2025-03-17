using AutoMapper;
using Common.ViewModels.InteractionVMs;
using Common.ViewModels.StudentVMs;
using Models.Accounts;
using Models.Interactions;

namespace Common.Mapping;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Interaction, InteractionVM>();
        CreateMap<Interaction, InteractionDetailVM>();

        // Chuyển từ Account sang StudentVM
        CreateMap<Account, StudentVM>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
            .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.Teacher.FirstName + " " + src.Teacher.LastName));

        CreateMap<Account, StudentDetailVM>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
            .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.Teacher.FirstName + " " + src.Teacher.LastName));
    }
}
