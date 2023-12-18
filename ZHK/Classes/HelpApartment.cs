﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ZHK.Classes
{
    public class HelpApartment
    {
        public HelpApartment(int iD, int houseID, string rcName, int number, decimal area, int countOfRooms, int section, int floor, string isSold, int? buildingCost, int? apartmentValueAdded, byte? isDeleted, int rCID, string adr)
        {
            ID = iD;
            HouseID = houseID;
            RCName = rcName;
            Number = number;
            Area = area;
            CountOfRooms = countOfRooms;
            Section = section;
            Floor = floor;
            IsSold = isSold;
            BuildingCost = buildingCost;
            ApartmentValueAdded = apartmentValueAdded;
            IsDeleted = isDeleted;
            RCID = rCID;
            Adr = adr;
        }

        public int ID { get; set; }
        public int HouseID { get; set; }
        public string RCName { get; set; }
        public int Number { get; set; }
        public decimal Area { get; set; }
        public int CountOfRooms { get; set; }
        public int Section { get; set; }
        public int Floor { get; set; }
        public string IsSold { get; set; }
        public int? BuildingCost { get; set; }
        public int? ApartmentValueAdded { get; set; }
        public byte? IsDeleted { get; set; }
        public int RCID { get; set; }
        public string Adr { get; set; }



    }
}
