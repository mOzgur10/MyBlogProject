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
            CreateMap<AppUser, AppUserDTO>().ReverseMap();
            CreateMap<Article, ArticleDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Comment, CommentDTO>().ReverseMap();
            //CreateMap<BaseEntity, IBaseEntity>().ReverseMap();
          
        }
    }
}
