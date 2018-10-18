using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalManagmentSystemWebApp.Models
{
    public class NurseDutyScheduleModel
    {
        [Required(ErrorMessage = "Please Select Nurse")]
        public int NurseId { get; set; }


        [Required(ErrorMessage = "Please Select Date")]
        public string Date { get; set; }


        [Required(ErrorMessage = "Please Select Shift")]
        public int ShiftId { get; set; }
    }
}