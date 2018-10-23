using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HospitalManagmentSystemWebApp.Models;

namespace HospitalManagmentSystemWebApp.Gateways
{
    public class PatientGateway : CommonGateway
    {


        public int Save(PatientModel doctor)
        {
            query = "INSERT INTO PatientTable " +
                "VALUES(@firstName,@lastName,@gender,@Age,@Height," +
                    "@Weight,@DateOfBirth,@AddmissionDate,@ContactNo ) ";

            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@firstName", doctor.FirstName);
            Command.Parameters.AddWithValue("@lastName", doctor.LastName);
            Command.Parameters.AddWithValue("@gender", doctor.Gender);
            Command.Parameters.AddWithValue("@Age", doctor.Age);
            Command.Parameters.AddWithValue("@ContactNo", doctor.ContactNo);
            Command.Parameters.AddWithValue("@Height", doctor.Height);
            Command.Parameters.AddWithValue("@Weight", doctor.Weight);
            Command.Parameters.AddWithValue("@DateOfBirth", doctor.DateOfBirth);
            Command.Parameters.AddWithValue("@AddmissionDate", doctor.AddmissionDate);
           

            Connection.Open();
            int rowEffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowEffect;

        }



        //-----------------View Patient--------------------

        public List<PatientModel> ViewPaitent(string contactNo)
        {
            List<PatientModel> patientsList = new List<PatientModel>();
            if (contactNo == "")
            {
                query = "SELECT * FROM PatientTable";
            }
            else
            {
                query = "SELECT * FROM PatientTable WHERE ContactNo='"+contactNo+"' ";
            }

            Command = new SqlCommand(query,Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                PatientModel patient = new PatientModel();
                patient.FirstName = Reader["FirstName"].ToString();
                patient.LastName = Reader["LastName"].ToString();
                patient.ContactNo = Reader["ContactNo"].ToString();
                patient.Age = Convert.ToInt16(Reader["Age"]);
                patient.DateOfBirth = Reader["BirthDate"].ToString();
                patient.AddmissionDate = Reader["AdmitteDate"].ToString();

                patientsList.Add(patient);
            }
            Connection.Close();


            return patientsList;
        }






    }
}