using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BaoHongAcademy.Domain.Enums.EnumCommon;

namespace BaoHongAcademy.Domain.Entities
{
    public class Blog : BaseEntity
    {
        public Guid BlogId { get; set; } = Guid.NewGuid();
        public string Author { get; set; }
        public BlogType BlogType { get; set; }
        public string BlogContent { get; set; }
    }
}
