using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal2
{
    public class Proveedor
    {
        public Proveedor(int proveedorid, string nombre, long cuit, string email, long celular, string rubro, string direccion)
        {
            Proveedorid = proveedorid;
            Nombre = nombre;
            Cuit = cuit;
            Email = email;
            Celular = celular;
            Rubro = rubro;
            Direccion = direccion;
        }

        public int Proveedorid { get; set; }
        public string Nombre { get; set; }
        public long Cuit { get; set; }
        public string Email { get; set; }
        public long Celular { get;  set; }
        public string Rubro { get; set; }
        public string Direccion { get;  set; }
    }
}
