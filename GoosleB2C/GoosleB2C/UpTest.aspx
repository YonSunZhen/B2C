<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpTest.aspx.cs" Inherits="GoosleB2C.Web.UpTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <script type="text/javascript" src="JS/easyUI/jquery-1.7.2.min.js"></script> 
    <script type="text/javascript" src="JS/jquery.form.js"></script>
    <script type="text/javascript">
        function upload() {
            var options = {
                type: "POST",                            //当然这个是传送方式
                url: 'UpFiles.ashx',        //一般处理程序的路径
                success: function (msg) {        //返回的参数
                    $("#server_img").attr("src", msg);            //回显图片。
                }
            }
            // 将options传给ajaxForm
           // $('#aspnetForm').ajaxSubmit(options);
            $('#form1').ajaxSubmit(options);
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <img id="server_img" width="360px" style="border: 1px solid #ccc; padding: 2px;"   title="" alt="" />   //用于回显图片
    <asp:FileUpload ID="Up_load" runat="server" onchange="upload()"  ontextchange="upload()"/>   
    </div>
    </form>
</body>
</html>
