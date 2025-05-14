using AutoMapper;
using MyBlog.Application.DTOs;
using MyBlog.Core.CoreEntities.BaseEntities;
using MyBlog.Core.CoreEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Mappers
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<AppUser, AppUserDTO>()
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Id) ? Guid.NewGuid().ToString() : src.Id));

            
            CreateMap<Article, ArticleDTO>()
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Id) ? Guid.NewGuid().ToString() : src.Id));
            

            
            CreateMap<Category, CategoryDTO>()
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Id) ? Guid.NewGuid().ToString() : src.Id));

            
            CreateMap<Comment, CommentDTO>()
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Id) ? Guid.NewGuid().ToString() : src.Id));
            

        }
    }
}
