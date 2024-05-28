using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturaDeVenta
{
    public class Cliente
    {
        public string idCliente { get; set; }
        public string nombre { get; set; }
        public string celular { get; set;}

        public Cliente(string idCliente, string nombre, string celular)
        {
            this.idCliente = idCliente;
            this.nombre = nombre;
            this.celular = celular;
        }
    }
}