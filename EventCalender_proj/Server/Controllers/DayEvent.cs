﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCalender_proj.Server.Controllers
  
{
    public class DayEvent
    {
        public int DayEventId {  get; set; }

        public string Note { get; set; }
        public DateTime EventDate { get; set; } = new DateTime(2000, 1, 1);

        public DateTime FromDate { get; set; } = new DateTime(2000, 1, 1);

        public DateTime ToDate { get; set; } = new DateTime(2000, 1, 1);
        public string DateValue { get; set; }
        public string DateName { get; set; }
        public string Message { get; set; }


    }

}
