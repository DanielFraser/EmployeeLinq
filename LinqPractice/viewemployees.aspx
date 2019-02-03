<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewemployees.aspx.cs" Inherits="LinqPractice.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://code.jquery.com/jquery-3.3.1.js" integrity="sha256-2Kok7MbOyxpgUVvAk/HJ2jigOSYS2auK4Pfzbm7uH60="
        crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm"
        crossorigin="anonymous">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl"
        crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q"
        crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="float: left; width: 10vw; margin-right: 5px">
            <asp:Button runat="server" Text="Order by Department" OnClick="orderByDept" CssClass="btn btn-warning" Style="margin-top: 20px;" />
            <br />
            <asp:Button runat="server" Text="Employee Name ToUpper" OnClick="toUpper" CssClass="btn btn-dark" Style="margin-top: 20px;" /><br />
            <asp:Button runat="server" Text="Highest Salary" OnClick="highestSalary" CssClass="btn btn-success" Style="margin-top: 20px;" /><br />
            <asp:Button runat="server" Text="Test Transaction" OnClick="addNewItems" CssClass="btn btn-danger" Style="margin-top: 20px;" /><br />
        </div>
        <asp:GridView Style="width: 80vw; float: right" CssClass="table table-bordered table-striped table-responsive" ID="employeetbl" runat="server" AllowPaging="true" PageSize="5" OnPageIndexChanging="empgrid_PageIndexChanging">
            <HeaderStyle CssClass="thead-dark" />
        </asp:GridView>


    </form>
</body>
</html>
