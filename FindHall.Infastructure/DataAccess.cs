using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHall.Infastructure
{
    public class DataAccess
    {
        public SqlConnection con;
        public SqlCommand com;
        public static String ConString = ConfigurationManager.ConnectionStrings["DataConnection"].ConnectionString;

        public DataAccess()
        {
            con = new SqlConnection(ConString);
            com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
        }

        public int ExecuteCommand(String SP, int UsrKy, Dictionary<string, object> paramDictionary)
        {
            string getSpNmWthPrmAndValue = "";
            string getPrmAndValue = "";
            string getSPName = "";

            int r;
            try
            {
                con.Open();
                com.CommandText = SP;

                if (paramDictionary != null)
                {
                    SqlParameter param;
                    foreach (string key in paramDictionary.Keys)
                    {
                        param = com.CreateParameter();
                        param.ParameterName = "@" + key;
                        param.Value = paramDictionary[key];
                        com.Parameters.Add(param);
                    }
                }

                getSPName = com.CommandText;
                getPrmAndValue = ExceptionHandlingDataLayer.GetPrmAndValue(com);
                getSpNmWthPrmAndValue = ExceptionHandlingDataLayer.GetSpNmWthPrmAndValue(com);

                r = com.ExecuteNonQuery();
                return r;
            }
            catch (Exception ex)
            {
                string errMsg = ex.Message.ToString();
                ExceptionHandlingDataLayer.ErrLog_Insert(getSPName, getPrmAndValue, errMsg, 1, UsrKy, 1);
                ExceptionHandlingDataLayer.WriteToLog(getSpNmWthPrmAndValue + "ErrMsg : " + errMsg);
                throw new ApplicationException(getSpNmWthPrmAndValue + "ErrMsg : " + errMsg);
            }
        }

        public SqlDataReader ExecuteSelect(String SP, int UsrKy, Dictionary<string, object> paramDictionary)
        {
            string getSpNmWthPrmAndValue = "";
            string getPrmAndValue = "";
            string getSPName = "";

            con.Close();
            con = new SqlConnection(ConString);
            com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlDataReader dr;
                con.Open();
                com.CommandText = SP;
                if (paramDictionary != null)
                {
                    SqlParameter param;
                    foreach (string key in paramDictionary.Keys)
                    {
                        param = com.CreateParameter();
                        param.ParameterName = "@" + key;
                        param.Value = paramDictionary[key];
                        com.Parameters.Add(param);
                    }
                }

                getSPName = com.CommandText;
                getPrmAndValue = ExceptionHandlingDataLayer.GetPrmAndValue(com);
                getSpNmWthPrmAndValue = ExceptionHandlingDataLayer.GetSpNmWthPrmAndValue(com);

                dr = com.ExecuteReader();
                return dr;

            }
            catch (Exception ex)
            {
                string errMsg = ex.Message.ToString();
                ExceptionHandlingDataLayer.ErrLog_Insert(getSPName, getPrmAndValue, errMsg, 1, UsrKy, 1);
                ExceptionHandlingDataLayer.WriteToLog(getSpNmWthPrmAndValue + "ErrMsg : " + errMsg);
                throw new ApplicationException(getSpNmWthPrmAndValue + "ErrMsg : " + errMsg);
            }
        }

        public ArrayList ExectuteQuery(String SP, int UsrKy, params object[] para)
        {
            string getSpNmWthPrmAndValue = "";
            string getPrmAndValue = "";
            string getSPName = "";

            SqlDataReader dr = null;
            ArrayList recordList = new ArrayList();
            ArrayList record;

            try
            {
                con.Open();
                com.CommandText = SP;
                for (int a = 0; a < para.Length; a++)
                    com.Parameters.AddWithValue(a.ToString(), para[a]);

                getSPName = com.CommandText;
                getPrmAndValue = ExceptionHandlingDataLayer.GetPrmAndValue(com);
                getSpNmWthPrmAndValue = ExceptionHandlingDataLayer.GetSpNmWthPrmAndValue(com);

                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    record = new ArrayList();
                    for (int i = 0; i <= dr.FieldCount - 1; i++)
                    {
                        record.Add(dr[i]);
                    }
                    recordList.Add(record);
                }
                return recordList;
            }
            catch (Exception ex)
            {
                string errMsg = ex.Message.ToString();
                ExceptionHandlingDataLayer.ErrLog_Insert(getSPName, getPrmAndValue, errMsg, 1, UsrKy, 1);
                ExceptionHandlingDataLayer.WriteToLog(getSpNmWthPrmAndValue + "ErrMsg : " + errMsg);
                throw new ApplicationException(getSpNmWthPrmAndValue + "ErrMsg : " + errMsg);
            }
        }
    }
}
