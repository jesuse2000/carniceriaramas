<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FProducto.aspx.cs" Inherits="Presentacion.FProducto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp;Productos<br />
            <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvProductos_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField SelectText="Seleccionar Producto" ShowSelectButton="True" />
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
            Nota Especial: <asp:TextBox ID="txbNotaEspecial" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
            <br />
            <br />
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
