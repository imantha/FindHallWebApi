using FindHall.Model.Entity;
using FindHall.Service.Contracts;
using FindHall.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FindHallWebApi.Controllers
{
    [RoutePrefix("api")]
    public class FindHallController : ApiController
    {

        IFindHallService findHallservice = new FindHallService();
        [HttpGet]
        [Route("GetHallDetails")]
        public List<HallDetails> GetHallDetails(int userky)
        {
            return findHallservice.GetHallDetails(userky);
        }
        [HttpGet]
        [Route("GetSelectedHAllDetails")]
        public List<HallDetails> GetSelectedHAllDetails(int userky, string city, string street, string hall)
        {
            return findHallservice.GetSelectedHAllDetails(userky, city, street, hall);
        }
        [HttpGet]
        [Route("GetHallAvbDetails")]
        public Availability GetHallAvbDetails(int userky, string hallid)
        {
            return findHallservice.GetHallAvbDetails(userky, hallid);
        }
        [HttpGet]
        [Route("GetHallbookingDates")]
        public List<BookingDetails> GetHallbookingDates(int userky, string hallid)
        {
            return findHallservice.GetHallbookingDates(userky, hallid);
        }
    }
}
