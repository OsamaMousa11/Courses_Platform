﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePlatform.Core.DTO
{
    public class UserResponse
    {
        public Guid Id { get; set; }        
        public string UserName { get; set; }
        public string Email { get; set; }   
        public string Role { get; set; }    
    }
}
