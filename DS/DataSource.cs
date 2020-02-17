using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DS
{
    public class DataSource
    {
        public static List<Mother> mothers;
        public static List<Child> childs;
        public static List<Nanny> nannys;
        public static List<Contract> contracts;
        public DataSource()
        {
            mothers = new List<Mother>();
            childs = new List<Child>();
            nannys = new List<Nanny>();
            contracts = new List<Contract>();
        }
    }
}
