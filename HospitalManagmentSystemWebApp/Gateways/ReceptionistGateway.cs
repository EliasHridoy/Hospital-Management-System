using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HospitalManagmentSystemWebApp.Models;

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


    }
}