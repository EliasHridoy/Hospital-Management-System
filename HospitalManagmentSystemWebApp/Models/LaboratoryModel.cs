using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalManagmentSystemWebApp.Models
{
    public class LaboratoryModel
    {
        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }
        
        public string Description { get; set; }

    }
}