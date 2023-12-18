using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ZHK.Classes
{
    public static class Errors
    {
        public static void CheckIsSatus1(int c1)
        {
            var apartInfo = (from A in ЖК_311Entities.GetContext().Apartaments.ToList()
                             where A.House.ResidentialComplexID == c1 && A.IsSold == true
                             select A).ToList();
            if (apartInfo.Count > 0)
            {
                MessageBox.Show($"Имеются проданные квартиры", "ОШИБКА");
                throw new Exception();
            }

        }
        public static void CheckIsSatus2(int c1)
        {
            var КСInfo = (from A in ЖК_311Entities.GetContext().Apartaments.ToList()
                             where A.House.ResidentialComplex.Status == "1:план" && A.ID == c1
                          select A).ToList();
            if (КСInfo.Count > 0)
            {
                MessageBox.Show($"Статус ЖК - 1:план ", "ОШИБКА");
                throw new Exception();
            }

        }
        public static void CheckIsEmpty(params Control[] controls)
        {
            for (int i = 0; i < controls.Length; i++)
            {
                if (controls[i] is TextBox)
                {

                    if (string.IsNullOrEmpty(((TextBox)controls[i]).Text))
                    {
                        MessageBox.Show($"{controls[i].Name} не заполнен", "ОШИБКА");
                        throw new Exception();
                    }
                }
                if (controls[i] is ComboBox)
                {
                    if (((ComboBox)controls[i]).SelectedItem == null)
                    {
                        MessageBox.Show($"{controls[i].Name} не заполнен", "ОШИБКА");
                        throw new Exception();
                    }
                }
            }
        }

        public static bool CheckNotNegative(params Control[] controls)
        {
            for (int i = 0; i < controls.Length; i++)
            {
               if (CheckIsNumber(controls))
               {
                    if (Convert.ToInt32(((TextBox)controls[i]).Text) < 0)
                    {
                        MessageBox.Show($"{controls[i].Name} отрицательное число", "ОШИБКА");
                        throw new Exception();
                    }
               }
            }
            return true;
        }
        public static bool CheckIsNumberDouble(params Control[] controls)
        {
            for (int i = 0; i < controls.Length; i++)
            {
                if (controls[i] is TextBox)
                {
                    try
                    {
                        decimal temp = Convert.ToDecimal(((TextBox)controls[i]).Text);

                    }
                    catch
                    {
                        MessageBox.Show($"{controls[i].Name} не число", "ОШИБКА");
                        throw new Exception();
                    }
                    if (Convert.ToDouble(((TextBox)controls[i]).Text) < 0)
                    {
                        MessageBox.Show($"{controls[i].Name} отрицательное число", "ОШИБКА");
                        throw new Exception();
                    }
                }
            }
            return true;
        }


        public static bool CheckIsNumber(params Control[] controls)
        {
            for (int i = 0; i < controls.Length; i++)
            {
                if (controls[i] is TextBox)
                {
                    try
                    {
                        int temp = Convert.ToInt32(((TextBox)controls[i]).Text);
                    }
                    catch
                    {
                        MessageBox.Show($"{controls[i].Name} не число", "ОШИБКА");
                        throw new Exception();
                    }
                }
            }
            return true; 
        }

        public static bool IsNatural(params Control[] controls)
        {
            for (int i = 0; i < controls.Length; i++)
            {
                if (CheckNotNegative(controls))
                {
                    if (Convert.ToInt32(((TextBox)controls[i]).Text) % 1 != 0)
                    {
                        MessageBox.Show($"{controls[i].Name} не натуральное число", "ОШИБКА");
                        throw new Exception();
                    }
                    
                }
            }
            return true;
        }
    }
}
