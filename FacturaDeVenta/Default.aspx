<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FacturaDeVenta.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Programa - Factura De Venta</title>
</head>
<body>
    <form id="FormularioFacturaVenta" runat="server">
        <header class="header">
            <h1>FACTURA DE VENTA</h1>
            <div class="header_left">
                <asp:Label runat="server" Text="idCliente"></asp:Label>
                <asp:TextBox ID="txtIdCliente" runat="server"></asp:TextBox>

                <asp:Label runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>

                <asp:Label runat="server" Text="Celular"></asp:Label>
                <asp:TextBox ID="txtCelular" runat="server"></asp:TextBox>
            </div>
            <div class="header_right">
                <asp:Label runat="server" Text="idProducto"></asp:Label>
                <asp:TextBox ID="txtIdProducto" runat="server"></asp:TextBox>

                <asp:Label runat="server" Text="Nombre Producto"></asp:Label>
                <asp:TextBox ID="txtNombreProducto" runat="server"></asp:TextBox>

                <asp:Label runat="server" Text="Precio"></asp:Label>
                <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>

                <asp:Label runat="server" Text="Cantidad"></asp:Label>
                <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="calcularTablaIngreso" runat="server" Text="Calcular" OnClick="calcularTablaIngreso_Click" />
        </header>
        
        <main class="main">
            <div class="input">
                <table class="tabla_ingreso" border="1">
                    <tr class="tabla_head">
                        <th class="tabla_th">Subtotal</th>
                        <th class="tabla_th">Descuento 3%</th>
                        <th class="tabla_th">IVA 19%</th>
                        <th class="tabla_th">Neto</th>
                    </tr>
                    <tr class="tabla_datos">
                        <td id="txtSubTotal" class="tabla_td" runat="server"></td>
                        <td id="txtDescuento" class="tabla_td" runat="server"></td>
                        <td id="txtIva" class="tabla_td" runat="server"></td>
                        <td id="txtNeto" class="tabla_td" runat="server"></td>
                    </tr>
                </table>
                <asp:Button ID="BtnAgregar" runat="server" Text="Agregar"/>
                <asp:Button ID="BtnLimpiar" runat="server" Text="Limpiar" OnClick="BtnLimpiar_Click"/>
                <asp:Button ID="BtnNueva" runat="server" Text="Nueva"/>
            </div>

            <div class="output">
                <asp:GridView ID="TablaSalida" class="tabla_salida" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" />
                        <asp:BoundField DataField="Descuento" HeaderText="Descuento 3%" />
                        <asp:BoundField DataField="Iva" HeaderText="IVA 19%" />
                        <asp:BoundField DataField="Neto" HeaderText="Neto" />
                    </Columns>
                </asp:GridView>
            </div>
        </main>
    </form>
</body>
</html>
