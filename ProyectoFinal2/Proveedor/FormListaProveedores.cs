using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoFinal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoFinal2
{
    public partial class FormListaProveedores : Form
    {
        public FormListaProveedores()
        {
            InitializeComponent();
        }

        private void FormListaProveedores_Load(object sender, EventArgs e)
        {
            CargarProveedores();
        }
        public void CargarProveedores()
        {
            var listaProveedores = ProveedorController.GetListadoNombres();

            if (listaProveedores.Proveedores.Count > 0)
            {
                dataGridView2.DataSource = listaProveedores.Proveedores;
            }
            else
            {
                MessageBox.Show("No hay Proveedores para mostrar.");
            }
        }


        
    }
}