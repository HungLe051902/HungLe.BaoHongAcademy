using BaoHongAcademy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaoHongAcademy.API.Interfaces
{
    public interface ICourseService
    {
        public bool CreateCourse(Course course);
    }
}
