<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EPedido.aspx.cs" Inherits="Presentacion.EPedido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Telefono del Cliente <asp:TextBox ID="txbTel" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator_Colonia" ControlToValidate="txbTel"
            ErrorMessage="*requerido" ForeColor="Red" ValidationGroup="form_ejm"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Button ID="btnInsertar" runat="server" Text="Enviar Pedido" OnClick="btnInsertar_Click" ValidationGroup="form_ejm"/>
            <br />
            <br />
            <asp:Label ID="lbResp" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Estado"></asp:Label>
            <asp:DropDownList ID="ddlEstado" runat="server">
                <asp:ListItem>Excelente</asp:ListItem>
                <asp:ListItem>Regular</asp:ListItem>
                <asp:ListItem>Malo</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" ValidationGroup="form_ejm"/>
            <br />
            <asp:Label ID="lbResp2" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
