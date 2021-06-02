<%@ Page Title="" Language="C#" MasterPageFile="~/View/AccessBrasil.Master" AutoEventWireup="true" CodeBehind="CriarModelo.aspx.cs" Inherits="Carros.View.CriarModelo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <div class="container">
                <h1>Cadastro de Modelo</h1>
                <div class="form-group col-md-4">
                    <asp:Label runat="server" AssociatedControlID="ddlMarca">Selecione a Marca</asp:Label>
                    <asp:DropDownList runat="server" ID="ddlMarca" DataTextField="DescMarca" DataValueField="CodMarca" CssClass="form-control custom-select"></asp:DropDownList>
                </div>
                <div class="form-group col-md-4">
                    <asp:Label runat="server" AssociatedControlID="txtModelo">Modelo </asp:Label>
                    <asp:TextBox runat="server" ID="txtModelo" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="requiredModelo" runat="server" ControlToValidate="txtModelo" ErrorMessage="Por Favor, digite o modelo a ser cadastrado!" ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </div>
                <p>
                    <asp:Label ID="lblMensagem" runat="server" ForeColor="Red"></asp:Label>
                </p>
                <br />
                <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" CssClass="btn btn-primary" />
            </div>
        </div>
    </form>
</asp:Content>
