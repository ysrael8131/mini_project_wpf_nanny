using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using GoogleMapsApi;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
namespace BL
{
    public class Bl_imp : IBL
    {
        DAL.IDAL dal = DAL.FactoryDal.getDal();
        public void addChild(Child a)
        {
            dal.addChild(a);
        }
        /// <summary>
        /// func to insert contract
        /// </summary>
        /// <param name="a"></param>
        public void addContract(Contract a)
        {
            Child temp1 = dal.getChild(a.childID);
            Nanny temp2 = dal.getNanny(a.NannyID);
            Mother temp3 = dal.getMother(temp1.MotherID); 
            
            //check the age child that more 3 months 
            if (DateTime.Compare(DateTime.Now.AddMonths(-3), temp1.birthDay) == -1)
            {
                throw new Exception("the age of the child is less than 3 month");
            }
            //Checks if children are in range
            if (DateTime.Now.AddMonths(-temp2.age_child_max) > temp1.birthDay
                && DateTime.Now.AddMonths(-temp2.age_child_min) < temp1.birthDay)
                throw new Exception("The child is not within the age range of the nanny");
            IEnumerable<Contract> con = dal.getListContracts();

            var contract = from item in con
                           where item.NannyID == a.NannyID
                           select item;
            //the number of contracts
            int sumcontract = contract.Count();
            //The number of children of the mother
            int sumChildsPerMother = contract.Count
                (

                    item => item.MotherID == temp1.MotherID
                );
            //Checks if there is an excess of children
            if (sumcontract + 1 > temp2.maxChilds)
            {
                throw new Exception("the nanny has the max of contracts");
            }

            a.salaryPerHour = temp2.salaryPerHour;
            a.salaryPerMonth = temp2.salaryPerMonth;
            //Calculation of salary
            switch (a.ContracPer)
            {
                case true:
                   // TimeSpan time = new TimeSpan();
                    double time = 0;
                    foreach (var item in temp3.arr)
                    {
                        if (item.day_work)
                        {
                            time += (item.end - item.start).Hours+ (item.end - item.start).Minutes/60;
                        }
                    }

                    a.totalSalary = (temp2.salaryPerHour * (time * 4) * (1 - (sumChildsPerMother * 0.02)));
                    break;
                case false:
                    a.totalSalary = (1 - (sumChildsPerMother * 0.02)) * temp2.salaryPerMonth;
                    break;
                    
            }
            a.MotherID = temp1.MotherID;
            dal.addContract(a);

        }
        /// <summary>
        /// func to insert mothers
        /// </summary>
        /// <param name="a"></param>
        public void addMother(Mother a)
        {
            if (a.SearchAddres == null)
                a.SearchAddres = a.Addres;
            dal.addMother(a);
        }
        /// <summary>
        /// func to insert nannys 
        /// </summary>
        /// <param name="a"></param>
        public void addNanny(Nanny a)
        {
            //Check if age nanny is less than 18
            if (DateTime.Compare(DateTime.Now.AddYears(-18), a.birthDay) == -1)
                throw new Exception("Can not register a nanny under age 18");
            dal.addNanny(a);
        }
        /// <summary>
        /// remove child by id child
        /// </summary>
        /// <param name="id"></param>
        public void deleteChild(int? id)
        {
            List<Contract> temp = (dal.getListContracts().Where(item => item.childID == id)).ToList();
            if (temp.Count != 0)
                dal.deleteContract(temp[0].num_contract);
            dal.deleteChild(id);


        }
        /// <summary>
        /// remove contrct by num of contract 
        /// </summary>
        /// <param name="numContract"></param>
        public void deleteContract(int numContract)
        {
            dal.deleteContract(numContract);
        }
        /// <summary>
        /// remove mother by id of mother
        /// </summary>
        /// <param name="id"></param>
        public void deleteMother(int? id)
        {
            Mother temp = dal.getMother(id);
            dal.deleteMother(id);
            var childsPerMother = dal.getListChilds(temp);
            foreach (var item in childsPerMother)
            {
                deleteChild(item.id);
            }

        }

        /// <summary>
        /// remove nanny by id nanny
        /// </summary>
        /// <param name="id"></param>
        public void deleteNanny(int? id)
        {
            List<Contract> temp = (dal.getListContracts().Where(item => item.NannyID == id)).ToList();
            for (int i = 0; i < temp.Count; i++)
            {
                dal.deleteContract(temp[i].num_contract);
            }

            dal.deleteNanny(id);
        }

        public Child getChild(int? id)
        {
            return dal.getChild(id);
        }

        public Mother getMother(int? id)
        {
            return dal.getMother(id);
        }
        public Contract getContract(int num_contract)
        {
            return dal.getContract(num_contract);
        }
        public Nanny getNanny(int? id)
        {
            return dal.getNanny(id);
        }

        public IEnumerable<Child> getListChilds(Mother a)
        {
            return dal.getListChilds(a);
        }

        public IEnumerable<Contract> getListContracts()
        {
            return dal.getListContracts();
        }

        public IEnumerable<Mother> getListMothers()
        {
            return dal.getListMothers();
        }

        public IEnumerable<Nanny> getListNannys()
        {
            return dal.getListNannys();
        }

        public IEnumerable<Child> getListChild2()
        {
            return dal.getListChild2();
        }


        public void updateChild(Child a)
        {
            dal.updateChild(a);
        }

        public void updateContract(Contract a)
        {
            dal.updateContract(a);
        }

        public void updateMother(Mother a)
        {
            Mother temp = dal.getMother(a.id);
            if (temp.Addres==a.SearchAddres)
            {
                a.SearchAddres = a.Addres;
            }
            dal.updateMother(a);
        }

        public void updateNanny(Nanny a)
        {
            dal.updateNanny(a);
        }
        
     
        

    }
}