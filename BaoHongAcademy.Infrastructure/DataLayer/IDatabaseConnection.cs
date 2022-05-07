using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoHongAcademy.Infrastructure.DataLayer
{
    public interface IDatabaseConnection : IDisposable
    {
        string ConnectionString { get; set; }
        void Open();
        void Close();

        void BeginTransaction();
    }
}
