using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanzhenCinema.Models;

namespace QuanzhenCinema.Business{
    public class Movie_ViewModel{
        public int MOVIE_ID { get; set; }
        public String NAME { get; set; }
        public String DESCRIPTION { get; set; }
        public DateTime EXPIRE_DATE { get; set; }
    }
    public class Schedule_ViewModel{
        public int SCHEDULE_ID { get; set; }
        public int DISPLAY_ID { get; set; }
        public int HALL_ID { get; set; }
        public int ORIGINAL_PRICE { get; set; }
        public DateTime START_TIME { get; set; }
        public DateTime END_TIME { get; set; }
    }
    public class Seat_ViewModel{
        public int COLUMN_ID { get; set; }
        public int ROW_ID { get; set; }
        public int HALL_ID { get; set; }
    }

    public class Sale{
        Quanzhen db;
        DateTime d;
        int movie_id;
        int schedule_id;

        public Sale(DateTime dt){
            db = new Quanzhen();
            d = dt;
        }
        public Sale(DateTime dt,int Movie_id){
            db = new Quanzhen();
            d = dt;
            movie_id = Movie_id;
        }
        public Sale(int Schedule_id){
            db = new Quanzhen();
            schedule_id = Schedule_id;
        }

        public List<Movie_ViewModel> getMovies(){
            DateTime temp = d.AddDays(1);
            String sql = "select * from movie where expire_date > to_date('" + d.Year + '-' + d.Month + '-' + d.Day + "','YYYY-MM-DD')";
            List<Movie_ViewModel> movie = db.Database.SqlQuery<Movie_ViewModel>(sql).ToList();

            return movie;
        }

        public List<Schedule_ViewModel> getSchedules(){
            DateTime temp = d.AddDays(1);
            String sql = "Select schedule_id,display_id,hall_id,original_price,start_time,end_time from schedule natural join display where movie_id=" + movie_id + " and start_time>to_date('" + d.Year + '-' + d.Month + '-' + d.Day + "','YYYY-MM-DD') and end_time<to_date('" + temp.Year + '-' + temp.Month + '-' + temp.Day + "','YYYY-MM-DD')";
            List<Schedule_ViewModel> schedule = db.Database.SqlQuery<Schedule_ViewModel>(sql).ToList();
            return schedule;
        }

        public List<String> getSeats(){
            String sql = "select * from ticket where schedule_id=" + schedule_id;
            List<TICKET> ticket = db.Database.SqlQuery<TICKET>(sql).ToList();
            List<String> seats = new List<string>();

            for (int i = 0; i < ticket.Count; i++)
            {
                seats.Add(ticket[i].SEAT_ROW_ID + "_" + ticket[i].SEAT_COLUMN_ID);
            }
            return seats;
        }
    }
}