﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZHK.Classes;

namespace ZHK.Forms
{
    /// <summary>
    /// Логика взаимодействия для Apartment.xaml
    /// </summary>
    public partial class FormApartment : Page
    {
        DataGrid dGridAP;
        public FormApartment(DataGrid dGridAp)
        {
            dGridAP = dGridAp;

            InitializeComponent();
            LogicMethods.GetUniqueValues("ResidentialComplex", "Name", ComboboxRC);
            LogicMethods.GetUniqueValues("Apartaments", "IsSold", ComboboxStatus);
            if (dGridAP.SelectedItem != null)
            {
                var db = new ЖК_311Entities();
                var apartm = db.Apartaments.First(e => e.ID == ((HelpApartment)dGridAP.SelectedItem).ID);
                ComboboxRC.Text = apartm.House.ResidentialComplex.Name.ToString();
                ComboboxHouse.Text = apartm.House.ID.ToString();
                TxtBoxNumber.Text = apartm.Number.ToString();
                TxtBoxArea.Text = apartm.Area.ToString();
                TxtBoxRooms.Text = apartm.CountOfRooms.ToString();
                TxtBoxSection.Text = apartm.Section.ToString();
                TxtBoxFloor.Text = apartm.Floor.ToString();
                ComboboxStatus.Text = apartm.IsSold.ToString();
                TxtBoxMoney.Text = apartm.BuildingCost.ToString();
                TxtBoxKDC.Text = apartm.ApartmentValueAdded.ToString();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить?", "Удалить", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {               
                    using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=ЖК_311;Integrated Security=SSPI;"))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand($"DELETE FROM Apartaments WHERE ID = @value1 ", conn))
                        {
                            cmd.Parameters.AddWithValue("@value1", ((HelpApartment)dGridAP.SelectedItem).ID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    Switcher.MainFrame.Navigate(new ListApartments());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Нет такой квартиры {ex}");
            }
        }

        private async void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Errors.CheckIsEmpty(TxtBoxNumber, ComboboxHouse, TxtBoxFloor, TxtBoxKDC, TxtBoxSection, TxtBoxRooms, ComboboxStatus, TxtBoxMoney);
                Errors.CheckNotNegative(TxtBoxMoney, TxtBoxKDC);
                Errors.IsNatural(TxtBoxFloor, TxtBoxSection, TxtBoxNumber, TxtBoxRooms);
                Errors.CheckIsNumberDouble(TxtBoxArea);
                if (ComboboxStatus.SelectedItem.ToString() == "True")
                { Errors.CheckIsSatus2((int)((HelpApartment)dGridAP.SelectedItem).ID); }
                using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=ЖК_311;Integrated Security=SSPI;"))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand($"UPDATE Apartaments SET HouseID = @value1, Number = @value2, Area = @value3, CountOfRooms = @value4, Section = @value5, Floor = @value6, IsSold = @value7, BuildingCost = @value8, ApartmentValueAdded = @value9 WHERE ID = @value10", conn))
                    {
                        cmd.Parameters.AddWithValue("@value1", ComboboxHouse.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@value2", TxtBoxNumber.Text);
                        cmd.Parameters.AddWithValue("@value3", TxtBoxArea.Text.Replace(',', '.'));
                        cmd.Parameters.AddWithValue("@value4", TxtBoxRooms.Text);
                        cmd.Parameters.AddWithValue("@value5", TxtBoxSection.Text);
                        cmd.Parameters.AddWithValue("@value6", TxtBoxFloor.Text);
                        cmd.Parameters.AddWithValue("@value7", ComboboxStatus.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@value8", TxtBoxMoney.Text);
                        cmd.Parameters.AddWithValue("@value9", TxtBoxKDC.Text);
                        cmd.Parameters.AddWithValue("@value10", ((HelpApartment)dGridAP.SelectedItem).ID);
                        await cmd.ExecuteNonQueryAsync();
                        Switcher.MainFrame.Navigate(new ListApartments());
                    }
                }
            }
            catch
            {
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Errors.CheckIsEmpty(TxtBoxNumber, ComboboxHouse, TxtBoxFloor, TxtBoxKDC, TxtBoxSection, TxtBoxRooms, ComboboxStatus, TxtBoxMoney);
                Errors.CheckNotNegative(TxtBoxMoney, TxtBoxKDC);
                Errors.IsNatural(TxtBoxFloor, TxtBoxSection, TxtBoxNumber, TxtBoxRooms);
                Errors.CheckIsNumberDouble(TxtBoxArea);
                using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=ЖК_311;Integrated Security=SSPI;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand($"INSERT INTO Apartaments (HouseID, Number, Area, CountOfRooms, Section, Floor, IsSold, BuildingCost, ApartmentValueAdded) VALUES (@value1, @value2, @value3, @value4, @value5, @value6, @value7, @value8, @value9)", conn))
                    {
                        cmd.Parameters.AddWithValue("@value1", ComboboxHouse.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@value2", TxtBoxNumber.Text);
                        cmd.Parameters.AddWithValue("@value3", TxtBoxArea.Text.Replace(',', '.'));
                        cmd.Parameters.AddWithValue("@value4", TxtBoxRooms.Text);
                        cmd.Parameters.AddWithValue("@value5", TxtBoxSection.Text);
                        cmd.Parameters.AddWithValue("@value6", TxtBoxFloor.Text);
                        cmd.Parameters.AddWithValue("@value7", ComboboxStatus.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@value8", TxtBoxMoney.Text);
                        cmd.Parameters.AddWithValue("@value9", TxtBoxKDC.Text);

                        cmd.ExecuteNonQuery();
                    }

                }
                Switcher.MainFrame.Navigate(new ListApartments());
            }
            catch
            {
            }
        }

        private void ComboboxRC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboboxHouse.Items.Clear();
            LogicMethods.GetUniqueValues2(ComboboxRC.SelectedItem.ToString(), ComboboxHouse);
        }
    }
}
