using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManagmentSystemWebApp.Gateways;
using HospitalManagmentSystemWebApp.Models;

namespace HospitalManagmentSystemWebApp.Managers
{
    public class PatientManager
    {
        PatientGateway patientGateway = new PatientGateway();


        public string Save(PatientModel patient)
        {
            int rowEffect = patientGateway.Save(patient);

            if (rowEffect > 0) { return "Save Successful"; }
            else { return "Save Faild"; }

        }


        public List<PatientModel> ViewPaitent(string contactNo)
        {
            return patientGateway.ViewPaitent(contactNo);
        }



    }
    }