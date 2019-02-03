<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewemployees.aspx.cs" Inherits="LinqPractice.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="employeetbl" runat="server" AllowPaging="true" PageSize="5" OnPageIndexChanging="empgrid_PageIndexChanging">
        </asp:GridView>
        <asp:Button runat="server" Text="Order by Department" OnClick="orderByDept" />
        <asp:Button runat="server" Text="Employee Name ToUpper" OnClick="toUpper" />
        <asp:Button runat="server" Text="Highest Salary" OnClick="highestSalary" />
        <asp:Button runat="server" Text="Test Transaction" OnClick="addNewItems" />
    </form>
</body>
</html>
