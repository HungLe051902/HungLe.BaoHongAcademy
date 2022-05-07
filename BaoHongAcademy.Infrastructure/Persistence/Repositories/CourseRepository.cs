using BaoHongAcademy.Domain.Entities;
using BaoHongAcademy.Infrastructure.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoHongAcademy.Infrastructure.Persistence.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly BaoHongContext _context;
        public CourseRepository(BaoHongContext context) : base(context)
        {
            _context = context;
        }
    }
}
