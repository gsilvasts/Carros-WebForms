<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Carros.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
</head>

<body>
    <header>
        <div class="navbar navbar-expand-lg navbar-light bg-light" role="navigation">
            <a class="navbar-brand" href="Default.aspx">Access Brasil</a>
            <div class="collapse navbar-collapse" id="navbarText">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item">
                        <a class="nav-link active" href="CadastrarVeiculo.aspx">Cadastrar</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="CriarMarca.aspx">Marca</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="CriarModelo.aspx">Modelo</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="Editar.aspx">Editar Veículo</a>
                    </li>
                </ul>
            </div>
        </div>
    </header>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Loja de Carros</h2>
            <div class="container form-control">
                <asp:GridView ID="gridCarros" runat="server" CssClass="table table-hover table-striped" DataKeyNames="CodCarro" GridLines="None" AutoGenerateColumns="false" SelectMethod="gridCarros_GetData" DeleteMethod="gridCarros_DeleteItem">
                    <Columns>
                        <asp:BoundField DataField="DescMarca" HeaderText="Marca" />
                        <asp:BoundField DataField="DescModelo" HeaderText="Modelo" />
                        <asp:BoundField DataField="Ano" HeaderText="Ano" />
                        <asp:BoundField DataField="Cor" HeaderText="Cor" />
                        <asp:ButtonField ButtonType="Button" CommandName="Delete" runat="server" Text="Excluir" ControlStyle-CssClass="btn btn-outline-danger" />
                    </Columns>
                    <RowStyle CssClass="cursor-pointer" />
                </asp:GridView>
            </div>
            <p>
                <asp:Label ID="lblMensagem" runat="server"></asp:Label>
            </p>
        </div>
    </form>
</body>
</html>
