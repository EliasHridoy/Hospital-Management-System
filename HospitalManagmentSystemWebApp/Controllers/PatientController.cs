using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagmentSystemWebApp.Managers;
using HospitalManagmentSystemWebApp.Models;

namespace HospitalManagmentSystemWebApp.Controllers
{
    public class PatientController : Controller
    {
        private PatientManager patientManager;

        public PatientController()
        {
            patientManager = new PatientManager();
        }

        [HttpGet]
        public ActionResult Save()
        {

            return View();
        }
        
        [HttpPost]
        public ActionResult Save(PatientModel patient)
        {
            ViewBag.message = patientManager.Save(patient);
            return View();
        }
	}
}