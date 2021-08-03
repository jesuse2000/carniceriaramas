<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FPedidos.aspx.cs" Inherits="Presentacion.FPedidos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Pedidos
            <br />
            <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvPedidos_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField SelectText="Seleccionar Pedido" ShowSelectButton="True" />
                    <asp:BoundField DataField="id_Pedido" HeaderText="Identificador del Pedido" />
                    <asp:BoundField DataField="FechaHora" HeaderText="Fecha y Hora del Pedido" />
                    <asp:BoundField DataField="F_Cliente" HeaderText="Identificador del Cliente" />
                    <asp:BoundField DataField="F_Carnicero" HeaderText="Identificador del Carnicero" />
                    <asp:BoundField DataField="Envio" HeaderText="Envio del Pedido" />
                    <asp:BoundField DataField="Pago" HeaderText="Forma del Pago" />
                </Columns>
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
        </div>
    </form>
</body>
</html>
