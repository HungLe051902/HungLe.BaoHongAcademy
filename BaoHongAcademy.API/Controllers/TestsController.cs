using BaoHongAcademy.Domain.Entities;
using BaoHongAcademy.Infrastructure.DataLayer;
using Microsoft.AspNetCore.Mvc;
using static BaoHongAcademy.Domain.Enums.EnumCommon;

namespace BaoHongAcademy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        [HttpGet("adonet")]
        public void TestADONET()
        {
            using (var dbCon = new DatabaseConnection())
            {
                //var blog = new Blog()
                //{
                //    Author = "Nam",
                //    BlogType = BlogType.IT,
                //    BlogContent = "Nam"
                //};

                //dbCon.InsertIntoDB<Blog>("Proc_InsertBlog", blog);
                //dbCon.BeginTransaction();
                //dbCon.ExcuteCommand("Update Course Set Author = 'Lan' where CourseId = 'A6CC66D1-846C-49DE-5E84-08D9FFE64326'", isSqlRaw: true, parameters: null);
                //dbCon.ExcuteCommand("Delete from Blog where BlogId = '728B4370-3A0E-4045-9C55-4BF50BA7F707'", isSqlRaw: true, parameters: null);
                //dbCon.Commit();

                var a = dbCon.GetData<Blog>("Proc_GetBlog123");
            }
        }
    }
}
