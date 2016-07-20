using QuanzhenCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanzhenCinema.Business{
    public class Management{
        Quanzhen db;
        public Management(){
            db = new Quanzhen();
        }
        public int getMovieCount(){
            DateTime dt = new DateTime();
            String sql = "select * from movie where expire_date > to_date('"+dt.Year+'-'+dt.Month+'-'+dt.Day+"', 'YYYY-MM-DD')";
            List<MOVIE> movie = db.Database.SqlQuery<MOVIE>(sql).ToList();
            return movie.Count;
        }
       public int getDiscountCount(){
           String sql = "select * from discount";
           List<DISCOUNT> discount = db.Database.SqlQuery<DISCOUNT>(sql).ToList();
           return discount.Count;
       }
        public int getStaffCount(){
            String sql = "select * from staff";
            List<STAFF> staff = db.Database.SqlQuery<STAFF>(sql).ToList();
            return staff.Count;
        }
        public int getMemberCount(){
            String sql = "select * from member";
            List<MEMBER> member = db.Database.SqlQuery<MEMBER>(sql).ToList();
            return member.Count;
        }
    }
}