using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaoHongAcademy.Domain.Entities;
using BaoHongAcademy.Domain.Models;

namespace BaoHongAcademy.API.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// To authenticate user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>Token</returns>
        public string Authenticate(string userName, string password);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Task<ActionServiceResult> RegisterUser(string userName, string password);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetById(Guid id);
    }
}
