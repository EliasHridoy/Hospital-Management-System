
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalManagmentSystemWebApp.Models
{
    public class PatientModel
    {

        [Required]
        
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; } 
        
        [Required] 
        public int Age { get; set; }
        [Required]
        public string ContactNo { get; set; }
        
        [Required(ErrorMessage = "Please enter a valid Date")]
        public string DateOfBirth { get; set; }

        [Required]
        public float Height { get; set; }
        [Required]
        public float Weight { get; set; }
        [Required]
        public string AddmissionDate { get; set; }
    }
}