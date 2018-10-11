using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HospitalManagmentSystemWebApp.Gateways;
using HospitalManagmentSystemWebApp.Models;
using HospitalManagmentSystemWebApp.Models.ViewModels;

namespace HospitalManagmentSystemWebApp.Managers
{
    public class DoctorManager
    {
        private DoctorGateway doctorGateway;

        public DoctorManager()
        {
            doctorGateway = new DoctorGateway();
        }



        public string Save(DoctorModel doctor)
        {
            int rowEffect = doctorGateway.Save(doctor);

            if (rowEffect > 0) { return "Save Successful"; }
            else { return "Save Faild"; }
            
        }



        public List<SpecializationViewModel> GetSpecialization()
        {
            return doctorGateway.GetSpecialization();

        }


    }
}