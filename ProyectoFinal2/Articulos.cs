using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    public class Articulo
    {
        public Articulo(long articuloid, string detalle, string presentacion, decimal precio_compra, decimal precio_venta, int stock, string proveedor)
        {
            Articuloid = articuloid;
            Detalle = detalle;
            Presentacion = presentacion;
            Precio_compra = precio_compra;
            Precio_venta = precio_venta;
            Stock = stock;
            Proveedor = proveedor;

        }

        public long Articuloid { get; set; }
        public string Detalle { get; set; }
        public string Presentacion { get; set; }
        public decimal Precio_compra { get; set; }
        public decimal Precio_venta { get; set; }
        public int Stock { get; set; }
        public string Proveedor { get; set; }
    }

}