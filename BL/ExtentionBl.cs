using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsApi;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
using BE;

namespace BL
{

    public static class ExtentionBl
    {
        static DAL.IDAL dal = DAL.FactoryDal.getDal();

        /// <summary>
        /// Group all contracts by distance
        /// </summary>
        /// <param name="bl"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static IEnumerable<IGrouping<int, Contract>> groupingContract(this IBL bl, bool b = false)
        {
            
            IEnumerable<Contract> con = dal.getListContracts();
            var contract = from item in con
                           let distance = bl.CalculateDistance(dal.getNanny(item.NannyID).addres,
                           dal.getMother(item.MotherID).SearchAddres)
                           group item by ((distance / 1000) / 2) * 2;
            //Sorted by distance
            if (b == true)
            {
                var sortGroup = from item in contract
                                orderby item.Key
                                select item;
                return sortGroup;
            }
            return contract;
        }



        /// <summary>
        /// A function that returns a distance between 2 targets
        /// </summary>
        /// <param name="bl"></param>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        public static int CalculateDistance(this IBL bl, string source, string dest)
        {
            var drivingDirectionRequest = new DirectionsRequest
            {
                TravelMode = TravelMode.Walking,
                Origin = source,
                Destination = dest,
            };
            DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
            Route route = drivingDirections.Routes.First();
            Leg leg = route.Legs.First();
            return leg.Distance.Value;
        }



        /// <summary>
        /// Returns all caregivers according to requirements
        /// </summary>
        /// <param name="bl"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IEnumerable<Nanny> RangeNanny(this IBL bl, int? id)
        {
            Mother temp = dal.getMother(id);
            IEnumerable<Nanny> nanny = dal.getListNannys();
            if (temp.SearchAddres != null)
            {
                var distance1 = from item in nanny
                                let distanceNanny = bl.helpfuncrange(item.addres, temp.SearchAddres, item)
                                orderby distanceNanny
                                where distanceNanny <= temp.RangeOfKm
                                select item;
                return distance1;
            }
            var distance2 = from item in nanny
                            let distanceNanny = bl.helpfuncrange(item.addres, temp.Addres, item)
                            orderby distanceNanny
                            where distanceNanny <= temp.RangeOfKm
                            select item;

            return distance2;


        }
        public static int helpfuncrange(this IBL bl, string sur, string dst, Nanny nanny)
        {
            nanny.distance = (bl.CalculateDistance(sur, dst)) / 1000;
            return (int)nanny.distance;
        }


        /// <summary>
        /// Returns the total wage paid by the mother
        /// </summary>
        /// <param name="bl"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static double? totalPay(this IBL bl, int motherID)
        {
            double? temp = 0;
            foreach (var item in dal.getListContracts())
            {
                if (item.MotherID == motherID)
                {
                    temp += item.salaryPerMonth;
                }
            }
            return temp;
        }

        /// <summary>
        /// All nannies have an elevator in the building
        /// </summary>
        /// <param name="floor"></param>
        /// <returns></returns>
        public static IEnumerable<Nanny> accessibility(this IBL bl, int floor)
        {
            return dal.getListNannys().Where
                (
                item => item.floor <= floor || item.elevators == true
                ).ToList();
        }


        /// <summary>
        /// Create a group of nannies by key
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static IEnumerable<IGrouping<int, Nanny>> groupingNanny(this IBL bl, bool sort, bool minOrMax = false)
        {
            IEnumerable<Nanny> nanny = dal.getListNannys();
            //Func<Nanny, bool, int> func = ;
            var nannys = from item in nanny
                         let a = myFunc(item, minOrMax)
                         group item by a;
            if (sort)
            {
                nannys = from item in nanny
                         orderby item.FirstName
                         group item by myFunc(item, minOrMax);
                return nannys;
            }

            return nannys;

        }
        static int myFunc(Nanny nan, bool minOrMax)
        {
            if (minOrMax)
                return nan.age_child_min / 6;
            return nan.age_child_max / 6;

        }

        /// <summary>
        /// Returns all the nannies according to the mother's constraints
        /// according to work hours
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static IEnumerable<Nanny> RequiredMother(this IBL bl, Mother a)
        {
            //IEnumerable<Child> child = dal.getListChilds(a);
            IEnumerable<Nanny> nannys = dal.getListNannys();
            List<Nanny> temp1 = new List<Nanny>();
            Func<Nanny, Mother, bool> func1 = myFunc1;
            Func<Nanny, Mother, bool> func2 = myFunc2;
            var nan = from i in nannys
                      where myFunc1(i, a)
                      select i;
            if (nan.Count() != 0)
            {
                return nan;
            }
            nan = from i in nannys
                  where myFunc2(i, a)
                  select i;
            for (int i = 0; i < 5 && nan.ToArray()[i] != null; i++)
            {
                temp1[i] = nan.ToArray()[i];

            }
            return temp1;
        }



        static bool myFunc2(Nanny nan, Mother mom)
        {
            for (int i = 0; i < nan.work.Length; i++)
            {
                if ((!nan.work[i].day_work && mom.arr[i].day_work) || nan.work[i].start.Minutes - mom.arr[i].start.Minutes > 30 ||
                    mom.arr[i].end.Minutes - nan.work[i].end.Minutes > 30)
                    return false;
            }
            return true;
        }
        static bool myFunc1(Nanny nan, Mother mom)
        {
            for (int i = 0; i < nan.work.Length; i++)
            {
                if ((!nan.work[i].day_work && mom.arr[i].day_work) ||
                    (int)mom.arr[i].start.TotalMinutes < (int)nan.work[i].start.TotalMinutes ||
                    (int)nan.work[i].end.TotalMinutes < (int)mom.arr[i].end.TotalMinutes)
                    return false;
            }
            return true;
        }


        /// <summary>
        /// All contracts to be completed
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public static IEnumerable<Contract> finishContract(this IBL bl, int month)
        {
            return dal.getListContracts().Where
                (
                item => item.end.AddMonths(-month) == DateTime.Now
                );



        }
        static Func<Contract, bool> func = (item => item.contractSigne == true);


        public static IEnumerable<Contract> allContractCondtion(this IBL bl)
        {
            return dal.getListContracts().Where(func);
        }

        public static int sumContrctCondtion(this IBL bl)
        {
            return dal.getListContracts().Count(func);
        }

        /// <summary>
        /// Returns all caregivers who are vacationing by 'TAMT'
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Nanny> vacationKind(this IBL bl)
        {
            return dal.getListNannys().Where
                (
                item => item.vacation_kind == true
                );
        }


        /// <summary>
        /// Returns all the children without a nanny
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Child> withoutNanny(this IBL bl)
        {
            List<Child> temp = new List<Child>();
            IEnumerable<Child> childs = dal.getListChild2();
            var child = from item in childs
                        where helpFunc1(item.id)
                        select item;
            return temp.ToList();

        }
        /// <summary>
        /// Auxiliary function for the previous function
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool helpFunc1(int? id)
        {

            foreach (var item in dal.getListContracts())
            {
                if (item.childID == id)
                    return false;
            }
            return true;

        }


    }
}
