﻿using MyBlog.Application.DTOs;
using MyBlog.Application.Services.IServices;
using MyBlog.Application.Utilities.IUnitOfWorks;
using MyBlog.Core.CoreEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Services
{
    public class AppUserService : BaseService<AppUserDTO,AppUser>,IAppUserService
    {
        public AppUserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<string> GetImageUrlById(string id)
        {
            return "";
        }
    }
}
