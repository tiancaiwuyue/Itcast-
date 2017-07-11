using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buffet店
{
    class StaticMethods
    {
        public static void SetButton(Button button)
        {
            MethodInfo methodinfo = button.GetType().GetMethod("SetStyle", BindingFlags.NonPublic
            | BindingFlags.Instance | BindingFlags.InvokeMethod);
            methodinfo.Invoke(button, BindingFlags.NonPublic
            | BindingFlags.Instance | BindingFlags.InvokeMethod, null, new object[]
            {ControlStyles.Selectable,false}, Application.CurrentCulture);
        }
        public static void CalculatePrice(object obj)
        {

        }

        internal static void ChangeItem(ListBox listbox, SinglePriceInterface obj)
        {
            double subTotal = 0;
            double tax = DinnerLunchPrice.Tax;
            double total;
            if (listbox.Items.Count != 0)
            {
                foreach (var item in listbox.Items)
                {
                    if (item.ToString().Contains(obj.Name))
                    {
                        int i = listbox.Items.IndexOf(item);
                        listbox.Items.Remove(item);
                        listbox.Items.Insert(i, obj.Name.PadRight(14) + "x" + obj.Count.ToString().PadRight(2) + "$" + obj.Count * obj.Price);

                        listbox.SelectedIndex = i;
                        listbox.Focus();

                        for (int j = 1; j < listbox.Items.Count - 3; j++)
                        {
                            string[] str = listbox.Items[j].ToString().Split('$');
                            try
                            {
                                subTotal += double.Parse(str[1]);
                            }
                            catch
                            {
                                listbox.Items.RemoveAt(0);
                                subTotal += double.Parse(str[1]);
                            }
                            
                        }
                        listbox.Items.RemoveAt(listbox.Items.Count - 3);
                        listbox.Items.RemoveAt(listbox.Items.Count - 1);
                        listbox.Items.Insert(listbox.Items.Count - 1, "Subtotal".PadRight(17) + "$" + subTotal);
                        total = Math.Round(subTotal * (1 + (tax / 100)), 2);
                        listbox.Items.Add("Total".PadRight(17) + "$" + total);
                        if (obj.Count == 0)
                        {
                            listbox.Items.RemoveAt(i);
                        }
                        return;
                    }
                }
                if (listbox.Items.Count > 1)
                {
                    listbox.Items.Insert(listbox.Items.Count - 3, obj.Name.PadRight(14) + "x" + obj.Count.ToString().PadRight(2) + "$" + obj.Count * obj.Price);
                    listbox.SelectedIndex = listbox.Items.Count - 4;
                    listbox.Focus();
                    for (int j = 1; j < listbox.Items.Count - 3; j++)
                    {
                        string[] str = listbox.Items[j].ToString().Split('$');
                        try
                        { subTotal += double.Parse(str[1]); }
                        catch
                        {
                            listbox.Items.RemoveAt(0);
                            subTotal += double.Parse(str[1]);
                        }
                        
                    }
                    listbox.Items.RemoveAt(listbox.Items.Count - 3);
                    listbox.Items.RemoveAt(listbox.Items.Count - 1);
                    listbox.Items.Insert(listbox.Items.Count - 1, "Subtotal".PadRight(17) + "$" + subTotal);
                    total = Math.Round(subTotal * (1 + (tax / 100)), 2);
                    listbox.Items.Add("Total".PadRight(17) + "$" + total);
                }
                else
                {
                    listbox.Items.Add(obj.Name.PadRight(14) + "x" + obj.Count.ToString().PadRight(2) + "$" + obj.Count * obj.Price);
                    listbox.SelectedIndex = listbox.Items.Count - 1;
                    listbox.Focus();
                    string[] str = listbox.Items[1].ToString().Split('$');
                    subTotal += double.Parse(str[1]);
                    listbox.Items.Add("Subtotal".PadRight(17) + "$" + subTotal);
                    listbox.Items.Add("Tax".PadRight(18) + tax + "%");
                    total = Math.Round(subTotal * (1 + (tax / 100)), 2);
                    listbox.Items.Add("Total".PadRight(17) + "$" + total);
                }
            }
            else
            {
                listbox.Items.Insert(0, "Table".PadRight(17) + "A1");
                listbox.Items.Add(obj.Name.PadRight(14) + "x" + obj.Count.ToString().PadRight(2) + "$" + obj.Count * obj.Price);
                listbox.SelectedIndex = listbox.Items.Count - 1;
                listbox.Focus();
                string[] str = listbox.Items[1].ToString().Split('$');
                subTotal += double.Parse(str[1]);
                listbox.Items.Add("Subtotal".PadRight(17) + "$" + subTotal);
                listbox.Items.Add("Tax".PadRight(18) + tax + "%");
                total = Math.Round(subTotal * (1 + (tax / 100)), 2);
                listbox.Items.Add("Total".PadRight(17) + "$" + total);
            }
        }

        internal static void ChangeItem(ListBox listbox, string item, string n, string k)
        {
            if (listbox.Items.Contains(item.PadRight(18) + n))
            {
                listbox.Items.Remove(item.PadRight(18) + n);
                listbox.Items.Insert(0, item.PadRight(18) + k);
                listbox.SelectedIndex = 0;
                listbox.Focus();
            }
            else
            {
                listbox.Items.Insert(0, item.PadRight(18) + k);
                listbox.SelectedIndex = 0;
                listbox.Focus();
            }
        }
    }
}
