using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIIE.Models
{
    public class ReinscriptionModels
    {
        public class ReinscriptionData
        {
            public string BeginDate { get; set; }
            public string EndingDate { get; set; }
            public double Quantity1 { get; set; }
            public double Quantity2 { get; set; }
        }

        public class ReinscriptionUpdate
        {
        }
    }
}