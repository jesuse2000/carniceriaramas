<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FCarnicero.aspx.cs" Inherits="Presentacion.FCarnicero" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>CRUD Carniceros</title>
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
                <li class="ident"><a href="EPedido.aspx">Enviar</a></li>
                <li class="ident"><a href="Consultas.aspx">Consultas</a></li>
                <li class="inab">
                    <a>Actualización y Eliminación</a>
                    <ul class="submenu">
                        <li><a class="inabSel">Carniceros</a></li>
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
            <h2 class="pest">CRUD - Carnicero</h2>
                  </div>
            <br />
            <asp:GridView ID="gvCarnicero" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvCarnicero_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField SelectText="Seleccionar Carnicero" ShowSelectButton="True" />
                    <asp:BoundField DataField="id_Carnicero" HeaderText="Identificador del Carnicero" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre del Carnicero" />
                    <asp:BoundField DataField="Celular" HeaderText="Celular del Carnicero" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo" />
                    <asp:BoundField DataField="Exp_anios" HeaderText="Años de Experiencia" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            Celular:
            <asp:TextBox ID="txbCelular" runat="server"></asp:TextBox>
            <br />
            Correo:
           
            <asp:TextBox ID="txbCorreo" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnActualizar" class="btn btn-outline-warning" runat="server" OnClick="btnActualizar_Click" Text="Actualizar" Visible="False" />
            <br />
            <br />
            <asp:Button ID="btnEliminar" class="btn btn-outline-danger" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" Visible="False" />
            <br />
            <br />

        </div>
    </form>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</body>
</html>
