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
                headerDescription.InnerText = DateTime.Now.ToString("dd MMMM yyyy");

                DataTable dt = new DataTable();
                dt.Columns.Add("idFactura");
                dt.Columns.Add("idCliente");
                dt.Columns.Add("idProducto");
                dt.Columns.Add("Cantidad");
                dt.Columns.Add("Precio");
                dt.Columns.Add("Subtotal");
                dt.Columns.Add("Descuento");
                dt.Columns.Add("Iva");
                dt.Columns.Add("Neto");

                TablaSalida.DataSource = dt;
                TablaSalida.DataBind();

                Session["FacturaTable"] = dt;
            }
        }

        protected void calcularTablaIngreso_Click(object sender, EventArgs e)
        {
            //Captura datos cliente
            string idCliente = txtIdCliente.Text;
            string nombreCliente = txtNombre.Text;
            string celularCliente = txtCelular.Text;
            Cliente cliente = new Cliente(idCliente, nombreCliente, celularCliente); //Crea Cliente con los datos del input

            //Captura datos producto
            string idProducto = txtIdProducto.Text;
            string nombreProducto = txtNombreProducto.Text;
            string precio = txtPrecio.Text;
            string cantidad = txtCantidad.Text;
            //Datos producto string a numero
            double precioProducto = double.Parse(precio);
            int cantidadProducto = int.Parse(cantidad);
            Producto producto = new Producto(idProducto, nombreProducto, precioProducto, cantidadProducto); //Crea Producto con los datos del input

            //Calcular Subtotal
            double subTotal = producto.calcularSubTotal();
            txtSubTotal.InnerText = subTotal.ToString();
            //Calcular Descuento
            double descuento = producto.calcularDescuento(subTotal);
            txtDescuento.InnerText = descuento.ToString();
            //Calcular Iva
            double iva = producto.calcularIva(subTotal);
            txtIva.InnerText = iva.ToString();
            //Calcular Neto
            double neto = producto.calcularNeto(subTotal, descuento, iva);
            txtNeto.InnerText = neto.ToString();

            string idFactura = idCliente + idProducto;
            Factura factura = new Factura(idFactura, cliente, producto, subTotal, descuento, iva, neto); //Crea Factura

            //Guardar la factura en la sesión
            Session["CurrentFactura"] = factura;

            txtIdCliente.Enabled = false;
            txtNombre.Enabled = false;
            txtCelular.Enabled = false;
            txtIdProducto.Enabled = false;
            txtNombreProducto.Enabled = false;
            txtPrecio.Enabled = false;
            txtCantidad.Enabled = false;

            BtnAgregar.Visible = true;
            BtnNueva.Visible = true;
        }

        protected void BtnNueva_Click(object sender, EventArgs e)
        {
            //Limpiando tabla calculada
            txtSubTotal.InnerText = "0";
            txtDescuento.InnerText = "0";
            txtIva.InnerText = "0";
            txtNeto.InnerText = "0";

            //Limpiando inputs de factura
            txtIdCliente.Text = ""; 
            txtNombre.Text = "";
            txtCelular.Text = "";
            txtIdProducto.Text = "";
            txtNombreProducto.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";

            BtnAgregar.Visible = false;
            BtnNueva.Visible = false;

            txtIdCliente.Enabled = true;
            txtNombre.Enabled = true;
            txtCelular.Enabled = true;
            txtIdProducto.Enabled = true;
            txtNombreProducto.Enabled = true;
            txtPrecio.Enabled = true;
            txtCantidad.Enabled = true;
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            //Recuperar la tabla de la sesión
            DataTable dt = (DataTable)Session["FacturaTable"];
            Factura factura = (Factura)Session["CurrentFactura"];

            if (factura != null)
            {
                DataRow dr = dt.NewRow();
                dr["idFactura"] = factura.idFactura;
                dr["idCliente"] = factura.cliente.idCliente;
                dr["idProducto"] = factura.producto.idProducto;
                dr["Cantidad"] = factura.producto.cantidad;
                dr["Precio"] = factura.producto.precio;
                dr["Subtotal"] = factura.subTotal;
                dr["Descuento"] = factura.descuento;
                dr["Iva"] = factura.iva;
                dr["Neto"] = factura.neto;
                dt.Rows.Add(dr);

                //Asignar la tabla actualizada al GridView
                TablaSalida.DataSource = dt;
                TablaSalida.DataBind();

                //Guardar la tabla actualizada en la sesión
                Session["FacturaTable"] = dt;

                //Limpiando tabla calculada
                txtSubTotal.InnerText = "0";
                txtDescuento.InnerText = "0";
                txtIva.InnerText = "0";
                txtNeto.InnerText = "0";

                //Limpiando inputs de producto
                txtIdProducto.Text = "";
                txtNombreProducto.Text = "";
                txtPrecio.Text = "";
                txtCantidad.Text = "";

                BtnAgregar.Visible = false;
                BtnNueva.Visible = false;

                txtIdProducto.Enabled = true;
                txtNombreProducto.Enabled = true;
                txtPrecio.Enabled = true;
                txtCantidad.Enabled = true;
            }
        }
    }
}