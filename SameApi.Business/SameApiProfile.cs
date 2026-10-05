using AutoMapper;
using SameApi.Dto;
using SameApi.Model;
using SameApi.Model.LKP;

namespace SameApi.Business
{
    public class SameApiProfile : Profile
    {
        public SameApiProfile()
        {

            //User
            CreateMap<UserInput, UserDao>()
                .ForMember(dest => dest.GenderDao, opt => opt.Ignore())
                .ForMember(dest => dest.SchoolDao, opt => opt.Ignore())
                .ForMember(dest => dest.ProfessionDao, opt => opt.Ignore()); CreateMap<UserDao, UserResponse>();
            CreateMap<UserDao, UserResponse>()
                .ForMember(
                    dest => dest.Gender,
                    opt => opt.MapFrom(src => src.GenderDao)
                )
                .ForMember(
                dest => dest.School,
                opt => opt.MapFrom(src => src.SchoolDao)
                );

            //Gender
            CreateMap<GenderInput, LKP_GenderDao>();
            CreateMap<LKP_GenderDao, GenderResponse>();

            //Profession
            CreateMap<ProfessionInput, LKP_ProfessionDao>();
            CreateMap<LKP_ProfessionDao, ProfessionResponse>();

            //School
            CreateMap<Schoolnput, LKP_SchoolDao>();
            CreateMap<LKP_SchoolDao, SchoolResponse>();

            //Post
            CreateMap<PostInput, PostDao>();
            CreateMap<PostDao,PostResponse>();

            //Comment
            CreateMap<CommentInput, CommentDao>();
            CreateMap<CommentDao, CommentResponse>();


        }
    }
}