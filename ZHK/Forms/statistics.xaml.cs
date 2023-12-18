using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
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
    /// <summary>
    /// Логика взаимодействия для statistics.xaml
    /// </summary>
    public partial class statistics : Page
    {
        public statistics()
        {
            InitializeComponent();
            LogicMethods.GetUniqueValues("ResidentialComplex", "Name", comboboxRC);

        }

        private void comboboxRC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void BtnRes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Errors.CheckNotNegative(textboxStP, TextBoxStCom);
                if (textboxStP.Text.Length > 0 && TextBoxStCom.Text.Length > 0 && comboboxRC.Text.Length > 0)
                {

                    var a1 = from ap in ЖК_311Entities.GetContext().Apartaments.ToList()
                             where ap.House.ResidentialComplex.Name == comboboxRC.SelectedItem.ToString()
                             select new { ap.ID,ap.HouseID, adr = ap.House.Street + " д." + ap.House.Number + " кв." + ap.Number, Zena = ap.House.HouseValueAdded + ap.House.ResidentialComplex.ComplexValueAdded + ap.ApartmentValueAdded + ap.Area * Convert.ToInt32(textboxStP.Text) + ap.CountOfRooms * Convert.ToInt32(TextBoxStCom.Text) };
                    DGrid1.ItemsSource = a1.ToList();


                    var a2 = from h in ЖК_311Entities.GetContext().Houses.ToList()
                                    join a in a1 on h.ID equals a.HouseID into ap
                                    from a in ap.DefaultIfEmpty().ToList()
                                    where a != null && h.ResidentialComplex.Name == comboboxRC.SelectedItem.ToString()
                                    group new { h, a } by new { a.HouseID, h.ResidentialComplex.ID, h.Number} into g
                                    select new { g.Key.HouseID, IDRC = g.Key.ID, g.Key.Number, sum1 = g.Sum(p=>p.a.Zena) };
                    DGrid2.ItemsSource = a2.ToList();

                    var a3 = from c in ЖК_311Entities.GetContext().ResidentialComplexes.ToList()
                             join a in a2 on c.ID equals a.IDRC into ap
                             from a in ap.DefaultIfEmpty().ToList()
                             where a != null && c.Name == comboboxRC.SelectedItem.ToString()
                             group new { c, a } by new { c.ID, c.Name } into g
                             select new { g.Key.ID, g.Key.Name, sum2 = g.Sum(p => p.a.sum1) };
                    DGrid3.ItemsSource = a3.ToList();

                }
            }
            catch
            { }
        }
    }
}
