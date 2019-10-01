using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BenchBnB.Models.ViewModels
{
    public class AllLists
    {
        public List<User> Users { get; set; }
        public List<Bench> Benches { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
