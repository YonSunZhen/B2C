<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadImg.aspx.cs" Inherits="GoosleB2C.Web.UploadImg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script type="text/javascript" src="JS/easyUI/jquery-1.7.2.min.js"></script> 
    <script type="text/javascript" src="JS/jquery.form.js"></script>
    <script>
        jQuery(document).ready(function () {

            jQuery(".checkimg").click(function () {

                jQuery('#FileUpload1').click();

            });  

            jQuery("#FileUpload1").change(function () {

                jQuery("#fileform").ajaxSubmit({

                    url: "UpTest.aspx?action=topimg&FileName=FileUpload1",

                    dataType: 'text', //数据格式为json

                    beforeSend: function () { //开始上传 

                    },

                    success: function (data) { //成功

                        jQuery("#u_img").attr("src", data); 

                    },

                    error: function (xhr) { //上传失败

                        //alert("上传失败");
                    }
                })
            });
        })
</script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        
<img id="u_img" runat="server" src="/images/t2.jpg" />

 <input type="button" class="checkimg" value="修改头像"/>

<input id="FileUpload1" name="FileUpload1" type="file" style="display:none" />
    </div>
    </form>
</body>
</html>
