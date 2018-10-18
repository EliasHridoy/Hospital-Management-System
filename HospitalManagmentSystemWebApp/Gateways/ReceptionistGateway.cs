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
                "VALUES(@firstName,@lastName,@NID,@address," +
                    "@qalification,@Age,@BloodGroup ) ";

            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@firstName", receptionist.FirstName);
            Command.Parameters.AddWithValue("@lastName", receptionist.LastName);
            Command.Parameters.AddWithValue("@Age", receptionist.Age);
            Command.Parameters.AddWithValue("@address", receptionist.Address);
            Command.Parameters.AddWithValue("@qalification", receptionist.Qualification);
            Command.Parameters.AddWithValue("@NID", receptionist.NID);
            Command.Parameters.AddWithValue("@BloodGroup", receptionist.BloodGroup);

            Connection.Open();
            int rowEffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowEffect;

        }



        //---------------------------Duty----------------------------------------------------

        public int DutySave(ReceptionistDutyModel receptionistDuty)
        {
            query = "INSERT INTO NurseDutyScheduleTable VALUES(  '" + receptionistDuty.ReceptionistId + "', '" + receptionistDuty.Date + "', '" + receptionistDuty.ShiftId + "'   )";

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

        //----------------------------------------------------------------------------------
      

        //----------------------------------------------------------------------------------


    }
}