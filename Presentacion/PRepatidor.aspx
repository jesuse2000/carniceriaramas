<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PRepatidor.aspx.cs" Inherits="Presentacion.PRepatidor" %>

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
            Repartidores
            <br />
            <br />
            <asp:GridView ID="gvRepartidores" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvRepartidores_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField SelectText="Seleccionar Repartidor" ShowSelectButton="True" />
                    <asp:BoundField DataField="id_Repartidor" HeaderText="Identificador del Repartidor" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Celular" HeaderText="Celular" />
                    <asp:BoundField DataField="Licencia" HeaderText="Licencia" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:GridView ID="gvEntrega" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvEntrega_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField SelectText="Seleccionar Entrega de Pedido" ShowSelectButton="True" />
                    <asp:BoundField DataField="id_Entrega" HeaderText="Identificador de Entrega" />
                    <asp:BoundField DataField="F_Pedido" HeaderText="Identificador de Pedido" />
                    <asp:BoundField DataField="F_Repartidor" HeaderText="Identificador del Repartidor" />
                    <asp:BoundField DataField="Salida" HeaderText="Hora de Salida" />
                    <asp:BoundField DataField="SeEntrego" HeaderText="Hora de Entrega" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado en que se entrego" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:GridView ID="gvPedidos" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False">
                <Columns>
                    <asp:CommandField SelectText="Seleccionar Pedido" ShowSelectButton="True" />
                    <asp:BoundField DataField="id_Pedido" HeaderText="Identificador de Pedido" />
                    <asp:BoundField DataField="FechaHora" HeaderText="Fecha y Hora" />
                    <asp:BoundField DataField="F_Cliente" HeaderText="Identificador del Cliente" />
                    <asp:BoundField DataField="F_Carnicero" HeaderText="Identificador del Carnicero" />
                    <asp:BoundField DataField="Envio" HeaderText="Envio" />
                    <asp:BoundField DataField="Pago" HeaderText="Forma de Pago" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:GridView ID="gvProducto" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="id_prod" HeaderText="Identificador del Producto" />
                    <asp:BoundField DataField="NombreProd" HeaderText="Nombre del Producto" />
                    <asp:BoundField DataField="Peso" HeaderText="Peso del Producto" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                    <asp:BoundField DataField="PrecioFinal" HeaderText="Total a Pagar" />
                    <asp:BoundField DataField="NotaEspecial" HeaderText="Nota Especial" />
                    <asp:BoundField DataField="F_Pedido" HeaderText="Identificador del Pedido" />
                </Columns>
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
</body>
</html>
