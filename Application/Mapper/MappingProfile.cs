using Application.Articles;
using Application.Profiles;
using AutoMapper;
using Domain;

namespace Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Article, ArticleDTO>();
            CreateMap<UserArticle ,UserLike>()
            .ForMember(x=>x.UserName, y=>y.MapFrom(d=>d.User.UserName))
             .ForMember(x=>x.Id, y=>y.MapFrom(d=>d.UserId));
        }
    }
}