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

            var users = new User[]
            {
                new User()
                {
                    UserId = Guid.NewGuid(), CreatedBy = "HungLX", UserName = "Lê Xuân Hưng",
                    Email = "lexuanhung@gmail.com", Fullname = "Lê Xuân Hưng", Password = "123456@Abc",
                    DateOfBirth = DateTime.Now, Gender = EnumCommon.Gender.Male
                },
                new User()
                {
                    UserId = Guid.NewGuid(), CreatedBy = "HungLX1", UserName = "Lê Xuân Nam",
                    Email = "lexuannam@gmail.com", Fullname = "Lê Xuân Nam", Password = "123456@Abc",
                    DateOfBirth = DateTime.Now, Gender = EnumCommon.Gender.Male
                },
                new User()
                {
                    UserId = Guid.NewGuid(), CreatedBy = "HungLX2", UserName = "Nguyễn Vân Anh",
                    Email = "nguyenva@gmail.com", Fullname = "Nguyễn Vân Anh", Password = "12345689@Abc",
                    DateOfBirth = DateTime.Now, Gender = EnumCommon.Gender.Female
                },
                new User()
                {
                    UserId = Guid.NewGuid(), CreatedBy = "HungLX", UserName = "Đặng Thanh Hải",
                    Email = "dangth@gmail.com", Fullname = "Đặng Thanh Hải", Password = "123456@Abc",
                    DateOfBirth = DateTime.Now, Gender = EnumCommon.Gender.Male
                },
                new User()
                {
                    UserId = Guid.NewGuid(), CreatedBy = "HungLX", UserName = "Bùi Thị Phóng",
                    Email = "phongbt@gmail.com", Fullname = "Bùi Thị Phóng", Password = "12123456@Abc",
                    DateOfBirth = DateTime.Now, Gender = EnumCommon.Gender.Female
                },
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
