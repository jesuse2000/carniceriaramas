<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FCarnicero.aspx.cs" Inherits="Presentacion.FCarnicero" %>

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
            <asp:GridView ID="gvCarnicero" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvCarnicero_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField SelectText="Seleccionar Carnicero" ShowSelectButton="True" />
                    <asp:BoundField DataField="id_Carnicero" HeaderText="Identificador del Carnicero" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre del Carnicero" />
                    <asp:BoundField DataField="Celular" HeaderText="Celular del Carnicero" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo" />
                    <asp:BoundField DataField="Exp_anios" HeaderText="Años de Experiencia" />
                </Columns>
            </asp:GridView>
            <br />
            <br />
            Celular: <asp:TextBox ID="txbCelular" runat="server"></asp:TextBox>
            <br />
            Correo:
            <asp:TextBox ID="txbCorreo" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnActualizar" runat="server" OnClick="btnActualizar_Click" Text="Actualizar" Visible="False" />
            <br />
            <br />
            <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" Visible="False" />
            <br />
            <br />

        </div>
    </form>
</body>
</html>
