using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace ZHK.Classes
{
    public static class LogicMethods
    {
        public static string CurrentPage()
        {
            var currentPage = Switcher.MainFrame.Content;
            string sentence = currentPage.ToString();
            string[] newSentence = sentence.Split('.');
            string lWord = newSentence[newSentence.Length - 1];
            return lWord;
        }

        public static void SortByCityStatus(DataGrid dGridRC)
        {
            ICollectionView cv = CollectionViewSource.GetDefaultView(dGridRC.ItemsSource);
            if (cv != null && cv.CanSort == true)
            {
                cv.SortDescriptions.Clear();
                cv.SortDescriptions.Add(new SortDescription("City", ListSortDirection.Ascending));
                cv.SortDescriptions.Add(new SortDescription("Status", ListSortDirection.Ascending));
            }
        }

        public static void GetUniqueValues(string TableName, string ColumnName, ComboBox comboBoxUI)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=watatomPC1;Initial Catalog=ЖК_311;Integrated Security=SSPI;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand($"SELECT DISTINCT {ColumnName} FROM {TableName}", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBoxUI.Items.Add(reader[ColumnName].ToString());
                    }
                }
            }
        }
        public static void GetUniqueValues2(string where, ComboBox comboBoxUI)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=watatomPC1;Initial Catalog=ЖК_311;Integrated Security=SSPI;"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand($"SELECT DISTINCT House.ID FROM House INNER JOIN ResidentialComplex ON House.ResidentialComplexID = ResidentialComplex.ID where ResidentialComplex.Name = '{where}' ", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBoxUI.Items.Add(reader["ID"].ToString());
                    }
                }
            }
        }

        public static List<DGridHouse> GetHouseInfo()
        {
            var a1 = ЖК_311Entities.GetContext().Apartaments.ToList();
            var houseInfo = (from h in ЖК_311Entities.GetContext().Houses.ToList()
                             join c in ЖК_311Entities.GetContext().ResidentialComplexes on h.ResidentialComplexID equals c.ID
                             join a in ЖК_311Entities.GetContext().Apartaments on h.ID equals a.HouseID into ap
                             from a in ap.DefaultIfEmpty().ToList()
                             where a != null
                             group new { h, c, a } by new { a.HouseID, h.ID, c.Name, h.Street, h.Number, c.Status } into g
                             select new DGridHouse(g.Key.HouseID, g.Key.ID, g.Key.Name, g.Key.Street, g.Key.Number, g.Key.Status, g.Count(x => x.a.IsSold == true), g.Count(x => x.a.IsSold != true))).ToList();
            return houseInfo;
        }


        public static List<HelpApartment> GetApartmentInfo()
        {
            var a1 = ЖК_311Entities.GetContext().Apartaments.ToList();
            var apartInfo = (from h in ЖК_311Entities.GetContext().Houses.ToList()
                             join c in ЖК_311Entities.GetContext().ResidentialComplexes on h.ResidentialComplexID equals c.ID
                             join a in ЖК_311Entities.GetContext().Apartaments on h.ID equals a.HouseID into ap
                             from a in ap.DefaultIfEmpty().ToList()
                             where a != null
                             select new HelpApartment(a.ID, a.HouseID,c.Name, a.Number, Math.Round(a.Area, 1), a.CountOfRooms, a.Section, a.Floor, (bool)a.IsSold ? "продана" : "продается" , a.BuildingCost, a.ApartmentValueAdded, a.IsDeleted, c.ID,  h.Street + " д." + h.Number + " кв." + a.Number)).ToList();
            return apartInfo;
        }

        public static List<House> GetHousesByComplexId(int complexID)
        {
            var db = new ЖК_311Entities();
            var houses = db.Houses.Where(h => h.ResidentialComplexID == complexID);
            return houses.ToList();
        }

        public static bool CanChangeStatusToPlan(int complexID)
        {
            var apartments = ЖК_311Entities.GetContext().Apartaments.Where(a => a.ID == complexID);
            bool hasSoldApartments = apartments.Any(a => a.IsSold == true);
            if (hasSoldApartments)
            {
                return false;
            }
            return true;
        }

        public static void FilterStatus(DataGrid dGripRC, ComboBox filter)
        {
            dGripRC.ItemsSource = from rc in ЖК_311Entities.GetContext().ResidentialComplexes.ToList()
                                  where rc.Status == filter.SelectedItem.ToString()
                                  orderby rc.City , rc.Status 
                                  select rc;
        }
        public static void FilterCity(DataGrid dGripRC, ComboBox filter)
        {
            dGripRC.ItemsSource = from rc in ЖК_311Entities.GetContext().ResidentialComplexes.ToList()
                                  where rc.City == filter.SelectedItem.ToString()
                                  orderby rc.City , rc.Status 
                                  select rc;
        }
        public static void FilterAddress(DataGrid dGripRC, ComboBox filter)
        {
            var db = new ЖК_311Entities();
            var content = new List<DGridHouse>();
            foreach(var house in db.Houses.Where(e => e.Street == filter.SelectedItem.ToString()))
            {
                var appartaments = db.Apartaments.Where(a => a.HouseID == house.ID);
                content.Add(new DGridHouse(house.ID, house.ResidentialComplexID, house.ResidentialComplex.Name, house.Street, house.Number, house.ResidentialComplex.Status
                    , appartaments.Count(x => x.IsSold == true), appartaments.Count(x => x.IsSold != true)));
            }
            dGripRC.ItemsSource = content;
        }
        public static void FilterRC(DataGrid dGripRC, ComboBox filter)
        {
            var db = new ЖК_311Entities();
            var content = new List<DGridHouse>();
            foreach (var house in db.Houses.Where(e => e.ResidentialComplex.Name.ToString() == filter.SelectedItem.ToString()))
            {
                var appartaments = db.Apartaments.Where(a => a.HouseID == house.ID);
                content.Add(new DGridHouse(house.ID, house.ResidentialComplexID, house.ResidentialComplex.Name, house.Street, house.Number, house.ResidentialComplex.Status
                    , appartaments.Count(x => x.IsSold == true), appartaments.Count(x => x.IsSold != true)));
            }

            dGripRC.ItemsSource = content;
        }

        public static void FilterRCInApartments(DataGrid dGripRC, ComboBox filter)
        {
            var a1 = ЖК_311Entities.GetContext().Apartaments.ToList();
            var apartInfo = (from h in ЖК_311Entities.GetContext().Houses.ToList()
                             join c in ЖК_311Entities.GetContext().ResidentialComplexes on h.ResidentialComplexID equals c.ID
                             join a in ЖК_311Entities.GetContext().Apartaments on h.ID equals a.HouseID into ap
                             from a in ap.DefaultIfEmpty().ToList()
                             where a != null && a.House.ResidentialComplex.Name == filter.SelectedItem.ToString()
                             select new HelpApartment(a.ID, a.HouseID, c.Name, a.Number, Math.Round(a.Area, 1), a.CountOfRooms, a.Section, a.Floor, (bool)a.IsSold ? "продана" : "продается", a.BuildingCost, a.ApartmentValueAdded, a.IsDeleted, c.ID, h.Street + " д." + h.Number + " кв." + a.Number)).ToList();
            dGripRC.ItemsSource = apartInfo;
        }

        public static void FilterHouseInApartments(DataGrid dGripRC, ComboBox filter)
        {
            var a1 = ЖК_311Entities.GetContext().Apartaments.ToList();
            var apartInfo = (from h in ЖК_311Entities.GetContext().Houses.ToList()
                             join c in ЖК_311Entities.GetContext().ResidentialComplexes on h.ResidentialComplexID equals c.ID
                             join a in ЖК_311Entities.GetContext().Apartaments on h.ID equals a.HouseID into ap
                             from a in ap.DefaultIfEmpty().ToList()
                             where a != null && a.House.Number == filter.SelectedItem.ToString()
                             select new HelpApartment(a.ID, a.HouseID, c.Name, a.Number, Math.Round(a.Area, 1), a.CountOfRooms, a.Section, a.Floor, (bool)a.IsSold ? "продана" : "продается", a.BuildingCost, a.ApartmentValueAdded, a.IsDeleted, c.ID, h.Street + " д." + h.Number + " кв." + a.Number)).ToList();
            dGripRC.ItemsSource = apartInfo;
        }
    }
}
