using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturaDeVenta
{
    public class Producto
    {
        public string idProducto { get; set; }
        public string nombreProducto { get; set; }
        public double precio { get; set; }
        public int cantidad { get; set; }

        public Producto(string idProducto, string nombreProducto, double precio, int cantidad)
        {
            this.idProducto = idProducto;
            this.nombreProducto = nombreProducto;
            this.precio = precio;
            this.cantidad = cantidad;
        }

        public double calcularSubTotal()
        {
            return this.precio * this.cantidad;
        }

        public double calcularDescuento(double subTotal)
        {
            return subTotal * 0.03;
        }

        public double calcularIva(double subTotal)
        {
            return subTotal * 0.19;
        }

        public double calcularNeto(double subTotal, double descuento, double iva)
        {
            return subTotal - descuento + iva;
        }
    }
}