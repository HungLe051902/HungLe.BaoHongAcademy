using BaoHongAcademy.API.Interfaces;
using BaoHongAcademy.Domain.Entities;
using BaoHongAcademy.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BaoHongAcademy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : BaseController
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost("create-course")]
        public ActionServiceResult CreateCourse([NotNull] Course course)
        {
            var result = _courseService.CreateCourse(course);
            if (result)
            {
                return new ActionServiceResult(true, (int)HttpStatusCode.OK, "Create course successfully", true);
            }
            return new ActionServiceResult(false, (int)HttpStatusCode.InternalServerError, "Create course fail", true);
        }
    }
}
