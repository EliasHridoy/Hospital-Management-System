using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManagmentSystemWebApp.Gateways;
using HospitalManagmentSystemWebApp.Models;
using HospitalManagmentSystemWebApp.Models.ViewModels;

namespace HospitalManagmentSystemWebApp.Managers
{
    public class ReceptionistManager
    {

        private ReceptionistGateway receptionistGateway;

        public ReceptionistManager()
        {
            receptionistGateway = new ReceptionistGateway();
        }




        public string Save(ReceptionistModel receptionist)
        {
            int rowEffect = receptionistGateway.Save(receptionist);

            if (rowEffect > 0) { return "Save Successful"; }
            else { return "Save Faild"; }

        }


         //---------------------------Duty----------------------------------------------------

        public string DutySave(ReceptionistDutyModel receptionistDuty)
        {
            int rowEffect = receptionistGateway.DutySave(receptionistDuty);

            if (rowEffect > 0) { return "Save Successful"; }
            else { return "Save Faild"; }
        }


        public List<ReceptionistViewModel> GetAllReceptionist()
        {
            return receptionistGateway.GetAllReceptionist();
        }

        //---------------duty view ------------------------------------

        public List<ReceptionistDutyViewModel> ViewReceptionistDuty(string date, int shiftId = 0)
        {
            return receptionistGateway.ViewReceptionistDuty(date, shiftId);
        }


    }
}