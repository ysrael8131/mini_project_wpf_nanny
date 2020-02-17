using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{

    public class FactoryBl
    {
        static IBL bl = null;

        public static IBL getBl()
        {
            if (bl == null)
                bl = new Bl_imp();
            return bl;
        }
    }
}
