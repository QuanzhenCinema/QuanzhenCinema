using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanzhenCinema.Business
{
    public class ClassPackage
    {
        public ClassPackage(Schedule_Movie sm)
        {
            movie = sm.movie();
            schedule = sm.schedule();
            Hall = sm.Hall();
        }
        public List<DisplayMovieName_ViewModel> movie;
        public List<SCHEDULE_ViewModel> schedule;
        public List<HALL_ViewModel> Hall;
    }
}