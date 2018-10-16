using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalManagmentSystemWebApp.Models
{

    public class ReceptionistModel
    {


        [Required(ErrorMessage = "Please Enter First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Last Name")]
        public string LastName { get; set; }

        
        [Required(ErrorMessage = "Please Provide Address")]
        public string Address { get; set; }
       

        [Required(ErrorMessage = "Please enter your Qualification")]
        public string Qualification { get; set; }


        [Required(ErrorMessage = "Please enter Blood Group")]
        public string  BloodGroup { get; set; }
        
        [Required(ErrorMessage = "Please enter NID")] 
        public int NID { get; set; }

        [Required(ErrorMessage = "Please enter Age")]
        public int Age { get; set; }

       

    }
}