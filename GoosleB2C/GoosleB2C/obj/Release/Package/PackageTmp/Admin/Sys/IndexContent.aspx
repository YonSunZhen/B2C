﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexContent.aspx.cs" Inherits="GoosleB2C.Web.Admin.Sys.IndexContent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="/JS/easyUI/jquery-1.7.2.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="/webuploader/smart-green.css" />
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
          <form id="form_edit" name="form_edit" method="post" url="IndexContent.aspx">
              <div id="" class="edit_info">
                  <div id="" class="other_Div">
                      <span class="">显示成功案例</span>
                      <br/>
                      <select id="ipt_isshowsuccess" class="easyui-combobox" name="ipt_isshowsuccess" panelMaxHeight="200px" panelHeight="auto" editable="false" style="width: 175px;">
                          <option value='0'>不显示</option>
                          <option value='1'>显示</option>                                                
                      </select>                 
                  </div>
                  <div id="" class="title_Div">
                      <span class="">显示个数</span>
                      <br/>
                      <input id="ipt_successtotal"  name="ipt_successtotal" type="text" class="easyui-validatebox" data-options="validType:'integer'" />                      
                  </div>

                  <div id="" class="other_Div">
                      <span class="">显示产品</span>
                      <br/>
                      <select id="ipt_isshowproduct" class="easyui-combobox" name="ipt_isshowproduct" panelMaxHeight="200px" panelHeight="auto" editable="false" style="width: 175px;">
                          <option value='0'>不显示</option>
                          <option value='1'>显示</option>                                                
                      </select>                 
                  </div>
                  <div id="" class="title_Div">
                      <span class="">产品个数</span>
                      <br/>
                      <input id="ipt_producttotal"  name="ipt_producttotal" type="text" class="easyui-validatebox" data-options="validType:'integer'" />                      
                  </div>
                  
                  <div id="" class="other_Div">
                      <span class="">显示文章</span>
                      <br/>
                      <select id="ipt_isshowarticle" class="easyui-combobox" name="ipt_isshowarticle" panelMaxHeight="200px" panelHeight="auto" editable="false" style="width: 175px;">
                          <option value='0'>不显示</option>
                          <option value='1'>显示</option>                                                
                      </select>                 
                  </div>
                  <div id="" class="title_Div">
                      <span class="">文章篇数</span>
                      <br/>
                      <input id="ipt_articletotal"  name="ipt_articletotal" type="text" class="easyui-validatebox" data-options="validType:'integer'" />                      
                  </div>

                  <div id="" class="other_Div">
                      <span class="">显示视频</span>
                      <br/>
                      <select id="ipt_isshowvideo" class="easyui-combobox" name="ipt_isshowvideo" panelMaxHeight="200px" panelHeight="auto" editable="false" style="width: 175px;">
                          <option value='0'>不显示</option>
                          <option value='1'>显示</option>                                                
                      </select>                 
                  </div>
                  <div id="" class="other_Div">
                      <span class="">视频自动播放</span>
                      <br/>
                      <select id="ipt_isrun" class="easyui-combobox" name="ipt_isrun" panelMaxHeight="200px" panelHeight="auto" editable="false" style="width: 175px;">
                          <option value='0'>否</option>
                          <option value='1'>是</option>                                                
                      </select>                 
                  </div>
                  <div id="" class="title_Div">
                      <span class="">视频路径</span>
                      <br/>
                      <input id="ipt_videopath"  name="ipt_videopath" type="text" class="easyui-validatebox" />                      
                  </div>
                  <div id="" class="title_Div">
                      <span class="">视频栏标题</span>
                      <br/>
                      <input id="ipt_videotitle"  name="ipt_videotitle" type="text" class="easyui-validatebox" />                      
                  </div>                                                   
              </div>                                                        
          </form>
    </div>
    <div id="edit-buttons">
        <a id="btn_add" href="javascript:;" class="easyui-linkbutton">提交</a> 
        <a href="javascript:;" class="easyui-linkbutton"
            onclick="$('#edit').dialog('close');return false;">取消</a>
    </div>

    <script type="text/javascript">
        $(function () {
            InitGird();           
        });
        //初始化表格
        function InitGird() {
            $('#tab_list').datagrid({
                title: '手机端首页内容列表', //表格标题
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
	                { field: 'cbx', checkbox: true }	                
                ]],
                columns: [[
                    {
                        title: '显示成功案例', field: 'JSON_isshowsuccess', formatter: function (value, rec, index) {
                            if (value == 0) {
                                return '不显示';
                            }
                            else if (value == 1) {
                                return '显示';
                            }                           
                        }, width: 100
                    },
                    { title: '显示个数', field: 'JSON_successtotal', width: 100 },
                    {
                        title: '显示产品', field: 'JSON_isshowproduct', formatter: function (value, rec, index) {
                            if (value == 0) {
                                return '不显示';
                            }
                            else if (value == 1) {
                                return '显示';
                            }
                        }, width: 100
                    },
                    { title: '产品个数', field: 'JSON_producttotal', width: 100 },
                    {
                        title: '显示文章', field: 'JSON_isshowarticle', formatter: function (value, rec, index) {
                            if (value == 0) {
                                return '不显示';
                            }
                            else if (value == 1) {
                                return '显示';
                            }
                        }, width: 100
                    },
                    { title: '文章篇数', field: 'JSON_articletotal', width: 100 },
                    {
                        title: '显示视频', field: 'JSON_isshowvideo', formatter: function (value, rec, index) {
                            if (value == 0) {
                                return '否';
                            }
                            else if (value == 1) {
                                return '是';
                            }
                        }, width: 100
                    },
                    {
                        title: '视频自动播放', field: 'JSON_isrun', formatter: function (value, rec, index) {
                            if (value == 0) {
                                return '不显示';
                            }
                            else if (value == 1) {
                                return '显示';
                            }
                        }, width: 100
                    },
                    //{ title: '视频路径', field: 'JSON_videopath', width: 300 },
                    //{ title: '视频栏标题', field: 'JSON_videotitle', width: 300 },
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
        $.extend($.fn.validatebox.defaults.rules, {
            integer: {
                validator: function (value, param) {
                    return /^[+]?[0-9]\d*$/.test(value);
                },
                message: '请输入最小为0的整数。'
            }
        });
        function OpenWin() {
            $("#edit").dialog({ title: "新增手机端首页内容" });
            $('#form_edit input').val('');                        
            $("#edit").dialog("open");
            $("#edit-buttons a:first").attr("onclick", "Add(0); return false;")
        }
        function GetInputData(id, cmd) {            
            var postdata = "{ \"action\":\"" + cmd + "\",";
            $("#" + id + " input[type!='checkbox']").each(function () {
                postdata += "\"" + $(this).attr("name") + "\":\"" + $(this).val() + "\",";
            });
            $("#" + id + " input[type='checkbox']").each(function () {
                postdata += "\"" + $(this).attr("name") + "\":\"" + this.checked + "\",";
            });            

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
            $("#edit").dialog({ title: "编辑手机端首页内容" });            
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
                    console.info(data);
                    $("#form_edit").form('load', dataObj1);
                }
            })
            $("#edit").dialog("open");
            $("#btn_add").attr("onclick", "Add(\'" + uid + "\'); return false;")
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
    </script>
</body>
</html>
