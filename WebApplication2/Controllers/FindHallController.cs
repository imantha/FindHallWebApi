using FindHall.Model.Entity;
using FindHall.Service.Contracts;
using FindHall.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    [RoutePrefix("api/FindHall")]
    public class FindHallController : ApiController
    {

            IFindHallService findHallservice = new FindHallService();
            [HttpGet]
            [Route("GetHallDetails")]
            /// <summary>
            /// insert labour details
            /// </summary>
            public HallDetails GetHallDetails(string name)
            {
                return findHallservice.GetHallDetails(name);
            }
    }
}
