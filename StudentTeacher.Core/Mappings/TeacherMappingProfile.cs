﻿using AutoMapper;
using StudentTeacher.Core.Dtos;
using StudentTeacher.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Core.Mappings
{
    public class TeacherMappingProfile: Profile
    {
        public TeacherMappingProfile() 
        {
            CreateMap<Teacher, TeacherDto>();
            CreateMap<TeacherCreationDto, Teacher>();
            CreateMap<TeacherUpdateDto, Teacher>().ReverseMap();
        }
    }
}
