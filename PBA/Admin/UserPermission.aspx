<%@ Page Title="User Permission"
    Language="C#"
    MasterPageFile="~/PBA.Master"
    AutoEventWireup="true"
    CodeBehind="UserPermission.aspx.cs"
    Inherits="PBA.Admin.UserPermission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css/Mainmaster.css" rel="stylesheet" />
    <link href="../Css/Controll.css" rel="stylesheet" />
    <link href="../Css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container mt-4">

    <div class="card">
        <div class="card-header bg-primary text-white text-center">
            <h4>User Permission</h4>
        </div>

        <div class="card-body">

            <!-- Role Selection -->
            <div class="row mb-3">
                <div class="col-md-3">
                    <asp:Label ID="lblRole" runat="server" Text="Role Name" />
                </div>
                <div class="col-md-4">
                    <asp:DropDownList
                        ID="ddlRole"
                        runat="server"
                        CssClass="form-control"
                        AutoPostBack="true"
                        OnSelectedIndexChanged="ddlRole_SelectedIndexChanged" />
                </div>
            </div>

            <!-- User Selection -->
            <div class="row mb-3">
                <div class="col-md-3">
                    <asp:Label ID="lblUserName" runat="server" Text="User Name" />
                </div>
                <div class="col-md-4">
                    <asp:DropDownList
                        ID="ddlUsers"
                        runat="server"
                        CssClass="form-control"
                        AutoPostBack="true"
                        OnSelectedIndexChanged="ddlUsers_SelectedIndexChanged1" />
                </div>
            </div>

            <!-- Permission Grid -->
            <asp:GridView
                ID="Gvuserpermission"
                runat="server"
                AutoGenerateColumns="False"
                CssClass="table table-bordered table-striped"
                OnSelectedIndexChanged="Gvuserpermission_SelectedIndexChanged">

                <Columns>

                    <asp:CommandField ShowSelectButton="True" />

                    <asp:BoundField
                        DataField="Id"
                        HeaderText="Id" />

                    <asp:BoundField
                        DataField="ScreenName"
                        HeaderText="Screen Name" />

                    <asp:TemplateField HeaderText="Create">
                        <ItemTemplate>
                            <asp:CheckBox
                                runat="server"
                                Checked='<%# Convert.ToBoolean(Eval("IsCreate")) %>'
                                Enabled="false" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:CheckBox
                                runat="server"
                                Checked='<%# Convert.ToBoolean(Eval("IsUpdate")) %>'
                                Enabled="false" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:CheckBox
                                runat="server"
                                Checked='<%# Convert.ToBoolean(Eval("IsDelete")) %>'
                                Enabled="false" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="View">
                        <ItemTemplate>
                            <asp:CheckBox
                                runat="server"
                                Checked='<%# Convert.ToBoolean(Eval("IsView")) %>'
                                Enabled="false" />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>

            </asp:GridView>

        </div>
    </div>

</div>

</asp:Content>
