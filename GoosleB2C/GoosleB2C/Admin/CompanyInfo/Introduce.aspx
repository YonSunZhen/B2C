<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Introduce.aspx.cs" Inherits="GoosleB2C.Web.Admin.CompanyInfo.Introduce" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="/JS/easyUI/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://cdn.bootcss.com/bootstrap/3.3.7/css/bootstrap.min.css" type="text/css"/>
    <link href="css/common.css" type="text/css" rel="stylesheet"/>
    <link href="css/index.css" type="text/css" rel="stylesheet"/>
    <%--<script src="js/jquery-1.8.3.min.js" type="text/javascript"></script>--%>    
    <script src="js/imgUp1.js"></script> 
    <script src="js/imgUp.js"></script>         
    <title></title>
    <style>
        #main{
            width:800px;
            height:400px;
            margin-left:50px;
            margin-top:30px;
            /*background-color:red;*/        
        }
        #introduce{
            margin:0 auto;
            text-align:center;
        }
        #content{
            margin:0 auto;
            /*text-align:center;*/
        }
        #imgs div{
            float:left;
            padding:3px;
        }
        #imgs div img{
            width:484px;
            height:284px;
        }
        #imgs1 div{
            float:left;
            padding:3px;
        }
        #imgs1 div img{
            width:150px;
            height:150px;
        }
    </style>
</head>
<body>  
    <div id="main">
        <form id="form_edit" enctype="multipart/form-data" method="post">
            <div class="form-group">               
                <h3>公司简介</h3>
            </div>
            <hr />                    
            <div class="form-group form-inline">
               <label for="exampleInputName2">副标题:</label>
               <input name="ipt_name2" type="text" class="form-control" id="ipt_name2" placeholder="请输入副标题" style="width:93.5%"/>
            </div> 
                     
            <div class="form-group">
                <label for="exampleInputName3">简介文字详情:</label>
                <textarea name="ipt_introduce" class="form-control" rows="3" placeholder="请输入简介文字详情" id="ipt_introduce"></textarea>
            </div>
                     
            <%--<div class="form-group">
                <label>封面图片:</label>
                <label for="imgFile1"><img id="add_img1" style="width:40px;height:40px;" src="../../UpLoadImg/添加按钮.png"/></label>
                <label>(点击上传)</label>
                <input type="file" name="imgFile1" id="imgFile1" style="display:none" />
                <div id="imgs" style="width:500px;height:300px;border:2px solid #e6e2e2;padding:3px;">                                                                                
                </div>
            </div> --%>  
            <label>封面图片:</label>  
            <div class="img-box full">
	            <section class=" img-section">	            
		            <div id="first" class="z_photo1 upimg-div clear" >			   
				            <section class="z_file fl">
					            <img src="img/a11.png" class="add-img"/>
					            <input type="file" name="file" id="file1" class="file1" value="" accept="image/jpg,image/jpeg,image/png,image/bmp" multiple="multiple" />
				            </section>
		            </div>
	            </section>
            </div>    
                                                       
            <%--<div class="form-group">
                <label>图片详情:</label>
                <label for="imgFile2"><img id="add_img2" style="width:40px;height:40px;" src="../../UpLoadImg/添加按钮.png"/></label>
                <label>(点击上传)</label>
                <input type="file" name="imgFile2" id="imgFile2" style="display:none" multiple />
                <div id="imgs1" style="width:800px;height:200px;overflow:auto;border:2px solid #e6e2e2;padding:3px;">                                                                                
                </div>
            </div>--%>
            <label>图片详情:</label>
            <div class="img-box full">
	            <section class=" img-section">	            
		            <div id="second" class="z_photo upimg-div clear" >			   
				            <section class="z_file fl">
					            <img src="img/a11.png" class="add-img"/>
					            <input type="file" name="file" id="file" class="file" value="" accept="image/jpg,image/jpeg,image/png,image/bmp" multiple="multiple" />
				            </section>
		            </div>
	            </section>
            </div>
            <aside class="mask works-mask">
	            <div class="mask-content">
		            <p class="del-p ">您确定要删除作品图片吗？</p>
		            <p class="check-p"><span class="del-com wsdel-ok">确定</span><span class="wsdel-no">取消</span></p>
	            </div>
            </aside>


            <div class="form-group">
                <label for="ipt_remarks">备注:</label>
                <textarea name="ipt_remarks" class="form-control" rows="3" placeholder="请输入备注:" id="ipt_remarks"></textarea>
            </div> 
            <div class="form-inline">
               <button onclick="Editdata(1)" class="btn btn-default">提交修改</button>               
               <button onclick="re(1)" class="btn btn-default">取消</button>
            </div>                      
        </form>                            
    </div>
   
