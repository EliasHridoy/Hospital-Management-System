using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagmentSystemWebApp.Managers;
using HospitalManagmentSystemWebApp.Models;

namespace HospitalManagmentSystemWebApp.Controllers
{
    public class ReceptionistDutyController : Controller
    {

        private ReceptionistManager receptionistManager;
        private NurseDutyScheduleManager nurseDutyScheduleManager;
        public ReceptionistDutyController()
        {
            receptionistManager = new ReceptionistManager();
            nurseDutyScheduleManager = new NurseDutyScheduleManager();
        }


        [HttpGet]
        public ActionResult DutySave()
        {
            ViewBag.receptionistList = receptionistManager.GetAllReceptionist();
            ViewBag.shiftList = nurseDutyScheduleManager.GetAllShift();
            return View();
        }
        [HttpPost]
        public ActionResult DutySave(ReceptionistDutyModel receptionistDuty)
        {
            ViewBag.receptionistList = receptionistManager.GetAllReceptionist();
            ViewBag.shiftList = nurseDutyScheduleManager.GetAllShift();
            ViewBag.message = receptionistManager.DutySave(receptionistDuty);

            ModelState.Clear();

            return View();
        }

	}
}