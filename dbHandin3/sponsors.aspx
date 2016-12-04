<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="sponsors.aspx.cs" Inherits="dbHandin3.sponsors" Theme="themeIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-md-12">
        <h4><b>Sponsors</b></h4>
    <div class="row">
        <div class="col-md-7">

        <asp:Repeater ID="RepeaterSponsors" runat="server">
            <HeaderTemplate>
                <table class="mdl-data-table mdl-js-data-table mdl-data-table--selectable mdl-shadow--2dp">
                    <thead>
                    <tr>
                        <td><b>Sponsor id</b></td>
                        <td><b>Company name</b></td>
                        <td><b>Website</b></td>
                        <td><b>Logo</b></td>
                    </tr>
                 </thead>
            </HeaderTemplate>
            <ItemTemplate>
                 <tbody>
                <tr>
                    <td><%# Eval("SponsorID") %></td>
                    <td><%# Eval("Companyname") %></td>
                    <td><%# Eval("Website") %></td>
                    <td><img src="images/<%# Eval("Logo") %>" alt="Sponsor Logo" width="100px"/></td>
                </tr>
                </tbody>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>

            </div>
            <div class="col-md-5">

                &nbsp;<asp:DropDownList ID="DropDownListSponsors" runat="server" Height="28px" Width="200px">
                </asp:DropDownList>

                <br />
                <br />
                <asp:TextBox ID="TextBoxId" CssClass="form-control" placeholder="Sponsor id" runat="server" Width="200px" ForeColor="#CCCCCC" ReadOnly="True"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBoxCompany" CssClass="form-control" placeholder="Company name" runat="server" Width="200px"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBoxWebsite" CssClass="form-control" placeholder="Website" runat="server" Width="200px"></asp:TextBox>
                <br />
                <asp:FileUpload ID="fileUpload" runat="server" /><br /><br />
                <%--<asp:TextBox ID="TextBoxLogo" CssClass="form-control" placeholder="Logo" runat="server" Width="200px"></asp:TextBox>--%>
                <br />
                <asp:Label ID="LabelMessages" runat="server" Font-Bold="True"></asp:Label>
                <br />
          <br />


                <asp:Button ID="ButtonCreate" runat="server" Text="Create" CssClass="btn btn-success" OnClick="ButtonCreate_Click" />
&nbsp;&nbsp;
                <asp:Button ID="ButtonUpdate" runat="server" Text="Update" CssClass="btn btn-warning" OnClick="ButtonUpdate_Click" />
&nbsp;&nbsp;
                <asp:Button ID="ButtonDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="ButtonDelete_Click" />
&nbsp;&nbsp;
                <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" CssClass="btn btn-default" OnClick="ButtonCancel_Click" />

            </div>
        </div>
    </div>

 </asp:Content>

