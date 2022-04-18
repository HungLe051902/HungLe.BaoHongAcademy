using BaoHongAcademy.API.Interfaces;
using BaoHongAcademy.Domain.Entities;
using BaoHongAcademy.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaoHongAcademy.API.Services
{
    public class CourseService : ICourseService
    {
        private readonly BaoHongContext _dbContext;
        public CourseService(BaoHongContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CreateCourse(Course course)
        {
            _dbContext.Courses.Add(course);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
