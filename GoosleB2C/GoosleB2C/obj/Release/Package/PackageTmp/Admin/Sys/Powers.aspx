<%@  Language="C#"  AutoEventWireup="true" CodeBehind="Powers.aspx.cs" Inherits="GoosleB2C.Web.Admin.Sys.Powers" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <script src="/JS/easyUI/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="/JS/easyUI/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="/JS/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <link href="/JS/easyUI/themes/gray/easyui.css" rel="stylesheet" type="text/css" /> 
    <link href="/JS/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="/JS/wikmenu.js" type="text/javascript"></script>
    <script src="/JS/wikmain.js" type="text/javascript"></script>
    <link href="/css/default1.css" rel="stylesheet" type="text/css" />
    <title>Powers</title>
</head>
<body>
        <%--列表 start--%>
    <form id="form_list" name="form_list" method="post">
        <table id="tab_list">

        </table>
<%--         <div id="tab_toolbar" style="padding: 0 2px;">
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
                        <div name="realname">
                            角 色</div>
                    </div>
                </td>
            </tr>
           </table>
       
    </div>--%>
    </form>
<%--列表 end--%>
<%--添加 修改 start--%>
        <div id="edit" class="easyui-dialog" title="编辑角色" style="width: 350px; height: 240px;"
        modal="true" closed="true" buttons="#edit-buttons">
          <form id="form_edit" name="form_edit" method="post" url="Roles.aspx">
        <table class="table_edit">
<%--            <tr>
                <td class="tdrl">
                    ID：
                </td>
                <td class="tdrn">
                    <input id="ipt_id"  name="ipt_id" type="text" class="easyui-validatebox"
                        required="true" />
                </td>
            </tr>--%>
            <tr>
                <td class="tdrl">
                    角色名称：
                </td>
                <td class="tdrn">
                    <input id="ipt_rolename"  name="ipt_rolename" type="text" class="easyui-validatebox"
                        required="true" />
                </td>
            </tr>
            <tr>
                <td class="tdsl">
                    排序：
                </td>
                <td class="tdsr">
                    <input id="ipt_roleorder" name="ipt_roleorder" type="text" class="easyui-validatebox"
                        required="true" />
                </td>
            </tr>
            <tr>
                <td class="tdcul">
                    介绍说明：
                </td>
                <td class="tdjs">
                    <input id="ipt_intro" name="ipt_intro" type="text" class="easyui-validatebox"
                         />
                </td>
            </tr>
            <tr style="display:none">
                <td class="tdcul">
                    创建人：
                </td>
                <td class="tdcur">
                    <input id="ipt_createuser" name="ipt_createuser" type="text" 
                         />
                </td>
            </tr>
            <tr style="display:none">
                <td class="tdcdl">
                    创建日期：
                </td>
                <td class="tdcdr">
            
                    <input id="ipt_createdate" name="ipt_createdate" class="easyui-datebox"  type="text" value="1/1/2018"
                        />
                </td>
            </tr>
            <tr style="display:none">
                <td class="tduul">
                    更新人：
                </td>
                <td class="tduur">
                        <input id="ipt_updateuser" name="ipt_updateuser" type="text" 
                         />
                </td>
            </tr>
