<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="ck_test.aspx.cs" Inherits="GoosleB2C.Web.Admin.ck_test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script type="text/javascript" src="/Admin/build/ckeditor.js"></script>

    <script type="text/javascript" src="/Admin/WebUploader/js/jquery-1.8.3.min.js"></script>

    <script src="/JS/easyUI/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="/JS/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <link href="/JS/easyUI/themes/gray/easyui.css" rel="stylesheet" type="text/css" /> 
    <link href="/JS/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="/JS/wikmenu.js" type="text/javascript"></script>
    <script src="/JS/wikmain.js" type="text/javascript"></script>
    <title></title>
</head>
<body>
    <form id="form1">
    <div>
        <textarea rows="30" cols="50" name="editor" id="editor"></textarea>
    </div>
    </form>
    <script type="text/javascript">
        var myEditor = null;
        $(function () {            
            InitGird(1);
        });
        ClassicEditor
                .create(document.querySelector('#editor'), {
                    ckfinder: {
                        uploadUrl: '/Admin/WebUploader/ajax.ashx?action=UpLoadFile'
                    }
                })
                .then(editor => {
                    myEditor = editor;

                })
                .catch(error => {
                    console.error(error);
                });
        function InitGird(id) {           
            $.ajax({
                url: 'ck_test.aspx',
                type: 'post',
                data: { "action": "query", "id": id },                
                async: false,
                success: function (data) {
                    var dataObj1 = eval("(" + data + ")"); //转换为json对象                                                       
                    myEditor.setData(decodeURIComponent(dataObj1["ipt_webdetails"]));                                        
                }
            });
        }
    </script>
</body>
</html>
