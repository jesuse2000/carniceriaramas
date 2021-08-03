<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormPedido.aspx.cs" Inherits="Presentacion.FormPedido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Pedido</title>
    <link rel="stylesheet" href="StyleSheet1.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</head>
<body style="background-color:darkseagreen">
    <!--Barra de Menu-->
    <header>
        <nav class="navegacion">
            <ul class="menu">
                <li class="ident"><a href="index.aspx">Alta de Clientes</a></li>
                <li class="inabSel"><a>Pedido</a></li>
                <li class="ident"><a href="EPedido.aspx">Enviar</a></li>
                <li class="ident"><a href="Consultas.aspx">Consultas</a></li>
                <li class="inab">
                    <a>Actualización y Eliminación</a>
                    <ul class="submenu">
                        <li><a class="ident" href="FCarnicero.aspx">Carniceros</a></li>
                        <li><a class="ident" href="FCliente.aspx">Clientes</a></li>
                        <li><a class="ident" href="FEntregaPedido.aspx">Entregas</a></li>
                        <li><a class="ident" href="FPedidos.aspx">Pedidos</a></li>
                        <li><a class="ident" href="FProducto.aspx">Productos</a></li>
                        <li><a class="ident" href="FRepartidor.aspx">Repartidores</a></li>
                        <li><a class="ident" href="FUbicacion.aspx">Ubicaciones</a></li>
                    </ul>
                </li>
                <li class="inab">
                    <a>Consultas</a>
                    <ul class="submenu">
                        <li><a class="ident" href="InsertCR.aspx">Carniceros y Repartidores</a></li>
                        <li><a class="ident" href="PClientes.aspx">Clientes</a></li>
                        <li><a class="ident" href="PRepatidor.aspx">Repartidor</a></li>
                    </ul>
                </li>
            </ul>
        </nav>
    </header>
    <!--Fin de barra de Menu-->
    <form id="form1" runat="server">
        <div class="container" id="formulario">
              <div class="container">
            <h2 class="pest">Pedido</h2>
                  </div>
            <br />
            <asp:Label ID="lbTel" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Telefono: "></asp:Label>
            <asp:TextBox ID="txbTelefono" runat="server" Enabled="False" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator_Colonia" ControlToValidate="txbTelefono"
            ErrorMessage="*requerido" ForeColor="Red" ValidationGroup="form_ejm"></asp:RequiredFieldValidator>
            <br />
            <br />
            Envio: <asp:DropDownList ID="ddlEnvio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEnvio_SelectedIndexChanged">
                <asp:ListItem Value="1">Envio a domicilio</asp:ListItem>
                <asp:ListItem Value="0">Recoger en la sucursal</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            Forma de pago:
            <asp:DropDownList ID="ddlSucursal" runat="server" Visible="False">
                <asp:ListItem>Pago Electronico</asp:ListItem>
                <asp:ListItem>Pago en la sucursal</asp:ListItem>
            </asp:DropDownList>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlRepartidor" runat="server" Visible="False">
                <asp:ListItem>Pago al repartidor</asp:ListItem>
                <asp:ListItem>Pago electronico</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            Nombre del producto:&nbsp;
            <asp:TextBox ID="txbNomP" runat="server" CssClass="auto-style1"></asp:TextBox>
            <br />
            <br />
            Peso:&nbsp;
            <asp:TextBox ID="txbPeso" runat="server" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txbTelefono"
            ErrorMessage="*requerido" ForeColor="Red" ValidationGroup="form_ejm"></asp:RequiredFieldValidator>
            <br />
            <br />
            Cantidad (Precio):&nbsp;
            <asp:TextBox ID="txbCantidad" runat="server" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txbTelefono"
            ErrorMessage="*requerido" ForeColor="Red" ValidationGroup="form_ejm"></asp:RequiredFieldValidator>
            <br />
            <br />
            Nota Especial:&nbsp;&nbsp;
            <asp:TextBox ID="txbNotaFinal" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lbResp" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            Precio Final:&nbsp;
            <asp:TextBox ID="txbPFinal" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnInsertPedido" class="btn btn-outline-info" runat="server" OnClick="btnInsertPedido_Click" Text="Realizar Pedido" ValidationGroup="form_ejm"/>
            <br />
            <br />
            <br />
        </div>
    </form>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</body>
</html>
