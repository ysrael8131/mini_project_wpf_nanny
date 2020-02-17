using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDAL
    {
        void addNanny(Nanny a);
        void deleteNanny(int? id);
        void updateNanny(Nanny a);

        void addMother(Mother a);
        void deleteMother(int? id);
        void updateMother(Mother a);

        void addChild(Child a);
        void deleteChild(int? id);
        void updateChild(Child a);

        void addContract(Contract a);
        void deleteContract(int numContract);
        void updateContract(Contract a);

        IEnumerable<Mother> getListMothers();
        IEnumerable<Nanny> getListNannys();
        IEnumerable<Contract> getListContracts();
        IEnumerable<Child> getListChilds(Mother a);
        IEnumerable<Child> getListChild2();

        Child getChild(int? id);
        Mother getMother(int? id);
        Contract getContract(int num_contract);
        Nanny getNanny(int? id);
    }
}
