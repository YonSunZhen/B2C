<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="WebInfo.aspx.cs" Inherits="GoosleB2C.Web.Admin.WebInfoManage.WebInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="/webuploader/webuploader.css" /> 
    <link rel="stylesheet" type="text/css" href="/webuploader/smart-green.css" />      
	<script type="text/javascript" src="/webuploader/jquery-1.8.3.min.js"></script>    
	<script type="text/javascript" src="/webuploader/webuploader.min.js"></script>
	<script type="text/javascript" charset="utf-8" src="/webuploader/uploader.js"></script> 

    <script type="text/javascript" src="/Admin/ckeditor.js"></script>
    
    <script src="/JS/easyUI/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="/JS/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <link href="/JS/easyUI/themes/gray/easyui.css" rel="stylesheet" type="text/css" /> 
    <link href="/JS/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="/JS/wikmenu.js" type="text/javascript"></script>
    <script src="/JS/wikmain.js" type="text/javascript"></script>
    <title></title>
    <style>      
        .ck-editor__main{         
            max-width:975px;            
        }
        .ck-editor__top{           
            max-width:975px;          
        } 
        .ck{
            height:250px;
        }
        .edit_info{
            width:1060px;
            margin:0 50px 0 50px;            
        }
        .smart-green {
            max-width: 1060px;           
            padding: 1px 0px 1px 0px;
            margin: 0 50px 0 50px;           
            border-radius: 5px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
        }
        .lef {
            float: left;
            width: 1060px;
        }
        .rig {
            float: left;
            width: 1060px;
        }               
    </style>
