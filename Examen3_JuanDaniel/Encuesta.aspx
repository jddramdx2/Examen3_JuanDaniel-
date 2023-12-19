<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Encuesta.aspx.cs" Inherits="Examen3_JuanDaniel.Encuesta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Encuesta</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Encuesta examen final Juan Daniel Diaz Redondo</h2>
            <div>
                <asp:Label runat="server" AssociatedControlID="txtNumeroEncuesta">Número de Encuesta:</asp:Label>
                <asp:TextBox runat="server" ID="txtNumeroEncuesta" Enabled="false"></asp:TextBox>
            </div>
            <div>
                <asp:Label runat="server" AssociatedControlID="txtNombre">Nombre del Participante:</asp:Label>
                <asp:TextBox runat="server" ID="txtNombre" required="true"></asp:TextBox>
            </div>
            <div>
                <asp:Label runat="server" AssociatedControlID="txtEdad">Edad de Nacimiento:</asp:Label>
                <asp:TextBox runat="server" ID="txtEdad" TextMode="Number" required="true" min="18" max="50"></asp:TextBox>
            </div>
            <div>
                <asp:Label runat="server" AssociatedControlID="txtCorreo">Correo Electrónico:</asp:Label>
                <asp:TextBox runat="server" ID="txtCorreo" TextMode="Email" required="true"></asp:TextBox>
            </div>
            <div>
                <asp:Label runat="server" AssociatedControlID="ddlPartido">Partido Político:</asp:Label>
                <asp:DropDownList runat="server" ID="ddlPartido" required="true">
                    <asp:ListItem Text="PLN" Value="PLN"></asp:ListItem>
                    <asp:ListItem Text="PUSC" Value="PUSC"></asp:ListItem>
                    <asp:ListItem Text="PAC" Value="PAC"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <asp:Button runat="server" ID="btnEnviarEncuesta" Text="Enviar Encuesta" OnClick="btnEnviarEncuesta_Click" />
                <asp:Button runat="server" ID="btnGenerarReporte" Text="Generar Reporte" OnClick="btnGenerarReporte_Click" />
            </div>
        </div>
    </form>
</body>
</html>