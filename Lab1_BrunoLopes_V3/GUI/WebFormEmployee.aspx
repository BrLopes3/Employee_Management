<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormEmployee.aspx.cs" Inherits="Lab1_BrunoLopes_V3.GUI.WebFormEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 67%;
        }
        .auto-style2 {
            text-align: center;
            font-size: large;
            background-color: #3399FF;
        }
        .auto-style3 {
            width: 179px;
        }
        .auto-style4 {
            width: 227px;
        }
        .auto-style5 {
            width: 27px;
        }
        .auto-style6 {
            width: 179px;
            height: 31px;
        }
        .auto-style7 {
            width: 227px;
            height: 31px;
        }
        .auto-style8 {
            width: 27px;
            height: 31px;
        }
        .auto-style9 {
            height: 31px;
        }
        .auto-style10 {
            width: 202px;
        }
        .auto-style11 {
            height: 31px;
            width: 202px;
        }
        .auto-style12 {
            width: 55px;
        }
        .auto-style13 {
            height: 31px;
            width: 55px;
        }
        .auto-style14 {
            width: 179px;
            height: 9px;
        }
        .auto-style15 {
            width: 227px;
            height: 9px;
        }
        .auto-style16 {
            width: 27px;
            height: 9px;
        }
        .auto-style17 {
            height: 9px;
            width: 202px;
        }
        .auto-style18 {
            height: 9px;
            width: 55px;
        }
        .auto-style19 {
            height: 9px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2" colspan="6"><strong>Employee Maintenance</strong></td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style12">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Employee ID: </td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextBoxID" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style10">
                    <asp:Button ID="ButtonSave" runat="server" OnClick="ButtonSave_Click" Text="Save" Width="124px" />
                </td>
                <td class="auto-style12">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">First Name:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextBoxFirstName" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style10">
                    <asp:Button ID="ButtonUpdate" runat="server" OnClick="ButtonUpdate_Click" Text="Update" Width="124px" />
                </td>
                <td class="auto-style12">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Last Name:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style10">
                    <asp:Button ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" Text="Delete" Width="124px" />
                </td>
                <td class="auto-style12">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Job Title:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextBoxJobTitle" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style10">
                    <asp:Button ID="ButtonList" runat="server" OnClick="ButtonList_Click" Text="List All" Width="124px" />
                </td>
                <td class="auto-style12">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style12">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Search By:</td>
                <td class="auto-style4">
                    <asp:DropDownList ID="DropDownListSearchOption" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListSearchOption_SelectedIndexChanged" Width="170px">
                    </asp:DropDownList>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style10">
                    <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="Search" Width="124px" />
                </td>
                <td class="auto-style12">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="LabelDisplay" runat="server"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="TextBoxInput" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style12">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="LabelLastName" runat="server"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="TextBoxInputLastName" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style8"></td>
                <td class="auto-style11"></td>
                <td class="auto-style13"></td>
                <td class="auto-style9"></td>
            </tr>
            <tr>
                <td class="auto-style14"></td>
                <td class="auto-style15"></td>
                <td class="auto-style16"></td>
                <td class="auto-style17"></td>
                <td class="auto-style18"></td>
                <td class="auto-style19"></td>
            </tr>
            <tr>
                <td colspan="4" rowspan="2">
                    <asp:GridView ID="GridViewEmployee" runat="server" Width="537px">
                    </asp:GridView>
                </td>
                <td class="auto-style12">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
