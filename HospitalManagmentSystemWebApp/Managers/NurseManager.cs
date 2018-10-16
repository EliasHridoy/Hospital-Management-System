using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManagmentSystemWebApp.Gateways;
using HospitalManagmentSystemWebApp.Models;

namespace HospitalManagmentSystemWebApp.Managers
{
    public class NurseManager
    {


        
        private NurseGateway nurseGateway;

        public NurseManager()
        {
            nurseGateway = new NurseGateway();
        }



        public string Save(NurseModel nurse)
        {
            int rowEffect = nurseGateway.Save(nurse);

            if (rowEffect > 0) { return "Save Successful"; }
            else { return "Save Faild"; }
            
        }


        //-------------------show nurse--------------------------

        public List<NurseModel> GetAllNurse()
        {
            return nurseGateway.GetAllNurse();

        }



    }
}