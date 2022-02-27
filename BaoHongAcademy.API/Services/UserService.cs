using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaoHongAcademy.API.Helpers;
using BaoHongAcademy.API.Helpers.Constants;
using BaoHongAcademy.API.Interfaces;
using BaoHongAcademy.Domain.Entities;
using BaoHongAcademy.Domain.Models;
using BaoHongAcademy.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BaoHongAcademy.API.Services
{
    public class UserService : IUserService
    {
        private readonly BaoHongContext _dbContext;
        private readonly AppSettings _appSettings;

        public UserService(BaoHongContext dbContext, IOptions<AppSettings> appSettings)
        {
            _dbContext = dbContext;
            _appSettings = appSettings.Value;
        }

        public string Authenticate(string userName, string password)
        {
            var userAuthen = _dbContext.Users.FirstOrDefault(e => e.Email == userName);

            var token = (dynamic)null;
            if (userAuthen != null && HelperMethods.VerifyHash(password, HashAlgorithmCode.SHA512, userAuthen.Password))
            {
                token = HelperMethods.GenerateJwtToken(userAuthen, _appSettings.SecretKey);
            }

            return token;
        }

        public Task<ActionServiceResult> RegisterUser(string email, string password)
        {
            var users = _dbContext.Users;

            var existedUser = users.FirstOrDefault(u => u.Email == email.Trim());

            if (existedUser == null)
            {
                users.Add(new User()
                {
                    Email = email,
                    Password = HelperMethods.ComputeHash(password, HashAlgorithmCode.SHA512, null)
                });
                _dbContext.SaveChanges();

                return Task.FromResult(new ActionServiceResult(true, StatusCodes.Status200OK, "Đăng ký thành công", true)) ;
            }

            return Task.FromResult(new ActionServiceResult(true, StatusCodes.Status409Conflict, "Email đã được đăng ký", null));
        }

        public User GetById(Guid id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.UserId == id);
        }
    }
}
