<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewEmployee.aspx.cs" Inherits="NewEmployee" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <center><h1>הוספת עובד חדש</h1></center>
    <div>
    
        <br />
    
    </div>
    <center>
    <asp:Label ID="Label1" runat="server" Text="שם מלא"></asp:Label>
       <p>
    <asp:TextBox ID="NameTB" runat="server"></asp:TextBox>
    </p>
    <p>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ErrorMessage="אנא הכנס ערך" ControlToValidate="NameTB" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <asp:Label ID="Label2" runat="server" Text="תעודת זהות" ></asp:Label>
    <p>
        <asp:TextBox ID="IdTB" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
            ErrorMessage="הכנס מספר תז תקין" ValidationExpression="[0-9]{9}" 
            ControlToValidate="IdTB" ForeColor="Red"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ErrorMessage="אנא הכנס ערך" ControlToValidate="IdTB" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
        <p>
        <asp:Label ID="Label3" runat="server" Text="כתובת מגורים"></asp:Label>
    </p>
    <p>
        <asp:TextBox ID="AddressTB" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ErrorMessage="אנא הכנס ערך" ControlToValidate="AddressTB" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
        <p>
        <asp:Label ID="Label4" runat="server" Text="תאריך לידה"></asp:Label>
    </p>
    <p>
        <asp:TextBox ID="DateOfBirthTB" runat="server" type="date" Width="170px"></asp:TextBox>
    </p>
    <p>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ErrorMessage="אנא הכנס ערך" ControlToValidate="DateOfBirthTB" 
            ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
        <p>
        <asp:Label ID="Label5" runat="server" Text="מספר טלפון נייד"></asp:Label>
    </p>
    <p>
        <asp:TextBox ID="PhoneNumberTB" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ErrorMessage="הכנס מספר תקין" ValidationExpression="^[0][5][0|2|3|4|5|8|9]{1}[-]{0,1}[0-9]{7}$" 
            ControlToValidate="PhoneNumberTB" ForeColor="Red"></asp:RegularExpressionValidator>
    </p>
        <p>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
            ErrorMessage="אנא הכנס ערך" ControlToValidate="PhoneNumberTB" ForeColor="Red"></asp:RequiredFieldValidator>
    </p>
        <p>
            <asp:Label ID="Label6" runat="server" Text="תמונת העובד"></asp:Label>
    </p>
        <p>
            <asp:FileUpload ID="FileUpload1" runat="server" Width="191px" />

    </p>
        <p>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                ErrorMessage="בחר קובץ" ControlToValidate="FileUpload1" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                ErrorMessage="הכנס סוג קובץ תקין" 
                ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.gif|.jpeg|.jpg|.png)$"
                ControlToValidate="FileUpload1" ForeColor="Red"></asp:RegularExpressionValidator>
        </p>

    <asp:Button ID="Button1" runat="server" Text="הוספת עובד חדש" 
            onclick="Button1_Click" />
    </center>
    </div>
    
    </form>
</body>
</html>
