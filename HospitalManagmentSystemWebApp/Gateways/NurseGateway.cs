using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HospitalManagmentSystemWebApp.Models;

namespace HospitalManagmentSystemWebApp.Gateways
{
    public class NurseGateway :CommonGateway
    {



        public int Save(NurseModel nurse)
        {
            query = "INSERT INTO NurseTable " +
                "VALUES(@firstName,@lastName,@address," +
                    "@dateOfJoining,@NID ) ";

            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@firstName", nurse.FirstName);
            Command.Parameters.AddWithValue("@lastName", nurse.LastName);
            
            Command.Parameters.AddWithValue("@address", nurse.Address);
            
            
            Command.Parameters.AddWithValue("@dateOfJoining", nurse.DateOfJoining);
            
            Command.Parameters.AddWithValue("@NID", nurse.NID);
            

            Connection.Open();
            int rowEffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowEffect;

        }



        //-------show Nurse------------------------------------

        public List<NurseModel> GetAllNurse()
        {
            query = "SELECT * FROM NurseTable";

            Command = new SqlCommand(query, Connection);
            List<NurseModel> nurseList = new List<NurseModel>();

            Connection.Open();
            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                NurseModel nurse = new NurseModel();

                
                nurse.FirstName = Reader["FirstName"].ToString();
                nurse.LastName = Reader["LastName"].ToString();
                nurse.Address = Reader["Address"].ToString();
                nurse.NID = Convert.ToInt32(Reader["NID"]);
                
                

                nurseList.Add(nurse);
            }
            Connection.Close();
            return nurseList;
        }





    }
}