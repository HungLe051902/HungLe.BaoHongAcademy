using BaoHongAcademy.Domain.Models;
using BaoHongAcademy.Domain.Models.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using BaoHongAcademy.API.Interfaces;
using static BaoHongAcademy.Domain.Enums.EnumCommon;
using BaoHongAcademy.API.Helpers.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace BaoHongAcademy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController
    {
        private readonly IUserService _userService;

        public AccountsController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ActionServiceResult Authenticate(UserCred userCred)
        {
            var token = _userService.Authenticate(userCred.UserName, userCred.Password);
            if (!String.IsNullOrEmpty(token))
            {
                return new ActionServiceResult(true, (int)AppCode.Success, "Đăng nhập thành công", token);
            }
            return new ActionServiceResult(false, (int)AppCode.Error, "Đăng nhập thất bại", null);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionServiceResult> Register([NotNull] UserCred userCred)
        {
            var result = await _userService.RegisterUser(userCred.UserName, userCred.Password);
            return result;
        }
    }
}
