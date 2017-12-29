using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FindHall.Infastructure
{
    class ExceptionHandlingDataLayer
    {

        /// <summary>
        /// GetSpNmWthPrmAndValue
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static string GetSpNmWthPrmAndValue(SqlCommand command)
        {
            string spName = "SP Name : ";
            string paramString = "Parameters with value : ";
            string mTempValue = "null";
            string mTempParamNm = "null";

            spName = spName + command.CommandText.ToString();
            for (int i = 0; i < command.Parameters.Count; i++)
            {
                mTempParamNm = command.Parameters[i].ParameterName.ToString();
                if (command.Parameters[i].Value != null)
                    mTempValue = command.Parameters[i].Value.ToString();

                if (i < command.Parameters.Count - 1)
                    paramString = paramString + mTempParamNm + " : " + mTempValue + ",\n ";
                else if (i == command.Parameters.Count - 1)
                    paramString = paramString + mTempParamNm + " : " + mTempValue + ".\n ";
            }

            return spName + ", " + paramString;
        }

        /// <summary>
        /// GetPrmAndValue
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static string GetPrmAndValue(SqlCommand command)
        {
            string paramString = "";
            string mTempValue = "null";
            string mTempParamNm = "null";


            for (int i = 0; i < command.Parameters.Count; i++)
            {
                mTempParamNm = command.Parameters[i].ParameterName.ToString();
                if (command.Parameters[i].Value != null)
                    mTempValue = command.Parameters[i].Value.ToString();

                if (i < command.Parameters.Count - 1)
                {
                    paramString = paramString + mTempParamNm + " : " + mTempValue + ",\n ";
                }
                else if (i == command.Parameters.Count - 1)
                    paramString = paramString + mTempParamNm + " : " + mTempValue + ".\n ";
            }

            return paramString;
        }

        /// <summary>
        /// WriteToLog
        /// </summary>
        /// <param name="LogMsg"></param>
        public static void WriteToLog(string LogMsg)
        {
            using (StreamWriter w = File.AppendText(HttpContext.Current.Request.MapPath("..") + "\\Logs\\ErrorLog\\FindHallExceptionLog.txt"))
            {
                Log(LogMsg, w);
            }

            //using (StreamReader r = File.OpenText("log.txt"))
            //{
            //    DumpLog(r);
            //}
        }
        
        /// <summary>
        /// Log
        /// </summary>
        /// <param name="logMessage"></param>
        /// <param name="w"></param>
        public static void Log(string logMessage, TextWriter w)
        {
            string userHostAddress = HttpContext.Current.Request.UserHostAddress;
            string userHostName = HttpContext.Current.Request.UserHostName;

            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1} {2} {3}", userHostAddress, userHostName, DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }

        /// <summary>
        /// DumpLog
        /// </summary>
        /// <param name="r"></param>
        public static void DumpLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }

        /// <summary>
        /// ErrLog_Insert
        /// </summary>
        /// <param name="SPNm"></param>
        /// <param name="OthVal"></param>
        /// <param name="ErrMsg"></param>
        /// <param name="ObjKy"></param>
        /// <param name="UsrKy"></param>
        /// <param name="DeviceKy"></param>
        /// <returns></returns>
        public static bool ErrLog_Insert(string SPNm, string OthVal, string ErrMsg, int ObjKy, int UsrKy, int DeviceKy)
        {
            string getSpNmWthPrmAndValue = "";
            string getPrmAndValue = "";
            string getSPName = "";

            try
            {
                using (SqlConnection sqlcon = new SqlConnection(DataAccess.ConString))
                {
                    using (SqlCommand command = sqlcon.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "ErrLog_Insert";

                        command.Parameters.AddWithValue("@SPNm", SPNm);
                        command.Parameters.AddWithValue("@OthVal", OthVal);
                        command.Parameters.AddWithValue("@ErrMsg", ErrMsg);
                        command.Parameters.AddWithValue("@ObjKy", ObjKy);
                        command.Parameters.AddWithValue("@InsertDt", DateTime.Now);
                        command.Parameters.AddWithValue("@UsrKy", UsrKy);
                        command.Parameters.AddWithValue("@DeviceKy", DeviceKy);

                        getSPName = command.CommandText;
                        getPrmAndValue = ExceptionHandlingDataLayer.GetPrmAndValue(command);
                        getSpNmWthPrmAndValue = ExceptionHandlingDataLayer.GetSpNmWthPrmAndValue(command);

                        sqlcon.Open();
                        command.ExecuteNonQuery();
                        sqlcon.Close();

                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                string errMsg = ex.Message.ToString();
                //ExceptionHandlingDataLayer.ErrLog_Insert(getSPName, getPrmAndValue, errMsg, 1, UsrKy, 1);
                ExceptionHandlingDataLayer.WriteToLog(getSpNmWthPrmAndValue + "ErrMsg : " + errMsg);
                throw new Exception(getSpNmWthPrmAndValue + "ErrMsg : " + errMsg);
            }
        }

    }
}
