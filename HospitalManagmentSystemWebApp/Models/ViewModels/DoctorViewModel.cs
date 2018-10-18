using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagmentSystemWebApp.Models.ViewModels
{
    public class DoctorViewModel
    {
        public int  Id { get; set; }
        public string Name { get; set; }
       
        public string Specialization { get; set; }

        public string AvailableTime { get; set; }
        public int MaximumAppointment { get; set; }
        public int RemainingAppointment { get; set; }
        
    }
}