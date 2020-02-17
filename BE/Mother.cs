using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Mother
    {
        
        public Mother()
        {
            
            for (int j = 0; j < 6; j++)
            {
                arr[j] = new Work_information();  
            }
        }
        public int? id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string PhoneNumber { set; get; }
        public string Addres { set; get; }
        public string SearchAddres { set; get; }
        public bool elevators { set; get; }
        public int RangeOfKm { set; get; }
        public Work_information[] arr { get; set; } = new Work_information[6];
        
        
        public override string ToString()
        {
            return ("mother id: " + id.ToString() + '\n' +
                "name: " + FirstName + "  " + LastName 
                );
        }
    }
}
