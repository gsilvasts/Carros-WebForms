<%@ Page Title="" Language="C#" MasterPageFile="~/View/AccessBrasil.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="Carros.View.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <h1>Editar Dados</h1>
            <div class="container">
                <div class="row">
                    <asp:Label runat="server" AssociatedControlID="ddlCarro">Selecione um veículo</asp:Label>
                    <div class="form-group col-md-4">
                        <asp:DropDownList runat="server" ID="ddlCarro" DataTextField="Carro" DataValueField="CodCarro" CssClass="form-control custom-select"></asp:DropDownList>
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" CssClass="btn btn-primary" OnClick="btnPesquisar_Click" />
                    </div>
                    <p>
                        <asp:Label ID="lblMensagem" runat="server" ForeColor="Red"></asp:Label>
                    </p>
                </div>
            </div>
            <br />
            <br />
            <asp:Panel ID="pnlEditar" runat="server">
                <div class="container">
                    <div class="form-group col-md-4">
                        <asp:Label runat="server" AssociatedControlID="ddlModelo">Marca e Modelo</asp:Label>
                        <asp:DropDownList runat="server" ID="ddlModelo" DataTextField="Modelo" DataValueField="CodModelo" CssClass="form-control custom-select"></asp:DropDownList>
                    </div>
                    <div class="form-group col-md-2">
                        <asp:Label runat="server" AssociatedControlID="txtAno">Ano</asp:Label>
                        <asp:TextBox runat="server" ID="txtAno" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="requiredAno" runat="server" ControlToValidate="txtAno" ErrorMessage="Por Favor, Digite o ano do veículo." ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-md-2">
                        <asp:Label runat="server" AssociatedControlID="txtCor">Cor</asp:Label>
                        <asp:TextBox runat="server" ID="txtCor" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="requiredCor" runat="server" ControlToValidate="txtCor" ErrorMessage="Por Favor, Digite a cor do veículo." ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </div>
                    <br />
                    <asp:Button ID="btnAtualizar" runat="server" Text="Atualizar" CssClass="btn btn-success" OnClick="btnAtualizar_Click" />                    
                </div>
            </asp:Panel>
        </div>
    </form>
</asp:Content>
