using System;
using System.Collections.Generic;
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


        //-------show Laboratory------------------------------------

        public List<LaboratoryModel> GetAllLaboratory()
        {
            query = "SELECT * FROM LaboratoryTable";

            Command = new SqlCommand(query, Connection);
            List<LaboratoryModel> laboratoryList = new List<LaboratoryModel>();

            Connection.Open();
            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                LaboratoryModel laboratory = new LaboratoryModel();


                laboratory.Name = Reader["TestName"].ToString();
                laboratory.Description = Reader["Descriptions"].ToString();
                laboratory.Price = Convert.ToInt32(Reader["Price"]);
                
                laboratoryList.Add(laboratory);
            }
            Connection.Close();
            return laboratoryList;
        }





    }
}