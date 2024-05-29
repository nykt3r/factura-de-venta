<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FacturaDeVenta.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Programa - Factura De Venta</title>
    <link rel="stylesheet" type="text/css" href="Css/style.css"/>
</head>
<body>
    <form id="FormularioFacturaVenta" class="container" runat="server">
        <header class="header">
            <div class="header_left">
                <h1 class="header_title">FACTURA DE VENTA</h1>
                <p id="headerDescription" class="header_description" runat="server">14 JUNE 2022</p>
            </div>
            <div class="header_right">
                <p class="header_description">Pascual Bravo Project</p>
            </div>
        </header>
        
        <main class="main">
             <section class="initial">
                <div class="initial_left">
                    <h2 class="initial_title">DATOS DEL CLIENTE</h2>
                    <asp:Label class="label" runat="server" Text="idCliente"></asp:Label>
                    <asp:TextBox class="txtbox" ID="txtIdCliente" runat="server" required="true" TextMode="Number" oninput="validarNumeroPositivo(this)"></asp:TextBox>

                    <asp:Label class="label" runat="server" Text="Nombre"></asp:Label>
                    <asp:TextBox class="txtbox" ID="txtNombre" runat="server" required="true"></asp:TextBox>

                    <asp:Label class="label" runat="server" Text="Celular"></asp:Label>
                    <asp:TextBox class="txtbox" ID="txtCelular" runat="server" required="true" TextMode="Number" oninput="validarNumeroPositivo(this)"></asp:TextBox>

                    <asp:Button ID="calcularTablaIngreso" class="button button_calcular" runat="server" Text="Calcular" OnClick="calcularTablaIngreso_Click" />
                </div>

                <div class="initial_right">
                    <h2 class="initial_title">DATOS DEL PRODUCTO</h2>
                    <asp:Label class="label" runat="server" Text="idProducto"></asp:Label>
                    <asp:TextBox class="txtbox" ID="txtIdProducto" runat="server" required="true" TextMode="Number" oninput="validarNumeroPositivo(this)"></asp:TextBox>

                    <asp:Label class="label" runat="server" Text="Nombre Producto"></asp:Label>
                    <asp:TextBox class="txtbox" ID="txtNombreProducto" runat="server" required="true"></asp:TextBox>

                    <asp:Label class="label" runat="server" Text="Precio"></asp:Label>
                    <asp:TextBox class="txtbox" ID="txtPrecio" runat="server" required="true" TextMode="Number" oninput="validarNumeroPositivo(this)"></asp:TextBox>

                    <asp:Label class="label" runat="server" Text="Cantidad"></asp:Label>
                    <asp:TextBox class="txtbox" ID="txtCantidad" runat="server" required="true" TextMode="Number" oninput="validarNumeroPositivo(this)"></asp:TextBox>
                </div>
            </section>

            <section class="input_values">
                <div class="table">
                    <table class="input_table" border="1">
                        <tr class="table_head">
                            <th class="table_th">Subtotal</th>
                            <th class="table_th">Descuento 3%</th>
                            <th class="table_th">IVA 19%</th>
                            <th class="table_th">Neto</th>
                        </tr>
                        <tr class="table_data">
                            <td id="txtSubTotal" class="table_td" runat="server">0</td>
                            <td id="txtDescuento" class="table_td" runat="server">0</td>
                            <td id="txtIva" class="table_td" runat="server">0</td>
                            <td id="txtNeto" class="table_td" runat="server">0</td>
                        </tr>
                    </table>
                </div>
                <div class="input_buttons">
                    <asp:Button ID="BtnAgregar" class="button button_agregar" runat="server" Text="Agregar Factura" OnClick="BtnAgregar_Click" Visible="False"/>
                    <asp:Button ID="BtnNueva" class="button button_nueva" runat="server" Text="Nueva Factura" OnClick="BtnNueva_Click" Visible="False"/>
                </div>
            </section>

            <section class="output_values">
                <asp:GridView ID="TablaSalida" class="output_table" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="idFactura" HeaderText="ID Factura" />
                        <asp:BoundField DataField="idCliente" HeaderText="ID Cliente" />
                        <asp:BoundField DataField="idProducto" HeaderText="ID Producto" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
                        <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" />
                        <asp:BoundField DataField="Descuento" HeaderText="Descuento 3%" />
                        <asp:BoundField DataField="Iva" HeaderText="IVA 19%" />
                        <asp:BoundField DataField="Neto" HeaderText="Neto" />
                    </Columns>
                </asp:GridView>
            </section>
        </main>
        <footer class="footer">
            <h2 class="footer_title">&copy Factura de Venta - PB Project 2024</h2>
        </footer>
    </form>
    <script src="validarNumPositivo.js"></script>
</body>
</html>
