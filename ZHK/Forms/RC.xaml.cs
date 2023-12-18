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

    public partial class RC : Page
    {
        DataGrid dGridRC;
        public RC(DataGrid dGridRc)
        {
            dGridRC = dGridRc;
            InitializeComponent();

            LogicMethods.GetUniqueValues("ResidentialComplex", "Status", ComboBoxStatus);
            if (dGridRC.SelectedItem != null)
            {
                var tempHouses = LogicMethods.GetHousesByComplexId(((ResidentialComplex)dGridRC.SelectedItem).ID);
                DGridH.ItemsSource = tempHouses.ToList();
                TxtBoxName.Text = ((ResidentialComplex)dGridRC.SelectedItem).Name;
                TxtBoxCity.Text = ((ResidentialComplex)dGridRC.SelectedItem).City;
                TxtBoxKDC.Text = ((ResidentialComplex)dGridRC.SelectedItem).ComplexValueAdded.ToString();
                TxtBoxMoney.Text = ((ResidentialComplex)dGridRC.SelectedItem).BuildingCost.ToString();
                ComboBoxStatus.SelectedItem = ((ResidentialComplex)dGridRC.SelectedItem).Status.ToString();
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
                        using (SqlCommand cmd = new SqlCommand($"DELETE FROM ResidentialComplex WHERE ID = @value1", conn))
                        {
                            cmd.Parameters.AddWithValue("@value1", ((ResidentialComplex)dGridRC.SelectedItem).ID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    Switcher.MainFrame.Navigate(new ListRC());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Нет такого ЖК {ex}");
            }


        }

        private async void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ComboBoxStatus.SelectedItem.ToString()== "1:план")
                { Errors.CheckIsSatus1((int)((ResidentialComplex)dGridRC.SelectedItem).ID); }
                Errors.CheckIsEmpty(TxtBoxName, TxtBoxMoney, TxtBoxKDC, TxtBoxCity, ComboBoxStatus);
                Errors.CheckNotNegative(TxtBoxMoney, TxtBoxKDC);

                using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=ЖК_311;Integrated Security=SSPI;"))
                {
                    conn.Open();
                    if (LogicMethods.CanChangeStatusToPlan((int)((ResidentialComplex)dGridRC.SelectedItem).ID))
                    {

                        using (SqlCommand cmd = new SqlCommand($"UPDATE ResidentialComplex SET Name = @value1, City = @value2, ComplexValueAdded = @value3, BuildingCost = @value4, Status = @value5 WHERE ID = @value6", conn))
                        {
                            cmd.Parameters.AddWithValue("@value1", TxtBoxName.Text);
                            cmd.Parameters.AddWithValue("@value2", TxtBoxCity.Text);
                            cmd.Parameters.AddWithValue("@value3", TxtBoxKDC.Text);
                            cmd.Parameters.AddWithValue("@value4", TxtBoxMoney.Text);
                            cmd.Parameters.AddWithValue("@value5", ComboBoxStatus.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@value6", ((ResidentialComplex)dGridRC.SelectedItem).ID);
                            await cmd.ExecuteNonQueryAsync();
                            Switcher.MainFrame.Navigate(new ListRC());
                        }
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
                Errors.CheckIsEmpty(TxtBoxName, TxtBoxMoney, TxtBoxKDC, TxtBoxCity, ComboBoxStatus);
                Errors.CheckNotNegative(TxtBoxMoney, TxtBoxKDC);

                using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=ЖК_311;Integrated Security=SSPI;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand($"INSERT INTO ResidentialComplex (Name, City, ComplexValueAdded, BuildingCost, Status) VALUES (@value1, @value2, @value3, @value4, @value5)", conn))
                    {
                        cmd.Parameters.AddWithValue("@value1", TxtBoxName.Text);
                        cmd.Parameters.AddWithValue("@value2", TxtBoxCity.Text);
                        cmd.Parameters.AddWithValue("@value3", TxtBoxKDC.Text);
                        cmd.Parameters.AddWithValue("@value4", TxtBoxMoney.Text);
                        cmd.Parameters.AddWithValue("@value5", ComboBoxStatus.SelectedItem.ToString());
                        cmd.ExecuteNonQuery();
                    }
                }
                Switcher.MainFrame.Navigate(new ListRC());
            }
            catch
            {
            }
        }
    }
}
