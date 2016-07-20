using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanzhenCinema.Models;

namespace QuanzhenCinema.Business{
    public class DisplayMovieName_ViewModel
    {
        public int DISPLAY_ID { get; set; }
        public int MOVIE_ID { get; set; }
        public int IS_3D { get; set; }
        public int IS_IMAX { get; set; }
        public string LANGUAGE { get; set; }
        public int LOWEST_PRICE { get; set; }
        public int LENGTH { get; set; }
        public string Name { get; set; }
        public DateTime Expire_date { get; set; }
    }

    public class SCHEDULE_ViewModel
    {
        public int SCHEDULE_ID { get; set; }
        public int DISPLAY_ID { get; set; }
        public int DAY { get; set; }
        public int HALL_ID { get; set; }
        public int ORIGINAL_PRICE { get; set; }
        public DateTime? START_TIME { get; set; }
        public DateTime? END_TIME { get; set; }
        public string Name { get; set; }
    }

    public class HALL_ViewModel
    {
        public int HALL_ID { get; set; }
        public int CAPACITY { get; set; }
        public int IS_3D { get; set; }
        public int IS_DOLAB { get; set; }
        public int IS_IMAX { get; set; }
    }

    public class Package{
        public Package(Schedule_Movie sm){
            display = sm.getDisplay();
            schedule = sm.getSchedule();
            hall = sm.getHall();
        }
        public List<DisplayMovieName_ViewModel> display;
        public List<SCHEDULE_ViewModel> schedule;
        public List<HALL_ViewModel> hall;
    }

    public class Schedule_Movie{
        Quanzhen db;
        DateTime dt;

        public Schedule_Movie(DateTime d){
            db = new Quanzhen();
            dt = d;
        }

        public List<DisplayMovieName_ViewModel> getDisplay(){
            String sql = "select display_id,movie_id,is_3d,is_imax,language,lowest_price,length,name,expire_date from display natural join movie where expire_date > to_date('" + dt.Year + "-" + dt.Month + "-" + dt.Day + "','YYYY-MM-DD')";
            List<DisplayMovieName_ViewModel> display_moviename = db.Database.SqlQuery<DisplayMovieName_ViewModel>(sql).ToList();
            return display_moviename;
        }

        public List<SCHEDULE_ViewModel> getSchedule(){
            DateTime temp = dt.AddDays(1);
            String sql = "select * from schedule where start_time > to_date('" + dt.Year + '-' + dt.Month + '-' + dt.Day + "','YYYY-MM-DD') and end_time < to_date('" + temp.Year + '-' + temp.Month + '-' + temp.Day + "','YYYY-MM-DD')";
            List<SCHEDULE_ViewModel> s = db.Database.SqlQuery<SCHEDULE_ViewModel>(sql).ToList();
            return s;
        }

        public List<HALL_ViewModel> getHall(){
            String sql = "select * from hall";
            List<HALL_ViewModel> s = db.Database.SqlQuery<HALL_ViewModel>(sql).ToList();
            return s.ToList();
        }
    }
}