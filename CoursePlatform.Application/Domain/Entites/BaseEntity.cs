﻿namespace CoursePlatform.Core.Domain.Entites
{
    public class BaseEntity
    {       
        public Guid Id { get; set; }=Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        
    }
}
