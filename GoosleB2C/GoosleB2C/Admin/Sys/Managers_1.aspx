<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Managers_1.aspx.cs" Inherits="GoosleB2C.Web.Admin.Sys.Managers_1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="/JS/easyUI/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="/JS/easyUI/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="/JS/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <link href="/JS/easyUI/themes/gray/easyui.css" rel="stylesheet" type="text/css" /> 
    <link href="/JS/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="/JS/wikmenu.js" type="text/javascript"></script>
    <script src="/JS/wikmain.js" type="text/javascript"></script>
    <title>测试Managers_1</title>
</head>
<body>
    <div id="tab_toolbar" style="padding: 0 2px;">
        <table cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>                
                <td style="padding-left: 2px">                                 
                        <a href="#" onclick="$('#form_edit input').val('');OpenWin();return false;" id="a_add"
                            class="easyui-linkbutton" iconcls="icon-add">添加</a>                    
                        <a href="#" onclick="DelData(0);return false;" id="a_del" class="easyui-linkbutton" iconcls="icon-cancel">删除</a>                   
                </td>
                <td style="text-align: right; padding-right: 15px">
                    <input id="ipt_search" menu="#search_menu" />
                    <div id="search_menu" style="width:120px">
                        <div name="username">
                            账 号</div>
                        <div name="realname">
                            姓 名</div>
                        <div name="role">
                            角 色</div>
                    </div>
                </td>
            </tr>
        </table>       
    </div>
    <table id="tab_list"></table>
    <script type="text/javascript">
        $(function () {
            InitGird();
            InitSearch();
        }           
            );
        function InitGird() {
            $("#tab_list").datagrid({
                title:"用户列表",
                url: location.href,
                sortName: "JSON_id", //排序字段
                idField: "JSON_id", //标识字段,主键
                iconCls: "", //标题左边的图标
                width: "80%", //宽度
                height: $(parent.document).find("#mainPanle").height() - 10 > 0 ? $(parent.document).find("#mainPanle").height() - 10 : 500, //高度
                nowrap: false, //是否换行，True 就会把数据显示在一行里
                striped: true, //True 奇偶行使用不同背景色
                collapsible: false, //可折叠
                sortOrder: "desc", //排序类型
                remoteSort: true, //定义是否从服务器给数据排序
                frozenColumns: [[//冻结的列，不会随横向滚动轴移动
	                { field: 'cbx', checkbox: true },
	                { title: '账号', field: 'JSON_username', width: 150, sortable: true },
                    { title: '中文名', field: 'JSON_cnname', width: 150 }
                ]],
                columns: [[
                    {
                        title: '状态', field: 'JSON_state', formatter: function (value, rec, index) {
                            if (value == -2) {
                                return '禁止用户';
                            }
                            else if (value == -1) {
                                return '删除用户';
                            }
                            else if (value == 0) {
                                return '未通过用户';
                            }
                            else if (value == 1) {
                                return '正式用户';
                            }
                        }, width: 120
                    },
                    {
                        title: '类型', field: 'JSON_usertype', formatter: function (value, rec, index) {
                            if (value == 1) {
                                return '普通管理';
                            }
                            else if (value == 9) {
                                return '高级管理';
                            }
                            else if (value == 99) {
                                return '超级管理员';
                            }
                        }, width: 120
                    },
                    {
                        title: '角色id', field: 'JSON_roleid', formatter: function (value, rec, index) {
                            if (value == "0") {
                                return "零权限管理员";
                            }
                            else if (value == "1") {
                                return "xx权限管理员";
                            }
                        }, width: 120
                    },
                    { title: '手机', field: 'JSON_mobile', width: 150 },
                    {
                        title: '操作', field: 'JSON_id', width: 80, formatter: function (value, rec) {
                            return '<a style="color:red" href="javascript:;" onclick="EditData(' + value + ');$(this).parent().click();return false;">修改</a>';
                        }
                    }
                ]],
                toolbar: "#tab_toolbar",
                queryParams: { "action": "query" },
                pagination: true, //是否开启分页
                pageNumber: 1, //默认索引页
                pageSize: 10, //默认一页数据条数
                rownumbers: true //行号
                
            }
                );
        }
        function InitSearch() {
            $("#ipt_search").searchbox({
                width: 200,
                iconCls: 'icon-save',
                searcher: function (val, name) {
                    $('#tab_list').datagrid('options').queryParams.search_type = name;
                    $('#tab_list').datagrid('options').queryParams.search_value = val;
                    $('#tab_list').datagrid('reload');
                },
                prompt: '请输入要查询的账号'
            });
        }
        function OpenWin() {
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
        //提交按钮事件
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
            $("#edit").dialog("open");
            $("#btn_add").attr("onclick", "Add(" + uid + "); return false;");

            $.post(location.href, { "action": "queryone", "id": uid }, function (data) {
                var dataObj = eval("(" + data + ")"); //转换为json对象    
                console.info(dataObj);
                $("#form_edit").form('load', dataObj);
            });
        }

        //删除按钮事件
        function DelData(id) {
            $.messager.confirm('提示', '确认删除？', function (r) {
                if (r) {
                    var selected = "";
                    if (id <= 0) {
                        $($('#tab_list').datagrid('getSelections')).each(function () {
                            selected += this.JSON_id + ",";
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
