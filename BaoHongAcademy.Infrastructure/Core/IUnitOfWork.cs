using BaoHongAcademy.Infrastructure.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoHongAcademy.Infrastructure.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBlogRepository Blogs { get; }

        int Complete(); 
    }
}
