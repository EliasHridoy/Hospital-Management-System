using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagmentSystemWebApp.Managers;
using HospitalManagmentSystemWebApp.Models;

namespace HospitalManagmentSystemWebApp.Controllers
{
    public class LaboratoryController : Controller
    {
        private LaboratoryManager laboratoryManager;

        public LaboratoryController()
        {
            laboratoryManager = new LaboratoryManager();
        }


        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Save(LaboratoryModel laboratory)
        {

            ViewBag.message = laboratoryManager.Save(laboratory);

            return View();
        }
	}
}