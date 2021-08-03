<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PClientes.aspx.cs" Inherits="Presentacion.PClientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvClientes_SelectedIndexChanged">
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
            <asp:GridView ID="gvCarnicero" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="id_Carnicero" HeaderText="Identificador del Carnicero" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre del Carnicero" />
                    <asp:BoundField DataField="Celular" HeaderText="Celular del Carnicero" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo" />
                    <asp:BoundField DataField="Exp_anios" HeaderText="Años de Experiencia" />
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
            <asp:GridView ID="gvEPedidos" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvEPedidos_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField SelectText="Seleccionar Entrega" ShowSelectButton="True" />
                    <asp:BoundField DataField="id_Entrega" HeaderText="Idetificador de Entrega" />
                    <asp:BoundField DataField="F_Pedido" HeaderText="Identificador de Pedido" />
                    <asp:BoundField DataField="F_Repartidor" HeaderText="Identificador de Repartidor" />
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
            <asp:GridView ID="gvRepartidor" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="id_Repartidor" HeaderText="Identificador del Repartidor" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre del Repartidor" />
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
            <br />
            Telefono del Cliente: <asp:TextBox ID="txbTel" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnConsulta" runat="server" Text="Consultar" OnClick="btnConsulta_Click" />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
