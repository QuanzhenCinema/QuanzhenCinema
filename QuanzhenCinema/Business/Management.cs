using QuanzhenCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;

namespace QuanzhenCinema.Business
{

    public class barChartInfo
    {
        public string movie_name { get; set; }
        //        public DateTime time { get; set; }
        public double rate { get; set; }
    }

    public class lineChartInfo
    {
        public DateTime time { get; set; }
        public int count_price = 0;
    }

    public class pieChartInfo
    {
        public int label_source { get; set; }
        public double value_rate { get; set; }
    }

    public class chartInfo
    {
        public string movie_name { get; set; }
        public int count_price { get; set; }
    }

    public class Management
    {
        Quanzhen db;
        public Management()
        {
            db = new Quanzhen();
        }
        public int getMovieCount()
        {
            DateTime dt = new DateTime();
            String sql = "select * from movie where expire_date > to_date('" + dt.Year + '-' + dt.Month + '-' + dt.Day + "', 'YYYY-MM-DD')";
            List<MOVIE> movie = db.Database.SqlQuery<MOVIE>(sql).ToList();
            return movie.Count;
        }
        public int getDiscountCount()
        {
            String sql = "select * from discount";
            List<DISCOUNT> discount = db.Database.SqlQuery<DISCOUNT>(sql).ToList();
            return discount.Count;
        }
        public int getStaffCount()
        {
            String sql = "select * from staff";
            List<STAFF> staff = db.Database.SqlQuery<STAFF>(sql).ToList();
            return staff.Count;
        }
        public int getMemberCount()
        {
            String sql = "select * from member";
            List<MEMBER> member = db.Database.SqlQuery<MEMBER>(sql).ToList();
            return member.Count;
        }

        public string getBarChartInfo()
        {
            string sql = "with tot_count(movie_name,value) as( select name, sum(capacity)  from movie natural join display natural join schedule join hall on hall.hall_id = schedule.hall_id where to_number(to_char(sysdate + 3, 'DD')) = to_number(to_char(start_time, 'DD'))  group by name) select name movie_name, count(*) / tot_count.value rate from movie natural join display natural join schedule natural join ticket, tot_count where to_number(to_char(sysdate + 3, 'DD')) = to_number(to_char(start_time, 'DD'))  and tot_count.movie_name = name group by name, tot_count.value";
            List<barChartInfo> bci = db.Database.SqlQuery<barChartInfo>(sql).ToList();
            var json = new JavaScriptSerializer().Serialize(bci);
            return json;
        }

        public string getLineChartInfo(string movieName)
        {
            string sql = "select sysdate-1 time, sum(original_price) count_price from ticket, schedule natural join display natural join movie where ticket.schedule_id = schedule.schedule_id and to_number(to_char(sysdate, 'dd')) - 1 = to_number(to_char(start_time, 'dd')) and name = '" + movieName + "'";
            List<lineChartInfo> lci = db.Database.SqlQuery<lineChartInfo>(sql).ToList();
            sql = "select sysdate-2 time, sum(original_price) count_price from ticket, schedule natural join display natural join movie where ticket.schedule_id = schedule.schedule_id and  to_number(to_char(sysdate, 'dd')) - 2 = to_number(to_char(start_time, 'dd')) and name = '" + movieName + "'";
            lci.AddRange(db.Database.SqlQuery<lineChartInfo>(sql).ToList());
            sql = "select sysdate-3 time, sum(original_price) count_price from ticket, schedule natural join display natural join movie where ticket.schedule_id = schedule.schedule_id and to_number(to_char(sysdate, 'dd')) - 3 = to_number(to_char(start_time, 'dd')) and name = '" + movieName + "'";
            lci.AddRange(db.Database.SqlQuery<lineChartInfo>(sql).ToList());
            sql = "select sysdate-4 time, sum(original_price) count_price from ticket, schedule natural join display natural join movie where ticket.schedule_id = schedule.schedule_id and to_number(to_char(sysdate, 'dd')) - 4 = to_number(to_char(start_time, 'dd')) and name = '" + movieName + "'";
            lci.AddRange(db.Database.SqlQuery<lineChartInfo>(sql).ToList());
            sql = "select sysdate-5 time, sum(original_price) count_price from ticket, schedule natural join display natural join movie where ticket.schedule_id = schedule.schedule_id and to_number(to_char(sysdate, 'dd')) - 5 = to_number(to_char(start_time, 'dd')) and name = '" + movieName + "'";
            lci.AddRange(db.Database.SqlQuery<lineChartInfo>(sql).ToList());
            sql = "select sysdate-6 time, sum(original_price) count_price from ticket, schedule natural join display natural join movie where ticket.schedule_id = schedule.schedule_id and to_number(to_char(sysdate, 'dd')) - 6 = to_number(to_char(start_time, 'dd')) and name = '" + movieName + "'";
            lci.AddRange(db.Database.SqlQuery<lineChartInfo>(sql).ToList());
            sql = "select sysdate-7 time, sum(original_price) count_price from ticket, schedule natural join display natural join movie where ticket.schedule_id = schedule.schedule_id and to_number(to_char(sysdate, 'dd')) - 7 = to_number(to_char(start_time, 'dd')) and name = '" + movieName + "'";
            lci.AddRange(db.Database.SqlQuery<lineChartInfo>(sql).ToList());
            var json = new JavaScriptSerializer().Serialize(lci);
            return json;
        }

        public string getPieChartInfo()
        {
            string sql = "with order_count(value) as (select count(*)  from myorder natural join ticket natural join schedule where to_number(to_char(sysdate + 3, 'dd')) = to_number(to_char(start_time, 'dd'))) select operator_id label_source, count(order_id) / order_count.value value_rate from myorder natural join ticket natural join schedule natural join order_count where to_number(to_char(sysdate + 3, 'dd')) = to_number(to_char(start_time, 'dd')) group by operator_id, order_count.value";
            List<pieChartInfo> pci = db.Database.SqlQuery<pieChartInfo>(sql).ToList();
            var json = new JavaScriptSerializer().Serialize(pci);
            return json;
        }

        public string getChartInfo()
        {
            string sql = "select name movie_name, sum(original_price)*count(ticket_id) count_price from movie natural join display natural join schedule,ticket where ticket.schedule_id = schedule.schedule_id group by name";
            List<chartInfo> ci = db.Database.SqlQuery<chartInfo>(sql).ToList();
            var json = new JavaScriptSerializer().Serialize(ci);
            return json;
        }
    }
}