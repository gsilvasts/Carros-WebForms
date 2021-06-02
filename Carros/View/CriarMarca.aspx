<%@ Page Title="" Language="C#" MasterPageFile="~/View/AccessBrasil.Master" AutoEventWireup="true" CodeBehind="CriarMarca.aspx.cs" Inherits="Carros.View.CriarMarca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <h1>Cadastro de Marca</h1>
            <div class="form-group col-md-4">
                <asp:Label runat="server" AssociatedControlID="txtMarca">Marca </asp:Label>
                <asp:TextBox runat="server" ID="txtMarca" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="requiredMarca" runat="server" ControlToValidate="txtMarca" ErrorMessage="Por Favor, digite a marca a ser cadastrada!" ForeColor="Red">
                </asp:RequiredFieldValidator>
            </div>
            <p>
                <asp:Label ID="lblMensagem" runat="server" ForeColor="Red"></asp:Label>
            </p>
            <br />
            <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" CssClass="btn btn-primary" />
        </div>
    </form>
</asp:Content>
