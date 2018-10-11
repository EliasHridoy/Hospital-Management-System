using System.Data.SqlClient;
using HospitalManagmentSystemWebApp.Models;

namespace HospitalManagmentSystemWebApp.Gateways
{
    public class LaboratoryGateway : CommonGateway
    {

        public int Save(LaboratoryModel laboratory)
        {
            if (laboratory.Description != null)
            {
                query = "INSERT INTO LaboratoryTable VALUES(@TEST,@DESCRIPTION)";
                Command = new SqlCommand(query, Connection);
                Command.Parameters.AddWithValue("TEST", laboratory.Name);
                Command.Parameters.AddWithValue("DESCRIPTION", laboratory.Description);
            }
            else
            {
                query = "INSERT  INTO LaboratoryTable(TestName)  values(@TEST);";
                Command = new SqlCommand(query, Connection);
                Command.Parameters.AddWithValue("TEST", laboratory.Name);
            }
           


            Connection.Open();
            int rowEffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowEffect;

        }



    }
}