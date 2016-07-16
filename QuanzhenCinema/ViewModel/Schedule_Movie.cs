using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanzhenCinema.Models;

namespace QuanzhenCinema.ViewModel{
    public class Schedule_Movie{
        IEnumerable<DISPLAY> Display { get; set; }
        IEnumerable<HALL> Hall { get; set; }
        IEnumerable<String> Move_Name { get; set; }
    }
}