</head>
<body>
    <form id="form_edit" name="form_edit" method="post" url="WebInfo.aspx">
        <div style="font-size:30px;font-weight:bold;margin-top:13px;">
            网站信息管理
            <%--<hr style="height:5px;border:none;border-top:1px solid #ffffff;" />--%>                     
        </div>        
        <div id="" class="edit_info">
            <div id="" class="title_Div">
                <span class="">首页标题</span>
                <br />
                <input id="ipt_title" name="ipt_title" type="text" class="easyui-validatebox" required="true" />            
            </div>                        
            <div id="" class="other_Div">
                <span class="">网站名称</span>
                <br />
                <input id="ipt_webname" name="ipt_webname" type="text" class="easyui-validatebox" require="true" />
            </div>
            <div id="" class="other_Div">
                <span class="">小程序名</span>
                <br />
                <input id="ipt_vname" name="ipt_vname" />
            </div>          
            <div id="" class="other_Div">
                <span class="">备案号</span>
                <br />
                <input id="ipt_records" name="ipt_records" />
            </div>
            <div id="" class="other_Div">
                <span class="">seoKey</span>
                <br />
                <input id="ipt_seokey" name="ipt_seokey" />
            </div>
            <div id="" class="other_Div">
                <span class="">seoDesceibe</span>
                <br />
                <textarea id="ipt_seodescribe" name="ipt_seodescribe" rows="9" cols="136"></textarea>
            </div>
            <div id="" class="other_Div">
                <span class="">小程序底部信息</span>
                <br />
                <textarea id="ipt_vbottom" name="ipt_vbottom" rows="9" cols="136"></textarea>
            </div>                      
            <div id="" class="other_Div">
                <span class="">网页手机网页底部信息</span>
                <textarea rows="30" cols="50" name="editor" id="editor"></textarea>
            </div>
            <%--<div id="" class="other_Div">
                <span class="">小程序底部信息</span>
                <textarea rows="30" cols="50" name="veditor" id="veditor"></textarea>
            </div>--%>
        </div>

        <div class="smart-green tab">
            <ul style="-webkit-padding-start: 0px;">
                <li class="lef">
                    <span>网页端logo(306*98)</span>
                </li>
                <li id="web_rig" class="rig">
                    <input type="hidden" style="float: left; height: 30px; width: 500px;" readonly="readonly" name="txtImgUrl" class="upload-path" />
                    <div style="float: left; margin-left: 8px;" class="upload-box upload-img"></div>
                    <div style="clear: both;"></div>
                    <div class="imgDiv">
                        <img class="upload-imgurl" width="306" />
                    </div>

                </li>
                <li class="clear"></li>
            </ul>

            <ul style="-webkit-padding-start: 0px;">
                <li class="lef">
                    <span>手机端logo</span>
                </li>
                <li id="phone_rig" class="rig">
                    <input type="hidden" style="float: left; height: 30px; width: 500px;" readonly="readonly" name="txtImgUrl" class="upload-path" />
                    <div style="float: left; margin-left: 8px;" class="upload-box pupload-img"></div>
                    <div style="clear: both;"></div>
                    <div class="imgDiv">
                        <img class="upload-imgurl" width="200" />
                    </div>

                </li>
                <li class="clear"></li>
            </ul>

            <ul style="-webkit-padding-start: 0px;">
                <li class="lef">
                    <span>小程序二维码</span>
                </li>
                <li id="weixin_rig" class="rig">
                    <input type="hidden" style="float: left; height: 30px; width: 500px;" readonly="readonly" name="txtImgUrl" class="upload-path" />
                    <div style="float: left; margin-left: 8px;" class="upload-box vupload-img"></div>
                    <div style="clear: both;"></div>
                    <div class="imgDiv">
                        <img class="upload-imgurl" width="200" />
                    </div>

                </li>
                <li class="clear"></li>
            </ul>
            <div style="margin-right:5px;">
                <label>
                    <input type="button" class="button" value="取消" onclick="re_(); re(); " />
                </label>
                <label>
                    <input type="button" class="button" value="提交" onclick="Editdata(); Del();" />
                </label>
            </div>           
        </div>
        


                 
        <input type="hidden" id="ck_content" />
        <input type="hidden" id="vck_content" />         
    </form>

    <script type="text/javascript">
        var myEditor = null;
        var myvEditor = null;
        var initArry = [];
        var waterMarkType = "";
        var waterMarkPosition = "";
        var waterMarkContent = "";
        var waterMarkPicture = "";
        var waterMarkTransparency = "";
        $(function () {
            InitGird();
            queryWatermark_state();
            $(".upload-img").InitUploader({
                waterMarkType: waterMarkType,
                waterMarkPosition: waterMarkPosition,
                waterMarkContent: waterMarkContent,
                waterMarkPicture: waterMarkPicture,
                waterMarkTransparency: waterMarkTransparency,
                sendurl: "/webuploader/cs_ashx/ajax.ashx",
                width: "306",
                height: "98",
                Logo_brand: "success_Del",              
            });
            $(".pupload-img").InitUploader({
                waterMarkType: waterMarkType,
                waterMarkPosition: waterMarkPosition,
                waterMarkContent: waterMarkContent,
                waterMarkPicture: waterMarkPicture,
                waterMarkTransparency: waterMarkTransparency,
                sendurl: "/webuploader/cs_ashx/ajax.ashx",
                width: "306",
                height: "98",
                Logo_brand: "success_Del",
            });
            $(".vupload-img").InitUploader({
                waterMarkType: waterMarkType,
                waterMarkPosition: waterMarkPosition,
                waterMarkContent: waterMarkContent,
                waterMarkPicture: waterMarkPicture,
                waterMarkTransparency: waterMarkTransparency,
                sendurl: "/webuploader/cs_ashx/ajax.ashx",
                width: "306",
                height: "98",
                Logo_brand: "success_Del",
            });            
            $(".imgDiv").mouseenter(function () {
                $(this).find(".delete").show();
            });
            $(".imgDiv").mouseleave(function () {
                $(this).find(".delete").hide();
            });
            collect_initImg();
        })
        ClassicEditor
                .create(document.querySelector('#editor'), {
                    ckfinder: {
                        uploadUrl: '/webuploader/cs_ashx/waterMark_ajax.ashx?action=UpLoadFile_ck'
                    }
                })
                .then(editor => {
                    myEditor = editor;
                })
                .catch(error => {
                    console.error(error);
                });
        //ClassicEditor
        //        .create(document.querySelector('#veditor'), {
        //            ckfinder: {
        //                uploadUrl: '/webuploader/cs_ashx/waterMark_ajax.ashx?action=UpLoadFile_ck'
        //            }
        //        })
        //        .then(veditor => {
        //            myvEditor = veditor;
        //        })
        //        .catch(error => {
        //            console.error(error);
        //        });
        function InitGird() {
            $.ajax({
                url: 'WebInfo.aspx',
                type: 'post',
                data: { "action": "query" },
                async: false,
                success: function (data) {
                    var dataObj1 = eval("(" + data + ")"); //转换为json对象
                    var ck_content = document.getElementById("ck_content");
                    //alert("查询成功");
                    dataObj1["ipt_seodescribe"] = dataObj1["ipt_seodescribe"].replace(/br/g, "\n");
                    dataObj1["ipt_vbottom"] = dataObj1["ipt_vbottom"].replace(/br/g, "\n");
                    //$("#ipt_webname").val(dataObj1["ipt_webname"]);
                    //$("#ipt_title").val(dataObj1["ipt_title"]);
                    //$("#ipt_vname").val(dataObj1["ipt_vname"]);
                    //$("#ipt_records").val(dataObj1["ipt_records"]);
                    //$("#ipt_seokey").val(dataObj1["ipt_seokey"]);
                    //$("#ipt_seodescribe").val(dataObj1["ipt_seodescribe"]);
                    
                    
                    //var vck_content = document.getElementById("vck_content");
                    ck_content.value = dataObj1["ipt_bottominfo"];
                    //vck_content.value = dataObj1["ipt_vbottom"];
                    myEditor.setData(decodeURIComponent(ck_content.value));
                    //myvEditor.setData(decodeURIComponent(vck_content.value));

                    if (dataObj1["ipt_logo"]) {
                        var thumbSrc = dataObj1["ipt_logo"];
                        //var thumbSrc = mainSrc + "_.jpg";
                        var input = document.createElement("input");
                        var a = document.createElement("a");
                        var del_img = document.createElement("img");                                                   
                        input.setAttribute("type", "hidden");
                        input.setAttribute("name", "hid_photo_name");
                        input.setAttribute("value", dataObj1["ipt_logo"].split("_")[0] + "|" + thumbSrc);
                        input.setAttribute("class", "hidden-src");
                        a.setAttribute("href", "javascript:;");
                        a.setAttribute("onclick", "delImg_(this);");
                        del_img.setAttribute("src", "/UpLoadImg/a7.png");
                        del_img.setAttribute("class", "delete");                         
                        a.appendChild(del_img);
                        $("#web_rig").children(".imgDiv").children(".upload-imgurl").attr("src", thumbSrc);
                        $("#web_rig").children(".imgDiv").append(a);
                        $("#web_rig").append(input);                       
                    }                  

                    if (dataObj1["ipt_vlogo"]) {
                        var thumbSrc = dataObj1["ipt_vlogo"];
                        //var thumbSrc = mainSrc + "_.jpg";
                        var input = document.createElement("input");
                        var a = document.createElement("a");
                        var del_img = document.createElement("img");
                        input.setAttribute("type", "hidden");
                        input.setAttribute("name", "hid_photo_name");
                        input.setAttribute("value", dataObj1["ipt_vlogo"].split("_")[0] + "|" + thumbSrc);
                        input.setAttribute("class", "hidden-src");
                        a.setAttribute("href", "javascript:;");
                        a.setAttribute("onclick", "delImg_(this);");
                        del_img.setAttribute("src", "/UpLoadImg/a7.png");
                        del_img.setAttribute("class", "delete");
                        a.appendChild(del_img);
                        $("#phone_rig").children(".imgDiv").children(".upload-imgurl").attr("src", thumbSrc);
                        $("#phone_rig").children(".imgDiv").append(a);
                        $("#phone_rig").append(input);
                        
                    }                   

                    if (dataObj1["ipt_vcode"]) {
                        var thumbSrc = dataObj1["ipt_vcode"];
                        //var thumbSrc = mainSrc + "_.jpg";
                        var input = document.createElement("input");
                        var a = document.createElement("a");
                        var del_img = document.createElement("img");
                        input.setAttribute("type", "hidden");
                        input.setAttribute("name", "hid_photo_name");
                        input.setAttribute("value", dataObj1["ipt_vcode"].split("_")[0] + "|" + thumbSrc);
                        input.setAttribute("class", "hidden-src");
                        a.setAttribute("href", "javascript:;");
                        a.setAttribute("onclick", "delImg_(this);");
                        del_img.setAttribute("src", "/UpLoadImg/a7.png");
                        del_img.setAttribute("class", "delete");
                        a.appendChild(del_img);
                        $("#weixin_rig").children(".imgDiv").children(".upload-imgurl").attr("src", thumbSrc);
                        $("#weixin_rig").children(".imgDiv").append(a);
                        $("#weixin_rig").append(input);                       
                    }
                    console.info(data);
                    $("#form_edit").form('load', dataObj1);
                }
            })
        }
        function queryWatermark_state() {
            $.ajax({
                type: "post",
                async: false,
                //url: "/webuploader/cs_ashx/ajax.ashx?action=queryWaterMark",
                url: "/Admin/WebInfoManage/WaterMark.aspx",
                data: { "action": "queryWaterMark_state" },
                success: function (data) {
                    //alert(data);
                    var dataObj1 = eval("(" + data + ")"); //转换为json对象 
                    if (dataObj1["ipt_state"] == '1') {
                        waterMarkType = dataObj1["ipt_watertype"];
                        waterMarkPosition = dataObj1["ipt_position"];
                        if (dataObj1["ipt_words"] != null) {
                            waterMarkContent = dataObj1["ipt_words"];
                        }
                        else {
                            waterMarkContent = "";
                        }
                        if (dataObj1["ipt_img"] != null) {
                            waterMarkPicture = dataObj1["ipt_img"];
                        }
                        else {
                            waterMarkPicture = "";
                        }
                        waterMarkTransparency = dataObj1["ipt_transparent"];
                    }
                    else {
                        waterMarkType = "0";
                        waterMarkPosition = "0";
                        waterMarkContent = "";
                        waterMarkPicture = "";
                        waterMarkTransparency = "0";
                    }
                }               
            });
        }
        function GetInputData(id, cmd) {
            var myeditor = myEditor.getData();
            //var myveditor = myvEditor.getData();
            myeditor = encodeURIComponent(myeditor);           
            //myveditor = encodeURIComponent(myveditor);
            var seodescribe = document.getElementById("ipt_seodescribe").value;
            var vbottom = document.getElementById("ipt_vbottom").value;
            var seodescribe_;            
            var vbottom_;


            if (seodescribe != null) {
                seodescribe_ = seodescribe.replace(/\n/g, "br");
            }
            if (vbottom != null) {
                vbottom_ = vbottom.replace(/\n/g, "br");
            }

            var postdata = "{ \"action\":\"" + cmd + "\",";
            $("#" + id + " input[type!='checkbox']").each(function () {
                postdata += "\"" + $(this).attr("name") + "\":\"" + $(this).val() + "\",";
            });
            $("#" + id + " input[type='checkbox']").each(function () {
                postdata += "\"" + $(this).attr("name") + "\":\"" + this.checked + "\",";
            });

            if ($(".upload-img").siblings(".imgDiv").children("img").attr("src") != undefined) {
                var thumbSrc = $(".upload-img").siblings(".hidden-src").val().split("|")[1];
                postdata += "\"" + "ipt_logo" + "\":\"" + thumbSrc + "\",";
            }
            else {
                postdata += "\"" + "ipt_logo" + "\":\"" + "" + "\",";
            }
            if ($(".pupload-img").siblings(".imgDiv").children("img").attr("src") != undefined) {
                var thumbSrc = $(".pupload-img").siblings(".hidden-src").val().split("|")[1];
                postdata += "\"" + "ipt_vlogo" + "\":\"" + thumbSrc + "\",";
            }
            else {
                postdata += "\"" + "ipt_vlogo" + "\":\"" + "" + "\",";
            }
            if ($(".vupload-img").siblings(".imgDiv").children("img").attr("src") != undefined) {
                var thumbSrc = $(".vupload-img").siblings(".hidden-src").val().split("|")[1];
                postdata += "\"" + "ipt_vcode" + "\":\"" + thumbSrc + "\",";
            }
            else {
                postdata += "\"" + "ipt_vcode" + "\":\"" + "" + "\",";
            }
            postdata += "\"" + "ipt_seodescribe" + "\":\"" + seodescribe_ + "\",";
            postdata += "\"" + "ipt_vbottom" + "\":\"" + vbottom_ + "\",";
            postdata += "\"" + "ipt_bottominfo" + "\":\"" + myeditor + "\",";
            //postdata += "\"" + "ipt_vbottom" + "\":\"" + myveditor + "\",";


            postdata = postdata.substr(0, postdata.length - 1);
            postdata += "}";
            return eval("(" + postdata + ")");
        }
        function Editdata() {
            var json = GetInputData("form_edit", "edit");
            $.ajax({
                url: 'WebInfo.aspx',
                type: 'post',
                data: json,
                async: false,
                success: function (data) {
                    $.messager.alert('提示', data, 'info', function () {
                        if (data.indexOf("成功") > 0) {
                            console.info(data);
                            location.reload();
                        }
                    });
                }
            })
        }

        function collect_initImg() {
            if ($(".upload-img").siblings(".imgDiv").children("img").attr("src") != undefined) {
                var imgNames = $("#web_rig").children(".hidden-src").val();
                initArry.push(imgNames.split("|")[0], imgNames.split("|")[1]);
            }
            if ($(".pupload-img").siblings(".imgDiv").children("img").attr("src") != undefined) {
                var imgNames = $("#phone_rig").children(".hidden-src").val();
                initArry.push(imgNames.split("|")[0], imgNames.split("|")[1]);
            }
            if ($(".vupload-img").siblings(".imgDiv").children("img").attr("src") != undefined) {
                var imgNames = $("#weixin_rig").children(".hidden-src").val();
                initArry.push(imgNames.split("|")[0], imgNames.split("|")[1]);
            }
        }
        function re_() {
            //获得页面初始化后叉掉的图片数组
            var delImgarry = arry;
            //获得页面初始化后的图片数组
            var initImgarry = initArry;
            //alert(delImgarry);
            //获得进行各种操作后最终页面上的图片数组
            var lastImgarry = GetLastImg();
            var up_Img = [];
            for (var i = 0; i < delImgarry.length; i++) {
                var obj = delImgarry[i];
                var isExit = false;
                for (var j = 0; j < initImgarry.length; j++) {
                    var initObj = initImgarry[j];
                    if (obj == initObj) {
                        isExit = true;
                        break;
                    }
                }
                if (!isExit) {
                    up_Img.push(obj);
                }
            }
            for (var i = 0; i < lastImgarry.length; i++) {
                var obj = lastImgarry[i];
                var isExit = false;
                for (var j = 0; j < initImgarry.length; j++) {
                    var initObj = initImgarry[j];
                    if (obj == initObj) {
                        isExit = true;
                        break;
                    }
                }
                if (!isExit) {
                    up_Img.push(obj);
                }
            }

            for (var i = 0; i < up_Img.length - 1;) {
                delete_Imgs_ajax(up_Img[i], up_Img[i + 1]);
                i += 2;
            }
        }
        function GetLastImg() {
            var lastArry = [];
            if ($(".upload-img").siblings(".imgDiv").children("img").attr("src") != undefined) {
                var imgNames = $("#web_rig").children(".hidden-src").val();
                lastArry.push(imgNames.split("|")[0], imgNames.split("|")[1]);
            }
            if ($(".pupload-img").siblings(".imgDiv").children("img").attr("src") != undefined) {
                var imgNames = $("#phone_rig").children(".hidden-src").val();
                lastArry.push(imgNames.split("|")[0], imgNames.split("|")[1]);
            }
            if ($(".vupload-img").siblings(".imgDiv").children("img").attr("src") != undefined) {
                var imgNames = $("#weixin_rig").children(".hidden-src").val();
                lastArry.push(imgNames.split("|")[0], imgNames.split("|")[1]);
            }
            return lastArry;
        }
        function delete_Imgs_ajax(a, b) {
            $.ajax({
                url: "/webuploader/cs_ashx/ajax.ashx?action=delImg&oriSrc=" + a + "&thumbSrc=" + b,
                type: "GET",
                async: false,
                success: function (result) {
                    var result = eval("(" + result + ")");
                    console.log(result);
                }
            });
        }
        function re() {
            location.reload();
        }
    </script>
</body>
</html>
