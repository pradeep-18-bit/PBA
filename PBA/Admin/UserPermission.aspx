<%@ Page Title="" Language="C#" MasterPageFile="~/PBA.Master" AutoEventWireup="true"
    CodeBehind="UserPermission.aspx.cs" Inherits="PBA.Admin.UserPermission" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
<link href="../Css/Mainmaster.css" rel="stylesheet" />
    <link href="../Css/Controll.css" rel="stylesheet" />
    <link href="../Css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Css/Mainmaster.css" rel="stylesheet" />
    <link href="../Css/Controll.css" rel="stylesheet" />
    <link href="../Css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <div class="card-header text-center bg-primary text-white">
        <asp:Label ID="lblheading" runat="server" Text="USER PERMISSION"></asp:Label>
    </div>
    <table align="center">
        <tr>
            <td>
                <asp:Label ID="lblRole" runat="server" Text="Role Name"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlRole" Width="100px" CssClass="dropdown" runat="server" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlRole_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblUserName" runat="server" Text="User Name"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlUsers" runat="server" AutoPostBack ="true" 
                    onselectedindexchanged="ddlUsers_SelectedIndexChanged1">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:GridView ID="Gvuserpermission" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnSelectedIndexChanged="Gvuserpermission_SelectedIndexChanged">
                    <Columns>
                        <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="select" ShowHeader="True"
                            Text="select" />
                        <asp:TemplateField HeaderText="ID">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtid" runat="server" Text='<%# Bind("id") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Screen Name">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtScreenMame" runat="server" Text='<%# Bind("ScreenName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblscreenName" runat="server" Text='<%# Bind("ScreenName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Is Create">
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkIsCreate" Checked='<%# Convert.ToBoolean(Eval("IsCreate")) %>'
                                    runat="server" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="ckIsCreate" Checked='<%# Convert.ToBoolean(Eval("IsCreate")) %>'
                                    runat="server" Enabled="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Is Edit">
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkIsEdit" Checked='<%# Convert.ToBoolean(Eval("IsUpdate")) %>'
                                    runat="server" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="ckIsEdit" Checked='<%# Convert.ToBoolean(Eval("IsUpdate")) %>'
                                    runat="server" Enabled="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Is Delete">
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkIsDelete" Checked='<%# Convert.ToBoolean(Eval("IsDelete")) %>'
                                    runat="server" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="ckIsDelete" Checked='<%# Convert.ToBoolean(Eval("IsDelete")) %>'
                                    runat="server" Enabled="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Is View">
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkIsview" Checked='<%# Convert.ToBoolean(Eval("IsView")) %>' runat="server" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="ckIsView" Checked='<%# Convert.ToBoolean(Eval("IsView")) %>' runat="server"
                                    Enabled="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
