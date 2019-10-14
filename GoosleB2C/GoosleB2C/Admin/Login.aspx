<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GoosleB2C.Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>深圳谷嫂网络信息技术有限公司</title>
<link rel="stylesheet" type="text/css" href="../CSS/style.css"/>
<script type="text/javascript" src="../JS/js.js"></script>
<script type="text/javascript" src="../JS/MD5.js"></script>
<script type="text/javascript">
    function encodePsw() {

        var obj = document.getElementById('txtPwd');
        obj.value = hex_md5(obj.value);

        return true;
    }
</script>
</head>
<body>

    <form id="form1" runat="server">
    <div id="top"> </div>
      <div id="center">
    <div id="center_left"></div>
    <div id="center_middle">
    <div id="center_middle_content">
      <div class="user">
        <label>用户名：
        
        <asp:TextBox ID="txtUser" name="txtUser" runat="server" MaxLength="15"></asp:TextBox>
        </label>
      </div>
      <div class="user">
        <label>密　码：
     
         <asp:TextBox ID="txtPwd" name="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
        </label>
      </div>
      <div class="chknumber">
        <label>验证码：
       
        <asp:TextBox ID="txtChknumber" CssClass="chknumber_input" runat="server" MaxLength="4"></asp:TextBox>
        </label>
       
        <img id="imgVerify" src="ChkCode.aspx?" alt="看不清？点击更换" onclick="this.src=this.src+'?'" />
      </div>
      </div>
    </div>
    <div id="center_middle_right"></div>
    <div id="center_submit">
    <div id="center_submit_content">
      <div class="button"><asp:ImageButton runat="server" ImageUrl="../images/dl.gif" Width="57"  Height="20"  ID="imgBtnLogin" OnClientClick="return encodePsw()"  OnClick="imgBtnLogin_Click" /> </div>
      <div class="button"> <asp:ImageButton runat="server" ImageUrl="../images/cz.gif" Width="57" Height="20" ID="imgBtnCancle" OnClick="imgBtnCancle_Click" /> </div>
    </div>
    </div>
    <div id="center_right"></div>
  </div>

<div id="footer"></div>
    </form>
</body>
</html>
