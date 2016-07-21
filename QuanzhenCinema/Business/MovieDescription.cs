using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using QuanzhenCinema.Models;

namespace QuanzhenCinema.Business
{
    public class MovieDetailViewModel
    {
        public int MOVIE_ID { get; set; }
        public String NAME { get; set; }
        public String IMAGE_PATH { get; set; }
        public String DESCRIPTION { get; set; }
        public DateTime EXPIRE_DATE { get; set; }
    }
    public class TempScheduleViewModel
    {
        public DateTime START_TIME { get; set; }
        public String LANGUAGE { get; set; }
        public int IS_3D { get; set; }
        public int IS_IMAX { get; set; }
        public int HALL_ID { get; set; }
    }
    public class ScheduleViewModel
    {
        public DateTime START_TIME { get; set; }
        public String LANGUAGE { get; set; }
        public String DISPLAY_TYPE { get; set; }
        public int HALL_ID { get; set; }
    }

    public class MovieDetail{
        private Quanzhen db;
        private int movie_id;
        public MovieDetail(int Movie_Id){
            db=new Quanzhen();
            movie_id = Movie_Id;
        }

        public List<MovieDetailViewModel> getMovieDetails(){
            String sql = "select movie_id,name,image_path,description,expire_date from movie natural join image where movie_id = "+movie_id;
            List<MovieDetailViewModel> movieDetails = db.Database.SqlQuery<MovieDetailViewModel>(sql).ToList();
            return movieDetails;
        }

        public List<String> getCategory()
        {
            String sql = "select category_name from movie natural join category_movie natural join category where movie_id = "+movie_id;
            List<String> category = db.Database.SqlQuery<String>(sql).ToList();
            return category;
        }

        public List<int> getLength(){
            String sql = "select distinct length from display where MOVIE_ID="+movie_id;
            List<int> length = db.Database.SqlQuery<int>(sql).ToList();
            return length;
        }

        public List<ScheduleViewModel> getSchedule1(){
            DateTime dt = DateTime.Now.ToLocalTime();
            DateTime tom = dt.AddDays(1);
            String sql =
                "select start_time,language,is_3d,is_imax,hall_id from movie natural join display natural join schedule where movie_id = " +
                movie_id + " and start_time>to_date('" + dt.Year + '-' + dt.Month + '-' + dt.Day +
                "','YYYY-MM-DD') and end_time < to_date('"+tom.Year+'-'+tom.Month+'-'+tom.Day+"','YYYY-MM-DD')";
            List<TempScheduleViewModel> temp = db.Database.SqlQuery<TempScheduleViewModel>(sql).ToList();
            List<ScheduleViewModel> schedule=new List<ScheduleViewModel>();
            for (int i = 0; i < temp.Count; i++){
                ScheduleViewModel s=new ScheduleViewModel();
                s.START_TIME = temp[i].START_TIME;
                s.LANGUAGE = temp[i].LANGUAGE;
                s.HALL_ID = temp[i].HALL_ID;
                String text = "";
                if (temp[i].IS_3D == 1) {
                    text += "3D";
                } else {
                    text += "2D";
                }
                if (temp[i].IS_IMAX == 1) {
                    text += " IMax";
                }
                s.DISPLAY_TYPE = text;
                schedule.Add(s);
            }
            return schedule;
        }

        public List<ScheduleViewModel> getSchedule2()
        {
            DateTime dt = DateTime.Now.ToLocalTime().AddDays(1);
            DateTime tom = dt.AddDays(1);
            String sql =
                "select start_time,language,is_3d,is_imax,hall_id from movie natural join display natural join schedule where movie_id = " +
                movie_id + " and start_time>to_date('" + dt.Year + '-' + dt.Month + '-' + dt.Day +
                "','YYYY-MM-DD') and end_time < to_date('" + tom.Year + '-' + tom.Month + '-' + tom.Day + "','YYYY-MM-DD')";
            List<TempScheduleViewModel> temp = db.Database.SqlQuery<TempScheduleViewModel>(sql).ToList();
            List<ScheduleViewModel> schedule = new List<ScheduleViewModel>();
            for (int i = 0; i < temp.Count; i++)
            {
                ScheduleViewModel s = new ScheduleViewModel();
                s.START_TIME = temp[i].START_TIME;
                s.LANGUAGE = temp[i].LANGUAGE;
                s.HALL_ID = temp[i].HALL_ID;
                String text = "";
                if (temp[i].IS_3D == 1)
                {
                    text += "3D";
                }
                else {
                    text += "2D";
                }
                if (temp[i].IS_IMAX == 1)
                {
                    text += " IMax";
                }
                s.DISPLAY_TYPE = text;
                schedule.Add(s);
            }
            return schedule;
        }

        public List<ScheduleViewModel> getSchedule3()
        {
            DateTime dt = DateTime.Now.ToLocalTime().AddDays(2);
            DateTime tom = dt.AddDays(1);
            String sql =
                "select start_time,language,is_3d,is_imax,hall_id from movie natural join display natural join schedule where movie_id = " +
                movie_id + " and start_time>to_date('" + dt.Year + '-' + dt.Month + '-' + dt.Day +
                "','YYYY-MM-DD') and end_time < to_date('" + tom.Year + '-' + tom.Month + '-' + tom.Day + "','YYYY-MM-DD')";
            List<TempScheduleViewModel> temp = db.Database.SqlQuery<TempScheduleViewModel>(sql).ToList();
            List<ScheduleViewModel> schedule = new List<ScheduleViewModel>();
            for (int i = 0; i < temp.Count; i++)
            {
                ScheduleViewModel s = new ScheduleViewModel();
                s.START_TIME = temp[i].START_TIME;
                s.LANGUAGE = temp[i].LANGUAGE;
                s.HALL_ID = temp[i].HALL_ID;
                String text = "";
                if (temp[i].IS_3D == 1)
                {
                    text += "3D";
                }
                else {
                    text += "2D";
                }
                if (temp[i].IS_IMAX == 1)
                {
                    text += " IMax";
                }
                s.DISPLAY_TYPE = text;
                schedule.Add(s);
            }
            return schedule;
        }
    }
}