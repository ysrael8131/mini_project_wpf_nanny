using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using BE;
using DS;

namespace DAL
{
    class DalXml : IDAL
    {

        DataSource ds = new DataSource();

        //protected static DalXml dal;
        //public static DalXml Dal
        //{
        //    get
        //    {
        //        if (dal == null)
        //            dal = new DalXml();
        //        return dal;
        //    }
        //}


        static int num = 10000000;
        XElement MotherRoot;
        string motherPath = @"motherXml.xml";

        XElement ChildRoot;
        string childPath = @"childXml.xml";

        XElement ContractRoot;
        string contractPath = @"contractxml.xml";

        XElement NannyRoot;
        string nannyPath = @"nannyXml.xml";


       

        public DalXml()
        {

            if (!File.Exists(motherPath))
                CreateFiles();
            else
                LoadData();
        }





        private void CreateFiles()
        {
            
            MotherRoot = new XElement("Mothers");
            MotherRoot.Save(motherPath);

            ChildRoot = new XElement("Childs");
            ChildRoot.Save(childPath);

            ContractRoot= new XElement("Contracts");
            
            ContractRoot.Save(contractPath);

            NannyRoot = new XElement("Nannies");
            NannyRoot.Save(nannyPath);
        }


        private void LoadData()
        {

            try
            {
                ChildRoot = XElement.Load(childPath);
                DataSource.mothers = LoadListFromXML<List<Mother>>(motherPath);
                DataSource.nannys = LoadListFromXML<List<Nanny>>(nannyPath);
                DataSource.contracts = LoadListFromXML<List<Contract>>(contractPath);
                num = DataSource.contracts.LastOrDefault().num_contract + 1;

            }
            catch (Exception e)
            {
                throw new Exception("File upload problem");
            }

        }

        public static void SaveToXML<T>(T source, string path)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
            xmlSerializer.Serialize(file, source); file.Close();
        }