<%--            <tr>
                <td class="tdudl">
                    更新日期：
                </td>
                <td class="tdudr">
                    <input id="ipt_updatedate" name="ipt_updatedate" class="easyui-datebox"  type="text" value="1/1/2018" 
                        required="required" />
                </td>
            </tr>--%>
            <tr>
                <td class="tdrml">
                    备注：
                </td>
                <td class="tdrmr">
                        <textarea id="ipt_remark" name="ipt_remark"  rows="4" cols="25"></textarea>
                </td>
            </tr>

        </table>
        </form>
    </div>
    <div id="edit-buttons">
        <a id="btn_add" href="javascript:;" class="easyui-linkbutton">提交</a> 
        <a href="javascript:;" class="easyui-linkbutton"
            onclick="$('#edit').dialog('close');clean();return false;">取消</a>
    </div>
    <%--添加 修改 end--%>
    <script type="text/javascript">
        
        $(function () {
            InitGird();
            InitSearch();
        });
        //初始化表格
        function InitGird() {
            $('#tab_list').datagrid({
                title: '权限表格', //表格标题
                url: location.href, //请求数据的页面
 //               sortName: 'JSON_id', //排序字段
 //               idField: 'JSON_id', //标识字段,主键
                iconCls: '', //标题左边的图标
                width: '80%', //宽度
                height: $(parent.document).find("#mainPanle").height() - 10 > 0 ? $(parent.document).find("#mainPanle").height() - 10 : 500, //高度
                nowrap: false, //是否换行，True 就会把数据显示在一行里
                striped: true, //True 奇偶行使用不同背景色
                collapsible: false, //可折叠
                sortOrder: 'desc', //排序类型
                remoteSort: true, //定义是否从服务器给数据排序
                frozenColumns: [[//冻结的列，不会随横向滚动轴移动
	                //{ field: 'cbx', checkbox: true },
                    { title: 'ID', field: 'JSON_id', width:350 },
	                { title: '角色ID', field: 'JSON_roleid', width: 350 },
                    { title: '菜单ID', field: 'JSON_funid', width: 350 },
                    { title: '菜单权限值', field: 'JSON_powervalue', width: 80 },
                { title: '创建时间', field: 'JSON_createdate', width: 150 }


                    
				]],
            //    columns: [[
            //        { title: '介绍说明', field: 'JSON_intro', width: 150 },
            //        {title:'创建人',field:'JSON_createuser',width:100},
            //        { title: '创建日期', field: 'JSON_createdate', width: 150 }, 
            //        { title: '更新人', field: 'JSON_updateuser', width: 100},
            //        {title: '更新日期',field:'JSON_updatedate',width:150},
            //        {title: '备注',field:'JSON_remark',width:250},
            ////    { title: '操作', field: 'JSON_id', width: 80, formatter: function (value, rec) {
            ////    return '<a style="color:red" href="javascript:;" onclick="EditData(\''+value+'\');$(this).parent().click();return false;">修改</a>';
            ////}
            ////        }
            //    ]],
                //toolbar: "#tab_toolbar",
                queryParams: { "action": "query" },
                pagination: true, //是否开启分页
                pageNumber: 1, //默认索引页
                pageSize: 10, //默认一页数据条数
                rownumbers: true //行号
            });

        }
        //初始化搜索框
        function InitSearch() {
            $("#ipt_search").searchbox({
                width: 200,
                iconCls: 'icon-save',
                searcher: function (val, name) {
                    $('#tab_list').datagrid('options').queryParams.search_type = name;
                    $('#tab_list').datagrid('options').queryParams.search_value = val;
                    $('#tab_list').datagrid('reload');
                },
                prompt: '请输入要查询的角色名'
            });
        }

        //打开添加窗口
        function OpenWin() {
            clean();
            $("#edit").dialog("open");
            $("#edit-buttons a:first").attr("onclick", "Add(0); return false;")
        }
        //表格数据生成JSON
        //id = edit 
        function GetInputData(id, cmd) {
            var postdata = "{ \"action\":\"" + cmd + "\",";
            $("#" + id + " input[type!='checkbox']").each(function () {
                console.info(postdata);
                postdata += "\"" + $(this).attr("name") + "\":\"" + $(this).val() + "\",";
            });
            $("#" + id + " input[type='checkbox']").each(function () {
            //当表格为checkbox时
                postdata += "\"" + $(this).attr("name") + "\":\"" + this.checked + "\",";
            });
            //remark添加进Json
            postdata += "\"" + "ipt_remark" + "\":\"" + $("#ipt_remark").val() + "\",";

            postdata = postdata.substr(0, postdata.length - 1);
            postdata += "}";
            console.info(postdata);
            return eval("(" + postdata + ")");
        }
        //提交按钮事件
    function Add(uid) {
        if (!$("#form_edit").form("validate")) {
            return;
        }


        var json = GetInputData('edit', 'submit');
      
        json.id = uid;       
        $.post(location.href,json, function (data) {
            $.messager.alert('提示', data, 'info', function () {
                if (data.indexOf("成功") > 0) {
                    console.info(data);
                    $("#tab_list").datagrid("reload");
                    $("#edit").dialog("close");
                    clean();
                    
                }

            });
        });

    }
        //清空表单
    function clean() {
        $("#ipt_rolename").val("");
        $("#ipt_roleorder").val("");
        $("#ipt_remark").val("");
        $("#ipt_intro").val("");
    }
    //修改链接 事件
    function EditData(uid) {
        clean();
        $("#edit").dialog("open");
        $("#btn_add").attr("onclick", "Add(\'" + uid + "\'); return false;")       
 
        $.post(location.href, { "action": "queryone", "id": uid }, function (data) {//请求成功时执行的回调函数
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
                        selected += "\'"+this.JSON_id +"\'"+ ",";
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
