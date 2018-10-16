using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagmentSystemWebApp.Managers;
using HospitalManagmentSystemWebApp.Models;

namespace HospitalManagmentSystemWebApp.Controllers
{
    public class DoctorSaveController : Controller
    {
        DoctorManager doctorManager = new DoctorManager();

        [HttpGet]
        public ActionResult SaveDoctor()
        {
            ViewBag.specialization = doctorManager.GetSpecialization();
            return View();
        }
        [HttpPost]
        public ActionResult SaveDoctor(DoctorModel doctor)
        {
            ViewBag.specialization = doctorManager.GetSpecialization();

            ViewBag.message = doctorManager.Save(doctor);

            return View();
        }




    //---------------------Show Doctor---------------------------------------

        [HttpGet]
        public ActionResult ShowDoctor()
        {
            ViewBag.specialization = doctorManager.GetSpecialization();
            return View();
        }

        [HttpPost]
        public ActionResult ShowDoctor(DoctorModel doctor)
        {
            ViewBag.specialization = doctorManager.GetSpecialization();
            ViewBag.doctorList = doctorManager.GetAllDoctor(doctor.Specilization);

            return View();
        }
        


	}
}