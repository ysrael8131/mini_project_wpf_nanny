using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;
namespace PL
{
    class Program
    {

        static Random r = new Random();
        static void Main(string[] args)
        {

            BL.IBL bl = BL.FactoryBl.getBl();
            
            Bl_imp aaa = new BL.Bl_imp();
            Console.WriteLine(aaa.CalculateDistance(" קדיש לוז 10 ירושלים", "קוממיות 10 קרית גת"));
            Console.WriteLine();
            try
            {
                
                
                Mother mom1 = new Mother(1234, "dora1", "coen", "", "אוהב ישראל 3,ביתר עילית,ישראל", null, false);
                Mother mom2 = new Mother(1235, "dora2", "coen", "", "אוהב ישראל 3,ביתר עילית,ישראל", "קדושת לוי 115,ביתר עילית,ישראל", true);
                Mother mom3 = new Mother(1236, "dora3", "coen", "", "אוהב ישראל 3,ביתר עילית,ישראל", null, false);
                
                for (int i = 0; i < 6; i++)
                {
                    Work_information temp = new Work_information();
                    if (r.Next(0, 2) == 1)
                    {
                        temp.day_work = true;
                        temp.start = TimeSpan.Parse("8:30");
                        temp.end = TimeSpan.Parse("16:00");
                    }
                    else
                    {
                        temp.day_work = false;
                    }
                    mom3.arr[i] = temp;

                }
                Mother mom4 = new Mother(1237, "dora4", "coen", "", "אוהב ישראל 3,ביתר עילית,ישראל", null, true);
                Mother mom5 = new Mother(1238, "dora5", "coen", "", "אוהב ישראל 3,ביתר עילית,ישראל", null, false);
                Mother mom6 = new Mother(1239, "dora6", "coen", "", "אוהב ישראל 3,ביתר עילית,ישראל", null, true);
                bl.addMother(mom1);
                bl.addMother(mom2);
                bl.addMother(mom3);
                bl.addMother(mom4);
                bl.addMother(mom5);
                bl.addMother(mom6);
                foreach (var item in bl.getListMothers())
                {
                    Console.WriteLine(item);
                    Console.WriteLine();
                }
                bl.deleteMother(1234);
                bl.deleteMother(1239);
                Console.WriteLine("after delete 2 mothers" + '\n');
                foreach (var item in bl.getListMothers())
                {
                    Console.WriteLine(item);
                    Console.WriteLine();
                }

                Child ch1 = new Child(12345, 1235, "moshe1", "1/10/2017");
                Child ch2 = new Child(12346, 1235, "moshe2", "1/10/2017");
                Child ch3 = new Child(12347, 1236, "moshe3", "1/5/2017");
                Child ch4 = new Child(12348, 1236, "moshe4", "1/10/2017");
                Child ch5 = new Child(12349, 1236, "moshe5", "1/10/2017");
                Child ch6 = new Child(123410, 1237, "moshe6", "1/4/2017");
                Child ch7 = new Child(123411, 1237, "moshe7", "1/10/2017");
                Child ch8 = new Child(123412, 1237, "moshe8", "1/10/2017");
                Child ch9 = new Child(123413, 1237, "moshe9", "1/10/2017");
                Child ch10 = new Child(123414, 1238, "moshe10", "1/10/2017");
                Child ch11 = new Child(123415, 1238, "moshe11", "1/10/2017");
                Child ch12 = new Child(123416, 1238, "moshe12", "1/10/2017");
                Child ch13 = new Child(123417, 1238, "moshe13", "1/10/2017");
                Child ch14 = new Child(123418, 1238, "moshe14", "1/10/2017");
                Child ch15 = new Child(123419, 1238, "moshe15", "1/10/2017");
                bl.addChild(ch1);
                bl.addChild(ch2);
                bl.addChild(ch3);
                bl.addChild(ch4);
                bl.addChild(ch5);
                bl.addChild(ch6);
                bl.addChild(ch7);
                bl.addChild(ch8);
                bl.addChild(ch9);
                bl.addChild(ch10);
                bl.addChild(ch11);
                bl.addChild(ch12);
                bl.addChild(ch13);
                bl.addChild(ch14);
                bl.addChild(ch15);
                Console.WriteLine("mom2's children");
                foreach (var item in bl.getListChilds(mom2))
                {
                    Console.WriteLine(item);
                    Console.WriteLine();
                }
                Console.WriteLine("mom4's children");
                foreach (var item in bl.getListChilds(mom4))
                {
                    Console.WriteLine(item);
                    Console.WriteLine();
                }
                bl.deleteMother(1235);


                //Nanny nan1 = new Nanny(123, "sara1", "levi", "1/1/1993", 123456, "קדושת לוי 115,ביתר עילית,ישראל", true, 2, 2, 5, 3, 12, false, 25, 4000, true, null);
                //for (int j = 0; j < 6; j++)
                //{
                //    Work_information temp = new Work_information();
                //    temp.day_work = true;
                //    temp.start = TimeSpan.Parse("8:30");
                //    temp.end = TimeSpan.Parse("16:00");
                //    nan1.work[j] = temp;
                //}
                //Nanny nan2 = new Nanny(124, "sara2", "levi", "1/1/1993", 123456, "דרכי איש 10,ביתר עילית,ישראל", false, 2, 2, 3, 3, 12, false, 25, 4000, true, null);
                //Nanny nan3 = new Nanny(125, "sara3", "levi", "1/1/1993", 123456, "קדושת לוי 10,ביתר עילית,ישראל", false, 3, 2, 10, 5, 10, false, 25, 4000, true, null);
                //Nanny nan4 = new Nanny(126, "sara4", "levi", "1/1/1993", 123456, "באבא סאלי 10,ביתר עילית,ישראל", false, 4, 2, 2, 6, 9, false, 25, 4000, true, null);
                //Nanny nan5 = new Nanny(127, "sara5", "levi", "1/1/1993", 123456, "רבי עקיבא 11,ביתר עילית,ישראל", true, 5, 2, 6, 5, 8, false, 25, 4000, true, null);
                //bl.addNanny(nan1);
                //bl.addNanny(nan2);
                //bl.addNanny(nan3);
                //bl.addNanny(nan4);
                //bl.addNanny(nan5);

                Contract con1 = new Contract(123, 12347, false, false, contracPer.perHour);
                Contract con2 = new Contract(124, 123410, false, false, 0);
                Contract con3 = new Contract();
                Contract con4 = new Contract();
                Contract con5 = new Contract();
                Contract con6 = new Contract();
                Contract con7 = new Contract();
                Contract con8 = new Contract();
                Contract con9 = new Contract();
                bl.addContract(con1);
                bl.addContract(con2);
                foreach (var item in bl.getListContracts())
                {
                    Console.WriteLine(item);
                    Console.WriteLine();
                }
                bl.deleteMother(1236);
                foreach (var item in bl.getListContracts())
                {
                    Console.WriteLine(item);
                    Console.WriteLine();
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
