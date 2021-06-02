<%@ Page Title="" Language="C#" MasterPageFile="~/View/AccessBrasil.Master" AutoEventWireup="true" CodeBehind="CadastrarVeiculo.aspx.cs" Inherits="Carros.View.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <h1>Cadastro de Carros</h1>
            <div class="container">                    
                    <div class="form-group col-md-4">
                        <asp:Label runat="server" AssociatedControlID="ddlModelo">Selecione o modelo do veículo </asp:Label>
                        <asp:DropDownList runat="server" ID="ddlModelo" DataTextField="Modelo" DataValueField="CodModelo" CssClass="form-control custom-select"></asp:DropDownList>
                    </div>
                    <div class="form-group col-md-2">
                        <asp:Label runat="server" AssociatedControlID="txtAno">Ano: </asp:Label>
                        <asp:TextBox runat="server" ID="txtAno" CssClass="form-control" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="requiredAno" runat="server" ControlToValidate="txtAno" ErrorMessage="Por Favor, Digite o ano do veículo." ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group col-md-2">
                        <asp:Label runat="server" AssociatedControlID="txtCor">Cor: </asp:Label>
                        <asp:TextBox runat="server" ID="txtCor" CssClass="form-control"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="requiredCor" runat="server" ControlToValidate="txtCor" ErrorMessage="Por Favor, Digite a cor do veículo." ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    </div>

                    <p>
                        <asp:Label ID="lblMensagem" runat="server" ForeColor="Red"></asp:Label>
                    </p>
                    <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" CssClass="btn btn-primary" />                     
            </div>
        </div>
    </form>

</asp:Content>
