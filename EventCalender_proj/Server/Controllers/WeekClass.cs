using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCalender_proj.Server.Controllers
{
    public class WeekClass
    {
        public List<DayEvent> Dates { get; set; } = new List<DayEvent>();
    }
}
