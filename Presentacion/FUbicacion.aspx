<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FUbicacion.aspx.cs" Inherits="Presentacion.FUbicacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>CRUD Ubicaciones</title>
    <link rel="stylesheet" href="StyleSheet1.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</head>
<body style="background-color: darkseagreen">
    <!--Barra de Menu-->
    <header>
        <nav class="navegacion">
            <ul class="menu">
                <li class="ident"><a href="index.aspx">Alta de Clientes</a></li>
                <li class="ident"><a href="FormPedido.aspx">Pedido</a></li>
                <li class="ident"><a href="EPedido.aspx">Enviar</a></li>
                <li class="ident"><a href="Consultas.aspx">Consultas</a></li>
                <li class="inab">
                    <a>Actualización y Eliminación</a>
                    <ul class="submenu">
                        <li><a class="ident" href="FCarnicero.aspx">Carniceros</a></li>
                        <li><a class="ident" href="FCliente.aspx">Clientes</a></li>
                        <li><a class="ident" href="FEntregaPedido.aspx">Entregas</a></li>
                        <li><a class="ident" href="FPedidos.aspx">Pedidos</a></li>
                        <li><a class="ident" href="FProducto.aspx">Productos</a></li>
                        <li><a class="ident" href="FRepartidor.aspx">Repartidores</a></li>
                        <li><a class="inabSel">Ubicaciones</a></li>
                    </ul>
                </li>
                <li class="inab">
                    <a>Consultas</a>
                    <ul class="submenu">
                        <li><a class="ident" href="InsertCR.aspx">Carniceros y Repartidores</a></li>
                        <li><a class="ident" href="PClientes.aspx">Clientes</a></li>
                        <li><a class="ident" href="PRepatidor.aspx">Repartidor</a></li>
                    </ul>
                </li>
            </ul>
        </nav>
    </header>
    <!--Fin de barra de Menu-->
    <form id="form1" runat="server">
        <div class="container" id="formulario">
            <h2 class="pest">CRUD - Ubicación</h2>
            <br />
            <asp:GridView ID="gvUbicacion" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvUbicacion_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField SelectText="Seleccionar ubicacion" ShowSelectButton="True" />
                    <asp:BoundField DataField="id_ubicacion" HeaderText="Identificador de ubicacion" />
                    <asp:BoundField DataField="Colonia" HeaderText="Colonia" />
                    <asp:BoundField DataField="Calleynumero" HeaderText="Calle y Numero" />
                    <asp:BoundField DataField="Municipio" HeaderText="Municipio" />
                    <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" />
                    <asp:BoundField DataField="Referencia" HeaderText="Referencia" />
                    <asp:BoundField DataField="Caracteristica" HeaderText="Caracteristica" />
                    <asp:BoundField DataField="CP" HeaderText="Codigo Postal" />
                    <asp:BoundField DataField="F_Cliente" HeaderText="Identificador de Cliente" />
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
            <br />
            Colonia:
           
            <asp:TextBox ID="txbColonia" runat="server"></asp:TextBox>
            <br />
            <br />
            Calle y numero:
           
            <asp:TextBox ID="txbCalle" runat="server"></asp:TextBox>
            <br />
            <br />
            Municipio:
           
            <asp:TextBox ID="txbMunicipio" runat="server"></asp:TextBox>
            <br />
            <br />
            Ciudad:<asp:TextBox ID="txbCiudad" runat="server"></asp:TextBox>
            <br />
            <br />
            Referencia
           
            <asp:TextBox ID="txbReferencia" runat="server"></asp:TextBox>
            <br />
            <br />
            Caracteristica:
           
            <asp:TextBox ID="txbCaracteristica" runat="server"></asp:TextBox>
            <br />
            <br />
            Codigo Postal:
           
            <asp:TextBox ID="txbCP" runat="server"></asp:TextBox>
            <br />
            <br />
            Identificador del Cliente:&nbsp;
           
            <asp:DropDownList ID="ddlClientes" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnInsertar" class="btn btn-outline-success" runat="server" OnClick="btnInsertar_Click" Text="Insertar nueva ubicacion" />
            <br />
            <br />
            <asp:Label ID="lbResp" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnEliminar" class="btn btn-outline-danger" runat="server" Text="Eliminar Ubicacion" OnClick="btnEliminar_Click" />
            <br />
            <br />
            <br />
            Actualizar Ubicacion<br />
            <asp:GridView ID="gvUbAct" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvUbAct_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField SelectText="Seleccionar ubicacion" ShowSelectButton="True" />
                    <asp:BoundField DataField="id_ubicacion" HeaderText="Identificador de ubicacion" />
                    <asp:BoundField DataField="Colonia" HeaderText="Colonia" />
                    <asp:BoundField DataField="Calleynumero" HeaderText="Calle y Numero" />
                    <asp:BoundField DataField="Municipio" HeaderText="Municipio" />
                    <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" />
                    <asp:BoundField DataField="Referencia" HeaderText="Referencia" />
                    <asp:BoundField DataField="Caracteristica" HeaderText="Caracteristica" />
                    <asp:BoundField DataField="CP" HeaderText="Codigo Postal" />
                    <asp:BoundField DataField="F_Cliente" HeaderText="Identificador de Cliente" />
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
            <br />
            Identificador de la Ubicacion;
           
            <asp:TextBox ID="txbIUbicaAct" runat="server"></asp:TextBox>
            <br />
            <br />
            Colonia:<asp:TextBox ID="txbCAct" runat="server"></asp:TextBox>
            <br />
            <br />
            Calle y numero:<asp:TextBox ID="txbCaAct" runat="server"></asp:TextBox>
            <br />
            <br />
            Municipio:<asp:TextBox ID="txbMAct" runat="server"></asp:TextBox>
            <br />
            <br />
            Ciudad:<asp:TextBox ID="txbCiAct" runat="server"></asp:TextBox>
            <br />
            <br />
            Referencia:<asp:TextBox ID="txbRAct" runat="server"></asp:TextBox>
            <br />
            <br />
            Caracteristica:<asp:TextBox ID="txbCaraAct" runat="server"></asp:TextBox>
            <br />
            <br />
            Codigo Postal:<asp:TextBox ID="txbCodAct" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnActUb" class="btn btn-outline-warning" runat="server" OnClick="btnActUb_Click" Text="Actualizar Ubicacion" />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
</body>
</html>
