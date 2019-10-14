<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="GoosleB2C.Web.Admin.CompanyInfo.Product" %>

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
    <%--<script type="text/javascript" src="/Admin/build/translations/zh-cn.js"></script>--%>
    
    <script src="/JS/easyUI/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="/JS/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <link href="/JS/easyUI/themes/gray/easyui.css" rel="stylesheet" type="text/css" /> 
    <link href="/JS/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="/JS/wikmenu.js" type="text/javascript"></script>
    <script src="/JS/wikmain.js" type="text/javascript"></script>
    <title></title>
    <style>
        /*.ck-editor__main{         
            max-width:870px;            
        }
        .ck-editor__top{           
            max-width:870px;          
        }*/ 
        .ck-editor__editable{
            height:500px;
        }
        .edit_info{
            margin-left:30px;
            margin-right:20px;
        }
        .lef {
            float: left;
            width: 839px;
        }
        .rig {
            float: left;
            width: 839px;
        }
        #main_rig #imagelist{
            width:150px;
            height:150px;
        }
        #phone_rig #imagelist{
            width:150px; 
            height:150px;           
        } 
    </style>
</head>
<body>
    <form id="form_list" name="form_list" method="post">
        <table id="tab_list"></table>
        <div id="tab_toolbar" style="padding: 0 2px;">
            <table cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>              
                    <td style="padding-left: 2px">                                
                        <a href="#" onclick="OpenWin();return false;" id="a_add"
                            class="easyui-linkbutton" iconcls="icon-add">添加</a>                   
                        <a href="#" onclick="DelData(0);return false;" id="a_del" class="easyui-linkbutton" iconcls="icon-cancel">删除</a>                   
                    </td>            
                </tr>
            </table>    
        </div>
    </form>

    <%--编辑产品开始--%>
    <div id="edit" class="easyui-dialog" title="" style="width: 900px; height: 450px;"
        modal="true" closed="true" closable="false" resizable="true" buttons="#edit-buttons">
          <form id="form_edit" name="form_edit" method="post" url="Product.aspx">
              <div id="" class="edit_info">
                  <div id="" class="title_Div">
                      <span class="">标题</span>
                      <br/>
                      <input id="ipt_title"  name="ipt_title" type="text" class="easyui-validatebox" required="true" />                      
                  </div>
                  <div id="" class="title_Div">
                      <span class="">原价</span>
                      <br/>
                      <input id="ipt_originalprice"  name="ipt_originalprice" type="text" class="easyui-validatebox" required="true" />                      
                  </div>
                  <div id="" class="title_Div">
                      <span class="">折后价</span>
                      <br/>
                      <input id="ipt_price"  name="ipt_price" type="text" class="easyui-validatebox" required="true" />                      
                  </div>
                  <div id="" class="other_Div">
                      <span class="">总数量</span>
                      <br/>
                      <input id="ipt_total" name="ipt_total" type="text" class="easyui-validatebox"
                          data-options="validType:'total_integer'" />                      
                  </div>
                  <div id="" class="other_Div">
                      <span class="">总销量</span>
                      <br/>
                      <input id="ipt_sales" name="ipt_sales" type="text" class="easyui-validatebox"
                          data-options="validType:'total_integer'" />                      
                  </div>
                  <div id="" class="other_Div">
                      <span class="">分类</span>
                      <br/>
                      <select id="ipt_procategory" name="ipt_procategory" class="easyui-validatebox" required="true" style="width: 200px;">
                      </select>                     
                  </div>
                  <div id="" class="other_Div">
                      <span class="">产品状态</span>
                      <br/>
                      <select id="ipt_state" class="easyui-combobox" name="ipt_state" panelMaxHeight="200px" panelHeight="auto" editable="false" style="width: 200px;">
                          <option value='0'>下架</option>
                          <option value='1'>上架</option>
                      </select>                      
                  </div>
                  <div id="" class="other_Div">
                      <span class="">对应快递模板</span>
                      <br/>
                      <select id="ipt_deliverytempid" name="ipt_deliverytempid" panelMaxHeight="200px" panelHeight="auto" editable="false" style="width: 200px;">
                      </select>                     
                  </div>
                  <div id="" class="other_Div">
                      <span class="">排序</span>
                      <br/>
                      <input id="ipt_orders" name="ipt_orders" type="text" class="easyui-validatebox"
                          data-options="validType:'integer'" />                      
                  </div>
                  <div id="" class="other_Div">
                      <span class="">seoTitle</span>
                      <br/>
                      <input id="ipt_seotitle" name="ipt_seotitle" />
                  </div>
                  <div id="" class="other_Div">
                      <span class="">seoKey</span>
                      <br/>
                      <input id="ipt_seokey" name="ipt_seokey" />
                  </div>
                  <div id="" class="other_Div">
                      <span class="">seoDesceibe</span>
                      <br/>
                      <textarea id="ipt_seodescribe" name="ipt_seodescribe" rows="9" cols="114"></textarea>
                  </div>
                  <div id="" class="other_Div">
                      <span class="">手机详情页文字</span>
                      <br/>
                      <textarea id="ipt_details" name="ipt_details" rows="9" cols="114"></textarea>
                  </div>
                  <div id="" class="other_Div">
                      <span class="">备注</span>
                      <br/>
                      <textarea id="ipt_remark" name="ipt_remark" rows="9" cols="114"></textarea>
                  </div>
                  <div id="" class="other_Div">
                      <span class="">网页详情</span>
                      <textarea rows="30" cols="50" name="editor" id="editor"></textarea>
                  </div>
              </div>                              
              <div class="smart-green tab" style="margin-left:30px;">
                  <ul style="-webkit-padding-start: 0px;">
                      <li class="lef">
                          <span>主图(至多五张,建议图片大小为800*800)</span>
                      </li>                   
                      <li id="main_rig" class="rig">
                          <div style="float: left;" class="upload-box upload-album"></div>
                          <div style="float: left; margin-left: 8px;">
                              <%--<input id="chkThumb" name="chkThumb" type="checkbox" value="1" />
                              <label for="chkThumb">是否生成缩略图</label>--%>
                          </div>
                          <div class="clear"></div>
                          <div class="photo-list" style="overflow: auto;">
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
                      <li id="phone_rig" class="rig">
                          <div style="float: left;" class="upload-box pupload-album"></div>
                          <div style="float: left; margin-left: 8px;">
                              <%--<input id="chkThumb" name="chkThumb" type="checkbox" value="1" />
                              <label for="chkThumb">是否生成缩略图</label>--%>
                          </div>
                          <div class="clear"></div>
                          <div class="photo-list" style="overflow: auto;">
                              <ul>
                              </ul>
                          </div>                                                  
                      </li>
                      <li class="clear"></li>                     
                  </ul>
              </div>
              <input type="hidden" id="ck_content" /> 
          </form>
    </div>
    <div id="edit-buttons">
        <a id="btn_add" href="javascript:;" class="easyui-linkbutton">提交</a> 
        <a href="javascript:;" class="easyui-linkbutton"
            onclick="re_(); re();">取消</a>
    </div>    
    <script type="text/javascript">
        var myEditor = null;
        var initArry = [];
        var waterMarkType = "";
        var waterMarkPosition = "";
        var waterMarkContent = "";
        var waterMarkPicture = "";
        var waterMarkTransparency = "";
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
        $(function () {
            InitGird();
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
                sendurl: "/webuploader/cs_ashx/ajax.ashx",
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
                sendurl: "/webuploader/cs_ashx/ajax.ashx",
            });
        });
        
        function transForm(value, row, index) {
            return row.JSON_remark.replace(/br/g, ";")
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
        function InitGird() {
            $('#tab_list').datagrid({
                title: '产品管理列表', //表格标题
                url: location.href, //请求数据的页面
                sortName: 'JSON_pid', //排序字段
                idField: 'JSON_pid', //标识字段,主键
                iconCls: '', //标题左边的图标
                width: '100%', //宽度
                height: $(parent.document).find("#mainPanle").height() - 10 > 0 ? $(parent.document).find("#mainPanle").height() - 10 : 500, //高度
                nowrap: false, //是否换行，True 就会把数据显示在一行里
                striped: true, //True 奇偶行使用不同背景色
                collapsible: false, //可折叠
                sortOrder: 'desc', //排序类型
                remoteSort: true, //定义是否从服务器给数据排序
                frozenColumns: [[//冻结的列，不会随横向滚动轴移动
	                { field: 'cbx', checkbox: true },
	                { title: '标题', field: 'JSON_title', width: 350, sortable: true },
                ]],
                columns: [[
                    { title: '原价', field: 'JSON_originalprice', width: 50 },
                    //{ title: '分类', field: 'JSON_procategory', width: 100 },
                    {
                        title: '产品状态', field: 'JSON_state', width: 100, formatter: function (value, rec, index) {
                            if (value == 0) {
                                return '下架';
                            }
                            else if (value == 1) {
                                return '上架';
                            }
                        }
                    },                    
                    { title: '排序', field: 'JSON_orders', width: 50 },
                    //{ title: '对应快递模板', field: 'JSON_deliverytempid', width: 50 },
                    { title: '创建人', field: 'JSON_creator', width: 130 },
                    { title: '创建时间', field: 'JSON_createttime', width: 150 },
                    { title: '修改人', field: 'JSON_modifier', width: 130 },
                    { title: '修改时间', field: 'JSON_modifydate', width: 150 },                  
                    {
                        title: '操作', field: 'JSON_pid', width: 80, formatter: function (value, rec) {
                            return '<a style="color:red" href="javascript:;" onclick="EditData(\'' + value + '\');$(this).parent().click();return false;">修改</a>';
                        }
                    }
                ]],
                toolbar: "#tab_toolbar",
                queryParams: { "action": "query" },
                pagination: true, //是否开启分页
                pageNumber: 1, //默认索引页
                pageSize: 10, //默认一页数据条数
                rownumbers: true //行号
            });
        }
        function transDate(list, idstr, pidstr) {
            var result = [];
            var temp = {};
            for (let i = 0; i < list.length; i++) {
                //var obj = { "level": list[i].level, "path": list[i].path, "father": list[i].father, "order": list[i].order, "ipt_seotitle": list[i].seotitle, "ipt_seokey": list[i].seokey, "ipt_seoremark": list[i].seoremark, "ipt_categoryname": list[i].text };
                //list[i].attributes = obj;
                temp[list[i][idstr]] = list[i];//将nodes数组转成对象类型
            }
            for (let j = 0; j < list.length; j++) {
                tempVp = temp[list[j][pidstr]]; //获取每一个子对象的父对象
                if (tempVp) {                   //判断父对象是否存在，如果不存在直接将对象放到第一层
                    if (!tempVp["children"]) tempVp["children"] = [];//如果父元素的nodes对象不存在，则创建数组
                    tempVp["children"].push(list[j]);//将本对象压入父对象的nodes数组
                } else {
                    result.push(list[j]);       //将不存在父对象的对象直接放入一级目录
                }
            }
            return result;
        }
        function OpenWin() {
            $("#edit").dialog({ title: "新增产品" });
            $('#form_edit input').val('');
            $('#form_edit textarea').val('');

            $(".fl").remove();
            collect_initImg();            
            myEditor.setData("");
            
            $.ajax({
                type: "post",
                async: false, //同步执行
                dataType: 'jsonp',
                jsonp: "jsoncallback",
                jsonpCallback: 'getCategory',
                url: '/back/BackSer.asmx/getCategory',
                success: function (data) {
                    if (data) {
                        var tdata = JSON.parse(JSON.stringify(data).replace(/JSON_/g, "").replace(/categoryname/g, "text"));
                        // tdata = JSON.parse(JSON.stringify(tdata).replace(/categoryname/g, "text"));
                        var tree = transDate(tdata.rows, "id", "father");
                        $('#ipt_procategory').combotree({
                            data: tree,
                            valueField: "id",
                            textField: "text"
                        });
                        console.log(tree);
                    }
                },
                error: function (errorMsg) {
                    alert("不好意思，请求数据失败啦!");
                }
            });
            queryDeliverytemp();
            $("#edit").dialog("open");
            $.each(uploadBtnArry, function (index, el) {
                el.refresh();
            });
            $("#edit-buttons a:first").attr("onclick", "Add(0); Del_pro(); return false;")
        }
        $.extend($.fn.validatebox.defaults.rules, {
            integer: {
                validator: function (value, param) {
                    return /^[+]?[1-9]\d*$/.test(value);
                },
                message: '请输入最小为1的整数。'
            },
            total_integer: {
                validator: function (value, param) {
                    return /^[+]?[0-9]\d*$/.test(value);
                },
                message: '请输入最小为0的整数。'
            }
        });
        function GetInputData(id, cmd) {
            var remark = document.getElementById("ipt_remark").value;
            var details = document.getElementById("ipt_details").value;
            var seodescribe = document.getElementById("ipt_seodescribe").value;
            var mark;
            var details_;
            var seodescribe_;
            var list_src = "";//手机图
            var list_imgs = [];//主图
            //var myeditor = myEditor.getData();
            //myeditor = encodeURIComponent(myeditor);
            if (remark != null) {
                mark = remark.replace(/\n/g, "br");
            }
            if (details != null) {
                details_ = details.replace(/\n/g, "br");
            }
            if (seodescribe != null) {
                seodescribe_ = seodescribe.replace(/\n/g, "br");
            }
            

            var postdata = "{ \"action\":\"" + cmd + "\",";
            $("#" + id + " input[type!='checkbox']").each(function () {
                postdata += "\"" + $(this).attr("name") + "\":\"" + $(this).val() + "\",";
            });
            $("#" + id + " input[type='checkbox']").each(function () {
                postdata += "\"" + $(this).attr("name") + "\":\"" + this.checked + "\",";
            });

            if ($(".upload-album").siblings(".photo-list").children("ul").children("li")) {
                $(".upload-album").siblings(".photo-list").find("li").each(function () {
                    var val = $(this).children(".hidden-src").val();
                    list_imgs.push(val.split("|")[1]);
                })
                for (var i = 0; i < list_imgs.length; i++) {
                    var i = i + 1;
                    var ipt_imgs = "ipt_img" + i;
                    postdata += "\"" + ipt_imgs + "\":\"" + list_imgs[i - 1] + "\",";
                    i = i - 1;
                }               
            }           
            if ($(".pupload-album").siblings(".photo-list").children("ul").children("li")) {
                $(".pupload-album").siblings(".photo-list").find("li").each(function () {
                    var val = $(this).children(".hidden-src").val();
                    list_src += val.split("|")[1] + ";";
                })
                postdata += "\"" + "ipt_detailimgs" + "\":\"" + list_src + "\",";
            }
            else {
                postdata += "\"" + "ipt_detailimgs" + "\":\"" + "" + "\",";
            }

            var htmlEscape = encodeURIComponent(myEditor.getData());//编码
            postdata += "\"" + "ipt_remark" + "\":\"" + mark + "\",";
            postdata += "\"" + "ipt_details" + "\":\"" + details_ + "\",";
            postdata += "\"" + "ipt_seodescribe" + "\":\"" + seodescribe_ + "\",";
            postdata += "\"" + "ipt_webdetails" + "\":\"" + htmlEscape + "\",";

            postdata = postdata.substr(0, postdata.length - 1);
            postdata += "}";
            return eval("(" + postdata + ")");
        }
        function Add(pid) {
            if (!$("#form_edit").form("validate")) {
                return;
            }
            var json = GetInputData('edit', 'submit');
            json.id = pid;
            $.post(location.href, json, function (data) {
                $.messager.alert('提示', data, 'info', function () {
                    if (data.indexOf("成功") > 0) {
                        console.info(data);
                        $("#tab_list").datagrid("reload");
                        $("#edit").dialog("close");
                    }
                });
            });
        }
        function EditData(pid) {
            
            $("#edit").dialog({ title: "编辑产品" });
            $.ajax({
                type: "post",
                async: false, //同步执行
                dataType: 'jsonp',
                jsonp: "jsoncallback",
                jsonpCallback: 'getCategory',
                url: '/back/BackSer.asmx/getCategory',
                success: function (data) {
                    if (data) {
                        var tdata = JSON.parse(JSON.stringify(data).replace(/JSON_/g, "").replace(/categoryname/g, "text"));
                        // tdata = JSON.parse(JSON.stringify(tdata).replace(/categoryname/g, "text"));
                        var tree = transDate(tdata.rows, "id", "father");
                        $('#ipt_procategory').combotree({
                            data: tree,
                            valueField: "id",
                            textField: "text"
                        });
                        console.log(tree);
                    }
                },
                error: function (errorMsg) {
                    alert("不好意思，请求数据失败啦!");
                }
            });
            queryDeliverytemp();
            $.ajax({
                url: location.href,
                type: "post",
                async: false,
                data: {
                    "action": "queryone",
                    "id": pid
                },
                success: function (data) {
                    var dataObj1 = eval("(" + data + ")"); //转换为json对象 
                    var list_imgs = [];//主图
                    dataObj1["ipt_remark"] = dataObj1["ipt_remark"].replace(/br/g, "\n");
                    dataObj1["ipt_details"] = dataObj1["ipt_details"].replace(/br/g, "\n");
                    dataObj1["ipt_seodescribe"] = dataObj1["ipt_seodescribe"].replace(/br/g, "\n");
                    //document.getElementById("ck_content").value = dataObj1["ipt_webdetails"];
                    //var ck_con = decodeURIComponent(dataObj1["ipt_webcontent"]);
                    //var con = decodeURIComponent(document.getElementById("ck_content").value);
                    var htmlSql = dataObj1["ipt_webdetails"];
                    var htmlUnescape = decodeURIComponent(htmlSql);
                    myEditor.setData(htmlUnescape);

                    $(".fl").remove();

                    list_imgs.push(dataObj1["ipt_img1"]);
                    list_imgs.push(dataObj1["ipt_img2"]);
                    list_imgs.push(dataObj1["ipt_img3"]);
                    list_imgs.push(dataObj1["ipt_img4"]);
                    list_imgs.push(dataObj1["ipt_img5"]);                    
                    for (var i = 0; i < list_imgs.length; i++) {
                        if (list_imgs[i] != "") {
                            //var mainSrc = list_imgs[i];
                            //var thumbSrc = mainSrc + "_.jpg";
                            var thumbSrc = list_imgs[i];
                            var mainSrc = list_imgs[i].split("_")[0];
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
                            $(".upload-album").siblings(".photo-list").children("ul").append(li);

                            pre_delImg();
                        }
                        
                    }
                    

                    if (dataObj1["ipt_detailimgs"] != "") {
                        //$(".photo-list ul li").remove();
                        for (var i = 0; i < dataObj1["ipt_detailimgs"].split(";").length - 1; i++) {
                            //var mainSrc = dataObj1["ipt_detailimgs"].split(";")[i];
                            //var thumbSrc = mainSrc + "_.jpg";
                            var thumbSrc = dataObj1["ipt_detailimgs"].split(";")[i];
                            var mainSrc = dataObj1["ipt_detailimgs"].split(";")[i].split("_")[0];
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
                            $(".pupload-album").siblings(".photo-list").children("ul").append(li);

                            pre_delImg();


                        }
                    }
                    console.info(data);
                    $("#form_edit").form('load', dataObj1);
                }
            });           
            $("#edit").dialog("open");
            $.each(uploadBtnArry, function (index, el) {
                el.refresh();
            });            
            collect_initImg();
            $("#btn_add").attr("onclick", "Add(\'" + pid + "\'); Del_pro(); return false;")

        }
        function DelData(id) {
            $.messager.confirm('提示', '确认删除？', function (r) {
                if (r) {
                    var selected = "";
                    if (id <= 0) {
                        $($('#tab_list').datagrid('getSelections')).each(function () {
                            selected += "\'" + this.JSON_pid + "\'" + ",";
                        });
                        selected = selected.substr(0, selected.length - 1);
                        if (selected == "") {
                            $.messager.alert('提示', '请选择要删除的数据！', 'info');
                            return;
                        }
                    }
                    else {
                        selected = id;
                    }
                    $.post(location.href, { "action": "del", "cbx_select": selected }, function (data) {
                        $.messager.alert('提示', data, 'info', function () { $("#tab_list").datagrid("reload"); });
                    });

                }
            });
        }
        function pre_delImg() {
            $(".fl").mouseenter(function () {
                $(this).find(".delete").show();
            });
            $(".fl").mouseleave(function () {
                $(this).find(".delete").hide();
            });
        }
        function re() {
            if ($(".fl")) {
                $(".fl").remove();
            }
            $('#edit').dialog('close');
        }
        function collect_initImg() {
            if ($(".upload-album").siblings(".photo-list").children("ul").children("li")) {
                $(".upload-album").siblings(".photo-list").find("li").each(function () {
                    initArry.push($(this).children(".hidden-src").val().split("|")[0], $(this).children(".hidden-src").val().split("|")[1]);
                });
            }
            if ($(".pupload-album").siblings(".photo-list").children("ul").children("li")) {
                $(".pupload-album").siblings(".photo-list").find("li").each(function () {
                    initArry.push($(this).children(".hidden-src").val().split("|")[0], $(this).children(".hidden-src").val().split("|")[1]);
                });
            }
        }
        function re_() {
            //获得页面初始化后叉掉的图片数组
            var delImgarry = arry;
            //获得页面初始化后的图片数组
            var initImgarry = initArry;
            //alert(delImgarry);
            //获得进行各种操作后最终页面上的图片数组
            var lastImgarry = [];
            if ($(".upload-album").siblings(".photo-list").children("ul").children("li")) {
                lastImgarry = GetLastImg();
            }
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
            //alert(up_Img);
            for (var i = 0; i < up_Img.length - 1;) {
                //delete_Imgs_ajax(up_Img[i], up_Img[i + 1]);
                delete_Imgs_ajax(up_Img[i + 1], up_Img[i + 1] + '_400.jpg');
                delete_Imgs_ajax(up_Img[i + 1] + '_200.jpg', up_Img[i + 1] + '_60.jpg');
                //delete_Imgs_ajax(up_Img[i + 1] + '_400.jpg', up_Img[i + 1] + '_60.jpg');
                i += 2;
            }
            initArry = [];
            arry = [];
        }
        function GetLastImg() {
            var lastArry = [];
            if ($(".upload-album").siblings(".photo-list").children("ul").children("li")) {
                $(".upload-album").siblings(".photo-list").find("li").each(function () {
                    lastArry.push($(this).children(".hidden-src").val().split("|")[0], $(this).children(".hidden-src").val().split("|")[1]);
                });
            }
            if ($(".pupload-album").siblings(".photo-list").children("ul").children("li")) {
                $(".pupload-album").siblings(".photo-list").find("li").each(function () {
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
        function queryDeliverytemp() {
            $.ajax({
                url: location.href,
                type: "post",
                async: false,
                data: {
                    "action": "QueryDeliverytemp"
                },
                success: function (data) {
                    var dataObj = eval("(" + data + ")"); //转换为json对象                
                    $('#ipt_deliverytempid').combobox({
                        valueField: "id",
                        textField: "tempname",
                    }).combobox("loadData", dataObj);
                }
            })
        }
    </script>
</body>
</html>
