using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FactoryDal
    {
        static IDAL dl = null;
        public static IDAL getDal()
        {
            if (dl == null)
                dl = new DalXml();
            return dl;


        }
    }
}
