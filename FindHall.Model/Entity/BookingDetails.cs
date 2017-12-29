using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindHall.Model.Entity
{
    public class BookingDetails
    {

        public string From_dt { get; set; }
        public string To_dt { get; set; }
        public string IS_Recurring { get; set; }
        public string H_ID { get; set; }
        public string U_ID { get; set; }
        public string B_ID { get; set; }
    }
}