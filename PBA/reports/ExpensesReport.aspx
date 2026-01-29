<%@ Page Title="" Language="C#" MasterPageFile="~/PBA.Master" AutoEventWireup="true"
    CodeBehind="ExpensesReport.aspx.cs" Inherits="PBA.reports.ExpensesReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="../css/mainmaster.css" rel="stylesheet" />
    <link href="../css/controll.css" rel="stylesheet" />
    <link href="../css/bootstrap.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<link href="../Css/Mainmaster.css" rel="stylesheet" />
    <link href="../Css/Controll.css" rel="stylesheet" />
    <link href="../Css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <table>
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="lblHeading" runat="server" Text="Expenses Reports"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblExpense_Id" runat="server" Text="Expense_Id"></asp:Label>

            </td>
            <td>
                <asp:TextBox ID="txtExpense_Id" runat="server" 
                    ontextchanged="txtExpense_Id_TextChanged"></asp:TextBox>
            
            </td>
        </tr>
        <tr>
        <td colspan="2" align="center">
         <asp:GridView ID="GvExpensesReport" runat="server" CssClass="table table-striped table-hover" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GvUserDetails_SelectedIndexChanged">
                                            <AlternatingRowStyle BackColor="White" />
                                            <EditRowStyle BackColor="#2461BF" />
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                            <RowStyle BackColor="#EFF3FB" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                        </asp:GridView>
        </td>
        
        

        </tr>
        <tr>
        <td colspan="2" align="center">
            <asp:Button ID="btnGetdata" runat="server" Text="GetData" OnClick="btnGetdata_Click" />
            <asp:Button ID="btnReport" runat="server" Text="Generate Report" OnClick="btnReport_Click" />
            



        </td>
        </tr>
    </table>
</asp:Content>
