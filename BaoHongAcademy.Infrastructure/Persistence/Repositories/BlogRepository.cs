using BaoHongAcademy.Domain.Entities;
using BaoHongAcademy.Infrastructure.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoHongAcademy.Infrastructure.Persistence.Repositories
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        private readonly BaoHongContext _context;
        public BlogRepository(BaoHongContext context) : base(context)
        {
            _context = context;
        }
    }
}
