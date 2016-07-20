using QuanzhenCinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanzhenCinema.Business
{
    public class StaffManage
    {
        Quanzhen db;
        public StaffManage()
        {
            db = new Quanzhen();
        }

        public partial class Schedule_STAFF
        {
            public int ID { get; set; }
            public string PASSWORD { get; set; }
            public string NAME { get; set; }
            public int GENDER { get; set; }
            public string POSITION { get; set; }
            public string ROLE { get; set; }
        }

        public string searchRole(string name)
        {
            string sql = "select ROLE from STAFF where ID = " + name;
            List<string> role = db.Database.SqlQuery<string>(sql).ToList();
            return role.Count == 0 ? null : role.ElementAt(0);
        }
    }
}