using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{



    public class Contract
    {
        public Contract()
           
        {
            start = DateTime.Now;
            end = DateTime.Now;
        }
        public int num_contract { set; get; }
        public int? NannyID { set; get; }
        public int? MotherID { set; get; }
        public int? childID { set; get; }
        public bool knowlageMeet { set; get; }
        public bool contractSigne { set; get; }
        public double? salaryPerHour { set; get; }
        public double? salaryPerMonth { set; get; }
        public double? totalSalary { set; get; }
        public bool ContracPer { set; get; }
        public DateTime start { set; get; }
        public DateTime end { set; get; }

        public override string ToString()
        {

            return "num contract: " + num_contract + '\n' +
                "nanny id: " + NannyID + '\n' +
                "mother id: " + MotherID + '\n' +
                "Child id: " + childID + '\n' +
                 "salary: " + totalSalary;
        }
    }
}
