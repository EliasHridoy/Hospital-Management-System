using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace HospitalManagmentSystemWebApp.Models
{
    public class AppointmentScheduleModel
    {
        [Required(ErrorMessage = "Please Select Doctor")]
        public int  DoctorId { get; set; }
        [Required(ErrorMessage = "Please Select Date")]
        public string AppointmentDate { get; set; }

        [Required(ErrorMessage = "Please Select Time")]
        public string AppointmentTime { get; set; }
    }
}