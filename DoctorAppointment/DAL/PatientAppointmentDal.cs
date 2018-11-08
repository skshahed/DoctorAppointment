﻿using DoctorAppointment.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DoctorAppointment.DAL
{
    public class PatientAppointmentDal
    {

//Getting Doctor Category From DB Using DataAdapter-------->>>
        //public DataTable selectDoctorCategory()
        //{
        //    DataTable DocCatDt = new DataTable();
        //    string query = "SELECT * FROM DoctorCategory_T";
        //    DatabaseConnection con = new DatabaseConnection();
        //    try
        //    {
        //        SqlDataAdapter DocCatDa = new SqlDataAdapter(query, con.GetSqlConnection());
        //        DocCatDa.Fill(DocCatDt);
        //    }
        //    catch(Exception r)
        //    {
        //        DocCatDt = null;
        //    }
        //    finally
        //    {
        //        con.CloseConnection();
        //    }
        //    return DocCatDt;
        //}

//Getting Doctor Name From DB Using DataAdapter-------->>>
        //public DataTable selectDoctorName(DoctorCategory oDoctorCategory)
        //{
        //    //string docCatId = Ddl
        //    //DoctorCategory oDoctorCategory = new DoctorCategory();
        //    string catId = oDoctorCategory.Id.ToString();
        //    DataTable DocNameDt = new DataTable();
        //    string query = "SELECT user_id, name FROM UserProfile_T, DoctorInfo_T WHERE user_id = doctor_user_id AND doc_cat_id = '"+catId+"'";
        //    DatabaseConnection con = new DatabaseConnection();
        //    try
        //    {
        //        SqlDataAdapter DocNameDa = new SqlDataAdapter(query, con.GetSqlConnection());
        //        DocNameDa.Fill(DocNameDt);
        //    }
        //    catch (Exception r)
        //    {
        //        DocNameDt = null;
        //    }
        //    finally
        //    {
        //        con.CloseConnection();
        //    }
        //    return DocNameDt;
        //}
// Get Appointment Serial No 
        public string GetSerialNo(PatientAppointment oPatientAppointment)
        {
            string serial = "";
            DatabaseConnection con = new DatabaseConnection();
            string appointDate = oPatientAppointment.AppointDate;
            string doctorId = oPatientAppointment.DoctorUserId.ToString();
            string sql = "SELECT COUNT(appointment_id) from Appointment_T where doctor_user_id='" + doctorId + "' AND appoint_date ='" + appointDate + "'";
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con.GetSqlConnection());
                int count = (Int32) cmd.ExecuteScalar();
                serial = count.ToString();
            }
            catch (Exception r)
            {
                serial = "0";
            }
            finally
            {
                con.CloseConnection();
            }
            return serial;
        }
  
    }
}