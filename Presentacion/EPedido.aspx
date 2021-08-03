<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EPedido.aspx.cs" Inherits="Presentacion.EPedido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Enviar Pedido</title>
    <link rel="stylesheet" href="StyleSheet1.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</head>
<body style="background-color:darkseagreen">
    <!--Barra de Menu-->
    <header>
        <nav class="navegacion">
            <ul class="menu">
                <li class="ident"><a href="index.aspx">Alta de Clientes</a></li>
                <li class="ident"><a href="FormPedido.aspx">Pedido</a></li>
                <li class="inabSel"><a>Enviar</a></li>
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
            <h3 class="pest">Envios de pedido y Actualizacion de la entrega</h3>
                  </div>
            <br />
            <br />
            Telefono del Cliente <asp:TextBox ID="txbTel" runat="server" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator_Colonia" ControlToValidate="txbTel"
            ErrorMessage="*requerido" ForeColor="Red" ValidationGroup="form_ejm"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Button ID="btnInsertar" runat="server" Text="Enviar Pedido" OnClick="btnInsertar_Click" ValidationGroup="form_ejm" class="btn btn-outline-success"/>
            <br />
            <br />
            <asp:Label ID="lbResp" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Estado"></asp:Label>
            <asp:DropDownList ID="ddlEstado" runat="server">
                <asp:ListItem>Excelente</asp:ListItem>
                <asp:ListItem>Regular</asp:ListItem>
                <asp:ListItem>Malo</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnActualizar" CssClass="btn btn-outline-warning" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" ValidationGroup="form_ejm"/>
            <br />
            <br />
            <asp:Label ID="lbResp2" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
        </div>
    </form>
    <br />
    <br />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</body>
</html>
