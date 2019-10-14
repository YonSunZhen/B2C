<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Left.aspx.cs" Inherits="GoosleB2C.Web.Left" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/chili-1.7.pack.js"></script>
<script type="text/javascript" src="../js/jquery.easing.js"></script>
<script type="text/javascript" src="../js/jquery.dimensions.js"></script>
<script type="text/javascript" src="../js/jquery.accordion.js"></script>
<script language="javascript">
    jQuery().ready(function () {
        jQuery('#navigation').accordion({
            header: '.head',
            navigation1: true,
            event: 'click',
            fillSpace: true,
            animated: 'bounceslide'
        });
    });
</script>
<style type="text/css">
<!--
body {
	margin:0px;
	padding:0px;
	font-size: 12px;
	overflow:hidden;
	
	
	
	
}
#navigation {
	margin:0px;
	padding:0px;
	width:147px;
	overflow:hidden;
}
#navigation a.head {
	cursor:pointer;
	background:url(../images/main_34.gif) no-repeat scroll;
	display:block;
	font-weight:bold;
	margin:0px;
	padding:5px 0 5px;
	text-align:center;
	font-size:12px;
	text-decoration:none;
}
#navigation ul {
	border-width:0px;
	margin:0px;
	padding:0px;
	text-indent:0px;
}
#navigation li {
	list-style:none; display:inline;
	text-align:center;
}
#navigation li li a {
	display:block;
	font-size:12px;
	text-decoration: none;
	text-align:center;
	padding:3px;
	color: #073767;
	
}
#navigation li li a:hover {
	background:url(../images/tab_bg.gif) repeat-x;
		border:solid 1px #adb9c2;
		color: #068ccb;
}
-->
</style>
</head>
<body>
    <form id="form1" runat="server" style="height:100%; margin:0xp 0xp 0xp 0xp;overflow:hidden;">
    <div  style="height:100%; margin:0xp 0xp 0xp 0xp;overflow:hidden;">
    <asp:Literal ID="lt" runat="server" ></asp:Literal>
  
</div>

    </form>
</body>
</html>

