<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="GoosleB2C.Web.Admin.CompanyInfo.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="/webuploader/webuploader.css" /> 
    <link rel="stylesheet" type="text/css" href="/webuploader/smart-green.css" />      
	<script type="text/javascript" src="/webuploader/jquery-1.8.3.min.js"></script>    
	<script type="text/javascript" src="/webuploader/webuploader.min.js"></script>
	<script type="text/javascript" charset="utf-8" src="/webuploader/uploader.js"></script> 
    <title></title>
</head>
<body>
    <form id="form1">
        <div class="smart-green tab" style="margin-left:30px;">
                  <ul style="-webkit-padding-start: 0px;">
                      <li class="lef">
                          <span>主图(至多五张,建议图片大小为800*800)</span>
                      </li>                   
                      <li class="rig">
                          <div style="float: left;" class="upload-box upload-album"></div>
                          <div style="float: left; margin-left: 8px;">
                              <%--<input id="chkThumb" name="chkThumb" type="checkbox" value="1" />
                              <label for="chkThumb">是否生成缩略图</label>--%>
                          </div>
                          <div class="clear"></div>
                          <div class="photo-list" style="max-height: 400px; overflow: auto;">
                              <ul>
                              </ul>
                          </div>                                                  
                      </li>
                      <li class="clear"></li>                     
                  </ul>
                                                                       
                  <ul style="-webkit-padding-start: 0px;">
                      <li class="lef">
                          <span>手机详情页图片</span>
                      </li>                   
                      <li class="rig">
                          <div style="float: left;" class="upload-box pupload-album"></div>
                          <div style="float: left; margin-left: 8px;">
                              <%--<input id="chkThumb" name="chkThumb" type="checkbox" value="1" />
                              <label for="chkThumb">是否生成缩略图</label>--%>
                          </div>
                          <div class="clear"></div>
                          <div class="photo-list" style="max-height: 400px; overflow: auto;">
                              <ul>
                              </ul>
                          </div>                                                  
                      </li>
                      <li class="clear"></li>                     
                  </ul>
              </div>
    </form>
    <script type="text/javascript">
        var waterMarkType = "";
        var waterMarkPosition = "";
        var waterMarkContent = "";
        var waterMarkPicture = "";
        var waterMarkTransparency = "";
        $(function () {
            queryWatermark_state();
            $(".upload-album").InitUploader({
                btntext: "点击上传",
                multiple: true,
                water: false,
                width: "800",
                height: "800",
                Logo_brand: "Multiple_other",
                waterMarkType: waterMarkType,
                waterMarkPosition: waterMarkPosition,
                waterMarkContent: waterMarkContent,
                waterMarkPicture: waterMarkPicture,
                waterMarkTransparency: waterMarkTransparency,
                sendurl: "../../webuploader/cs_ashx/ajax.ashx",
            });
            $(".pupload-album").InitUploader({
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
                sendurl: "../../webuploader/cs_ashx/ajax.ashx",
            });
        });
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
            });
        }
    </script>
</body>
</html>
