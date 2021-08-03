<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FCliente.aspx.cs" Inherits="Presentacion.FCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>CRUD Cliente</title>
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
                        <li><a class="ident" href="FCarnicero.aspx">Carniceros</a></li>
                        <li><a class="inabSel">Clientes</a></li>
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
            <br />
            <h2 class="pest">CRUD - Clientes</h2>
            <br />
            <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvClientes_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField SelectText="Seleccionar Cliente" ShowSelectButton="True" />
                    <asp:BoundField DataField="id_Cliente" HeaderText="Identificacion del Cliente" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre del Cliente" />
                    <asp:BoundField DataField="App" HeaderText="Apellido Paterno" />
                    <asp:BoundField DataField="ApM" HeaderText="Apellido Materno" />
                    <asp:BoundField DataField="Celular" HeaderText="Celular del Cliente" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo del Cliente" />
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
            <br />
            Nombre:
            <asp:TextBox ID="txbNombre" runat="server"></asp:TextBox>
            <br />
            Apellido Paterno:
           
            <asp:TextBox ID="txbApp" runat="server"></asp:TextBox>
            <br />
            Apellido Materno:
           
            <asp:TextBox ID="txbApM" runat="server"></asp:TextBox>
            <br />
            Celular:
           
            <asp:TextBox ID="txbCelular" runat="server"></asp:TextBox>
            <br />
            Correo:
           
            <asp:TextBox ID="txbCorreo" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnInsertarCliente" class="btn btn-outline-success" runat="server" OnClick="btnInsertarCliente_Click" Text="Insertar Cliente" />
            <br />
            <br />
            <asp:Label ID="lbResp" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnActualizar" class="btn btn-outline-warning" runat="server" OnClick="btnActualizar_Click" Text="Actualizar" Visible="False" />
            <br />
            <br />
            <asp:Button ID="btnEliminar" class="btn btn-outline-danger" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" Visible="False" />
            <br />
            <br />
            <br />

        </div>
    </form>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</body>
</html>
