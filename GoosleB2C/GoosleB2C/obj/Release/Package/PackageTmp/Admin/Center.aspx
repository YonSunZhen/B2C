<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Center.aspx.cs" Inherits="GoosleB2C.Web.Center" %>



<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <style type="text/css">
   
    
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	overflow:hidden;
	height:100%;
	 
}
-->
</style>
</head>
<body style="height:100%">
    <form id="form1" runat="server">
    
    <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="8" bgcolor="#353c44">&nbsp;</td>
    <td width="147" valign="top"><iframe height="100%" width="100%" border="0" frameborder="0" src="Left.aspx" name="leftFrame" id="leftFrame" title="leftFrame"></iframe></td>
    <td width="10" bgcolor="#add2da">&nbsp;</td>
    <td valign="top"><iframe height="100%" width="100%" style="margin-top:0px" border="0" frameborder="0" src="TradeInfo/Index.aspx" name="rightFrame" id="rightFrame" title="rightFrame"></iframe></td>
    <td width="8" bgcolor="#353c44">&nbsp;<input type="hidden"  id="hiCenter"/></td>
  </tr>
</table>
   
    </form>
</body>
</html>
