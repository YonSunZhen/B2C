<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hahaha.aspx.cs" Inherits="GoosleB2C.Web.Admin.CompanyInfo.hahaha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="webuploader/webuploader.css" />
	<script type="text/javascript" src="js/jquery-1.8.3.min.js"></script>
	<script type="text/javascript" src="webuploader/webuploader.min.js"></script>
	<script type="text/javascript" charset="utf-8" src="js/uploader.js"></script>   
    <title></title>
    <style>
        .smart-green{
            max-width: 1000px;
            background: #F8F8F8;
            padding: 30px 30px 20px 30px;
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
            <ul style="height: 320px;">
				<li class="lef"><span>更改主图:</span></li>
				<li class="rig">
					<input type="text" style="float: left; height: 30px; width: 500px;" readonly="readonly" name="txtImgUrl" class="upload-path" />
					<div style="float: left; margin-left: 8px;" class="upload-box upload-img"></div>
					<div style="clear: both;"></div> 
                                      					
                    <div class="photo-one">
						<ul>
						
						</ul>
					</div>                
				</li>
				<li class="clear"></li>
			</ul>
            
            <ul>
				<li class="lef"><span>添加详情图</span></li>
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
        </div>
    </form>
  
    <script type="text/javascript">
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
            
        });             
    </script>
</body>
</html>
