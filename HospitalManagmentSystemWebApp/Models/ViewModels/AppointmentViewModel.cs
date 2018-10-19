using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagmentSystemWebApp.Models.ViewModels
{
    public class AppointmentViewModel
    {

        public string Name { get; set; }
        public string Date { get; set; }
        public int AppointmentNo { get; set; }
        public string PatientContactNo { get; set; }
        public string PatientName { get; set; }
    }
}