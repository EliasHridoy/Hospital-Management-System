using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HospitalManagmentSystemWebApp.Models;
using HospitalManagmentSystemWebApp.Models.ViewModels;

namespace HospitalManagmentSystemWebApp.Gateways
{
    public class AppointmentGateway : CommonGateway
    {

        public int Appointment(AppointmentScheduleModel appointment)
        {

            query = "INSERT INTO AppointmentScheduleTable VALUES('" + appointment.DoctorId + "' , '" +
                    appointment.AppointmentDate + "', '" + appointment.AppointmentTime + "') ";

            Command = new SqlCommand(query, Connection);
            
            Connection.Open();
            int rowEffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowEffect;


        }


        public List<DoctorViewModel> GetAllDoctor()
        {
            query = "SELECT * FROM DoctorTable";

            Command  = new SqlCommand(query, Connection);

            List<DoctorViewModel> doctorList = new List<DoctorViewModel>();

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                DoctorViewModel doctor = new DoctorViewModel();
                doctor.Id = Convert.ToInt32(Reader["Id"]);
                doctor.FirstName = Reader["FirstName"].ToString();
                doctor.LastName = Reader["LastName"].ToString();
                

                doctorList.Add(doctor);

            }
            Connection.Close();

            return doctorList;
        } 



    }
}