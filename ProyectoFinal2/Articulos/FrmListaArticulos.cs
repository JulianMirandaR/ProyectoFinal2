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
    public partial class FrmListaArticulos : Form// en este form solo se muetra los articulos en la lista
    {
        public FrmListaArticulos()
        {
            InitializeComponent();
        }

        private void FrmListaArticulos_Load(object sender, EventArgs e)
        {
            CargarArticulos();
        }

        public void CargarArticulos()
        {
            var listaArticulos = ArticuloController.GetListadoNombres();

            if (listaArticulos.Articulos.Count > 0)
            {
                dataGridView1.DataSource = listaArticulos.Articulos;
            }
            else
            {
                MessageBox.Show("No hay artículos para mostrar.");
            }
        }
    }
}