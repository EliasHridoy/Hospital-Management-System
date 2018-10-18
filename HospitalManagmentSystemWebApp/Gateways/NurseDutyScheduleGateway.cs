using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HospitalManagmentSystemWebApp.Models;
using HospitalManagmentSystemWebApp.Models.ViewModels;
using Microsoft.Ajax.Utilities;

namespace HospitalManagmentSystemWebApp.Gateways
{
    public class NurseDutyScheduleGateway:CommonGateway
    {


        public int Save(NurseDutyScheduleModel nurseDuty)
        {
            query = "INSERT INTO NurseDutyScheduleTable VALUES(  '"+ nurseDuty.NurseId+"', '"+nurseDuty.Date+"', '"+nurseDuty.ShiftId+"'   )";

            Command = new SqlCommand(query,Connection);

            Connection.Open();
            int rowEffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowEffect;
        }

        //----------------------------------------------------------------------------------

        public List<NurseViewModel> GetAllNurse()
        {

            query = "SELECT * FROM NurseTable";

            Command = new SqlCommand(query, Connection);

            List<NurseViewModel> nurseList = new List<NurseViewModel>();

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                NurseViewModel nurse = new NurseViewModel();
                nurse.Id = Convert.ToInt32(Reader["Id"]);
                nurse.Name = Reader["FirstName"].ToString() + " " + Reader["LastName"].ToString();


                nurseList.Add(nurse);

            }
            Connection.Close();

            return nurseList;
        }

        //----------------------------------------------------------------------------------
         public List<ShiftViewModel> GetAllShift()
                {

                    query = "SELECT * FROM ShiftTable";

                    Command = new SqlCommand(query, Connection);

                    List<ShiftViewModel> shiftList = new List<ShiftViewModel>();

                    Connection.Open();
                    Reader = Command.ExecuteReader();
                    while (Reader.Read())
                    {
                        ShiftViewModel shift = new ShiftViewModel();
                        shift.Id = Convert.ToInt32(Reader["Id"]);
                        shift.ShiftName = Reader["ShiftStart"].ToString() + "  to  " + Reader["ShiftEnd"].ToString();


                        shiftList.Add(shift);

                    }
                    Connection.Close();

                    return shiftList;
                }

                //----------------------------------------------------------------------------------

    }
}