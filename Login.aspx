<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <table align="center" cellpadding="6" cellspacing="0" width="800px" 
                    class="table123">
                    <tr>
                        <td colspan="3" class="title123">
                            Login&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblMsg" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="trr">
                            Email Id
                        </td>
                        <td class="trd">
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtuname" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="trr">
                            Password
                        </td>
                        <td class="trd">
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtpwd" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:LinkButton ID="LinkButton1" runat="server" 
                                PostBackUrl="~/DealerRegis.aspx">DealerRegistration</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/ForgotPassword.aspx">Forgot 
                    Password</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnLogin" runat="server" Text="Login" ValidationGroup="v" OnClick="btnLogin_Click"
                                Font-Bold="True" CssClass="button" />
                            &nbsp;
                            <asp:Button ID="btnCancel" runat="server" onclick="btnCancel_Click" 
                                Text="Cancel" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

