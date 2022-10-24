using System;
using System.Collections.Generic;
using System.Linq;
using Work01.Models.ViewModel;

namespace Work01.Models.DAL
{
    public class IndexDate
    {
        private readonly ExpenseTrackDbContaxt db;
        public IndexDate(ExpenseTrackDbContaxt db)
        {
            this.db = db;
                
        }
        public IEnumerable<User> vm { get; set; }
        public void onget()
        {
            vm = db.Users.ToList();
        }
        public void Onpost(DateTime startdate,DateTime endDate)
        {
            vm = (from x in db.Users where (x.ExpenseDate <= startdate) && (x.ExpenseDate >= endDate) select x).ToList();
        }



    }
}
