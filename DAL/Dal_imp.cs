using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS;
using BE;
namespace DAL
{
    public class Dal_imp : IDAL
    {
        DataSource ds;
        public Dal_imp()

        {
            ds = new DataSource();
        }

        static int num = 00000000;
        /// <summary>
        /// fun to insert child to list
        /// </summary>
        /// <param name="a"></param>
        public void addChild(Child a)
        {
            Child temp = getChild(a.id);
            if (temp != null)
                throw new Exception("Child with the same id already exists");
            DataSource.childs.Add(a);
        }
        /// <summary>
        /// func to insert contracts to list
        /// </summary>
        /// <param name="a"></param>
        public void addContract(Contract a)
        {
            a.num_contract = ++num;
            Child temp1 = getChild(a.childID);
            Mother temp2 = getMother(temp1.MotherID);
            Nanny temp3 = getNanny(a.NannyID);
            if (temp2 != null && temp3 != null)
                DataSource.contracts.Add(a);
        }
        /// <summary>
        /// func to insert mothers to list
        /// </summary>
        /// <param name="a"></param>
        public void addMother(Mother a)
        {
            Mother temp = getMother(a.id);
            if (temp != null)
                throw new Exception("Mother with the same id already exists");
            DataSource.mothers.Add(a);
        }
        /// <summary>
        /// func to insert nannys to list
        /// </summary>
        /// <param name="a"></param>
        public void addNanny(Nanny a)
        {
            Nanny temp = getNanny(a.id);
            if (temp != null)
                throw new Exception("Nanny with the same id already exists");
            DataSource.nannys.Add(a);
        }
        /// <summary>
        /// func to remove child from in list
        /// </summary>
        /// <param name="id"></param>
        public void deleteChild(int? id)
        {
            Child temp = getChild(id);
            if (temp == null)
                throw new Exception("Child not found");
            DataSource.childs.Remove(temp);
        }
        /// <summary>
        /// func to remove contract from in list
        /// </summary>
        /// <param name="numContract"></param>
        public void deleteContract(int numContract)
        {
            Contract temp = getContract(numContract);
            if (temp == null)
                throw new Exception("Contract not found");
            DataSource.contracts.Remove(temp);
        }
        /// <summary>
        /// func to remove mothers from in list
        /// </summary>
        /// <param name="id"></param>
        public void deleteMother(int? id)
        {
            Mother temp = getMother(id);
            if (temp == null)
                throw new Exception("Mother not found");
            DataSource.mothers.Remove(temp);

        }
        /// <summary>
        /// func to remove nannys from in list
        /// </summary>
        /// <param name="id"></param>
        public void deleteNanny(int? id)
        {
            Nanny temp = getNanny(id);
            if (temp == null)
                throw new Exception("Nanny not found");
            DataSource.nannys.Remove(DataSource.nannys.Find(item => item.id == id));
        }
        /// <summary>
        /// returns mothers list by IEnumerable 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Mother> getListMothers()
        {
            //if (DataSource.mothers.Any())
            //    throw new Exception("No mothers exist in the database");
            return DataSource.mothers;
        }
        /// <summary>
        /// returns childs list by his mothers
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public IEnumerable<Child> getListChilds(Mother a)
        {
            List<Child> temp = new List<Child>();
            temp.AddRange(DataSource.childs.FindAll(item => item.MotherID == a.id));
            //if (temp == null)
            //    throw new Exception("");


            //if (temp.Count == 0)
            //    return null;


            return temp;
        }
        /// <summary>
        /// returns contracs list by IEnumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Contract> getListContracts()
        {
           


            return DataSource.contracts;

        }
        /// <summary>
        /// returns childs list by IEnumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Child> getListChild2()
        {
            if (!DataSource.childs.Any())
                throw new Exception("No child exist");
            return DataSource.childs;
        }

        /// <summary>
        /// returns nannys list by IEnumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Nanny> getListNannys()
        {
            //if (!DataSource.nannys.Any())
            //    throw new Exception("No nannys exist in the database");
            return DataSource.nannys;

        }
        /// <summary>
        /// func that update the childs list
        /// </summary>
        /// <param name="a"></param>
        public void updateChild(Child a)
        {
            Child temp = getChild(a.id);
            if (temp == null)
                throw new Exception(" ");
            int index = DataSource.childs.FindIndex(item => item.id == a.id);
            DataSource.childs[index] = a;
        }
        /// <summary>
        /// func that update the contract list
        /// </summary>
        /// <param name="a"></param>
        public void updateContract(Contract a)
        {
            Contract temp = getContract(a.num_contract);
            if (temp == null)
                throw new Exception("");
            int index = DataSource.contracts.FindIndex(item => item.num_contract == a.num_contract);
            // a.num_contract = temp.num_contract;
            DataSource.contracts[index] = a;
        }
        /// <summary>
        /// func that update the mothers list
        /// </summary>
        /// <param name="a"></param>
        public void updateMother(Mother a)
        {
            Mother temp = getMother(a.id);
            if (temp == null)
                throw new Exception(" ");
            int index = DataSource.mothers.FindIndex(item => item.id == a.id);
            DataSource.mothers[index] = a;
        }
        /// <summary>
        /// func that update the nannys list
        /// </summary>
        /// <param name="a"></param>
        public void updateNanny(Nanny a)
        {
            Nanny temp = getNanny(a.id);
            if (temp == null)
                throw new Exception(" ");
            int index = DataSource.nannys.FindIndex(item => item.id == a.id);
            DataSource.nannys[index] = a;
        }


        /// <summary>
        /// return nanny by id of nanny
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Nanny getNanny(int? id)
        {
            return DataSource.nannys.Find(item => item.id == id);
        }

        /// <summary>
        /// return child by id of child
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Child getChild(int? id)
        {
            return DataSource.childs.Find(item => item.id == id);
        }


        /// <summary>
        /// return mother by id of mother
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Mother getMother(int? id)
        {
            return DataSource.mothers.Find(item => item.id == id);
        }

        /// <summary>
        /// return contract by num of contract
        /// </summary>
        /// <param name="num_contract"></param>
        /// <returns></returns>
        public Contract getContract(int num_contract)
        {
            return DataSource.contracts.Find(item => item.num_contract == num_contract);
        }

    }
}