<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="init_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>系统初始化</title>
</head>
<body>
    <form runat="server">
    <asp:Button ID="BtnArea" runat="server" Text="生成area.xml组织单位文件" onclick="BtnArea_Click" /><br />
    <asp:Button ID="BtnTradeSort" runat="server" Text="生成tradesort.xml供求类型表文件" 
        onclick="BtnTradeSort_Click" /><br />
    <asp:Button ID="BtnNewsType" runat="server" Text="生成newstype.xml新闻类型表文件" 
        onclick="BtnNewsType_Click" /><br />
    <asp:Button ID="BtnHzsClass" runat="server" Text="生成合作社类型表hzsclass.xml文件" 
        onclick="BtnHzsClass_Click" />
    <br />
    <asp:Button ID="Btnstart" runat="server" Text="初始化。。。" OnClick="Btnstart_Click"  /><br />
    <asp:Button ID="BtnDeleteInit" runat="server" Text="删除Init文件夹" 
        onclick="BtnDeleteInit_Click" />
    </form>
    
</body>
</html>
