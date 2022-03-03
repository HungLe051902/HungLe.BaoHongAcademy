using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaoHongAcademy.Domain.Entities;
using BaoHongAcademy.Domain.Enums;

namespace BaoHongAcademy.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BaoHongContext context)
        {
            if (context.Users.Any())
            {
                return;
            }
                
            // Data initilize here
        }
    }
}
