using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalManagmentSystemWebApp.Models
{
    public class ReceptionistDutyModel
    {
        
        [Required(ErrorMessage = "Please Select Receptionist ")]
        public int ReceptionistId { get; set; }


        [Required(ErrorMessage = "Please Select Date")]
        public string Date { get; set; }


        [Required(ErrorMessage = "Please Select Shift")]
        public int ShiftId { get; set; }
    }
}