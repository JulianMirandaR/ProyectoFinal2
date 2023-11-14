using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal2
{
    public class Utils
    {
        public static int BuscarComboBox<T>(ComboBox combo, T item)
        {
            int result = 0;
            int num = 0;
            foreach (T item2 in combo.Items)
            {
                if (item2.Equals(item))
                {
                    return num;
                }

                num++;
            }

            return result;
        }

        public static void LLenarCombobox<T>(ComboBox combo, List<T> items)
        {
            if (items.Count > 0)
            {
                foreach (T item in items)
                {
                    combo.Items.Add(item);
                }
                combo.SelectedIndex = 0;
            }
            else
            {
                // Maneja el caso en el que la lista 'items' está vacía
                MessageBox.Show("No hay elementos para llenar el ComboBox.");
            }
        }
    }
}

