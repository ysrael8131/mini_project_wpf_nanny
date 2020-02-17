using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BE
{
    public class Work_information
    {
        public TimeSpan start { set; get; }
        public TimeSpan end { set; get; }
        public bool day_work { set; get; }
        //public DayOfWeek day { set; get; }
        public Work_information()
        {
            start = new TimeSpan();
            end = new TimeSpan();
        }


        [XmlIgnore]
        public TimeSpan Start
        {
            get { return start; }
            set { start = value; }
        }

        [XmlIgnore]
        public TimeSpan End
        {
            get { return end; }
            set { end = value; }
        }

        [XmlElement("Start")]
        public long TimeSinceLastEventTicksStart
        {
            get { return start.Ticks; }
            set { start = new TimeSpan(value); }
        }

        [XmlElement("End")]
        public long TimeSinceLastEventTicksEnd
        {
            get { return end.Ticks; }
            set { end = new TimeSpan(value); }
        }
    }

}
