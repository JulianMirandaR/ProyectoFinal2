#region ensamblado ArticuloLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// C:\Users\juuli\Desktop\FACULTAD\2do año\Practica II\Segundo Cuatrimestre\WindowsFormsApp3\EmpleadosLibrary.dll
// Decompiled with ICSharpCode.Decompiler 7.1.0.6543
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal2
{
    public class DtoDetalle
    {
        public long Articuloid { get; set; }

        public string Detalle { get; set; }

        public string Presentacion { get; set; }

        public decimal Precio_compra { get; set; }

        public decimal Precio_venta { get; set; }

        public int Stock { get; set; }
        public string Proveedor { get; set; }


        public DtoDetalle(long articuloid, string detalle, string presentacion, decimal precio_compra, decimal precio_venta, int stock, string proveedor)
        {
            Articuloid = articuloid;
            Detalle = detalle;
            Presentacion = presentacion;
            Precio_compra = precio_compra;
            Precio_venta = precio_venta;
            Stock = stock;
            Proveedor = proveedor;
        }

        public DtoDetalle()
        {
            Articuloid = 0;
            Detalle = string.Empty;
        }
       
    }
    public class DtoDetalleProveedor
    {
        public int Proveedorid { get; set; }

        public string Nombre { get; set; }

        public long Cuit { get; set; }

        public string Email { get; set; }

        public long Celular { get; set; }

        public string Rubro { get; set; }

        public string Direccion { get; set; }

        public DtoDetalleProveedor(int proveedorid, string nombre, long cuit, string email, long celular, string rubro, string direccion)
        {
            Proveedorid = proveedorid;
            Nombre = nombre;
            Cuit = cuit;
            Email = email;
            Celular = celular;
            Rubro = rubro;
            Direccion = direccion;
        }

        public DtoDetalleProveedor()
        {
            Proveedorid = 0;
            Nombre = string.Empty;
        }
    }

    public class TResult<T>
    {
        public string Error { get; set; } = string.Empty;


        public bool IsValid { get; set; } = true;


        public List<T> Articulos { get; set; }

        public List<T> Proveedores { get; set; }

        public T Articulo { get; set; }
        public T Proveedor { get; set; }
    }
}
#if false // Registro de descompilación
"15" elementos en caché
------------------
Resolver: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Se encontró un solo ensamblado: "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Cargar desde: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\mscorlib.dll"
------------------
Resolver: "System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Se encontró un solo ensamblado: "System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Cargar desde: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\System.Data.dll"
------------------
Resolver: "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Se encontró un solo ensamblado: "System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
Cargar desde: "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\System.dll"
#endif
