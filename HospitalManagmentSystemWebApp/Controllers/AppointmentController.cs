using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagmentSystemWebApp.Managers;
using HospitalManagmentSystemWebApp.Models;

namespace HospitalManagmentSystemWebApp.Controllers
{
    public class AppointmentController : Controller
    {

        private AppointmentManager appointmentManager;
        private DoctorManager doctorManager;

        public AppointmentController()
        {
            appointmentManager = new AppointmentManager();
            doctorManager = new DoctorManager();
        }
        //--------------------------------------------------------------------

        [HttpGet]
        public ActionResult Appointment()
        {
            ViewBag.doctorList = appointmentManager.GetAllDoctor();
            ViewBag.specialization = doctorManager.GetSpecialization();

            return View();
        }
        [HttpPost]
        public ActionResult Appointment(AppointmentScheduleModel appointment)
        {
            ViewBag.doctorList = appointmentManager.GetAllDoctor();
            ViewBag.specialization = doctorManager.GetSpecialization();

            ViewBag.message = appointmentManager.Appointment(appointment);

            ModelState.Clear();

            return View();
        }



        public JsonResult GetDoctorById(int doctorId, string date)
        {
            return Json(appointmentManager.GetDoctorById(doctorId,date));
        }
        public JsonResult GetDoctorBySpecilization(int specializationId)
        {
            return Json(appointmentManager.GetDoctorBySpecilization(specializationId));
        }
	}
}