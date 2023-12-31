﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentTeacher.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Repository.Data
{
    public class TeacherData : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasData(
             new Teacher
             {
                 Id = 1,
                 Name = "John",
                 Subject = "Maths"
             },

             new Teacher
             {
                 Id = 2,
                 Name = "Femi",
                 Subject = "English"
             });
        }
    }
}
