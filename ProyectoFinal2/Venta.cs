using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal2
{
    public class Venta
    {
        public Venta(int ventaID, decimal monto, DateTime fecha, TimeSpan hora, int usuarioID)
        {
            VentaID = ventaID;
            Monto = monto;
            Fecha = fecha;
            Hora = hora;
            UsuarioID = usuarioID;
        }
        public int VentaID { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public int UsuarioID { get; set; }

        public Venta()
        {
        }
    }
}
