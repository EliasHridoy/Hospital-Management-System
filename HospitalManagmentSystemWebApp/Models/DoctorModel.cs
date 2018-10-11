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
        [Required]
        [Display(Name = "FristName")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public string Qualification { get; set; }
        [Required(ErrorMessage = "Please enter a valid Date")]
        public DateTime DateOfJoining { get; set; }
        [Required]
        public int Specilization { get; set; }
        [Required]
        public int NID { get; set; }
        [Required]
        public TimeSpan AvailableTime { get; set; }

    }
}