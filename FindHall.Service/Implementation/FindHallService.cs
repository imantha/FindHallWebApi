using FindHall.Infastructure;
using FindHall.Model.Entity;
using FindHall.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindHall.Service.Implementation
{
    public class FindHallService : IFindHallService
    {
        FindHallInfastructure dataAccess = new FindHallInfastructure();


        public List<HallDetails> GetHallDetails(int userky)
        {
            return dataAccess.GetHallDetails(userky);
        }
        public List<HallDetails> GetSelectedHAllDetails(int userky, string city, string street, string hall)
        {
            return dataAccess.GetSelectedHAllDetails(userky, city, street, hall);
        }
        public Availability GetHallAvbDetails(int userky, string hallid)
        {
            return dataAccess.GetHallAvbDetails(userky, hallid);
        }
        public List<BookingDetails> GetHallbookingDates(int userky, string hallid) {
            return dataAccess.GetHallbookingDates(userky, hallid);
        }
    }
}