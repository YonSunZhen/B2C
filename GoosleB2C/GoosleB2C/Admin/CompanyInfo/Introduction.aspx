<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="Introduction.aspx.cs" Inherits="GoosleB2C.Web.Admin.CompanyInfo.Introduction" %>

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
    <link rel="stylesheet" href="https://cdn.bootcss.com/bootstrap/3.3.7/css/bootstrap.min.css" type="text/css"/>
    <title></title>
    <style>                                                                                 
        .ck-editor__main{         
            max-width:975px;            
        }
        .ck-editor__top{           
            max-width:975px;          
        } 
        .ck{
            height:350px;
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
        #phone_rig #imagelist{
            width:200px;
            height:200px;
        }             
    </style>
</head>
<body>    
    <form id="form1" method="post" action="Introduction.aspx">
        <div id="name" style="font-size:30px;font-weight:bold;margin-top:13px; margin-left:8px;"></div> 
        <div class="edit_info">
            <%--<div class="form-group">
            <div class="tt">
                <h4>副标题:</h4>
                <input id="ipt_name2" name="ipt_name2" type="text" value="维多利亚有限公司" class="form-control" placeholder="请输入副标题" style="width:100%" />                 
            </div>
            </div> --%>           
            <div class="title_Div">
                <span>手机端文字详情:</span>
                <br />
                <textarea id="ipt_introduce" name="ipt_introduce" placeholder="请输入手机端文字详情" rows="9" cols="136"></textarea>                 
            </div>
            <%--CKEditor5--%>
            <div class="other_Div">
                <span>网页端</span>
                <textarea rows="30" cols="50" name="editor" id="editor"></textarea>
            </div>
            <div class="other_Div">
                <span>备注</span>
                <br />
                <textarea id="ipt_remarks" name="ipt_remarks" placeholder="请输入备注:" rows="9" cols="136"></textarea> 
            </div>                                 
        </div>          
        <div class="smart-green tab">
            <ul style="-webkit-padding-start: 0px;">
                <li class="lef">
                    <span>主图(大小为295*196的倍数)</span>
                </li>
                <li id="main_rig" class="rig">
                    <input type="hidden" style="float: left; height: 30px; width: 500px;" readonly="readonly" name="txtImgUrl" class="upload-path" />                    
                    <div style="float: left; margin-left:8px;" class="upload-box upload-img"></div>
                    <div style="clear: both;"></div>
                    <div class="imgDiv">
                        <img class="upload-imgurl" width="295" />
                    </div>
                                        
                </li>
                <li class="clear"></li>
            </ul>
                                                                  
            <ul style="-webkit-padding-start: 0px;">
				<li class="lef">
                    <span>手机端详情图</span>
				</li>
				<li id="phone_rig" class="rig">
					<div style="float: left; margin-left:8px;" class="upload-box upload-album"></div>	
                    <div style="float: left; margin-left: 8px;">
                        <%--<input id="chkThumb" name="chkThumb" type="checkbox" value="1" />--%>
                        <%--<label for="chkThumb">是否生成缩略图</label>--%>
                    </div>				
					<div class="clear"></div>
					<div class="photo-list" style="overflow:auto;">
						<ul>
						
						</ul>
					</div>
				</li>
				<li class="clear"></li>
			</ul>
            <div style="margin-right: 5px;">
                <label>
                    <input type="button" class="button" value="取消" onclick="re_(); re(); " />
                </label>
                <label>
                    <input type="button" class="button" value="提交" onclick="Editdata(); Del();" />
                </label>
            </div>
        </div>       
        <input type="hidden" id="ck_content" />                 
    </form>    
    <script type="text/javascript">
        var myEditor = null;
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
                width: "295",
                height: "196",
                Logo_brand: "success_Del",
                waterMarkType: waterMarkType,
                waterMarkPosition: waterMarkPosition,
                waterMarkContent: waterMarkContent,
                waterMarkPicture: waterMarkPicture,
                waterMarkTransparency: waterMarkTransparency,
                sendurl: "/webuploader/cs_ashx/ajax.ashx",
            });
            
            $(".upload-album").InitUploader({
                btntext: "点击上传",
                multiple: true,
                water: false,
                width: "375",
                height: "375",
                Logo_brand: "width",
                waterMarkType: waterMarkType,
                waterMarkPosition: waterMarkPosition,
                waterMarkContent: waterMarkContent,
                waterMarkPicture: waterMarkPicture,
                waterMarkTransparency: waterMarkTransparency,
                sendurl: "/webuploader/cs_ashx/ajax.ashx",
            });                                 
            $(".imgDiv").mouseenter(function () {
                $(this).find(".delete").show();
            });
            $(".imgDiv").mouseleave(function () {
                $(this).find(".delete").hide();
            });           
            $(".fl").mouseenter(function () {
                $(this).find(".delete").show();
            });
            $(".fl").mouseleave(function () {
                $(this).find(".delete").hide();
            });
            collect_initImg();
        });
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
        function InitGird() {
            var id = "";
            var url = location.search; //获取url中"?"符后的字串
            if (url.indexOf("?") != -1) {    //判断是否有参数
                var str = url.substr(1); //从第一个字符开始 因为第0个是?号 获取所有除问号的所有符串
                strs = str.split("=");   //用等号进行分隔 （因为知道只有一个参数 所以直接用等号进分隔 如果有多个参数 要用&号分隔 再用等号进行分隔）
                //alert(strs[1]);          //直接弹出第一个参数 （如果有多个参数 还要进行循环的）
                id = strs[1];
            }
            $.ajax({
                url: 'Introduction.aspx',
                type: 'post',
                data: { "action": "query", "id": id },                
                async: false,
                success: function (data) {
                    var dataObj1 = eval("(" + data + ")"); //转换为json对象
                    dataObj1["ipt_remarks"] = dataObj1["ipt_remarks"].replace(/br/g, "\n");
                    dataObj1["ipt_details"] = dataObj1["ipt_details"].replace(/br/g, "\n");
                    $("#ipt_name2").val(dataObj1["ipt_name2"]);
                    $("#ipt_introduce").val(dataObj1["ipt_details"]);
                    $("#ipt_remarks").val(dataObj1["ipt_remarks"]);
                    $(".upload-path").val(dataObj1["ipt_mainimg"]);
                    $("#name").html(dataObj1["ipt_name"] + '<hr style="height:5px;border:none;border-top:1px solid #ffffff;" />');

                    var ck_content = document.getElementById("ck_content");
                    ck_content.value = dataObj1["ipt_webdetails"];
                    //ck_content = dataObj1["ipt_webdetails"];                    
                    myEditor.setData(decodeURIComponent(ck_content.value));
                    //$(".ck-content").html(ck_content);                    
                    if (dataObj1["ipt_mainimg"]) {                      
                            //var mainSrc = dataObj1["ipt_mainimg"];                            
                        //var thumbSrc = mainSrc + "_.jpg";
                            var thumbSrc = dataObj1["ipt_mainimg"];
                            var mainSrc = dataObj1["ipt_mainimg"].split("_")[0];
                            var input = document.createElement("input");                          
                            var a = document.createElement("a");
                            var del_img = document.createElement("img");
                            //var node = document.createTextNode("删除");                            
                            input.setAttribute("type", "hidden");
                            input.setAttribute("name", "hid_photo_name");
                            input.setAttribute("value", mainSrc + "|" + thumbSrc);
                            input.setAttribute("class", "hidden-src");                                                
                            a.setAttribute("href", "javascript:;");
                            a.setAttribute("onclick", "delImg_(this);");
                            del_img.setAttribute("src", "/UpLoadImg/a7.png");
                            del_img.setAttribute("class", "delete");
                        //a.appendChild(node); 
                            a.appendChild(del_img);
                            $(".upload-imgurl").attr("src", thumbSrc);
                            $(".imgDiv").append(a);
                            $("#main_rig").append(input);                                                                                                
                    }                    
                                      
                    if (dataObj1["ipt_imgs"]) {
                        for (var i = 0; i < dataObj1["ipt_imgs"].split(";").length - 1; i++) {                            
                            //var mainSrc = dataObj1["ipt_imgs"].split(";")[i];
                            //var thumbSrc = mainSrc + "_.jpg";
                            var thumbSrc = dataObj1["ipt_imgs"].split(";")[i];
                            var mainSrc = dataObj1["ipt_imgs"].split(";")[i].split("_")[0];
                            var li = document.createElement("li");
                            var input = document.createElement("input");                            
                            var img = document.createElement("img");
                            var a = document.createElement("a");
                            var del_img = document.createElement("img");
                            //var node = document.createTextNode("删除");
                            li.setAttribute("class", "fl");
                            input.setAttribute("type", "hidden");
                            input.setAttribute("class", "hidden-src");
                            input.setAttribute("name", "hid_photo_name");
                            input.setAttribute("value", mainSrc + "|" + thumbSrc);                            
                            img.setAttribute("id", "imagelist");
                            img.setAttribute("class", "image-list");                            
                            img.setAttribute("src", thumbSrc);
                            a.setAttribute("href", "javascript:;");
                            a.setAttribute("onclick", "delImg(this);");
                            del_img.setAttribute("src", "/UpLoadImg/a7.png");
                            del_img.setAttribute("class", "delete");
                            //a.appendChild(node);
                            a.appendChild(del_img);
                            li.appendChild(img);
                            li.appendChild(input);                            
                            li.appendChild(a);
                            $(".photo-list").children("ul").append(li);                                                     
                        }
                    }                                      
                }
            });
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
            var introduce = $("#ipt_introduce").val();
            var remarks = $("#ipt_remarks").val();
            var introduce_ = "";
            var remarks_ = "";
            var list_src = "";
            var h1_ = $("#name").text();

            var myeditor = myEditor.getData();        
            myeditor = encodeURIComponent(myeditor);

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
            postdata += "\"" + "ipt_name" + "\":\"" + h1_ + "\",";
            if ($(".upload-img").siblings(".imgDiv").children("img").attr("src") != undefined) {
                var mainSrc = $(".upload-img").siblings(".hidden-src").val().split("|")[1];
                postdata += "\"" + "ipt_mainImg" + "\":\"" + mainSrc + "\",";
            }            
            else {
                postdata += "\"" + "ipt_mainImg" + "\":\"" + "" + "\",";
            }
            if ($(".upload-album").siblings(".photo-list").children("ul").children("li")) {
                $(".photo-list").find("li").each(function () {
                    var val = $(this).children(".hidden-src").val();                    
                    list_src += val.split("|")[1] + ";";
                })
                postdata += "\"" + "ipt_imgs" + "\":\"" + list_src + "\",";
            }
            else {
                postdata += "\"" + "ipt_imgs" + "\":\"" + "" + "\",";
            }
            postdata += "\"" + "ipt_webDetails" + "\":\"" + myeditor + "\",";
           

            postdata = postdata.substr(0, postdata.length - 1);
            postdata += "}";
            return eval("(" + postdata + ")");
        }
        function Editdata() {                       
            var id = "";
            var url = location.search; //获取url中"?"符后的字串
            if (url.indexOf("?") != -1) {    //判断是否有参数
                var str = url.substr(1); //从第一个字符开始 因为第0个是?号 获取所有除问号的所有符串
                strs = str.split("=");   //用等号进行分隔 （因为知道只有一个参数 所以直接用等号进分隔 如果有多个参数 要用&号分隔 再用等号进行分隔）
                //alert(strs[1]);          //直接弹出第一个参数 （如果有多个参数 还要进行循环的）
                id = strs[1];
            }
            var json = GetInputData("form1", "edit");
            json["id"] = id;
            $.ajax({
                url: 'Introduction.aspx',
                type: "post",
                async: false,
                data: json,
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
        function re() {
            location.reload();
        }
        function collect_initImg() {
            if ($(".upload-img").siblings(".imgDiv").children("img").attr("src") != undefined) {
                var imgNames = $("#main_rig").children(".hidden-src").val();
                initArry.push(imgNames.split("|")[0], imgNames.split("|")[1]);
            }          
            if ($(".upload-album").siblings(".photo-list").children("ul").children("li")) {
                $(".photo-list").find("li").each(function () {
                    initArry.push($(this).children(".hidden-src").val().split("|")[0], $(this).children(".hidden-src").val().split("|")[1]);
                });
            }                      
        }
        //取消按钮操作
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
                var imgNames = $("#main_rig").children(".hidden-src").val();
                lastArry.push(imgNames.split("|")[0], imgNames.split("|")[1]);
            }            
            if ($(".upload-album").siblings(".photo-list").children("ul").children("li")) {
                $(".photo-list").find("li").each(function () {
                    lastArry.push($(this).children(".hidden-src").val().split("|")[0], $(this).children(".hidden-src").val().split("|")[1]);
                });
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
    </script>
</body>
</html>
