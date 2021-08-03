<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FCliente.aspx.cs" Inherits="Presentacion.FCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

        &nbsp;Clientes<br />
            <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvClientes_SelectedIndexChanged">
                <Columns>
                <asp:CommandField SelectText="Seleccionar Cliente" ShowSelectButton="True" />
                <asp:BoundField DataField="id_Cliente" HeaderText="Identificacion del Cliente" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre del Cliente" />
                <asp:BoundField DataField="App" HeaderText="Apellido Paterno" />
                <asp:BoundField DataField="ApM" HeaderText="Apellido Materno" />
                <asp:BoundField DataField="Celular" HeaderText="Celular del Cliente" />
                <asp:BoundField DataField="Correo" HeaderText="Correo del Cliente" />
            </Columns>
            </asp:GridView>
            <br />
            Nombre: <asp:TextBox ID="txbNombre" runat="server"></asp:TextBox>
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
            <asp:Button ID="btnInsertarCliente" runat="server" OnClick="btnInsertarCliente_Click" Text="Insertar Cliente" />
            <br />
            <br />
            <asp:Label ID="lbResp" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnActualizar" runat="server" OnClick="btnActualizar_Click" Text="Actualizar" Visible="False" />
            <br />
            <br />
            <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" Visible="False" />
            <br />
            <br />
            <br />

        </div>
    </form>
</body>
</html>
