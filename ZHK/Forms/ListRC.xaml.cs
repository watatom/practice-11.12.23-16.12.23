﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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
    public partial class ListRC : Page
    {
        public ListRC()
        {
            InitializeComponent();
            var db = new ЖК_311Entities();
            var items =
                from ResidentialComplex in db.ResidentialComplexes
                orderby ResidentialComplex.City descending, ResidentialComplex.Status descending
                select ResidentialComplex;
            DGridRC.ItemsSource = items.ToList();
            LogicMethods.SortByCityStatus(DGridRC);
            LogicMethods.GetUniqueValues("ResidentialComplex", "Status", StatusFilter);
            LogicMethods.GetUniqueValues("ResidentialComplex", "City", CityFilter);
        }

        private void StatusFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LogicMethods.FilterStatus(DGridRC, StatusFilter);
        }

        private void CityFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LogicMethods.FilterCity(DGridRC, CityFilter);
        }

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {
            Switcher.MainFrame.Navigate(new RC(DGridRC));
        }
    }
}
