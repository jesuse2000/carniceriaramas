<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormPedido.aspx.cs" Inherits="Presentacion.FormPedido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Pedido<br />
            <br />
            <asp:Label ID="lbTel" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Telefono: "></asp:Label>
            <asp:TextBox ID="txbTelefono" runat="server" Enabled="False"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator_Colonia" ControlToValidate="txbTelefono"
            ErrorMessage="*requerido" ForeColor="Red" ValidationGroup="form_ejm"></asp:RequiredFieldValidator>
            <br />
            <br />
            Envio: <asp:DropDownList ID="ddlEnvio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEnvio_SelectedIndexChanged">
                <asp:ListItem Value="1">Envio a domicilio</asp:ListItem>
                <asp:ListItem Value="0">Recoger en la sucursal</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            Forma de pago:
            <asp:DropDownList ID="ddlSucursal" runat="server" Visible="False">
                <asp:ListItem>Pago Electronico</asp:ListItem>
                <asp:ListItem>Pago en la sucursal</asp:ListItem>
            </asp:DropDownList>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlRepartidor" runat="server" Visible="False">
                <asp:ListItem>Pago al repartidor</asp:ListItem>
                <asp:ListItem>Pago electronico</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            Nombre del producto:&nbsp;
            <asp:TextBox ID="txbNomP" runat="server" CssClass="auto-style1"></asp:TextBox>
            <br />
            <br />
            Peso:&nbsp;
            <asp:TextBox ID="txbPeso" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txbTelefono"
            ErrorMessage="*requerido" ForeColor="Red" ValidationGroup="form_ejm"></asp:RequiredFieldValidator>
            <br />
            <br />
            Cantidad (Precio):&nbsp;
            <asp:TextBox ID="txbCantidad" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txbTelefono"
            ErrorMessage="*requerido" ForeColor="Red" ValidationGroup="form_ejm"></asp:RequiredFieldValidator>
            <br />
            <br />
            Nota Especial:&nbsp;&nbsp;
            <asp:TextBox ID="txbNotaFinal" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lbResp" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            Precio Final:&nbsp;
            <asp:TextBox ID="txbPFinal" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnInsertPedido" runat="server" OnClick="btnInsertPedido_Click" Text="Realizar Pedido" ValidationGroup="form_ejm"/>
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
