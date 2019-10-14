<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="business_Culture.aspx.cs" Inherits="GoosleB2C.Web.Admin.CompanyInfo.business_Culture" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="webuploader/webuploader.css" />
	<script type="text/javascript" src="js/jquery-1.8.3.min.js"></script>
	<script type="text/javascript" src="webuploader/webuploader.min.js"></script>
	<script type="text/javascript" charset="utf-8" src="js/uploader.js"></script> 

    <script type="text/javascript" src="build/ckeditor.js"></script>

    <script src="/JS/easyUI/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="/JS/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <link href="/JS/easyUI/themes/gray/easyui.css" rel="stylesheet" type="text/css" /> 
    <link href="/JS/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="/JS/wikmenu.js" type="text/javascript"></script>
    <script src="/JS/wikmain.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://cdn.bootcss.com/bootstrap/3.3.7/css/bootstrap.min.css" type="text/css"/>
    <title></title>
    <style>
        .smart-green{
            max-width: 1000px;
            background: #F8F8F8;
            padding: 1px 30px 1px 30px;  
            margin:auto;          
            font: 12px Arial, Helvetica, sans-serif;
            color: #666;
            border-radius: 5px;
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
        }
        .fl {
			float: left;
			width: 350px;
			list-style-type: none;
            margin-bottom:5px;
            margin-right:5px;
		}
        .fl_ {
			float: left;
			width: 350px;
			list-style-type: none;
            margin-bottom:5px;
            margin-right:5px;
		}
        .clear {
			clear: both;
		}
		
		.tab ul li {
			line-height: 30px;
			list-style-type: none;
		}

		.lef {
			float: left;
			width: 110px;
		}

		.rig {
			float: left;
			width: 870px;
		}

        .ck {
			float: left;
			width: 870px;
		}

        textarea{
            resize:none
        }
        .dd{
            width:700px;
            height:210px;
            margin-left:30px;
            padding-right:50px;
        }
        .tt{
            width:700px;
            height:80px;
            margin-left:30px;
            padding-right:50px;
        }

        .smart-green label {
            line-height:28px;
            margin: 0px 0px 5px 30px;
        }
        .smart-green label>span {
            float: left;
            margin-top: 10px;
            color: #5E5E5E;
        }
        .smart-green .button {
            background-color: #9DC45F;
            border-radius: 5px;
            -webkit-border-radius: 5px;
            -moz-border-border-radius: 5px;
            border: none;
            padding: 10px 25px 10px 25px;
            color: #FFF;
            text-shadow: 1px 1px 1px #949494;
        }
        .smart-green .button:hover {
            background-color:#80A24A;
        }
        a{
            background: #E27575;
            border: none;
            padding: 10px 10px 10px 10px;
            color: #FFF;
            box-shadow: 1px 1px 5px #B6B6B6;
            border-radius: 3px;
            text-shadow: 1px 1px 1px #9E3F3F;
            cursor: pointer;
        }
        a:hover{
            background: #CF7A7A;
        }
        .form-group{
            margin-bottom:2px;
        }
        .ck-editor__editable{         
            max-width:870px;
            
        }
        .ck-editor__top{           
            max-width:870px;          
        }
        .ck{
            height:500px;
        }      
    </style>
