using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManagmentSystemWebApp.Gateways;
using HospitalManagmentSystemWebApp.Models;
using HospitalManagmentSystemWebApp.Models.ViewModels;

namespace HospitalManagmentSystemWebApp.Managers
{
    public class NurseDutyScheduleManager
    {
        NurseDutyScheduleGateway nurseDutyScheduleGateway = new NurseDutyScheduleGateway();



        public string Save(NurseDutyScheduleModel nurseDuty)
        {
            int rowEffect = nurseDutyScheduleGateway.Save(nurseDuty);

            if (rowEffect > 0) { return "Save Successful"; }
            else { return "Save Faild"; }
        }
          //----------------------------------------------------------------------------------

        public List<NurseViewModel> GetAllNurse()
        {
            return nurseDutyScheduleGateway.GetAllNurse();
        }
         //----------------------------------------------------------------------------------
        public List<ShiftViewModel> GetAllShift()
        {
            return nurseDutyScheduleGateway.GetAllShift();
        }

    }
}