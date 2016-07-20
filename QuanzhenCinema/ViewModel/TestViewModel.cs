using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanzhenCinema.Models;

namespace QuanzhenCinema.ViewModel
{
    public class TestViewModel{
        public IEnumerable<CATEGORY> CategoryList { get; set; }
        public IEnumerable<HALL> HallList { get; set; }
    }
}