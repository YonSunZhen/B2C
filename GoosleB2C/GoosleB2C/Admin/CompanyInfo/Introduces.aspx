<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Introduces.aspx.cs" Inherits="GoosleB2C.Web.Admin.CompanyInfo.Introduces" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="/JS/easyUI/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="/JS/easyUI/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="/JS/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <link href="/JS/easyUI/themes/gray/easyui.css" rel="stylesheet" type="text/css" /> 
    <link href="/JS/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="/JS/wikmenu.js" type="text/javascript"></script>
    <script src="/JS/wikmain.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://cdn.bootcss.com/bootstrap/3.3.7/css/bootstrap.min.css" type="text/css"/>
    <title></title>
    <style>
        textarea{
            resize:none
        }
        #localImgs img{
            width:150px;
            height:100px;
            float:left;
            padding-right:10px;
            padding-top:5px;
        }
        #localImgs_ img{
            width:150px;
            height:100px;
            float:left;
            padding-right:10px;
            padding-top:5px;
        }
        .dd{
            width:700px;
            height:200px;
            margin-left:30px;
            padding-right:50px;
        }
        .tt{
            width:700px;
            height:80px;
            margin-left:30px;
            padding-right:50px;
        }
    </style>
</head>
<body>
     <div class="form-group">               
        <h1 style="text-align:center;">公司简介</h1>
    </div>
    <hr /> 
     
    <form id="form_edit" name="form_edit" method="post"> 
        <div style="float:left;">
            <div class="form-group">
            <div class="tt">
                <h4>副标题:</h4>
            <input id="ipt_name2"  name="ipt_name2" type="text" class="form-control" placeholder="请输入副标题" style="width:100%" />                 
            </div>
        </div> 
            <div class="form-group">
            <div class="dd">
                <h4>简介文字详情:</h4>
            <textarea id="ipt_introduce" name="ipt_introduce" class="form-control" placeholder="请输入简介文字详情" rows="6" cols="50"></textarea>                 
            </div>
        </div>
            <div class="form-group">
            <div class="dd">
                <h4>备注:</h4>
            <textarea id="ipt_remarks" name="ipt_remarks" class="form-control" placeholder="请输入备注:" rows="7" cols="50"></textarea> 
            </div>                      
        </div>
        </div>       
         <div style="float:left;width:500px;height:200px;">
            <div class="form-group">
                <a href="#" onclick="Add_MainImg();return false;" id="a_addMainImg" class="easyui-linkbutton" iconcls="icon-add">更改主图</a>
            </div>
            <div class="form-group">
                <img id="mainImg" src="../../UpLoadImg/a11.png" style="width:300px;height:200px;" />
            </div>
            <div class="form-group">
                <a href="#" onclick="Add_Imgs();return false;" id="a_addImgs" class="easyui-linkbutton" iconcls="icon-add">添加详图</a>
            </div>
            <div class="form-group">
                <div id="localImgs_" style="width: 400px; height: 200px;overflow:auto;">

                </div>
            </div>
        </div>                             
        <input style="display:none;" type="text" id="imgs"/>
    </form>

    <div id="edit-buttons">
            <a id="btn_add" href="javascript:;" onclick="Editdata(1)" class="easyui-linkbutton">提交</a> 
            <a href="javascript:;" class="easyui-linkbutton" onclick="re(1)">取消</a>
    </div>
    
             
   <div id="edits" class="easyui-dialog" title="" style="width: 500px; height: 450px;" modal="true" closed="true" buttons="#editimg-buttons">
        <form id="imgs_edit" name="imgs_edit" runat="server">
            <div>
                <table>
                    <tr>
                        <td>
                            选择图片: 
                        </td>                       
                    </tr>
                    <tr>
                        <td>
                            <asp:FileUpload ID="imgFile2" runat="server" multiple="multiple" onchange="Previews()"/>
                        </td>                         
                    </tr>
                    <tr>
                        <td>
                            预览:
                            <div id="localImgs" style="width: 400px; height: 300px;overflow:auto;"> 
                                
                            </div>
                        </td>                         
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Button3" runat="server" Text="确认" OnClick="Button3_Click" />   
                        </td>   
                    </tr>
                </table>
            </div>
            <input style="display:none;" id="pd" name="pd" runat="server" type="text" value="1"/>                                                                                        
        </form>          
    </div>

   <script type="text/javascript">
       $(function () {
           InitGird(1);
       });
       function InitGird(id) {
           $.ajax({
               url: 'Introduces.aspx',
               type: 'post',
               data: { "action": "query", "id": id },
               async: false,
               success: function (data) {
                   var dataObj1 = eval("(" + data + ")"); //转换为json对象
                   var mainImg = document.getElementById("mainImg");
                   dataObj1["ipt_remarks"] = dataObj1["ipt_remarks"].replace(/br/g, "\n");
                   dataObj1["ipt_details"] = dataObj1["ipt_details"].replace(/br/g, "\n");
                   $("#ipt_name2").val(dataObj1["ipt_name2"]);
                   $("#ipt_introduce").val(dataObj1["ipt_details"]);
                   $("#ipt_remarks").val(dataObj1["ipt_remarks"]);
                   mainImg.src = dataObj1["ipt_mainimg"];
                   $("#imgs").val(dataObj1["ipt_imgs"]);
                   var a = document.getElementById("imgs").value;
                   var s = a.split(";");
                   console.log(s);
                   var b = document.getElementById("localImgs_");
                   for (var i = 0; i < s.length - 1; i++) {
                       var img = document.createElement("img");
                       img.setAttribute("id", "imgs" + i);
                       img.src = s[i];
                       b.appendChild(img);                 
                   }
               }
           })
       }
       function Add_MainImg() {
           $("#edits").dialog({ title: "更改主图" });
           var mainImg = document.getElementById("imgFile2");
           $("#pd").val("1");
           //var preview = document.getElementById("preview");
           mainImg.outerHTML = mainImg.outerHTML;
           $("#localImgs").html("");
           //preview.src = "../../UpLoadImg/a11.png";
           $("#edits").dialog("open");
           //$("#editimg-buttons a:first").attr("onclick", "Add_Img();return false;");
       }
       function Add_Imgs() {
           $("#edits").dialog({ title: "添加详图" });
           var mainImgs = document.getElementById("imgFile2");
           $("#pd").val("2");
           //var previews = document.getElementById("previews");
           mainImgs.outerHTML = mainImgs.outerHTML;
           $("#localImgs").html("");
           //previews.src = "../../UpLoadImg/a11.png";
           $("#edits").dialog("open");
       }
       function Previews() {
           var localImgs = document.getElementById("localImgs");
           var mainImgs = document.getElementById("imgFile2");
           var file = mainImgs.files;
           if (file) {
               for (var i = 0; i < file.length; i++) {                
                   var reader = new FileReader();
                   reader.onload = function (e) {
                       localImgs.innerHTML += '<div><img id="imgs_' + i + '" src="' + e.target.result + '" /></div>';
                   }
                   reader.readAsDataURL(file[i]);
               }
           }
       }
       function GetInputData(id, cmd) {
           var introduce = $("#ipt_introduce").val();
           var remarks = $("#ipt_remarks").val();
           var introduce_;
           var remarks_;
           if (introduce != null) {
               introduce_ = introduce.replace(/\n/g, "br");
           }
           if (remarks != null) {
               remarks_ = remarks.replace(/\n/g, "br");
           }
           var postdata = "{ \"action\":\"" + cmd + "\",";
           $("#" + id + " input[type!='checkbox']").each(function () {
               postdata += "\"" + $(this).attr("name") + "\":\"" + $(this).val() + "\",";
           });

           postdata += "\"" + "ipt_introduce" + "\":\"" + introduce_ + "\",";
           postdata += "\"" + "ipt_remarks" + "\":\"" + remarks_ + "\",";

           postdata = postdata.substr(0, postdata.length - 1);
           postdata += "}";
           return eval("(" + postdata + ")");
       }
       function Editdata(id) {
           var json = GetInputData("form_edit", "edit");
           json["id"] = id;
           $.ajax({
               url: 'Introduces.aspx',
               type: "post",
               async: false,
               data: json,
               success: function (data) {
                   $.messager.alert('提示', data, 'info', function () {
                       if (data.indexOf("成功") > 0) {
                           console.info(data);
                       }
                   });
               }
           })
       }
   </script>
</body>
</html>
