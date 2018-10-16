using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagmentSystemWebApp.Managers;
using HospitalManagmentSystemWebApp.Models;

namespace HospitalManagmentSystemWebApp.Controllers
{
    public class NurseController : Controller
    {




        NurseManager nurseManager = new NurseManager();



        [HttpGet]
        public ActionResult SaveNurse()
        {
            
            return View();
        }


        [HttpPost]
        public ActionResult SaveNurse(NurseModel nurse)
        {
            

            ViewBag.message = nurseManager.Save(nurse);

            return View();
        }

        //-------------show Nurse--------------------

        public ActionResult ShowNurse()
        {
            ViewBag.nurseList = nurseManager.GetAllNurse();
            return View();
        }

         



	}
}