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
                    appointment.AppointmentDate + "', '" + appointment.AppointmentNo + "' , '"+appointment.ContactNo+"') ";

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
                doctor.Name = Reader["FirstName"].ToString() +" "+ Reader["LastName"].ToString();
                

                doctorList.Add(doctor);

            }
            Connection.Close();

            return doctorList;
        }
        public List<DoctorViewModel> GetDoctorBySpecilization(int specializationId)
        {
            query = "SELECT * FROM DoctorTable WHERE SpecilizationId="+specializationId;

            Command  = new SqlCommand(query, Connection);

            List<DoctorViewModel> doctorList = new List<DoctorViewModel>();

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                DoctorViewModel doctor = new DoctorViewModel();
                doctor.Id = Convert.ToInt32(Reader["Id"]);
                doctor.Name = Reader["FirstName"].ToString() +" "+ Reader["LastName"].ToString();
                

                doctorList.Add(doctor);

            }
            Connection.Close();

            return doctorList;
        }



        public DoctorViewModel GetDoctorById(int doctorId, string date)
        {

            query = "SELECT * FROM DoctorTable WHERE Id=" + doctorId ;

            Command = new SqlCommand(query,Connection);
            DoctorViewModel doctor = new DoctorViewModel();
            
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            doctor.MaximumAppointment = Convert.ToInt32(Reader["MaximumAppointment"]);
            Connection.Close();


            query = "select Count(Id) as Appointed from AppointmentScheduleTable where doctorId='" + doctorId +
                    "' and Appointmentdate= '"+date+"' "  ;
            Command = new SqlCommand(query,Connection);
        
            
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            int appointed = Convert.ToInt32(Reader["Appointed"]);

            doctor.RemainingAppointment = doctor.MaximumAppointment - appointed;
            Connection.Close();
            return doctor;
        }


        ///----------------Appointment View ---------------------------------


        public List<AppointmentViewModel> ViewAppointment(string date, int doctorId)
        {
            if (doctorId > 0)
            {
                query = "SELECT * FROM AppointmentView WHERE Appointmentdate='" + date + "' and Id=" + doctorId;
            }
            else
            {
                query = "SELECT * FROM AppointmentView WHERE Appointmentdate='" + date + "' " ;
            }
            Command = new SqlCommand(query,Connection);

            List<AppointmentViewModel> appointmentList = new List<AppointmentViewModel>();

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                AppointmentViewModel viewAppointment = new AppointmentViewModel();

                viewAppointment.Name = Reader["FirstName"] + " " + Reader["LastName"];
                viewAppointment.Date = date;
                viewAppointment.AppointmentNo = Convert.ToInt32(Reader["AppointmentNo"]);
                viewAppointment.PatientContactNo = Reader["PatientContactNo"].ToString();

                appointmentList.Add(viewAppointment);

            }
            Connection.Close();


            foreach (var item in appointmentList)
            {
            
                query = "SELECT * FROM PatientTable WHERE ContactNo = '"+item.PatientContactNo+"'    ";

                Command = new SqlCommand(query, Connection);

                Connection.Open();

                Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    item.PatientName = Reader["FirstName"] + " " + Reader["LastName"];
                }
                Connection.Close();

            }
            





            return appointmentList;
        }



    }
}