using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturaDeVenta
{
    public class Factura
    {      
        public string idFactura { get; set; }
        public Cliente cliente { get; set; }
        public Producto producto { get; set; }
        public double subTotal { get; set; }
        public double descuento { get; set; }
        public double iva { get; set; }
        public double neto { get; set; }

        public Factura(string idFactura, Cliente cliente, Producto producto, double subTotal, double descuento, double iva, double neto)
        {
            this.idFactura = idFactura;
            this.cliente = cliente;
            this.producto = producto;
            this.subTotal = subTotal;
            this.descuento = descuento;
            this.iva = iva;
            this.neto = neto;
        }
    }
}