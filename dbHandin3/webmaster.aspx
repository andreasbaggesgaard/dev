<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="webmaster.aspx.cs" Inherits="dbHandin3.webmaster"  Theme="themeIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="jumbotron">
      <h1>Administrator</h1>
      <p>Welcome <b><asp:LoginName ID="LoginName1" runat="server" /></b> - Here you can create, read, update and delete pokémons</p>
    </div>

   <div class="row">
            <div class="col-md-9">
              <asp:GridView ID="GridViewPokemons"  class="table" runat="server" OnSelectedIndexChanged="GridViewPokemons_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="table-select" />
            </Columns>
        </asp:GridView>
   <a href="sponsors.aspx" style="font-weight:bolder;font-size:20px;"><span class="glyphicon glyphicon-circle-arrow-right" aria-hidden="true"></span> Manage sponsors</a>
       </div>
       <div class="col-md-3">
           <h4>Select a Pokémon</h4>
          <div class="form-group">
            <label>Number</label>
              <asp:TextBox ID="TextBoxEditNumber" class="form-control" runat="server"></asp:TextBox>
         </div>
           <div class="form-group">
            <label>Name</label>
              <asp:TextBox ID="TextBoxEditName" class="form-control" runat="server"></asp:TextBox>
         </div>
           <div class="form-group">
            <label>Next evolution</label>
              <asp:TextBox ID="TextBoxEditNextEvo" class="form-control" runat="server"></asp:TextBox>
         </div>
            <div class="form-group">
            <label>Image</label>
              <asp:TextBox ID="TextBoxEditImage" class="form-control" runat="server"></asp:TextBox>
         </div>
        <asp:Button ID="ButtonUpdate" class="btn btn-primary" runat="server" OnClick="ButtonUpdate_Click" Text="Update" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonDelete" class="btn btn-danger" runat="server" Text="Delete" OnClick="ButtonDelete_Click" />
        <br />
        <br />
        <asp:Label ID="LabelEditMessage" CssClass="bold-style" runat="server"></asp:Label>

           <!-- create pokemon -->
           <hr />
         <div class="createPokemon">
             <h4>Create a Pokémon</h4>
          <div class="form-group">
            <label>Number</label>
                 <asp:TextBox ID="TextBoxNumber" class="form-control" runat="server"></asp:TextBox>
         </div>
             <div class="form-group">
            <label>Name</label>
                 <asp:TextBox ID="TextBoxName" class="form-control" runat="server"></asp:TextBox>
         </div>
             <div class="form-group">
            <label>Next Evolution</label>
                 <asp:TextBox ID="TextBoxNextEvo" class="form-control" runat="server"></asp:TextBox>
         </div>
             <div class="form-group">
            <label>Image</label>
                 <asp:TextBox ID="TextBoxImage" class="form-control" runat="server"></asp:TextBox>
         </div>
        
        <asp:Button ID="ButtonCreate" class="btn btn-success" runat="server" OnClick="ButtonCreate_Click" Text="Create" />
        <br />
        <br />
        <asp:Label ID="LabelMessage" runat="server" CssClass="bold-style" ></asp:Label>

       </div>
   </div>
       </div>



     



 </asp:Content>
