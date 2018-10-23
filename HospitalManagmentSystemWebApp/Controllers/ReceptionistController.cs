using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagmentSystemWebApp.Managers;
using HospitalManagmentSystemWebApp.Models;

namespace HospitalManagmentSystemWebApp.Controllers
{
    public class ReceptionistController : Controller
    {

        private ReceptionistManager receptionistManager;

        public ReceptionistController()
        {
            receptionistManager = new ReceptionistManager();
            
        }


        [HttpGet]
        public ActionResult SaveReceptionist()
        {

            return View();
        }
        [HttpPost]
        public ActionResult SaveReceptionist(ReceptionistModel receptionist)
        {
            ViewBag.message = receptionistManager.Save(receptionist);

            return View();
        }

        //------------------View All receptionist--------------------

        public ActionResult ViewReceptionist()
        {
            List<ReceptionistModel> Model = receptionistManager.ViewReceptionist();
            return View(Model);
        }







	}
}