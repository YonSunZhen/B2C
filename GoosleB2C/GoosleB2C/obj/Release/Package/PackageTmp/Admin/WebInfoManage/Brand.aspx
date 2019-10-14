<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Brand.aspx.cs" Inherits="GoosleB2C.Web.Admin.WebInfoManage.Brand" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="/webuploader/webuploader.css" /> 
    <link rel="stylesheet" type="text/css" href="/webuploader/smart-green.css" />      
	<script type="text/javascript" src="/webuploader/jquery-1.8.3.min.js"></script>    
	<script type="text/javascript" src="/webuploader/webuploader.min.js"></script>
	<script type="text/javascript" charset="utf-8" src="/webuploader/upload_brand.js"></script>

    <script src="/JS/easyUI/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="/JS/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <link href="/JS/easyUI/themes/gray/easyui.css" rel="stylesheet" type="text/css" /> 
    <link href="/JS/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="/JS/wikmenu.js" type="text/javascript"></script>
    <script src="/JS/wikmain.js" type="text/javascript"></script>
    <title></title>
    <style>
        .edit_info{
            width:1060px;
            margin:auto;            
        }
        .brand_fl {
            float: left;            
            margin-top: 7px;
            margin-bottom: 5px;
            margin-right: 5px;           
        }
        .brand_fl select {
            width:175px; 
            vertical-align:middle;
            height:33px;
            margin-left:16px;                            
        }
        .brand_fl input{
            vertical-align:middle;
            margin-left:16px;
            width:504px;
            height:30px;
            font-size:16px;
            text-indent:10px;
            border-radius:5px;
            outline:none;
            border:0.5px;
            border-style:solid;
            border-color:#528ecc;            
        }
        .brand_fl .imgDiv{
            vertical-align:middle;
        }
        #web_rig #imagelist{
            width:400px;
            height:115px;
        }
        #phone_rig #imagelist{
            width:375px;
            height:160px;
        }
        #weixin_rig #imagelist{
            width:375px;
            height:160px;
        }      
    </style>
