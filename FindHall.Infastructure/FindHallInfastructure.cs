using FindHall.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FindHall.Infastructure
{
    public class FindHallInfastructure
    {
        private FindHall.Infastructure.DataAccess dataAccess;
        public FindHallInfastructure()
        {

            dataAccess = new FindHall.Infastructure.DataAccess();
        }

        public List<HallDetails> GetHallDetails(int userky)
        {

            try
            {

                string sp = "GetAllHAllDetails";

                

                Dictionary<string, object> paramDictionary = new Dictionary<string, object>();

                SqlDataReader sqldr = dataAccess.ExecuteSelect(sp, userky, paramDictionary);
                List<HallDetails> hallArr = new List<HallDetails>();
                if (sqldr.HasRows)
                {

                    while (sqldr.Read())
                    {
                        HallDetails halldetails = new HallDetails();
                        halldetails.H_ID = sqldr["H_ID"].ToString();
                        halldetails.U_ID = sqldr["U_ID"].ToString();
                        halldetails.Price = sqldr["Price"].ToString();
                        halldetails.Access_Instruction = sqldr["Access_Instruction"].ToString();
                        halldetails.Parking_Spaces = sqldr["Parking_Spaces"].ToString();
                        halldetails.Description = sqldr["Description"].ToString(); ;
                        halldetails.Number_of_Seat = sqldr["Number_of_Seat"].ToString();
                        halldetails.Type_of_Owner = sqldr["Type_of_Owner"].ToString();
                        halldetails.Hall_Name = sqldr["Hall_Name"].ToString();
                        halldetails.City = sqldr["City"].ToString();
                        halldetails.Street = sqldr["Street"].ToString();
                        halldetails.latitude = sqldr["latitude"].ToString();
                        halldetails.longitude = sqldr["longitude"].ToString();
                        halldetails.Address = sqldr["Address"].ToString();
                        hallArr.Add(halldetails);
                    }
                }
                return hallArr;
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Error while Executing the sql command", ex);
            }
        }
        public List<HallDetails> GetSelectedHAllDetails(int userky,string city, string street,string hall)
        {

            try
            {

                string sp = "GetSelectedHAllDetails";



                Dictionary<string, object> paramDictionary = new Dictionary<string, object>();
                paramDictionary.Add("city", city);
                paramDictionary.Add("street", street);
                paramDictionary.Add("hall", hall);


                SqlDataReader sqldr = dataAccess.ExecuteSelect(sp, userky, paramDictionary);
                List<HallDetails> hallArr = new List<HallDetails>();
                if (sqldr.HasRows)
                {

                    while (sqldr.Read())
                    {
                        HallDetails halldetails = new HallDetails();
                        halldetails.H_ID = sqldr["H_ID"].ToString();
                        halldetails.U_ID = sqldr["U_ID"].ToString();
                        halldetails.Price = sqldr["Price"].ToString();
                        halldetails.Access_Instruction = sqldr["Access_Instruction"].ToString();
                        halldetails.Parking_Spaces = sqldr["Parking_Spaces"].ToString();
                        halldetails.Description = sqldr["Description"].ToString(); ;
                        halldetails.Number_of_Seat = sqldr["Number_of_Seat"].ToString();
                        halldetails.Type_of_Owner = sqldr["Type_of_Owner"].ToString();
                        halldetails.Hall_Name = sqldr["Hall_Name"].ToString();
                        halldetails.City = sqldr["City"].ToString();
                        halldetails.Street = sqldr["Street"].ToString();
                        halldetails.latitude = sqldr["latitude"].ToString();
                        halldetails.longitude = sqldr["longitude"].ToString();
                        halldetails.Address = sqldr["Address"].ToString();
                        hallArr.Add(halldetails);
                    }
                }
                return hallArr;
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Error while Executing the sql command", ex);
            }
        }
        public Availability GetHallAvbDetails(int userky,string hallid)
        {

            try
            {

                string sp = "GetAvailabilityPeriod";



                Dictionary<string, object> paramDictionary = new Dictionary<string, object>();
                paramDictionary.Add("hall", hallid);


                SqlDataReader sqldr = dataAccess.ExecuteSelect(sp, userky, paramDictionary);
                Availability halldetails = new Availability();
                if (sqldr.HasRows)
                {

                    while (sqldr.Read())
                    {
                       
                        halldetails.H_ID = sqldr["H_ID"].ToString();
                        halldetails.From_dt = sqldr["From_dt"].ToString();
                        halldetails.To_dt = sqldr["To_dt"].ToString();
                       
                    }
                }
                return halldetails;
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Error while Executing the sql command", ex);
            }
        }

        public List<BookingDetails> GetHallbookingDates(int userky, string hallid)
        {

            try
            {

                string sp = "GetBookingdates";



                Dictionary<string, object> paramDictionary = new Dictionary<string, object>();
                paramDictionary.Add("hall", hallid);


                SqlDataReader sqldr = dataAccess.ExecuteSelect(sp, userky, paramDictionary);
                List<BookingDetails> details = new List<BookingDetails>();
                if (sqldr.HasRows)
                {

                    while (sqldr.Read())
                    {
                        BookingDetails Bdetails = new BookingDetails();
                        Bdetails.IS_Recurring = sqldr["IS_Recurring"].ToString();
                        Bdetails.From_dt = sqldr["From_dt"].ToString();
                        Bdetails.To_dt = sqldr["To_dt"].ToString();
                        Bdetails.H_ID = hallid;
                        details.Add(Bdetails);

                    }
                }
                return details;
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Error while Executing the sql command", ex);
            }
        }
    }
}