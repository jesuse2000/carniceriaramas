<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FPedidos.aspx.cs" Inherits="Presentacion.FPedidos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CRUD Pedidos</title>
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
                        <li><a class="ident" href="FCliente.aspx">Clientes</a></li>
                        <li><a class="ident" href="FEntregaPedido.aspx">Entregas</a></li>
                        <li><a class="inabSel">Pedidos</a></li>
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
            <h2 class="pest">CRUD - Pedidos</h2>
            <br />
            <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvPedidos_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField SelectText="Seleccionar Pedido" ShowSelectButton="True" />
                    <asp:BoundField DataField="id_Pedido" HeaderText="Identificador del Pedido" />
                    <asp:BoundField DataField="FechaHora" HeaderText="Fecha y Hora del Pedido" />
                    <asp:BoundField DataField="F_Cliente" HeaderText="Identificador del Cliente" />
                    <asp:BoundField DataField="F_Carnicero" HeaderText="Identificador del Carnicero" />
                    <asp:BoundField DataField="Envio" HeaderText="Envio del Pedido" />
                    <asp:BoundField DataField="Pago" HeaderText="Forma del Pago" />
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
            Actualizar forma de pago:
            <br />
            <asp:DropDownList ID="ddlActPedido" runat="server" Visible="False">
                <asp:ListItem>Pago al repartidor</asp:ListItem>
                <asp:ListItem>Pago electronico</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:DropDownList ID="ddlActPS" runat="server" Visible="False">
                <asp:ListItem>Pago en la sucursal</asp:ListItem>
                <asp:ListItem>Pago electronico</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
            <br />
            <br />
            <asp:Button ID="btnActPedido" runat="server" OnClick="btnActPedido_Click" Text="Actualizar Pedidos" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
        </div>
    </form>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</body>
</html>
