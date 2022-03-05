using BaoHongAcademy.Domain.Entities;
using BaoHongAcademy.Infrastructure.DataLayer;
using Microsoft.AspNetCore.Mvc;

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
                //dbCon.GetData<>
                var list = dbCon.GetDataRawSql<Blog>("select * from Blog Where Author = 'Hung';", null);
                var a = 1;
            }
        }
    }
}
