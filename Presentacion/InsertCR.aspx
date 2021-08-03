<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertCR.aspx.cs" Inherits="Presentacion.InsertCR" %>

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
            Carnicero
            o Repartidor<br />
            <br />
            Agregar:
            <asp:DropDownList ID="ddlRCarni" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRCarni_SelectedIndexChanged">
                <asp:ListItem>Carnicero</asp:ListItem>
                <asp:ListItem>Repartidor</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            Nombre:
            <asp:TextBox ID="txbNombre" runat="server"></asp:TextBox>
            <br />
            Celular:
            <asp:TextBox ID="txbCelular" runat="server"></asp:TextBox>
            <br />
            Correo:
            <asp:TextBox ID="txbCorreo" runat="server"></asp:TextBox>
            <br />
            Años de experiencia
            <asp:TextBox ID="txbAnios" runat="server"></asp:TextBox>
            <br />
            Licencia
            <asp:TextBox ID="txbLicencia" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <asp:Button ID="btnInsertCR" runat="server" Text="Insertar" OnClick="btnInsertCR_Click" />
            <br />
            <br />
            <asp:Label ID="lbResp" runat="server" Text="Label"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
