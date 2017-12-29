using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FindHall.Infastructure
{
    public class DBCon
    {
        public class DBConnection
        {
            public static string Con = ConfigurationManager.ConnectionStrings["DataConnection"].ConnectionString;
        }
    }
}