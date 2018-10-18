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

                //------------------------------------Nurse Duty View-------------------------------
        public List<NurseDutyViewModel> ViewNurseDuty(string date,int shiftId=0)
        {
            if (shiftId <= 0)
            {
                query = "SELECT * FROM NurseDutyView where Date = '"+date+"'  ";
            }
            else
            {
                query = "SELECT * FROM NurseDutyView where Date = '" + date + "' and shiftId= "+shiftId;
            }

            Command = new SqlCommand(query,Connection);


            List<NurseDutyViewModel> nurseDutyList = new List<NurseDutyViewModel>();

            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                NurseDutyViewModel nurse = new NurseDutyViewModel();

                nurse.Name = Reader["FirstName"] + " " + Reader["LastName"];
                nurse.Date = Reader["Date"].ToString();
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

                    nurse.Shift = shiftStart + " To " + shiftEnd;

                }
                else
                {
                    shiftEnd += " AM";
                }


                nurseDutyList.Add(nurse);
            }
            Connection.Close();

            return nurseDutyList;
        } 
                //----------------------------------------------------------------------------------

    }
}