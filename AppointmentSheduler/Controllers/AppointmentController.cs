using AppointmentSheduler.Models.Services;
using AppointmentSheduler.Models.ViewModels;
using AppointmentSheduler.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentSheduler.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _service;
        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            ViewBag.getDoctor = _service.getDoctorList();
            ViewBag.getPatient = _service.getPatientList();
            ViewBag.getTime = Helper.GetTimeDropDown();
            return View();
        }

     
    }
}
