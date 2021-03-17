using AppointmentSheduler.Models.ViewModels;
using AppointmentSheduler.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentSheduler.Models.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _context;

        public AppointmentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> addUpdate(AppointmentViewModel model)
        {
            var startDate = DateTime.Parse(model.StartDate);
            if(model!=null && model.Id>0)
            {
                return 1;
            }
            else
            {
                Appointment appointment = new Appointment()
                {
                    Title = model.Title,
                    Description = model.Description,
                    StartDate = startDate,
                    DoctorId = model.DoctorId,
                    PatientId = model.PatientId,
                    IsDoctorApproved = false,
                    AdminId = model.AdminId


                };
                _context.Appointments.Add(appointment);
                await _context.SaveChangesAsync();
            }
            return 2;
        }
        public List<DoctorViewModel> getDoctorList()
        {
            var doctors = (from user in _context.Users
                           join userRoles in _context.UserRoles on user.Id equals userRoles.UserId
                           join roles in _context.Roles.Where(x=>x.Name==Helper.Doctor) on userRoles.RoleId equals roles.Id
                           select new DoctorViewModel
                          {
                              Id = user.Id,
                              Name = user.Name
                          }
                          ).ToList();
            return doctors;
        }
        public List<PatientViewModel> getPatientList()
        {
            var patients = (from user in _context.Users
                           join userRoles in _context.UserRoles on user.Id equals userRoles.UserId
                           join roles in _context.Roles.Where(x => x.Name == Helper.Patient) on userRoles.RoleId equals roles.Id
                           select new PatientViewModel
                           {
                               Id = user.Id,
                               Name = user.Name
                           }
                          ).ToList();
            return patients;
        }
    }
}
