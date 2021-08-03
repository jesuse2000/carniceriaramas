<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FEntregaPedido.aspx.cs" Inherits="Presentacion.FEntregaPedido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Entrega de Pedidos<br />
            <br />
            
            <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvPedidos_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField SelectText="Seleccionar Entrega" ShowSelectButton="True" />
                    <asp:BoundField DataField="id_Entrega" HeaderText="Idetificador de Entrega" />
                    <asp:BoundField DataField="F_Pedido" HeaderText="Identificador de Pedido" />
                    <asp:BoundField DataField="F_Repartidor" HeaderText="Identificador de Repartidor" />
                    <asp:BoundField DataField="Salida" HeaderText="Hora de Salida" />
                    <asp:BoundField DataField="SeEntrego" HeaderText="Hora de Entrega" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado en que se entrego" />
                </Columns>
            </asp:GridView>
            
            <br />
            <br />
            Actualizar estado de entrega:
            <asp:TextBox ID="txbActEnt" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnActualizar" runat="server" OnClick="btnActualizar_Click" Text="Actualizar" />
            <br />
            <br />
            <br />
            <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
            <br />
            
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
