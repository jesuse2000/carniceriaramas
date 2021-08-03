<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PRepatidor.aspx.cs" Inherits="Presentacion.PRepatidor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Consulta Repartidores</title>
    <link rel="stylesheet" href="StyleSheet1.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
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
                        <li><a class="ident" href="InsertCR.aspx">Carniceros y Repartidores</a></li>
                        <li><a class="ident" href="PClientes.aspx">Clientes</a></li>
                        <li><a class="inabSel">Repartidor</a></li>
                    </ul>
                </li>
            </ul>
        </nav>
    </header>
    <!--Fin de barra de Menu-->
    <form id="form1" runat="server">
        <div class="container" id="formulario">
              <div class="container">
            <h2 class="pest">Consulta de Repartidores</h2>
                  </div>
            <br />
            <br />
            <asp:GridView ID="gvRepartidores" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvRepartidores_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField SelectText="Seleccionar Repartidor" ShowSelectButton="True" />
                    <asp:BoundField DataField="id_Repartidor" HeaderText="Identificador del Repartidor" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Celular" HeaderText="Celular" />
                    <asp:BoundField DataField="Licencia" HeaderText="Licencia" />
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
            <asp:GridView ID="gvEntrega" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvEntrega_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField SelectText="Seleccionar Entrega de Pedido" ShowSelectButton="True" />
                    <asp:BoundField DataField="id_Entrega" HeaderText="Identificador de Entrega" />
                    <asp:BoundField DataField="F_Pedido" HeaderText="Identificador de Pedido" />
                    <asp:BoundField DataField="F_Repartidor" HeaderText="Identificador del Repartidor" />
                    <asp:BoundField DataField="Salida" HeaderText="Hora de Salida" />
                    <asp:BoundField DataField="SeEntrego" HeaderText="Hora de Entrega" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado en que se entrego" />
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
            <asp:GridView ID="gvPedidos" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField SelectText="Seleccionar Pedido" ShowSelectButton="True" />
                    <asp:BoundField DataField="id_Pedido" HeaderText="Identificador de Pedido" />
                    <asp:BoundField DataField="FechaHora" HeaderText="Fecha y Hora" />
                    <asp:BoundField DataField="F_Cliente" HeaderText="Identificador del Cliente" />
                    <asp:BoundField DataField="F_Carnicero" HeaderText="Identificador del Carnicero" />
                    <asp:BoundField DataField="Envio" HeaderText="Envio" />
                    <asp:BoundField DataField="Pago" HeaderText="Forma de Pago" />
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
            <asp:GridView ID="gvProducto" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="id_prod" HeaderText="Identificador del Producto" />
                    <asp:BoundField DataField="NombreProd" HeaderText="Nombre del Producto" />
                    <asp:BoundField DataField="Peso" HeaderText="Peso del Producto" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                    <asp:BoundField DataField="PrecioFinal" HeaderText="Total a Pagar" />
                    <asp:BoundField DataField="NotaEspecial" HeaderText="Nota Especial" />
                    <asp:BoundField DataField="F_Pedido" HeaderText="Identificador del Pedido" />
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
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</body>
</html>