<script type="text/javascript">              
    //var oImgs = document.getElementById("imgs");
    //var oImgs1 = document.getElementById("imgs1");
    $(function () {
        QueryData(1);       
    })
    function QueryData(id) {
        $.ajax({
            url: 'Introduce.aspx',
            type: 'post',
            data: { "action": "query", "id": id },
            async: false,
            success: function (data) {               
                var dataObj1 = eval("(" + data + ")"); //转换为json对象                
                dataObj1["ipt_remarks"] = dataObj1["ipt_remarks"].replace(/br/g, "\n");            
                dataObj1["ipt_webdetails"] = dataObj1["ipt_webdetails"].replace(/br/g, "\n");
                
                $("#ipt_name2").val(dataObj1["ipt_name2"]);
                $("#ipt_introduce").val(dataObj1["ipt_webdetails"]);
                $("#ipt_remarks").val(dataObj1["ipt_remarks"]);
            }
        })
    }
    function re(id) {
        $.ajax({
            url: 'Introduce.aspx',
            type: 'post',
            data: { "action": "query", "id": id },
            async: false,
            success: function (data) {
                var dataObj1 = eval("(" + data + ")"); //转换为json对象                
                dataObj1["ipt_remarks"] = dataObj1["ipt_remarks"].replace(/br/g, "\n");
                dataObj1["ipt_webdetails"] = dataObj1["ipt_webdetails"].replace(/br/g, "\n");
                $("#ipt_name2").val(dataObj1["ipt_name2"]);
                $("#ipt_introduce").val(dataObj1["ipt_webdetails"]);
                $("#ipt_remarks").val(dataObj1["ipt_remarks"]);

            }
        })
    }
    function GetInputData(id,cmd) {
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
        var file = document.getElementById("file1").files[0];
        //var files_ = document.getElementById("imgFile2").files;
        var files_ = document.getElementById("file").files;
        var files_name = "";
        var src_ = "/UpLoadImg/";
        json["id"] = id;
        if (file) {           
            json.mainImg = src_ + file.name;           
        }
        if (files_) {
            for (var i = 0; i < files_.length; i++) {                
                files_name = files_name + src_ + files_[i].name + ";";               
            }
            json.img_Path = files_name;
        }        
        $.ajax({
            url: 'Introduce.aspx',
            type: "post",
            async: false,
            data: json,
            success: function (data) {
                //var dataObj1 = eval("(" + data + ")"); //转换为json对象 
                //dataObj1["ipt_remark"] = dataObj1["ipt_remark"].replace(/br/g, "\n");
                //console.info(data);
                //$("#edit").form('load', dataObj1);  
                //alert(data);
            }
        })              
    }   

    //判断是否是图片
    //$(':file').change(function () {
    //    var fileName = $(this).val();
    //    var ext = fileName.substr(fileName.lastIndexOf('.')).toLowerCase();
    //    if (ext == '.jpeg' || ext == '.jpg' || ext == '.png' || ext == '.gif') {
    //        return true;
    //    }
    //    else {
    //        $(this).val('');
    //        alert("图片格式不正确！")
    //    }
    //})
    //预览图片
    //$("#imgFile1").on("change", function () {
    //    var file = this.files[0];        
    //    if (file) {
    //        var reader = new FileReader();
    //        reader.onload = function (e) {
    //            oImgs.innerHTML = '<div><img id="img' + '" src="' + e.target.result + '" /></div>'
    //        }
    //        reader.readAsDataURL(file);
    //    }        
    //})

    //$("#imgFile2").on("change", function () {
    //    var file = this.files;
    //    if (file) {
    //        for (var i = 0; i < file.length; i++) {
    //            var reader = new FileReader();
    //            reader.onload = function (e) {
    //                oImgs1.innerHTML += '<div><img id="imgs_' + i + '" src="' + e.target.result + '" /></div>';
    //                console.log("img" + i);
    //            }
    //            reader.readAsDataURL(file[i]);
    //        }
    //    }
    //})
</script>
</body>
</html>