</head>
<body>
    <form id ="form_edit" method="post" action="Brand.aspx">
        <div style="font-size:30px;font-weight:bold;margin-top:13px; margin-left:8px;">展示图管理</div>
        <div class="smart-green tab">                                                                            
            <ul style="-webkit-padding-start: 0px;">
				<li class="lef">
                    <span>电脑端图（最多上传三张,1920*552）</span>
				</li>
				<li id="web_rig" class="rig">
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
            
            <ul style="-webkit-padding-start: 0px;">
				<li class="lef">
                    <span>手机端图（最多上传五张375*160）</span>
				</li>
				<li id="phone_rig" class="rig">
					<div style="float: left; margin-left:8px;" class="upload-box pupload-album"></div>	
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
            
            <ul style="-webkit-padding-start: 0px;">
				<li class="lef">
                    <span>小程序端图（最多上传五张375*160）</span>
				</li>
				<li id="weixin_rig" class="rig">
					<div style="float: left; margin-left:8px;" class="upload-box vupload-album"></div>	
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
                                                                                                              
            <label>			   
			    <input type="button"  class="button" value="取消" onclick="re_(); re(); "  />
	        </label>
            <label>			    
			    <input type="button"  class="button" value="提交" onclick="Editdata(); Del();"  />
	        </label>
        </div>
    </form>

    <script type="text/javascript">
        var initArry = [];
        var waterMarkType = "";
        var waterMarkPosition = "";
        var waterMarkContent = "";
        var waterMarkPicture = "";
        var waterMarkTransparency = "";
        $(function () {
            InitGird();
            queryWatermark_state();
            $(".upload-album").InitUploader({
                btntext: "点击上传",
                multiple: true,
                water: false,
                width: "1920",
                height: "552",
                Logo_brand: "success_Del",
                waterMarkType: waterMarkType,
                waterMarkPosition: waterMarkPosition,
                waterMarkContent: waterMarkContent,
                waterMarkPicture: waterMarkPicture,
                waterMarkTransparency: waterMarkTransparency,
                sendurl: "/webuploader/cs_ashx/ajax.ashx",
            });
            $(".pupload-album").InitUploader({
                btntext: "点击上传",
                multiple: true,
                water: false,
                width: "375",
                height: "160",
                Logo_brand: "success_Del",
                waterMarkType: waterMarkType,
                waterMarkPosition: waterMarkPosition,
                waterMarkContent: waterMarkContent,
                waterMarkPicture: waterMarkPicture,
                waterMarkTransparency: waterMarkTransparency,
                sendurl: "/webuploader/cs_ashx/ajax.ashx",
            });
            $(".vupload-album").InitUploader({
                btntext: "点击上传",
                multiple: true,
                water: false,
                width: "375",
                height: "160",
                Logo_brand: "success_Del",
                waterMarkType: waterMarkType,
                waterMarkPosition: waterMarkPosition,
                waterMarkContent: waterMarkContent,
                waterMarkPicture: waterMarkPicture,
                waterMarkTransparency: waterMarkTransparency,
                sendurl: "/webuploader/cs_ashx/ajax.ashx",
            });            
            collect_initImg();
            $(".imgDiv").mouseenter(function () {
                $(this).find(".delete").show();
            });
            $(".imgDiv").mouseleave(function () {
                $(this).find(".delete").hide();
            });
        });
        function InitGird() {
            $.ajax({
                url: 'Brand.aspx',
                type: 'post',
                data: { "action": "query" },
                async: false,
                success: function (data) {
                    var dataObj1 = eval("(" + data + ")"); //转换为json对象
                    var imgArry = [];
                    var pimgArry = [];
                    var vimgArry = [];                    
                    imgArry.push(dataObj1["ipt_img1"]);                                        
                    imgArry.push(dataObj1["ipt_img2"]);                                        
                    imgArry.push(dataObj1["ipt_img3"]);
                                       
                    pimgArry.push(dataObj1["ipt_pimg1"]);                                       
                    pimgArry.push(dataObj1["ipt_pimg2"]);                                      
                    pimgArry.push(dataObj1["ipt_pimg3"]);                                        
                    pimgArry.push(dataObj1["ipt_pimg4"]);                                        
                    pimgArry.push(dataObj1["ipt_pimg5"]);
                                        
                    vimgArry.push(dataObj1["ipt_vimg1"]);                                       
                    vimgArry.push(dataObj1["ipt_vimg2"]);                                        
                    vimgArry.push(dataObj1["ipt_vimg3"]);                                        
                    vimgArry.push(dataObj1["ipt_vimg4"]);                                        
                    vimgArry.push(dataObj1["ipt_vimg5"]);
                    var imgArry_size = imgArry.length;
                    var pimgArry_size = pimgArry.length;
                    var vimgArry_size = vimgArry.length;
                    for (var i = 0; i < imgArry_size; i++) {
                        i = i + 1;
                        var urls = "ipt_url" + i;
                        add_Li(imgArry[i-1], ".upload-album", dataObj1[urls]);
                        i = i - 1;
                    }
                    for (var i = 0; i < pimgArry_size; i++) {
                        var i = i + 1;
                        var urls = "ipt_purl" + i;
                        add_Li(pimgArry[i-1], ".pupload-album", dataObj1[urls]);
                        i = i - 1;
                    }
                    for (var i = 0; i < vimgArry_size; i++) {
                        var i = i + 1;
                        var urls = "ipt_vurl" + i;
                        add_Li(vimgArry[i-1], ".vupload-album", dataObj1[urls]);
                        i = i - 1;
                    }
                }
            })
        }
        function queryWatermark_state() {
            $.ajax({
                type: "post",
                async: false,                
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
            var postdata = "{ \"action\":\"" + cmd + "\",";                        
            var img_Arry = [];
            var url_Arry = [];
            var pimg_Arry = [];
            var purl_Arry = [];
            var vimg_Arry = [];
            var vurl_Arry = [];
            if ($(".upload-album").siblings(".photo-list").children("ul").children("li")) {
                $(".upload-album").siblings(".photo-list").find("li").each(function () {
                    var val = $(this).children(".imgDiv").children(".hidden-src").val();
                    var type_id = $(this).children("select").val() + ";" + $(this).children(".ID").val();
                    img_Arry.push(val.split("|")[1]);
                    url_Arry.push(type_id);
                })
                for (var i = 0; i < img_Arry.length; i++) {
                    var i = i + 1;
                    var ipt_imgs = "ipt_img" + i;
                    var ipt_urls = "ipt_url" + i;
                    var url_value = 
                    postdata += "\"" + ipt_imgs + "\":\"" + img_Arry[i - 1] + "\",";
                    postdata += "\"" + ipt_urls + "\":\"" + url_Arry[i - 1] + "\",";
                    i = i - 1;
                }
            }
            if ($(".pupload-album").siblings(".photo-list").children("ul").children("li")) {
                $(".pupload-album").siblings(".photo-list").find("li").each(function () {
                    var val = $(this).children(".imgDiv").children(".hidden-src").val();
                    var type_id = $(this).children("select").val() + ";" + $(this).children(".ID").val();
                    pimg_Arry.push(val.split("|")[1]);
                    purl_Arry.push(type_id);
                })
                for (var i = 0; i < pimg_Arry.length; i++) {
                    var i = i + 1;
                    var ipt_imgs = "ipt_pimg" + i;
                    var ipt_urls = "ipt_purl" + i;
                    var url_value =
                    postdata += "\"" + ipt_imgs + "\":\"" + pimg_Arry[i - 1] + "\",";
                    postdata += "\"" + ipt_urls + "\":\"" + purl_Arry[i - 1] + "\",";
                    i = i - 1;
                }
            }
            if ($(".vupload-album").siblings(".photo-list").children("ul").children("li")) {
                $(".vupload-album").siblings(".photo-list").find("li").each(function () {
                    var val = $(this).children(".imgDiv").children(".hidden-src").val();
                    var type_id = $(this).children("select").val() + ";" + $(this).children(".ID").val();
                    vimg_Arry.push(val.split("|")[1]);
                    vurl_Arry.push(type_id);
                })
                for (var i = 0; i < vimg_Arry.length; i++) {
                    var i = i + 1;
                    var ipt_imgs = "ipt_vimg" + i;
                    var ipt_urls = "ipt_vurl" + i;
                    var url_value =
                    postdata += "\"" + ipt_imgs + "\":\"" + vimg_Arry[i - 1] + "\",";
                    postdata += "\"" + ipt_urls + "\":\"" + vurl_Arry[i - 1] + "\",";
                    i = i - 1;
                }
            }

            postdata = postdata.substr(0, postdata.length - 1);
            postdata += "}";
            return eval("(" + postdata + ")");
        }
        function Editdata() {            
            var json = GetInputData("form_edit", "edit");            
            $.ajax({
                url: 'Brand.aspx',
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
        function re_() {
            //获得页面初始化后叉掉的图片数组
            var delImgarry = arry;
            //获得页面初始化后的图片数组
            var initImgarry = initArry;
            //alert(delImgarry);
            //获得进行各种操作后最终页面上的图片数组
            var lastImgarry = GetLastImg();
            var up_Img = [];
            var delImgarry_size = delImgarry.length;
            var initImgarry_size = initImgarry.length;
            var lastImgarry_size = lastImgarry.length;
            for (var i = 0; i < delImgarry_size; i++) {
                var obj = delImgarry[i];
                var isExit = false;
                for (var j = 0; j < initImgarry_size; j++) {
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
            for (var i = 0; i < lastImgarry_size; i++) {
                var obj = lastImgarry[i];
                var isExit = false;
                for (var j = 0; j < initImgarry_size; j++) {
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

            var upImg_size = up_Img.length - 1;
            for (var i = 0; i < upImg_size;) {
                delete_Imgs_ajax(up_Img[i], up_Img[i + 1]);
                i += 2;
            }
        }
        function GetLastImg() {
            var lastArry = [];            
            if ($(".upload-album").siblings(".photo-list").children("ul").children("li")) {
                $(".upload-album").siblings(".photo-list").find("li").each(function () {
                    lastArry.push($(this).children(".imgDiv").children(".hidden-src").val().split("|")[0], $(this).children(".imgDiv").children(".hidden-src").val().split("|")[1]);
                });
            }
            if ($(".pupload-album").siblings(".photo-list").children("ul").children("li")) {
                $(".pupload-album").siblings(".photo-list").find("li").each(function () {
                    lastArry.push($(this).children(".imgDiv").children(".hidden-src").val().split("|")[0], $(this).children(".imgDiv").children(".hidden-src").val().split("|")[1]);
                });
            }
            if ($(".vupload-album").siblings(".photo-list").children("ul").children("li")) {
                $(".vupload-album").siblings(".photo-list").find("li").each(function () {
                    lastArry.push($(this).children(".imgDiv").children(".hidden-src").val().split("|")[0], $(this).children(".imgDiv").children(".hidden-src").val().split("|")[1]);
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
        function collect_initImg() {
            if ($(".upload-album").siblings(".photo-list").children("ul").children("li")) {
                $(".upload-album").siblings(".photo-list").find("li").each(function () {
                    initArry.push($(this).children(".imgDiv").children(".hidden-src").val().split("|")[0], $(this).children(".imgDiv").children(".hidden-src").val().split("|")[1]);
                });
            }
            if ($(".pupload-album").siblings(".photo-list").children("ul").children("li")) {
                $(".pupload-album").siblings(".photo-list").find("li").each(function () {
                    initArry.push($(this).children(".imgDiv").children(".hidden-src").val().split("|")[0], $(this).children(".imgDiv").children(".hidden-src").val().split("|")[1]);
                });
            }
            if ($(".vupload-album").siblings(".photo-list").children("ul").children("li")) {
                $(".vupload-album").siblings(".photo-list").find("li").each(function () {
                    initArry.push($(this).children(".imgDiv").children(".hidden-src").val().split("|")[0], $(this).children(".imgDiv").children(".hidden-src").val().split("|")[1]);
                });
            }
        }
        function add_Li(obj, cl, urls) {
            if (obj != "") {
                //var mainSrc = obj;
                //var thumbSrc = mainSrc + "_.jpg";
                var mainSrc = obj.split("_")[0];
                var thumbSrc = obj;
                var li = document.createElement("li");
                var imgDiv = document.createElement("div");
                var input = document.createElement("input");
                var input_Id = document.createElement("input");
                var img = document.createElement("img");
                var a = document.createElement("a");
                var del_img = document.createElement("img");
                var select = document.createElement("select");
                imgDiv.setAttribute("class", "imgDiv")
                //select.setAttribute("class", "easyui-combobox");
                select.setAttribute("panelMaxHeight", "200px");
                select.setAttribute("panelHeight", "auto");
                select.setAttribute("editable", "false");
                //select.setAttribute("style", "width:175px");
                select.add(new Option("未选择", "0"));
                select.add(new Option("产品", "1"));
                select.add(new Option("案例", "2"));
                select.add(new Option("文章", "3"));
                //var selectType = $('<select class="easyui-combobox" panelMaxHeight="200px" panelHeight="auto" editable="false" style="width: 175px;">'
                //                    + '<option value="1">产品</option>'
                //                    + '<option value="2">案例</option>'
                //                    + '<option value="3">文章</option>'
                //                    + '</select>');
                li.setAttribute("class", "brand_fl");
                input.setAttribute("type", "hidden");
                input.setAttribute("class", "hidden-src");
                input.setAttribute("name", "hid_photo_name");
                input.setAttribute("value", mainSrc + "|" + thumbSrc);
                input_Id.setAttribute("class", "ID");
                input_Id.setAttribute("name", "ID");
                
                input_Id.setAttribute("placeholder", "请输入id值");
                img.setAttribute("id", "imagelist");
                img.setAttribute("class", "image-list");
                img.setAttribute("src", thumbSrc);
                a.setAttribute("href", "javascript:;");
                a.setAttribute("onclick", "delImg(this);");
                del_img.setAttribute("src", "/UpLoadImg/a7.png");
                del_img.setAttribute("class", "delete");
                

                if (urls != "") {
                    input_Id.setAttribute("value", urls.split(";")[1]);
                    select.value = urls.split(";")[0];
                }
                else {
                    input_Id.setAttribute("value", "");
                    select.value = "0";
                }
                a.appendChild(del_img);
                imgDiv.appendChild(img);
                imgDiv.appendChild(input);
                imgDiv.appendChild(a);
                li.appendChild(imgDiv);
                li.appendChild(select);
                li.appendChild(input_Id);
                $(cl).siblings(".photo-list").children("ul").append(li);
                //$(".upload-album").siblings(".photo-list").children("ul").append(select);
                //$(".upload-album").siblings(".photo-list").children("ul").append(input_Id);                
            }
        }
    </script>
</body>
</html>
