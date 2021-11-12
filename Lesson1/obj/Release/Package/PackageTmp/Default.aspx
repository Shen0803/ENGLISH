<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lesson1.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>Input your information
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="tbxName" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Age"></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="tbxAge" runat="server"></asp:TextBox>
            <asp:RadioButtonList ID="rbtnlistGender" runat="server">
                <asp:ListItem Text ="Male" Value ="0"></asp:ListItem>
                <asp:ListItem Text ="Female" Value ="1"></asp:ListItem>
            </asp:RadioButtonList>
            <asp:Label ID="Label3" runat="server" Text="學歷  "></asp:Label>
            <asp:DropDownList ID="ddlEducation" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem Text="國小以下" Value ="0"></asp:ListItem>
                <asp:ListItem Text="國小" Value ="1"></asp:ListItem>
                <asp:ListItem Text="國中" Value ="2"></asp:ListItem>
                <asp:ListItem Text="高中" Value ="3"></asp:ListItem>
                <asp:ListItem Text="大學" Value ="4"></asp:ListItem>
                <asp:ListItem Text="大學以上" Value ="5"></asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:CheckBoxList ID="cblInterest" runat="server">
                <asp:ListItem Text ="Playing the guitar" Value ="0"></asp:ListItem>
                <asp:ListItem Text ="Play baseball" Value ="1"></asp:ListItem>
                <asp:ListItem Text ="Play besketball" Value ="2"></asp:ListItem>
                <asp:ListItem Text ="Reading" Value ="3"></asp:ListItem>
                <asp:ListItem Text ="Singing" Value ="4"></asp:ListItem>
                <asp:ListItem Text ="Swimming" Value ="5"></asp:ListItem>
                <asp:ListItem Text ="Cooking" Value ="6"></asp:ListItem>
            </asp:CheckBoxList>
            <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert" />
            <asp:Button ID="btnSelect" runat="server" OnClick="btnSelect_Click" Text="Select" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
            <br />
            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
