using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHK.Classes
{
    public class DGridHouse
    {
        public DGridHouse(int idHouse, int residentialComplexID, string rcName, string street, string number, string statusRC, int soldApart, int soldingApart)
        {
            IDHouse = idHouse;
            ResidentialComplexID = residentialComplexID;
            RCName = rcName;
            Street = street;
            Number = number;
            StatusRC = statusRC;
            SoldApart = soldApart;
            SoldingApart = soldingApart;
        }

        public int IDHouse { get; set; }    
        public int ResidentialComplexID { get; set; }
        public string RCName { get; set; }
        public string Street {  get; set; }
        public string Number { get; set; }
        public string StatusRC { get; set; }
        public int SoldApart { get; set; }
        public int SoldingApart { get; set; }
    }
}