        public  T LoadListFromXML<T>(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open);

            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                T data = (T)xmlSerializer.Deserialize(file);
                file.Close();
                return data;
            }
            catch (Exception e)
            {
                file.Close();
             throw new Exception("error in the file");
            }
           
          
        }


        #region child func

        XElement ConvertChild(BE.Child child)
        {
            XElement childElement = new XElement("Child");
            foreach (PropertyInfo item in typeof(BE.Child).GetProperties())
            {
                if (item.GetValue(child, null) != null)
                {
                    childElement.Add(new XElement(item.Name, item.GetValue(child, null).ToString()));
                }
                else
                {
                    childElement.Add(new XElement(item.Name, ""));
                }
            }
            return childElement;

        }

        BE.Child ConvertChild(XElement element)
        {
            Child child = new Child();
            foreach (PropertyInfo item in typeof(BE.Child).GetProperties())
            {
                TypeConverter typeConverter = TypeDescriptor.GetConverter(item.PropertyType);
                object convertValue = null;
                if (item != null)
                    convertValue = typeConverter.ConvertFromString(element.Element(item.Name).Value);
                if (item.CanWrite)
                    item.SetValue(child, convertValue);
            }
            return child;
        }


        public void addChild(Child a)
        {
            Child temp = getChild(a.id);
            if (temp != null)
                throw new Exception("Child with the same id already exists");
            ChildRoot.Add(ConvertChild(a));
            ChildRoot.Save(childPath);

        }
        public Child getChild(int? id)
        {
            XElement childTemp = null;
            try
            {
                childTemp = (from item in ChildRoot.Elements()
                             where int.Parse(item.Element("id").Value) == id
                             select item).FirstOrDefault();
            }
            catch (Exception)
            {

                return null;
            }
            if (childTemp == null)
                return null;
            return ConvertChild(childTemp);
        }

        /// <summary>
        /// func to remove child from in list
        /// </summary>
        /// <param name="id"></param>
        public void deleteChild(int? id)
        {
            //Child temp = getChild(id);
            //if (temp == null)
            //    throw new Exception("Child not found");

            //ConvertChild(temp).Remove();
            //ChildRoot.Save(childPath);



            XElement toRemove = (from item in ChildRoot.Elements()
                where int.Parse(item.Element("id").Value) == id
                select item).FirstOrDefault();

            if (toRemove == null)
                throw new Exception("Student with the same id not found...");

            toRemove.Remove();

            ChildRoot.Save(childPath);
            //return true;v
        }
        public void updateChild(Child a)
        {
            Child temp = getChild(a.id);
            if (temp == null)
                throw new Exception("Child not found");
            deleteChild(a.id);
            addChild(a);

        }

        /// <summary>
        /// returns childs list by his mothers
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public IEnumerable<Child> getListChilds(Mother a)
        {
            List<Child> children = (from item in ChildRoot.Elements()
                                    let temp = ConvertChild(item)
                                    where temp.MotherID == a.id
                                    select temp).ToList();
            if (children.Count == 0)
                throw new Exception("This mother doesn't have children");

            return children;

            }

            public IEnumerable<Child> getListChild2()
        {
            List<Child> children = (from item in ChildRoot.Elements()
                                    select ConvertChild(item)).ToList();

            if (children.Count == 0)
                throw new Exception("No child exist");
            return children;

        }

        #endregion


        #region mother func


        /// <summary>
        /// func to insert mothers to list
        /// </summary>
        /// <param name="a"></param>
        public void addMother(Mother a)
        {

            Mother temp = getMother(a.id);
            if (temp != null)
                throw new Exception("Mother with the same id already exists");
            DS.DataSource.mothers.Add(a);
            SaveToXML<List<Mother>>(DS.DataSource.mothers, motherPath);
        }

        public void deleteMother(int? id)
        {
            Mother temp = getMother(id);
            if (temp == null)
                throw new Exception("Mother not found");
            DS.DataSource.mothers.Remove(temp);
            SaveToXML<List<Mother>>(DS.DataSource.mothers, motherPath);
        }

        public void updateMother(Mother a)
        {
            Mother temp = getMother(a.id);
            if (temp == null)
                throw new Exception("Mother not found");
            int index = DataSource.mothers.FindIndex(item => item.id == a.id);
            DataSource.mothers[index] = a;
            SaveToXML<List<Mother>>(DS.DataSource.mothers, motherPath);
        }

        public IEnumerable<Mother> getListMothers()
        {

            return DS.DataSource.mothers;
        }

        public Mother getMother(int? id)
        {
            return DS.DataSource.mothers.Find(item => item.id == id);
        }

        #endregion

        #region nanny func


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
            SaveToXML<List<Nanny>>(DataSource.nannys, nannyPath);

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
            SaveToXML<List<Nanny>>(DataSource.nannys, nannyPath);
        }


        /// <summary>
        /// func that update the nannys list
        /// </summary>
        /// <param name="a"></param>
        public void updateNanny(Nanny a)
        {
            Nanny temp = getNanny(a.id);
            if (temp == null)
                throw new Exception("Nanny not found");
            int index = DataSource.nannys.FindIndex(item => item.id == a.id);
            DataSource.nannys[index] = a;
            SaveToXML<List<Nanny>>(DataSource.nannys, nannyPath);
        }

        /// <summary>
        /// returns nannys list by IEnumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Nanny> getListNannys()
        {
            
            return DS.DataSource.nannys;

        }

        /// <summary>
        /// return nanny by id of nanny
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Nanny getNanny(int? id)
        {
            return DS.DataSource.nannys.Find(item => item.id == id);
        }



        #endregion

        #region contract func

        public void addContract(Contract a)
        {
            try
            {
                var con = (from item in getListContracts()
                    where item.childID == a.childID
                    select item).FirstOrDefault();
                if (con!=null)
                {
                    throw new Exception("Contract with this child already");
                }
                a.num_contract = ++num;
                Child temp1 = getChild(a.childID);
                Mother temp2 = getMother(temp1.MotherID);
                Nanny temp3 = getNanny(a.NannyID);
                if (temp2 != null && temp3 != null)
                    DataSource.contracts.Add(a);
                
                SaveToXML<List<Contract>>(DataSource.contracts, contractPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

       
        public void deleteContract(int numContract)
        {
            Contract temp = getContract(numContract);
            if (temp == null)
                throw new Exception("Contract not found");
            DataSource.contracts.Remove(temp);
            SaveToXML<List<Contract>>(DataSource.contracts, contractPath);

        }

        
        public void updateContract(Contract a)
        {
            Contract temp = getContract(a.num_contract);
            if (temp == null)
                throw new Exception("");
            int index = DataSource.contracts.FindIndex(item => item.num_contract == a.num_contract);
            DataSource.contracts[index] = a;
            SaveToXML<List<Contract>>(DataSource.contracts, contractPath);
        }

        
        public IEnumerable<Contract> getListContracts()
        {

            return DS.DataSource.contracts;

        }

       
        public Contract getContract(int num_contract)
        {
            return DS.DataSource.contracts.Find(item => item.num_contract == num_contract);
        }

        #endregion
    }

}

