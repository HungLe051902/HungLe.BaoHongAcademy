using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoHongAcademy.Domain.Entities
{
    public class Course 
    {
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
        public string Author { get; set; }
    }
}
