﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePlatform.Core.Domain.Entites
{
    public class BaseEntity
    {

        
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        
    }
}
