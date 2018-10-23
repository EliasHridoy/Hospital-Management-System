using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HospitalManagmentSystemWebApp.Models;
using HospitalManagmentSystemWebApp.Models.ViewModels;

namespace HospitalManagmentSystemWebApp.Gateways
{
    public class ReceptionistGateway : CommonGateway
    {






        public int Save(ReceptionistModel receptionist)
        {

            query = "INSERT INTO ReceptionistTable " +
                "VALUES(@firstName,@lastName,@contactNo,@address," +
                    "@qalification,@Age,@BloodGroup ) ";

            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@firstName", receptionist.FirstName);
            Command.Parameters.AddWithValue("@lastName", receptionist.LastName);
            Command.Parameters.AddWithValue("@Age", receptionist.Age);
            Command.Parameters.AddWithValue("@address", receptionist.Address);
            Command.Parameters.AddWithValue("@qalification", receptionist.Qualification);
            Command.Parameters.AddWithValue("@contactNo", receptionist.ContactNo);
            Command.Parameters.AddWithValue("@BloodGroup", receptionist.BloodGroup);

            Connection.Open();
            int rowEffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowEffect;

        }



        //---------------------------Show Receptionist----------------------------------------------------


        public List<ReceptionistModel> ViewReceptionist()
        {
            List<ReceptionistModel> receptionistList = new List<ReceptionistModel>();
           
                query = "SELECT * FROM ReceptionistTable";
            

            Command = new SqlCommand(query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                ReceptionistModel receptionist = new ReceptionistModel();
                receptionist.FirstName = Reader["FirstName"].ToString();
                receptionist.LastName = Reader["LastName"].ToString();
                receptionist.BloodGroup = Reader["BloodGroup"].ToString();
                receptionist.Address = Reader["Address"].ToString();
                receptionist.Age = Convert.ToInt32(Reader["Age"]);
                receptionist.ContactNo = Convert.ToInt32(Reader["ContactNo"]);
                
                receptionistList.Add(receptionist);
            }
            Connection.Close();


            return receptionistList;
        }





        //---------------------------Duty----------------------------------------------------

        public int DutySave(ReceptionistDutyModel receptionistDuty)
        {
            query = "INSERT INTO ReceptionistDutyTable VALUES(  '" + receptionistDuty.ReceptionistId + "', '" + receptionistDuty.Date + "', '" + receptionistDuty.ShiftId + "'   )";

            Command = new SqlCommand(query, Connection);

            Connection.Open();
            int rowEffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowEffect;
        }

        //----------------------------------------------------------------------------------

        public List<ReceptionistViewModel> GetAllReceptionist()
        {

            query = "SELECT * FROM ReceptionistTable";

            Command = new SqlCommand(query, Connection);

            List<ReceptionistViewModel> receptionistList = new List<ReceptionistViewModel>();

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                ReceptionistViewModel receptionist = new ReceptionistViewModel();
                receptionist.Id = Convert.ToInt32(Reader["Id"]);
                receptionist.Name = Reader["FirstName"].ToString() + " " + Reader["LastName"].ToString();


                receptionistList.Add(receptionist);

            }
            Connection.Close();

            return receptionistList;
        }

        //------------------------------------View Duty----------------------------------------------


        public List<ReceptionistDutyViewModel> ViewReceptionistDuty(string date, int shiftId = 0)
        {
            if (shiftId <= 0)
            {
                query = "SELECT * FROM ReceptionistDutyView where Date = '" + date + "'  ";
            }
            else
            {
                query = "SELECT * FROM ReceptionistDutyView where Date = '" + date + "' and shiftId= " + shiftId;
            }

            Command = new SqlCommand(query, Connection);


            List<ReceptionistDutyViewModel> receptionistDutyList = new List<ReceptionistDutyViewModel>();

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                ReceptionistDutyViewModel receptionist = new ReceptionistDutyViewModel();

                receptionist.Name = Reader["FirstName"] + " " + Reader["LastName"];
                receptionist.Date = date;
                string shiftStart = Reader["ShiftStart"].ToString();
                string shiftEnd = Reader["ShiftEnd"].ToString();
                // 14:00:00 To 22:00:00 

                int hour = Convert.ToInt32(shiftStart.Substring(0, 2));
                if (hour > 12)
                {
                    hour -= 12;
                    shiftStart = shiftStart.Remove(0, 2);
                    shiftStart = hour + shiftStart + " PM";
                }
                else
                {
                    shiftStart += " AM";
                }
                hour = Convert.ToInt32(shiftEnd.Substring(0, 2));
                if (hour > 12)
                {
                    hour -= 12;
                    shiftEnd = shiftEnd.Remove(0, 2);
                    shiftEnd = hour + shiftEnd + " PM";

                    receptionist.Shift = shiftStart + " To " + shiftEnd;

                }
                else
                {
                    shiftEnd += " AM";
                }


                receptionistDutyList.Add(receptionist);
            }
            Connection.Close();

            return receptionistDutyList;
        } 
      

        //----------------------------------------------------------------------------------


    }
}