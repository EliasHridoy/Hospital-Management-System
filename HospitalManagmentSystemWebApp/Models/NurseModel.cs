using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalManagmentSystemWebApp.Models
{
    public class NurseModel
    {

        [Required(ErrorMessage = "Please Enter First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Select Gender")]
        public string Address { get; set; }
        
        [Required(ErrorMessage = "Please enter a valid Date")]
        public DateTime DateOfJoining { get; set; }

        [Required(ErrorMessage = "Please enter NID")]
        public int NID { get; set; }
        
        



    }
}