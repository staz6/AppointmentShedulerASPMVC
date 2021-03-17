using AppointmentSheduler.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentSheduler.Models.Services
{
    public interface IAppointmentService
    {
        public List<DoctorViewModel> getDoctorList();

        public List<PatientViewModel> getPatientList();

        public Task<int> addUpdate(AppointmentViewModel model);
       
    }
}
