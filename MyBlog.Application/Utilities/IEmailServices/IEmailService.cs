﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Utilities.IEmailServices
{
    public interface IEmailService
    {
        bool UseEmailService { get; }
        Task<bool> SendEmailAsync(string toEmail, string subject, string body);
        
    }
}
