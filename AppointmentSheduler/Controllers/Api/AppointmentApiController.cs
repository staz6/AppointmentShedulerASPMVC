using AppointmentSheduler.Models.Services;
using AppointmentSheduler.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AppointmentSheduler.Controllers.Api
{
    [Route("api/Appointment")]
    [ApiController]
    public class AppointmentApiController : Controller
    {
        private readonly IAppointmentService _service;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string loginUserId;
        private readonly string role;
        public AppointmentApiController(IAppointmentService service, IHttpContextAccessor httpContextAccessor)
        {
            service = _service;
            loginUserId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            role = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
        }
        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("SaveData")]
        public IActionResult SaveData(AppointmentViewModel model)
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {
                commonResponse.Status = _service.addUpdate(model).Result;
                if (commonResponse.Status == 1)
                {
                    commonResponse.Message = "Updated";
                }
                if (commonResponse.Status == 2)
                {
                    commonResponse.Message = "Created";
                }
            }
            catch (Exception e)
            {
                commonResponse.Message = e.Message;
            }
            return View();
        }
    }
}
