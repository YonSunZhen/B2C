<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexImg.aspx.cs" Inherits="GoosleB2C.Web.Admin.Sys.IndexImg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="/webuploader/webuploader.css" /> 
    <link rel="stylesheet" type="text/css" href="/webuploader/smart-green.css" />      
	<script type="text/javascript" src="/webuploader/jquery-1.8.3.min.js"></script>    
	<script type="text/javascript" src="/webuploader/webuploader.min.js"></script>
	<script type="text/javascript" charset="utf-8" src="/webuploader/uploader.js"></script> 

    <script src="/JS/easyUI/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="/JS/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <link href="/JS/easyUI/themes/gray/easyui.css" rel="stylesheet" type="text/css" /> 
    <link href="/JS/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="/JS/wikmenu.js" type="text/javascript"></script>
    <script src="/JS/wikmain.js" type="text/javascript"></script>
    <title></title>
    <style>
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

    <%--开始--%>
    <div id="edit" class="easyui-dialog" title="" style="width: 900px; height: 450px;"
        modal="true" closed="true" closable="false" resizable="true" buttons="#edit-buttons">
          <form id="form_edit" name="form_edit" method="post" url="IndexImg.aspx">
              <div id="" class="edit_info">
                  <div id="" class="title_Div">
                      <span class="">打开链接</span>
                      <br/>
                      <input id="ipt_url"  name="ipt_url" type="text" class="easyui-validatebox" />                      
                  </div>
                  <div id="" class="other_Div">
                      <span class="">链接类型</span>
                      <br/>
                      <select id="ipt_urltype" class="easyui-combobox" name="ipt_urltype" panelMaxHeight="200px" panelHeight="auto" editable="false" style="width: 175px;">
                          <option value='1'>产品</option>
                          <option value='2'>案例</option>
                          <option value='3'>文章</option>                          
                      </select>                 
                  </div>
                  <div id="" class="other_Div">
                      <span class="">展示位置</span>
                      <br/>
                      <select id="ipt_position" class="easyui-combobox" name="ipt_position" panelMaxHeight="200px" panelHeight="auto" editable="false" style="width: 175px;">
                          <option value='1'>成功案例上面</option>
                          <option value='2'>成功案例下面产品上面</option>
                          <option value='3'>产品下面文章上面</option>
                          <option value='4'>文章下面</option>
                      </select>                      
                  </div>
                  <div id="" class="other_Div">
                      <span class="">排序</span>
                      <br/>
                      <input id="ipt_orders" name="ipt_orders" type="text" class="easyui-validatebox"
                          data-options="validType:'integer'" />                      
                  </div>
                  <div id="" class="other_Div">
                      <span class="">产品案例文章id</span>
                      <br/>
                      <input id="ipt_toid" name="ipt_toid" type="text" class="easyui-validatebox" />                      
                  </div>                                    
              </div>
                              
              <div class="smart-green tab" style="margin-left:30px;">                                                    
                  <ul style="-webkit-padding-start: 0px;">
                      <li class="lef">
                          <span>主图</span>
                      </li>
                      <li id="main_rig" class="rig">
                          <input type="hidden" style="float: left; height: 30px; width: 500px;" readonly="readonly" name="txtImgUrl" class="upload-path" />
                          <div style="float: left; margin-left: 8px;" class="upload-box upload-img"></div>
                          <div style="clear: both;"></div>
                          <div class="imgDiv">
                              <img class="upload-imgurl" width="200" />
                          </div>

                      </li>
                      <li class="clear"></li>
                  </ul>
              </div>             
          </form>
    </div>
    <div id="edit-buttons">
        <a id="btn_add" href="javascript:;" class="easyui-linkbutton">提交</a> 
        <a href="javascript:;" class="easyui-linkbutton"
            onclick="re_(); re();">取消</a>
    </div>

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
            $(".upload-img").InitUploader({
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
        });
        function InitGird() {
            $('#tab_list').datagrid({
                title: '手机端首页图列表', //表格标题
                url: location.href, //请求数据的页面
                sortName: 'JSON_id', //排序字段
                idField: 'JSON_id', //标识字段,主键
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
                ]],
                columns: [[
                    { title: '打开链接', field: 'JSON_url', width: 150 },
                    {
                        title: '链接类型', field: 'JSON_urltype', width: 80, formatter: function (value, rec, index) {
                            if (value == 1) {
                                return '产品';
                            }
                            else if (value == 2) {
                                return '案例';
                            }
                            else if (value == 3) {
                                return '文章';
                            }                           
                        }
                    },
                    { title: '产品案例文章id', field: 'JSON_toid', width: 300 },
                    {
                        title: '展示位置', field: 'JSON_position', width: 200, formatter: function (value, rec, index) {
                            if (value == 1) {
                                return '成功案例上面';
                            }
                            else if (value == 2) {
                                return '成功案例下面产品上面';
                            }
                            else if (value == 3) {
                                return '产品下面文章上面';
                            }
                            else if (value == 4) {
                                return '文章下面';
                            }                            
                        }
                    },
                    { title: '排序', field: 'JSON_orders', width: 50 },
                    //{ title: '对应快递模板', field: 'JSON_deliverytempid', width: 50 },            
                    { title: '修改人', field: 'JSON_updatepeople', width: 100 },
                    { title: '修改时间', field: 'JSON_updatetime', width: 145 },
                    {
                        title: '操作', field: 'JSON_id', width: 75, formatter: function (value, rec) {
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
        function OpenWin() {
            $("#edit").dialog({ title: "新增手机端首页图" });
            $('#form_edit input').val('');            

            $(".upload-imgurl").removeAttr("src");
            collect_initImg();            
                       
            $("#edit").dialog("open");
            $.each(uploadBtnArry, function (index, el) {
                el.refresh();
            });
            $("#edit-buttons a:first").attr("onclick", "Add(0); Del(); return false;")
        }
        $.extend($.fn.validatebox.defaults.rules, {
            integer: {
                validator: function (value, param) {
                    return /^[+]?[1-9]\d*$/.test(value);
                },
                message: '请输入最小为1的整数。'
            },            
        });
        function GetInputData(id, cmd) {            
            var postdata = "{ \"action\":\"" + cmd + "\",";
            $("#" + id + " input[type!='checkbox']").each(function () {
                postdata += "\"" + $(this).attr("name") + "\":\"" + $(this).val() + "\",";
            });
            $("#" + id + " input[type='checkbox']").each(function () {
                postdata += "\"" + $(this).attr("name") + "\":\"" + this.checked + "\",";
            });

            if ($(".upload-img").siblings(".imgDiv").children("img").attr("src") != undefined) {
                var mainSrc = $(".upload-img").siblings(".hidden-src").val().split("|")[1];
                postdata += "\"" + "ipt_img" + "\":\"" + mainSrc + "\",";
            }
            else {
                postdata += "\"" + "ipt_img" + "\":\"" + "" + "\",";
            }                      
            postdata = postdata.substr(0, postdata.length - 1);
            postdata += "}";
            return eval("(" + postdata + ")");
        }
        function Add(uid) {
            if (!$("#form_edit").form("validate")) {
                return;
            }
            var json = GetInputData('edit', 'submit');
            json.id = uid;
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
        function EditData(uid) {
            $("#edit").dialog({ title: "编辑手机端首页图" });          
            $.ajax({
                url: location.href,
                type: "post",
                async: false,
                data: {
                    "action": "queryone",
                    "id": uid
                },
                success: function (data) {
                    var dataObj1 = eval("(" + data + ")"); //转换为json对象                                        
                    $(".upload-path").val(dataObj1["ipt_img"]);                    

                    $(".upload-imgurl").removeAttr("src");                    

                    if (dataObj1["ipt_img"]) {
                        //var mainSrc = dataObj1["ipt_img"];
                        //var thumbSrc = mainSrc + "_.jpg";
                        var thumbSrc = dataObj1["ipt_img"];
                        var mainSrc = dataObj1["ipt_img"].split("_")[0];
                        var input = document.createElement("input");
                        var a = document.createElement("a");
                        var del_img = document.createElement("img");
                        input.setAttribute("type", "hidden");
                        input.setAttribute("name", "hid_photo_name");
                        input.setAttribute("value", mainSrc + "|" + thumbSrc);
                        input.setAttribute("class", "hidden-src");
                        a.setAttribute("href", "javascript:;");
                        a.setAttribute("onclick", "delImg_(this);");
                        del_img.setAttribute("src", "/UpLoadImg/a7.png");
                        del_img.setAttribute("class", "delete");
                        a.appendChild(del_img);
                        $(".upload-imgurl").attr("src", thumbSrc);
                        $(".imgDiv").append(a);
                        $("#main_rig").append(input);
                    }                    

                    $(".imgDiv").mouseenter(function () {
                        $(this).find(".delete").show();
                    });
                    $(".imgDiv").mouseleave(function () {
                        $(this).find(".delete").hide();
                    });
                    console.info(data);
                    $("#form_edit").form('load', dataObj1);
                }
            });
            $("#edit").dialog("open");
            $.each(uploadBtnArry, function (index, el) {
                el.refresh();
            });
            collect_initImg();            
            $("#btn_add").attr("onclick", "Add(\'" + uid + "\'); Del(); return false;")
        }
        function DelData(id) {
            $.messager.confirm('提示', '确认删除？', function (r) {
                if (r) {
                    var selected = "";
                    if (id <= 0) {
                        $($('#tab_list').datagrid('getSelections')).each(function () {
                            selected += "\'" + this.JSON_id + "\'" + ",";
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
        function re() {
            if ($(".upload-img").siblings(".imgDiv").children("img").attr("src") != undefined) {
                $(".upload-imgurl").removeAttr("src");
                $(".upload-imgurl").siblings("a").remove();
                $(".imgDiv").siblings("input").val("");
                $(".imgDiv").siblings(".hidden-src").remove();
            }           
            $('#edit').dialog('close');
        }
        function re_() {
            //获得页面初始化后叉掉的图片数组
            var delImgarry = arry;
            //获得页面初始化后的图片数组
            var initImgarry = initArry;
            //alert(delImgarry);
            //获得进行各种操作后最终页面上的图片数组
            var lastImgarry = [];
            var delImgarry_size = delImgarry.length;
            var initImgarry_size = initImgarry.length;            
            var up_Img = [];
            if ($(".imgDiv").children("img").attr("src") != undefined) {
                var imgNames = $("#main_rig").children(".hidden-src").val();
                lastImgarry.push(imgNames.split("|")[0], imgNames.split("|")[1]);
            }
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
            var upImg_size = up_Img.length - 1;
            for (var i = 0; i < upImg_size;) {
                delete_Imgs_ajax(up_Img[i], up_Img[i + 1]);
                i += 2;
            }
            initArry = [];
            arry = [];
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
            if ($(".upload-img").siblings(".imgDiv").children("img").attr("src") != undefined) {
                var imgNames = $("#main_rig").children(".hidden-src").val();
                initArry.push(imgNames.split("|")[0], imgNames.split("|")[1]);
            }            
        }
    </script>
</body>
</html>
