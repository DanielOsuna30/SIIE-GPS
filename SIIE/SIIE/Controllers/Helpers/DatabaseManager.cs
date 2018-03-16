using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SIIE.Controllers.Helpers
{
    public class DatabaseManager
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings[""].ConnectionString;

        public void Open()
        {

        }

        public void Close()
        {

        }

        public void Query()
        {

        }

    }
}