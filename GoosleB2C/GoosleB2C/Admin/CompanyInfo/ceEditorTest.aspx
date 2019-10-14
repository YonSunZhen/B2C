<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ceEditorTest.aspx.cs" Inherits="GoosleB2C.Web.Admin.CompanyInfo.ceEditorTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script type="text/javascript" src="js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="/Admin/ckeditor.js"></script>
    <title></title>
    <style>
        /*.ck-editor__editable{
            min-height:300px;
        }
        .ck-placeholder{
            min-height:25px;
        }*/
        .ck{
            height:200px;
        }
    </style>
</head>
<body>
    <form id="form1">
        <div style="padding-left:30px;width:800px;">
        <textarea id="editor" name="editor"></textarea>
        </div>
        <input type="button" value="点击" onclick="add();" />
        <img src="/UpLoadImg/2018/7/thumb_7aafb68e-c7c5-4e68-9201-73676d6014c4_0105.jpg" />
    </form>

    <script type="text/javascript"> 
        var ckeditor;
        ClassicEditor
            .create(document.querySelector('#editor'), {
                
                ckfinder: {
                    uploadUrl: '/webuploader/cs_ashx/waterMark_ajax.ashx?action=UpLoadFile_ck'
                }
            })
            .then(editor => {
                console.log(editor);
                ckeditor = editor;
            })
            .catch(error => {
                console.error(error);
            });
        function add() {
            var content = "<p>bbb</p>";
            ckeditor.setData(content);
        }
    </script>
</body>
</html>
