<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webupload.aspx.cs" Inherits="GoosleB2C.Web.Admin.Sys.webupload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="/webuploader/smart-green.css" rel="stylesheet" />
	<link rel="stylesheet" type="text/css" href="/webuploader/webuploader.css" />
	<script type="text/javascript" src="/webuploader/jquery-1.8.3.min.js"></script>
	<script type="text/javascript" src="/webuploader/webuploader.min.js"></script>
	<script type="text/javascript" charset="utf-8" src="/webuploader/uploader.js"></script>
    <title></title>
    <style type="text/css">
		.fl {
			float: left;
			width: 350px;
			list-style-type: none;
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
			width: 90px;
		}

		.rig {
			float: left;
			width: 870px;
		}
		
	</style>
</head>
<body>
    <form id="form1">
		<div class="smart-green tab">
			<h1>webuploader图片单张,多张批量上传,可设置生成缩略图
			<span>运用webuploader无刷新上传图片</span>
			</h1>
			<ul style="height: 320px;">
				<li class="lef"><span>单张上传:</span></li>
				<li id="main_img" class="rig">
					<input type="text" style="float: left; height: 30px; width: 450px;" readonly="readonly" name="txtImgUrl" class="upload-path" />
					<div style="float: left; margin-left: 8px;" class="upload-box upload-img"></div>
					<div style="clear: both;"></div>
					<img id="imageurl" class="upload-imgurl" width="300" />
				</li>
				<li class="clear"></li>
			</ul>
			<ul>
				<li class="lef"><span>批量上传</span></li>
				<li class="rig">
					<div style="float: left; " class="upload-box upload-album"></div>
					<div style="float: left; margin-left: 8px;"><input id="chkThumb" name="chkThumb" type="checkbox" value="1" /><label for="chkThumb">是否生成缩略图</label></div>
					<div class="clear"></div>
					<div class="photo-list">
						<ul>
						
						</ul>
					</div>
				</li>
				<li class="clear"></li>
			</ul>
			<label>
				<span>&nbsp;</span>
				<input type="button"  class="button" value="Save"  />
			</label>
		</div>
	</form>

    <script type="text/javascript">
        $(function () {

            //初始化上传控件
            $(".upload-img").InitUploader({
                sendurl: "/webuploader/cs_ashx/ajax.ashx",
            });

            $(".upload-album").InitUploader({
                btntext: "批量上传",
                multiple: true,
                water: false,
                thumbnail: false,
                sendurl: "/webuploader/cs_ashx/ajax.ashx",
            });
        });

    </script>
</body>
</html>
