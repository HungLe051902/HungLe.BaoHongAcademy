using BaoHongAcademy.Infrastructure.Core;
using BaoHongAcademy.Infrastructure.Core.Repositories;
using BaoHongAcademy.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoHongAcademy.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        public IBlogRepository Blogs { get; private set; }

        public UnitOfWork(BaoHongContext context)
        {
            _context = context;
            Blogs = new BlogRepository(context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
