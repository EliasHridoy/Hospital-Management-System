using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManagmentSystemWebApp.Gateways;
using HospitalManagmentSystemWebApp.Models;

namespace HospitalManagmentSystemWebApp.Managers
{
    public class LaboratoryManager
    {

        private LaboratoryGateway laboratoryGateway;

        public LaboratoryManager()
        {
            laboratoryGateway = new LaboratoryGateway();
        }



        public string Save(LaboratoryModel lab)
        {
            int rowEffect = laboratoryGateway.Save(lab);

            if (rowEffect > 0) { return "Save Successful"; }
            else { return "Save Faild"; }

        }




    }
}