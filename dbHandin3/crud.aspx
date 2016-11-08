<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="crud.aspx.cs" Inherits="dbHandin3.crud" Theme="themeIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="jumbotron">
      <h1>Pokehunter</h1>
      <p>Welcome <b><asp:LoginName ID="LoginName1" runat="server" /></b> - Here you can catch new Pokémons, and delete those in your pokeball</p>
    </div>
    
    <h4>Caught Pokémons:</h4>
        <asp:GridView ID="GridViewPokemons" CssClass="table crud" runat="server" 
            OnSelectedIndexChanged="GridViewPokemons_SelectedIndexChanged"
            OnRowDeleting="GridViewPokemons_RowDeleting"
            >
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ControlStyle-CssClass="btn btn-danger btn-xs"/>
                <asp:CommandField ShowSelectButton="True" />
                <asp:ImageField DataImageUrlField="image" ControlStyle-Width="100">
                </asp:ImageField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="LabelMessage" runat="server" ForeColor="#33CC33"></asp:Label>
        <br />
        <br />
        <asp:Label ID="LabelSelected" runat="server" ForeColor="Black" Text="Edit pokemon name"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
&nbsp;&nbsp;
        <asp:Label ID="LabelPokemonName" runat="server" Text="Pokemon name"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" />

 <br />
     <br />
     <br />
     <asp:Literal ID="LiteralPokemon" runat="server"></asp:Literal>
     <br />
     <br />
     <asp:Button ID="ButtonCatchPokemon" runat="server" OnClick="ButtonCatchPokemon_Click" Text="Catch a Pokémon" />
     <br />
     <br />
     <asp:Label ID="LabelCatchMessage" runat="server"></asp:Label>

 </asp:Content>
