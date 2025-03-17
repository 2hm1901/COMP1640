using AutoMapper;
using Common.DTOs.UserDtos;
using Common.ViewModels.InteractionVMs;
using Common.ViewModels.StudentVMs;
using Common.ViewModels.UserVMs;
using Models.Accounts;
using Models.Interactions;

namespace Common.Mapping;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Interaction, InteractionVM>();

        // Chuyển từ Account sang StudentVM
        CreateMap<Account, StudentVM>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
            .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.Teacher.FirstName + " " + src.Teacher.LastName));

        CreateMap<Account, StudentDetailVM>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
            .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.Teacher.FirstName + " " + src.Teacher.LastName));

        CreateMap<CreateUserDto, Account>();

        //Get user data
        CreateMap<Account, UserDetailVM>();
    }
}
