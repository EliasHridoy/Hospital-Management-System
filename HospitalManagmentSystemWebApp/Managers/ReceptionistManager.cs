using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManagmentSystemWebApp.Gateways;
using HospitalManagmentSystemWebApp.Models;

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
    }
}