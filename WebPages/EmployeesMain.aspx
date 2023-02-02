<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeesMain.aspx.cs" Inherits="EmployeesMain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Main Page</title>
</head>
<body>
    <form id="form1" runat="server">

    <div>
    <center>
    <b><h1> עובדי חברת כוח אדם</h1></center>
        <p> 
        <div dir=ltr>
            <asp:Button ID="Button1" runat="server" Text="הוספת עובד חדש" 
                BorderStyle=Groove BackColor="#00CC66" Font-Size="Medium" 
                onclick="Button1_Click"/></div>
        </p></b>
    
    </div>

    <div dir=rtl>
    <center>
        <asp:GridView ID="GridViewAllEmployees" runat="server" BackColor="White" 
            BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
            GridLines="Horizontal" AutoGenerateColumns="False" AllowPaging="True" 
            onpageindexchanging="GridViewAllEmployees_PageIndexChanging1" PageSize="6" 
            Font-Size="Large"
            onrowcommand="GridViewAllEmployees_RowCommand1">
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" Height="10px" Width="200px" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353"/>
            <Columns>
            <asp:BoundField DataField="FullName" HeaderText="שם מלא">

                </asp:BoundField>

                 <asp:BoundField DataField="Id" HeaderText="תעדות זהות" />

            <asp:ButtonField ButtonType="Image" ImageUrl="~/pic/employee1.png" 
                    CommandName="EmployeeCard" HeaderText="כרטיס עובד">

                </asp:ButtonField>

               
            </Columns>

<SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>

<SortedAscendingHeaderStyle BackColor="#487575"></SortedAscendingHeaderStyle>

<SortedDescendingCellStyle BackColor="#E5E5E5"></SortedDescendingCellStyle>

<SortedDescendingHeaderStyle BackColor="#275353"></SortedDescendingHeaderStyle>
        </asp:GridView>
        </center>
    </div>
    </form>
</body>
</html>
