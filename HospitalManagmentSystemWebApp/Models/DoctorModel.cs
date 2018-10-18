using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.UI.WebControls;

namespace HospitalManagmentSystemWebApp.Models
{
    public class DoctorModel
    {
        [Required(ErrorMessage = "Please Enter First Name")]
        [Display(Name = "FristName")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Select Gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please Provide Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter Nationality")]
        public string Nationality { get; set; }
        [Required(ErrorMessage = "Please enter your Qualification")]
        public string Qualification { get; set; }
        [Required(ErrorMessage = "Please enter a valid Date")]
        public DateTime DateOfJoining { get; set; }
        [Required(ErrorMessage = "Please Select Specialization")]
        public int Specilization { get; set; }
        [Required(ErrorMessage = "Please enter NID")]
        public int NID { get; set; }
        [Required(ErrorMessage = "Please Enter Time")]
        public TimeSpan AvailableTime { get; set; }
        
        [Required(ErrorMessage = "Please Enter Maximum Appointment ")]
        public int MaximumAppointment { get; set; }

    }
}