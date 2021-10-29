<%@ Page Title="" Language="C#" MasterPageFile="~/Escritorio_MP.master" AutoEventWireup="true" CodeFile="Escritorio.aspx.cs" Inherits="Escritorio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div style="text-align: center">
        <h1>Bienvenido, <asp:Label ID="lblSaludoUsuario" runat="server" Text=""></asp:Label></h1>
   </div>
</asp:Content>

