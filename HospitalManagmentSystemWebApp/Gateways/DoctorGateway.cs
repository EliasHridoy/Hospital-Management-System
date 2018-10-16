using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;
using HospitalManagmentSystemWebApp.Models;
using HospitalManagmentSystemWebApp.Models.ViewModels;

namespace HospitalManagmentSystemWebApp.Gateways
{
    public class DoctorGateway : CommonGateway
    {


        public int Save(DoctorModel doctor)
        {
            query = "INSERT INTO DoctorTabel " +
                "VALUES(@firstName,@lastName,@gender,@address,@nationality," +
                    "@qalification,@dateOfJoining,@specialization,@NID,@availableTime ) ";

            Command = new SqlCommand(query,Connection);

            Command.Parameters.AddWithValue("@firstName", doctor.FirstName);
            Command.Parameters.AddWithValue("@lastName", doctor.LastName);
            Command.Parameters.AddWithValue("@gender", doctor.Gender);
            Command.Parameters.AddWithValue("@address", doctor.Address);
            Command.Parameters.AddWithValue("@nationality", doctor.Nationality);
            Command.Parameters.AddWithValue("@qalification", doctor.Qualification);
            Command.Parameters.AddWithValue("@dateOfJoining", doctor.DateOfJoining);
            Command.Parameters.AddWithValue("@specialization", doctor.Specilization);
            Command.Parameters.AddWithValue("@NID", doctor.NID);
            Command.Parameters.AddWithValue("@availableTime", doctor.AvailableTime);

            Connection.Open();
            int rowEffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowEffect;

        }




        public List<SpecializationViewModel> GetSpecialization( )
        {
            query = "SELECT * FROM SpecializationTable ";
            Command = new SqlCommand(query,Connection);
            List<SpecializationViewModel> spelializationList = new List<SpecializationViewModel>();

            Connection.Open();
            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                SpecializationViewModel specializ = new SpecializationViewModel();

                specializ.Id = Convert.ToInt32(Reader["Id"]);
                specializ.Specialization = Reader["Specialization"].ToString();

                spelializationList.Add(specializ);

            }

            Connection.Close();

            return spelializationList;
        }


//---------------------------Show Doctor------------------------------------
        public List<DoctorViewModel> GetAllDoctor(int specilizationId)
        {
            query = "SELECT     DoctorTabel.Id,   DoctorTabel.FirstName, DoctorTabel.LastName, " +
                    " DoctorTabel.SpecilizationId, DoctorTabel.AvailableTime, " +
                    "SpecializationTable.Specialization "+
"FROM            DoctorTabel INNER JOIN " +
                         " SpecializationTable ON DoctorTabel.SpecilizationId = SpecializationTable.Id "+
						  " where SpecializationTable.Id="+specilizationId ;

            Command = new SqlCommand(query,Connection);
            List<DoctorViewModel> doctorList = new List<DoctorViewModel>();

            Connection.Open();
            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                DoctorViewModel doctor = new DoctorViewModel();

                doctor.Id = Convert.ToInt32(Reader["Id"]);
                doctor.FirstName = Reader["FirstName"].ToString();
                doctor.LastName = Reader["LastName"].ToString();
                doctor.Specialization = Reader["Specialization"].ToString();
                doctor.AvailableTime = (Reader["AvailableTime"].ToString());
                
                doctorList.Add(doctor);
            }
            Connection.Close();
            return doctorList;
        }










    }
}