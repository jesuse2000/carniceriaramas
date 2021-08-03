<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FRepartidor.aspx.cs" Inherits="Presentacion.FRepartidor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvRepartidor" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvRepartidor_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField SelectText="Seleccionar Repartidor" ShowSelectButton="True" />
                    <asp:BoundField DataField="id_Repartidor" HeaderText="Identificador del Repartidor" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Celular" HeaderText="Celular" />
                    <asp:BoundField DataField="Licencia" HeaderText="Licencia" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            Celular<asp:TextBox ID="txbCelular" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnActualizar" runat="server" OnClick="btnActualizar_Click" Text="Actualizar" />
            <br />
            <br />
            <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
            <br />
        </div>
    </form>
</body>
</html>
