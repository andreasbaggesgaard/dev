﻿<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="dbHandin3.Index" Theme="themeIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="banner" role="banner">
      <div class="overlay">
        <div class="container">
            <div class="col-md-10 col-md-offset-1">
                <div class="banner-text text-center">
                    <h1>Join today</h1>
                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent commodo cursus magna vel scelerisque nisl consectetur et.</p>

                    <a href="#" data-toggle="modal"  class="btn btn-large" data-target="#login-modal">Login</a>

                </div>
            </div>
        </div>
          </div>
    </section>

    <div class="modal fade" id="login-modal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
    	  <div class="modal-dialog">
				<div class="loginmodal-container">
					<h1>Login to Your Account</h1><br>
				                <asp:TextBox ID="TextBoxAlias" placeholder="Alias" runat="server"></asp:TextBox>      
    <asp:RequiredFieldValidator ID="RequiredFieldValidatorAlias" runat="server" ControlToValidate="TextBoxAlias" EnableClientScript="False" ErrorMessage="Password is missing" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
<br />
        <asp:TextBox ID="TextBoxPassword" placeholder="Password" runat="server"></asp:TextBox>      
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxPassword" EnableClientScript="False" ErrorMessage="Alias is missing" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
     <br />
        <asp:Button ID="ButtonLogin" runat="server" class="btn btn-large" OnClick="ButtonLogin_Click" Text="Login" />

        <asp:Label ID="LabelMessage" runat="server" foreColor="red"></asp:Label>
					
				  <div class="login-help">
					<a href="#">Register</a>
				  </div>
				</div>
			</div>
		  </div>


    <!-- -->
     <div class="row">
         <h3 style="text-align:center;margin-top:5%;margin-bottom:5%;">Wild Pokémons waiting to be caught!</h3>
         <div class="col-md-12">
            <asp:Repeater ID="RepeaterPokemons" runat="server">
            <ItemTemplate>             
                    <div style="float:left;margin-left: 12%;">
                        <img src="<%# Eval("image") %>" width="200"/>                   
               </div>
            </ItemTemplate>
        </asp:Repeater>
             </div>
    </div>
    <br />
    <br />
    <hr />
    <div class="row" style="min-height:400px">
         <h3 style="text-align:center;margin-top:5%;margin-bottom:5%;"><b>Sponsors</b></h3>
         <div class="col-md-12">
             <div style="margin-left:17%">
            <asp:Repeater ID="RepeaterSponsors" runat="server">
            <ItemTemplate>             
                    <div style="float:left;margin-left: 12%;">
                        <td><img src="images/<%# Eval("Logo") %>" alt="Sponsor Logo" width="100px"/></td>                  
               </div>
            </ItemTemplate>
        </asp:Repeater>
                 </div>
             </div>
    </div>

    
    
 </asp:Content>
