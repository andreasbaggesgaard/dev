<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="dbHandin3.register" Theme="themeIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="registerpoke col-md-4">
        <h4>Pokehunter registration</h4>

           <asp:TextBox ID="TextBoxName" placeholder="Firstname" runat="server" CssClass="reg"></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName" EnableClientScript="False" ErrorMessage="Firstname is missing" ForeColor="Red"></asp:RequiredFieldValidator>
   <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server" ControlToValidate="TextBoxName" EnableClientScript="False" ErrorMessage="Your name must only contain letters" ForeColor="Red" ValidationExpression="^([ \u00c0-\u01ffa-zA-Z'\-])+$"></asp:RegularExpressionValidator>
     

            <asp:TextBox ID="TextBoxLastname" placeholder="Lastname" runat="server" CssClass="reg"></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidatorLastname" runat="server" ControlToValidate="TextBoxLastname" EnableClientScript="False" ErrorMessage="Lastname is missing" ForeColor="Red"></asp:RequiredFieldValidator>
   <asp:RegularExpressionValidator ID="RegularExpressionValidatorLastname" runat="server" ControlToValidate="TextBoxLastname" EnableClientScript="False" ErrorMessage="Your name must only contain letters" ForeColor="Red" ValidationExpression="^([ \u00c0-\u01ffa-zA-Z'\-])+$"></asp:RegularExpressionValidator>


            <asp:TextBox ID="TextBoxAlias" placeholder="Alias" CssClass="reg" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidatorAlias" runat="server" ControlToValidate="TextBoxAlias" EnableClientScript="False" ErrorMessage="Alias is missing" ForeColor="Red"></asp:RequiredFieldValidator>

            <asp:TextBox ID="TextBoxAge" placeholder="Age" CssClass="reg" runat="server"></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidatorAge" runat="server" ControlToValidate="TextBoxAge" EnableClientScript="False" ErrorMessage="Age is missing" ForeColor="Red"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidatorAge" runat="server" ControlToValidate="TextBoxAge" EnableClientScript="False" ErrorMessage="Your age must be between 10-99 in order to play this game" ForeColor="Red" MaximumValue="99" MinimumValue="10" Type="Integer"></asp:RangeValidator>

        <div class="form-group">
            <label>Gender</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorGender" runat="server" ControlToValidate="RadioButtonListGender" EnableClientScript="False" ErrorMessage="Gender is missing" ForeColor="Red"></asp:RequiredFieldValidator>

        <asp:RadioButtonList ID="RadioButtonListGender" runat="server">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
                </asp:RadioButtonList>
            </div>


            <asp:TextBox ID="TextBoxEmail" placeholder="Email" CssClass="reg" runat="server"></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ControlToValidate="TextBoxEmail" EnableClientScript="False" ErrorMessage="Email is missing" ForeColor="Red"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ControlToValidate="TextBoxEmail" EnableClientScript="False" ErrorMessage="It must be a valid email" ForeColor="Red" ValidationExpression="[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&amp;'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"></asp:RegularExpressionValidator>
                 
             <asp:TextBox ID="TextBoxPassword" placeholder="Password" CssClass="reg" runat="server"></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassowrd" runat="server" ControlToValidate="TextBoxPassword" EnableClientScript="False" ErrorMessage="Password is missing" ForeColor="Red"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxPassword" EnableClientScript="False" ErrorMessage="Your password must contain at least 1 capital letter, 8 characters, 1 alphabet and 1 special character" ForeColor="Red" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,100}$"></asp:RegularExpressionValidator>
         
             <asp:TextBox ID="TextBoxPasswordConfirm" placeholder="Confirm password" CssClass="reg" runat="server"></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidatorPasswordConfirm" runat="server" ControlToValidate="TextBoxPasswordConfirm" EnableClientScript="False" ErrorMessage="Confirm your password" ForeColor="Red"></asp:RequiredFieldValidator>
<asp:CompareValidator ID="CompareValidatorConfirm" runat="server" ControlToCompare="TextBoxPassword" ControlToValidate="TextBoxPasswordConfirm" EnableClientScript="False" ErrorMessage="It doesn't match your password - Try again" ForeColor="Red"></asp:CompareValidator>
                  
        <br />
        <br />
        <asp:Button ID="ButtonRegister" runat="server" Text="Sign up now"  class="btn btn-danger" OnClick="ButtonRegister_Click"/>
        
        <br />
        <br />
        <asp:Label ID="LabelMessage" runat="server" ValidateRequestMode="Disabled"></asp:Label>
        
        </div>

 </asp:Content>
