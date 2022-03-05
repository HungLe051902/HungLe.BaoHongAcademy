using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaoHongAcademy.Domain.Entities;
using BaoHongAcademy.Domain.Enums;
using BaoHongAcademy.Infrastructure.Persistence;
using static BaoHongAcademy.Domain.Enums.EnumCommon;

namespace BaoHongAcademy.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BaoHongContext context)
        {
            //if (context.Users.Any())
            //{
            //    return;
            //}

            // Data initilize here

            if (!context.Blogs.Any())
            {
                var blogs = new List<Blog>()
                {
                    new Blog {Author = "Hung", BlogType = BlogType.Personal, BlogContent = "This is my blog"},
                    new Blog {Author = "Anh", BlogType = BlogType.Personal, BlogContent = "This is Anh's blog"},
                };

                using (var unitOfWork = new UnitOfWork(context))
                {
                    unitOfWork.Blogs.AddRange(blogs);
                    unitOfWork.Complete();
                }
            }

        }
    }
}