</head>
<body>
    <h1 style="text-align:center;">企业文化</h1>
    <hr />   
    <form id="form1" method="post"> 
        <div class="smart-green">        
            <div class="form-group">
            <div class="dd">
                <h4>手机端文字详情:</h4>
                <textarea id="ipt_introduce" name="ipt_introduce" class="form-control" placeholder="请输入手机端文字详情" rows="8" cols="50"></textarea>                 
            </div>
            </div>                     
        </div>          
        <div class="smart-green tab">
            <ul style="height: 260px; padding-left: 30px;">
                <li class="lef">
                    <h4>主图</h4>
                </li>
                <li class="rig">
                    <input type="hidden" style="float: left; height: 30px; width: 500px;" readonly="readonly" name="txtImgUrl" class="upload-path" />
                    <div style="float: left; margin-left: 8px; margin-left: 0px;" class="upload-box upload-img"></div>
                    <div style="clear: both;"></div>

                    <div class="photo-one">
                        <ul>
                        </ul>
                    </div>
                </li>
                <li class="clear"></li>
            </ul>
            
            <%--CKEditor5--%>
            <div style="padding-left:30px;">
                <textarea rows="30" cols="50" name="editor" id="editor"></textarea>
            </div>        
                                  
            <ul style="padding-left:30px;">
				<li class="lef"><h4>手机端详情图</h4></li>
				<li class="rig">
					<div style="float: left; " class="upload-box upload-album"></div>	
                    <%--<div style="float: left; margin-left: 8px;"><input id="chkThumb" name="chkThumb" type="checkbox" value="1" /><label for="chkThumb">是否生成缩略图</label></div>--%>				
					<div class="clear"></div>
					<div class="photo-list" style="height:400px;overflow:auto;">
						<ul>
						
						</ul>
					</div>
				</li>
				<li class="clear"></li>
			</ul>
              
            <div class="form-group">
            <div class="dd">
                <h4>备注:</h4>
                <textarea id="ipt_remarks" name="ipt_remarks" class="form-control" placeholder="请输入备注:" rows="8" cols="50"></textarea> 
            </div>                      
            </div>                             
            <label>
			    <span>&nbsp;</span>
			    <input type="button"  class="button" value="提交" onclick="Editdata(2); Del();"  />
	        </label>
            <label>
			    <span>&nbsp;</span>
			    <input type="button"  class="button" value="取消" onclick="re(2);"  />
	        </label>
        </div> 
        <input type="hidden" id="ck_content" />            
    </form>

    <script type="text/javascript">
        var myEditor = null;
           
        $(function () {            
            $(".upload-img").InitUploader({
                sendurl: "ajax.ashx",
            });
            $(".upload-album").InitUploader({
                btntext: "点击上传",
                multiple: true,
                water: false,
                thumbnail: true,
                sendurl: "ajax.ashx",
            });           
            
            InitGird(2);
            
        });
        ClassicEditor
                .create(document.querySelector('#editor'), {
                    ckfinder: {
                        uploadUrl: 'ajax.ashx?action=UpLoadFile'
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
                url: 'business_Culture.aspx',
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

                    var ck_content = document.getElementById("ck_content");
                    ck_content.value = dataObj1["ipt_webdetails"];
                    //ck_content = dataObj1["ipt_webdetails"];                    
                    myEditor.setData(decodeURIComponent(ck_content.value));
                    //$(".ck-content").html(ck_content);
                    

                    if (dataObj1["ipt_mainimg"]) {                      
                            var mainGuid = dataObj1["ipt_mainimg"].split("/")[4].slice(3);
                            var other = "/" + dataObj1["ipt_mainimg"].split("/")[1] + "/" + dataObj1["ipt_mainimg"].split("/")[2] + "/" + dataObj1["ipt_mainimg"].split("/")[3] + "/";
                            var thumbSrc = "../../" + other + "thumb_" + mainGuid;
                            var mainSrc = "../.." + dataObj1["ipt_mainimg"];
                            var li = document.createElement("li");
                            var input = document.createElement("input");
                            var img = document.createElement("img");
                            var a = document.createElement("a");
                            var node = document.createTextNode("删除");
                            li.setAttribute("class", "fl");
                            input.setAttribute("type", "hidden");
                            input.setAttribute("name", "hid_photo_name");
                            input.setAttribute("value", mainSrc + "|" + thumbSrc);
                            img.setAttribute("id", "imageurl");
                            img.setAttribute("class", "upload-imgurl");
                            //img.setAttribute("width", "300");
                            img.setAttribute("src", thumbSrc);
                            a.setAttribute("href", "javascript:;");
                            a.setAttribute("onclick", "delImg(this);");
                            a.appendChild(node);
                            li.appendChild(input);
                            li.appendChild(img);
                            li.appendChild(a);
                            $(".photo-one").children("ul").append(li);                                                                        
                    }
                    else
                    {
                        var li = document.createElement("li");
                        li.setAttribute("class", "fl");
                        li.innerHTML = "没有图片！";
                        $(".photo-one").children("ul").append(li);
                    }
                                      
                    if (dataObj1["ipt_imgs"]) {
                        for (var i = 0; i < dataObj1["ipt_imgs"].split(";").length - 1; i++) {
                            var one = dataObj1["ipt_imgs"].split(";")[i];
                            var mainGuid = one.split("/")[4].slice(3);
                            var other = "/" + one.split("/")[1] + "/" + one.split("/")[2] + "/" + one.split("/")[3] + "/";
                            var thumbSrc = "../../" + other + "thumb_" + mainGuid;
                            var mainSrc = "../.." + one;
                            var li = document.createElement("li");
                            var input = document.createElement("input");
                            var input1 = document.createElement("input");
                            var img = document.createElement("img");
                            var a = document.createElement("a");
                            var node = document.createTextNode("删除");
                            li.setAttribute("class", "fl");
                            input.setAttribute("type", "hidden");
                            input.setAttribute("class", "hidden-src");
                            input.setAttribute("name", "hid_photo_name");
                            input.setAttribute("value", mainSrc + "|" + thumbSrc);
                            input1.setAttribute("type", "hidden");
                            input1.setAttribute("name", "hid-photo-remark");
                            input1.setAttribute("value", "");
                            img.setAttribute("id", "imagelist");
                            img.setAttribute("class", "image-list");
                            //img.setAttribute("width", "300");
                            img.setAttribute("src", thumbSrc);
                            a.setAttribute("href", "javascript:;");
                            a.setAttribute("onclick", "delImg(this);");
                            a.appendChild(node);
                            li.appendChild(img);
                            li.appendChild(input);
                            li.appendChild(input1);
                            li.appendChild(a);
                            $(".photo-list").children("ul").append(li);                                                     
                        }
                    }
                    else
                    {
                        var li = document.createElement("li");
                        li.setAttribute("class", "fl_");
                        li.innerHTML = "没有图片！";
                        $(".photo-list").children("ul").append(li);
                    }                   
                }
            });
        }
        function GetInputData(id, cmd) {                     
            //var list_len = $(".upload-album").siblings(".photo-list").children("ul").children("li").length;
            var introduce = $("#ipt_introduce").val();
            var remarks = $("#ipt_remarks").val();
            var introduce_ = "";
            var remarks_ = "";
            var list_src = "";
            
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
            if ($(".upload-img").siblings(".photo-one").children("ul").children("li").children("img").length > 0) {
                var main_thumbSrc = $(".upload-img").siblings(".photo-one").children("ul").children("li").children("input").val();
                var mainSrc = main_thumbSrc.split("|")[0].slice(5);
                var thumbSrc = main_thumbSrc.split("|")[1];
                postdata += "\"" + "ipt_mainImg" + "\":\"" + mainSrc + "\",";
            }
            else {
                postdata += "\"" + "ipt_mainImg" + "\":\"" + "" + "\",";
            }
            if ($(".upload-album").siblings(".photo-list").children("ul").children("li").children("img").length > 0) {
                $(".photo-list").find("li").each(function () {
                    var val = $(this).children(".hidden-src").val();
                    list_src += val.split("|")[0].slice(5) + ";";
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
        function Editdata(id) {           
            //var ck_Src = $(".ck-content img").attr("src");
            var json = GetInputData("form1", "edit");
            json["id"] = id;
            $.ajax({
                url: 'business_Culture.aspx',
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
        function re(id) {
            location.reload();
        }       
    </script>
</body>
</html>
