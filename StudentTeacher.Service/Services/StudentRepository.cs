﻿using Microsoft.EntityFrameworkCore;
using StudentTeacher.Core.Models;
using StudentTeacher.Repository.Data;
using StudentTeacher.Repository.GenericRepository.Service;
using StudentTeacher.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Service.Services
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateStudentForTeacher(int teacherId, Student student)
        {
            student.TeacherId = teacherId;
            await CreateAsync(student);
        }

        public async Task DeleteStudent(Student student) => await RemoveAsync(student);

        public async Task<Student?> GetStudent(int teacherId, int studentId, bool trackChanges)
            => await FindByConditionAsync(e => e.TeacherId.Equals(teacherId) && e.Id.Equals(studentId), trackChanges).Result.SingleOrDefaultAsync();
    }
}
