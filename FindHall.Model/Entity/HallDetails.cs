using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindHall.Model.Entity
{
    public class HallDetails
    {
        public string H_ID { get; set; }
        public string U_ID { get; set; }
        public string Price { get; set; }
        public string Access_Instruction { get; set; }
        public string Parking_Spaces { get; set; }
        public string Description { get; set; }
        public string Postal_Code { get; set; }
        public string Number_of_Seat { get; set; }
        public string Type_of_Owner { get; set; }
        public string Hall_Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string Address { get; set; }
    }
}