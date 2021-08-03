<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertCR.aspx.cs" Inherits="Presentacion.InsertCR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Insertar Carniceros/Repartidores</title>
    <link rel="stylesheet" href="StyleSheet1.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
</head>
<body style="background-color: darkseagreen">
    <!--Barra de Menu-->
    <header>
        <nav class="navegacion">
            <ul class="menu">
                <li class="ident"><a href="index.aspx">Alta de Clientes</a></li>
                <li class="ident"><a href="FormPedido.aspx">Pedido</a></li>
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
                        <li><a class="inabSel">Carniceros y Repartidores</a></li>
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
            <h2 class="pest">Inserta Carnicero o Repartidor</h2>
                  </div>
            <br />
            <br />
            Agregar:
           
            <asp:DropDownList ID="ddlRCarni" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRCarni_SelectedIndexChanged">
                <asp:ListItem>Carnicero</asp:ListItem>
                <asp:ListItem>Repartidor</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            Nombre:
           
            <asp:TextBox ID="txbNombre" runat="server"></asp:TextBox>
            <br />
            <br />
            Celular:
           
            <asp:TextBox ID="txbCelular" runat="server" TextMode="Number"></asp:TextBox>
            <br />
            <br />
            Correo:
           
            <asp:TextBox ID="txbCorreo" runat="server" TextMode="Email"></asp:TextBox>
            <br />
            <br />
            Años de experiencia
           
            <asp:TextBox ID="txbAnios" runat="server" TextMode="Number"></asp:TextBox>
            <br />
            <br />
            Licencia
           
            <asp:TextBox ID="txbLicencia" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnInsertCR" runat="server" Text="Insertar" OnClick="btnInsertCR_Click" class="btn btn-outline-success" />
            <br />
            <br />
            <asp:Label ID="lbResp" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
        </div>
        <br />
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    </form>
</body>
</html>
