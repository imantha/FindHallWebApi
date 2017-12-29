using FindHall.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindHall.Service.Contracts
{
    public interface IFindHallService
    {
        List<HallDetails> GetHallDetails(int userky);
        List<HallDetails> GetSelectedHAllDetails(int userky, string city, string street, string hall);
        Availability GetHallAvbDetails(int userky, string hallid);
        List<BookingDetails> GetHallbookingDates(int userky, string hallid);
        
    }
}
