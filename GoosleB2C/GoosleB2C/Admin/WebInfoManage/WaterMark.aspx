<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WaterMark.aspx.cs" Inherits="GoosleB2C.Web.Admin.WebInfoManage.WaterMark" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="/webuploader/webuploader.css" /> 
    <link rel="stylesheet" type="text/css" href="/webuploader/smart-green.css" />      
	<script type="text/javascript" src="/webuploader/jquery-1.8.3.min.js"></script>    
	<script type="text/javascript" src="/webuploader/webuploader.min.js"></script>
	<script type="text/javascript" charset="utf-8" src="/webuploader/uploader.js"></script>
    
    <script src="/JS/easyUI/jquery-1.7.2.min.js" type="text/javascript"></script>
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

    <%--水印设置开始--%>
    <div id="edit" class="easyui-dialog" title="" style="width: 900px; height: 450px;"
        modal="true" closed="true" closable="false" resizable="true" buttons="#edit-buttons">
          <form id="form_edit" name="form_edit" method="post" url="Article.aspx">
              <div id="" class="edit_info">                 
                  <div id="" class="other_Div">
                      <span class="">类型</span>
                      <br/>
                      <select id="ipt_watertype" class="easyui-combobox" name="ipt_watertype" panelMaxHeight="200px" panelHeight="auto" editable="false" style="width: 175px;">
                          <option value='1'>文字水印</option>
                          <option value='2'>图片水印</option>
                      </select>                    
                  </div>
                  <div id="" class="other_Div">
                      <span class="">是否启用</span>
                      <br/>
                      <select id="ipt_state" class="easyui-combobox" name="ipt_state" panelMaxHeight="200px" panelHeight="auto" editable="false" style="width: 175px;">
                          <option value='0'>不启用</option>
                          <option value='1'>启用</option>
                      </select>                      
                  </div>
                  <div id="" class="other_Div">
                      <span class="">位置</span>
                      <br/>
                      <select id="ipt_position" class="easyui-combobox" name="ipt_position" panelMaxHeight="200px" panelHeight="auto" editable="false" style="width: 175px;">                          
                          <option value='1'>左上</option>
                          <option value='2'>上中</option>
                          <option value='3'>右上</option>
                          <option value='4'>左中</option>
                          <option value='5'>中间</option>
                          <option value='6'>右中</option>
                          <option value='7'>左下</option>
                          <option value='8'>下中</option>
                          <option value='9'>右下</option>                         
                      </select>                      
                  </div>
                  <div id="" class="other_Div">
                      <span class="">文字内容</span>
                      <br/>
                      <input id="ipt_words" name="ipt_words" type="text" class="easyui-validatebox" required="true" />
                  </div>
                  <div id="" class="other_Div">
                      <span class="">透明度(透明度1~10,数字越小越透明,10为不透明)</span>
                      <br/>
                      <input id="ipt_transparent" name="ipt_transparent" type="text" class="easyui-validatebox" data-options="required:'true',validType:'rateCheck'" />
                  </div>                                                                    
              </div>
              <div class="smart-green tab" style="margin-left:30px;">                                                    
                  <ul style="-webkit-padding-start: 0px;">
                      <li class="lef">
                          <span>水印图片</span>
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
        $(function () {
            InitGird();
            $(".upload-img").InitUploader({
                sendurl: "/webuploader/cs_ashx/waterMark_ajax.ashx",
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
                title: '水印设置列表', //表格标题
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
                columns: [[
                    { field: 'cbx', checkbox: true },
                    {
                        title: '是否启用', field: 'JSON_state', width: 100, formatter: function (value, rec, index) {
                            if (value == 0) {
                                return '不启用';
                            }
                            else if (value == 1) {
                                return '启用';
                            }
                        }
                    },
                    {
                        title: '类型', field: 'JSON_watertype', width: 100, formatter: function (value, rec, index) {
                            if (value == 1) {
                                return '文字水印';
                            }
                            else if (value == 2) {
                                return '图片水印';
                            }
                        }
                    },
                    {
                        title: '位置', field: 'JSON_position', width: 100, formatter: function (value, rec, index) {
                            if (value == 1) {
                                return '左上';
                            }
                            else if (value == 2) {
                                return '上中';
                            }
                            else if (value == 3) {
                                return '右上';
                            }
                            else if (value == 4) {
                                return '左中';
                            }
                            else if (value == 5) {
                                return '中间';
                            }
                            else if (value == 6) {
                                return '右中';
                            }
                            else if (value == 7) {
                                return '左下';
                            }
                            else if (value == 8) {
                                return '下中';
                            }
                            else if (value == 9) {
                                return '右下';
                            }
                        }
                    },
                    { title: '文字内容', field: 'JSON_words', width: 150 },
                    { title: '水印图片', field: 'JSON_img', width: 350 },
                    { title: '透明度', field: 'JSON_transparent', width: 50 },
                    {
                        title: '操作', field: 'JSON_id', width: 80, formatter: function (value, rec) {
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
        function OpenWin() {
            $("#edit").dialog({ title: "添加水印" });
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
            rateCheck: {
                validator: function (value, param) {
                    return value <= 10 && value >= 1;
                },
                message: '请输入1至10的正整数。'
            }
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
                var mainSrc = $(".upload-img").siblings(".hidden-src").val().split("|")[0];
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
            $("#edit").dialog({ title: "编辑水印设置" });            
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
                        var mainSrc = dataObj1["ipt_img"];
                        var thumbSrc = mainSrc + "_.jpg";
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
                        $(".upload-imgurl").attr("src", mainSrc);
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

            //lastImgarry = GetLastImg();
            //alert(lastImgarry);

            var up_Img = [];
            if ($(".imgDiv").children("img").attr("src") != undefined) {
                var imgNames = $("#main_rig").children(".hidden-src").val();
                lastImgarry.push(imgNames.split("|")[0], imgNames.split("|")[1]);
            }
            
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
                delete_Imgs_ajax(up_Img[i], up_Img[i + 1]);
                i += 2;
            }
            initArry = [];
            arry = [];
        }
        function GetLastImg() {
            var lastArry = [];
            if ($(".imgDiv").children("img").attr("src") != undefined) {
                var imgNames = $("#main_rig").children(".hidden-src").val();
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



        function collect_initImg() {
            if ($(".upload-img").siblings(".imgDiv").children("img").attr("src") != undefined) {
                var imgNames = $("#main_rig").children(".hidden-src").val();
                initArry.push(imgNames.split("|")[0], imgNames.split("|")[1]);
            }            
        }
    </script>
</body>
</html>
