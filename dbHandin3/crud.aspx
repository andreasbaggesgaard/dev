<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="crud.aspx.cs" Inherits="dbHandin3.crud" Theme="themeIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="jumbotron" style="min-height: 415px;">
         <div class="row">
         <div class="col-md-8">
      <h1>Pokehunter</h1>
      <p>Welcome <b><asp:LoginName ID="LoginName1" runat="server" /></b> - Here you can catch new Pokémons, evolve existing ones and delete those in your pokeball</p>
             <br />
             <br />
            <asp:Button ID="ButtonCatchPokemon" runat="server" OnClick="ButtonCatchPokemon_Click" Text="Catch a Pokémon" CssClass="trycatch btn btn-danger explore"/>
             <br />
             <br />
            <asp:Literal ID="LiteralCatchMessage" runat="server"></asp:Literal>
        </div>
         <div class="col-md-4">
             <div class="pokemon-container pull-right">
                 <div class="literalpokemon" style="height: 300px; width: 200px;">
                  <asp:Literal ID="LiteralPokemon" runat="server"></asp:Literal>

                     <br />
                     <br />

                     <asp:Button type='button' ID='ButtonCatch' runat='server' OnClick='ButtonCatch_Click' CssClass='btn btn-warning cb' Text='Try to catch' />

                     </div>   
                 </div>
          </div>
        </div>
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

     <br />
     <br />
    

 </asp:Content>
