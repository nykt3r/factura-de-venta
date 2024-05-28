using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacturaDeVenta
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Crear una tabla en memoria para llenar el GridView
                DataTable dt = new DataTable();
                dt.Columns.Add("Subtotal");
                dt.Columns.Add("Descuento");
                dt.Columns.Add("Iva");
                dt.Columns.Add("Neto");

                // Agregar filas de datos
                DataRow dr1 = dt.NewRow();
                dr1["Subtotal"] = "1000";
                dr1["Descuento"] = "30";
                dr1["Iva"] = "190";
                dr1["Neto"] = "1160";
                dt.Rows.Add(dr1);

                DataRow dr2 = dt.NewRow();
                dr2["Subtotal"] = "2000";
                dr2["Descuento"] = "60";
                dr2["Iva"] = "380";
                dr2["Neto"] = "2320";
                dt.Rows.Add(dr2);

                // Asignar el DataTable al GridView
                TablaSalida.DataSource = dt;
                TablaSalida.DataBind();
            }

        }

        protected void calcularTablaIngreso_Click(object sender, EventArgs e)
        {
            //Captura datos cliente
            string idCliente = txtIdCliente.Text;
            string nombreCliente = txtNombre.Text;
            string celularCliente = txtCelular.Text;

            //Captura datos producto
            string idProducto = txtIdProducto.Text;
            string nombreProducto = txtNombreProducto.Text;
            string precio = txtPrecio.Text;
            string cantidad = txtCantidad.Text;

            double precioProducto = double.Parse(precio);
            double cantidadProducto = double.Parse(cantidad);

            //Calcular Subtotal
            double subTotal = calcularSubTotal(precioProducto, cantidadProducto);
            txtSubTotal.InnerText = subTotal.ToString();

            //Calcular Descuento
            double descuento = calcularDescuento(subTotal);
            txtDescuento.InnerText = descuento.ToString();

            //Calcular Iva
            double iva = calcularIva(subTotal);
            txtIva.InnerText = iva.ToString();

            //Calcular Neto
            double neto = calcularNeto(subTotal, descuento, iva);
            txtNeto.InnerText = neto.ToString();
        }

        public double calcularSubTotal(double precio, double cantidad)
        {
            return precio * cantidad;
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
            return subTotal + descuento + iva;
        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            txtSubTotal.InnerText = "";
            txtDescuento.InnerText = "";
            txtIva.InnerText = "";
            txtNeto.InnerText = "";
        }
    }
}