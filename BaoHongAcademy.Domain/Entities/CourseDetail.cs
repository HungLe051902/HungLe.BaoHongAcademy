using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaoHongAcademy.Domain.Entities
{
    public class CourseDetail : BaseEntity
    {
        public Guid CourseDetailId { get; set; }
        public string HtmlContent { get; set; }
        public Guid CourseId { get; set; }
    }
}
