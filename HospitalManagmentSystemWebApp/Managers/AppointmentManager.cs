using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManagmentSystemWebApp.Gateways;
using HospitalManagmentSystemWebApp.Models;
using HospitalManagmentSystemWebApp.Models.ViewModels;

namespace HospitalManagmentSystemWebApp.Managers
{
    public class AppointmentManager
    {
        private AppointmentGateway appointmentGateway;

        public AppointmentManager()
        {
            appointmentGateway = new AppointmentGateway();
        }

        //--------------------------------------------------------------------

        public List<DoctorViewModel> GetAllDoctor()
        {
            return appointmentGateway.GetAllDoctor();
        }
        //--------------------------------------------------------------------

        public string Appointment(AppointmentScheduleModel appointment)
        {
            int rowEffect = appointmentGateway.Appointment(appointment); 

            if (rowEffect > 0) { return "Save Successful"; }
            else { return "Save Faild"; }
        }

        //--------------------------------------------------------------------




    }
}