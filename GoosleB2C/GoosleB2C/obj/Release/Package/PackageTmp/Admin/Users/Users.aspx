<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="GoosleB2C.Web.Admin.Users.Users" %>

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
    <title></title>
    <style>
        .table_edit{
            text-align:right;
            border-spacing:0px 8px;
        }
        .table_edit tr td input{
            height:20px
        }
        .tdal_{
            width:100px
        }
        .tdar_{
            width:180px
        }
        textarea{
            resize:none
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
                    <td style="text-align: right; padding-right: 15px">
                    <input id="ipt_search" menu="#search_menu" />
                    <div id="search_menu" style="width:120px">
                        <div name="username">
                            用户名</div>
                        <div name="realname">
                             姓名</div>                       
                </td>           
                </tr>
            </table>    
        </div>
    </form>

   <div id="edit" class="easyui-dialog" title="" style="width: 400px; height: 350px;"
        modal="true" closed="true" closable="false" resizable="true" buttons="#edit-buttons">
          <form id="form_edit" name="form_edit" method="post" url="Users.aspx">
        <table class="table_edit">
            <tr>
                <td class="tdal tdal_">
                    用户名：
                </td>
                <td class="tdar tdar_">
                    <input id="ipt_username"  name="ipt_username" type="text" class="easyui-validatebox" <%--style="height:20px"--%>
                        required="true" />
                </td>
            </tr>
            <tr>
                <td class="tdal tdal_">
                    密码：
                </td>
                <td class="tdar tdar_">
                    <input id="ipt_userpwd" name="ipt_password" type="password" class="easyui-validatebox"
                        data-options="required:'true',validType:'length[4,12]'" />
                </td>
            </tr>
            <tr>
                <td class="tdal tdal_">
                    姓名：
                </td>
                <td class="tdar tdar_">
                    <input id="ipt_realname" name="ipt_realname" type="text" class="easyui-validatebox"
                        data-options="required:'true',validType:'chinese'" />
                </td>
            </tr>            
            <tr>
                <td class="tdal tdal_">
                    手机号码：
                </td>
                <td class="tdar tdar_">
                    <input id="ipt_phone" name="ipt_phone" type="text" class="easyui-validatebox" data-options="required:'true',validType:'phone'"/>
                </td>
            </tr>
            <tr>
                <td class="tdal tdal_">
                    性别：
                </td>
                <td class="tdar tdar_">           
                        <select id="ipt_sex" class="easyui-combobox" name="ipt_sex" editable="false" style="width:175px">
                        <option value= "1">男</option>
                        <option value= "0">女</option>                       
                        </select>
                </td>
            </tr>
            <tr>
                <td class="tdal tdal_">
                    状态：
                </td>
                <td class="tdar tdar_">           
                        <select id="ipt_state" class="easyui-combobox" name="ipt_state" editable="false" style="width:175px;">                       
                        <option value="1">有效</option>
                        <option value="-1">黑名单</option>
                        <option value="0">删除</option>                        
                        </select>
                </td>
            </tr>
            <%--<tr>
                <td class="tdal tdal_">
                    等级id：
                </td>
                <td class="tdar tdar_">           
                        <select id="ipt_levelid" class="easyui-combobox" name="ipt_levelid" editable="false" style="width:175px;">                            
                        </select>
                </td>
            </tr>       --%>                
            <%--<tr>
                <td class="tdal tdal_">
                    积分：
                </td>
                <td class="tdar tdar_">
                    <input id="ipt_points" name="ipt_points" type="text"/>
                </td>
            </tr>--%>
            <%--<tr>
                <td class="tdal tdal_">
                    余款：
                </td>
                <td class="tdar tdar_">
                    <input id="ipt_fund" name="ipt_fund" type="text"/>
                </td>
            </tr>           --%> 
            <tr>
                <td class="tdal tdal_">
                    备注：
                </td>
                <td class="tdar tdar_">                   
                    <textarea id="ipt_remak" name="ipt_remak" rows="6" cols="21"></textarea>                  
                </td>
            </tr>
        </table>
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
            InitSearch();           
        });

        function transForm(value, row, index) {
            return row.JSON_remak.replace(/br/g,";")
        }       
        function InitGird() {
            $('#tab_list').datagrid({
                title: '用户列表', //表格标题
                url: location.href, //请求数据的页面
                sortName: 'JSON_uid', //排序字段
                idField: 'JSON_uid', //标识字段,主键
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
	                { title: '用户名', field: 'JSON_username', width: 150, sortable: true },
                    { title: '姓名', field: 'JSON_realname', width: 150 },
                ]],
                columns: [[                                                     
                    { title: '微信识别码', field: 'JSON_wid', width: 150 },
                    { title: '微信名字', field: 'JSON_wname', width: 150 },
                    { title: '微信头像', field: 'JSON_wimg', width: 150 },
                    { title: '微信其他码', field: 'JSON_wcode', width: 150 },                   
                    {
                        title: '性别', field: 'JSON_sex', width: 150, formatter: function (value, rec, index)
                        {
                            if (value == 1) {
                                return '男';
                            }
                            else if (value == 0) {
                                return '女';
                            }
                        }
                    },
                    { title: '手机号码', field: 'JSON_phone', width: 150 },
                    { title: '状态', field: 'JSON_state', width: 150, formatter: function (value, rec, index)                   
                        {
                        if (value == 1) {
                            return '有效';
                        }
                        else if (value == 0) {
                            return '删除';
                        }
                        else if (value == -1) {
                            return '黑名单';
                        }
                        },
                    },
                    { title: '等级名称', field: 'JSON_levelname', width: 150 },
                    { title: '积分', field: 'JSON_points', width: 150 },
                    { title: '余款', field: 'JSON_fund', width: 150 },
                    { title: '注册时间', field: 'JSON_logintime', width: 150 },
                    { title: '注册ip', field: 'JSON_loginip', width: 150 },
                    { title: '最后登录时间', field: 'JSON_lasttime', width: 150 },
                    { title: '最后登录ip', field: 'JSON_lastip', width: 150 },
                    { title: '备注', field: 'JSON_remak', width: 150, formatter:transForm },                    
                ]],
                toolbar: "#tab_toolbar",
                queryParams: { "action": "query" },
                pagination: true, //是否开启分页
                pageNumber: 1, //默认索引页
                pageSize: 10, //默认一页数据条数
                rownumbers: true //行号
            });           
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
            $("#edit").dialog({ title: "新增用户" });
            $('#form_edit input').val('');
            $('#form_edit textarea').val('');
            //$.ajax({
            //    url: location.href,
            //    type: "post",
            //    async: false,
            //    data: {
            //        "action": "QueryLevelName"
            //    },
            //    success: function (data) {
            //        var dataObj = eval("(" + data + ")"); //转换为json对象                
            //        $('#ipt_levelid').combobox({
            //            valueField: "id",
            //            textField: "levelname",
            //        }).combobox("loadData", dataObj);
            //    }
            //})
            $("#edit").dialog("open");
            $("#edit-buttons a:first").attr("onclick", "Add(0); return false;")
        }
        $.extend($.fn.validatebox.defaults.rules, {
            length: {//密码长度校验  
                validator: function (value, param) {
                    return value.length >= param[0] && param[1] >= value.length;
                },
                message: '请输入{0}-{1}位字符。'
            },
            chinese: {//中文名校验  
                validator: function (value, param) {
                    return /^[\u4E00-\u9FA5\uF900-\uFA2D]+$/.test($.trim(value));
                },
                message: '请输入中文。'
            },
            phone: {//手机号码校验  
                validator: function (value, param) {
                    return /^1[3 | 4 | 5 | 8 | 9]+\d{9}$/.test(value);
                },
                message: '请输入正确的手机号码。'
            }
        });
        function GetInputData(id, cmd) {
            var remak = document.getElementById("ipt_remak").value
            var mak;
            if (remak != null) {
                mak = remak.replace(/\n/g,"br")
            }
            var postdata = "{ \"action\":\"" + cmd + "\",";
            $("#" + id + " input[type!='checkbox']").each(function () {
                postdata += "\"" + $(this).attr("name") + "\":\"" + $(this).val() + "\",";
            });
            $("#" + id + " input[type='checkbox']").each(function () {
                postdata += "\"" + $(this).attr("name") + "\":\"" + this.checked + "\",";
            });

            postdata += "\"" + "ipt_remak" + "\":\"" + mak + "\",";

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
        function DelData(id) {
            $.messager.confirm('提示', '确认删除？', function (r) {
                if (r) {
                    var selected = "";
                    if (id <= 0) {
                        $($('#tab_list').datagrid('getSelections')).each(function () {
                            selected += "\'" + this.JSON_uid + "\'" + ",";
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
        function GetlevelPoint() {
            $.ajax({
                url:location.href,
                type: "post",
                async: false,
                data:{"action":"GetlevelPoint"},
                success: function (data) {
                    alert(data);
                }
            })
        }
    </script>
</body>
</html>
