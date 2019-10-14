<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisitRecord.aspx.cs" Inherits="GoosleB2C.Web.Admin.Sys.VisitRecord" %>

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
</head>
<body>
    <form id="form_list" name="form_list" method="post">
        <table id="tab_list"></table>
        <div id="tab_toolbar" style="padding: 0 2px;">
            <table cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>              
                    <td style="padding-left: 2px">                                                                          
                        <a href="#" onclick="DelData(0);return false;" id="a_del" class="easyui-linkbutton" iconcls="icon-cancel">删除</a>                   
                    </td>
                    <td>
                        <span>开始日期</span>
                        <input type="text" class="easyui-datebox" id="startDate"  editable="false" />
                        <span>结束日期</span>
                        <input type="text" class="easyui-datebox" id="endDate"  editable="false" />
                        <a href="javascript:;" onclick="Search();" class="easyui-linkbutton" iconCls="icon-search">查询</a>
                        <%--<span>年：</span>
                        <input id="year" style="line-height: 25px; font-size: 16px; text-indent: 10px; border-radius: 5px; outline: none; border: 0.5px; border-style: solid; border-color: #528ecc;" />
                        <span>月：</span>
                        <input id="month" style="line-height: 25px; font-size: 16px; text-indent: 10px; border-radius: 5px; outline: none; border: 0.5px; border-style: solid; border-color: #528ecc;" />
                        <span>日：</span>
                        <input id="day" style="line-height: 25px; font-size: 16px; text-indent: 10px; border-radius: 5px; outline: none; border: 0.5px; border-style: solid; border-color: #528ecc;" />--%>
                    </td>
                    <td style="text-align: right; padding-right: 15px">
                        <input id="ipt_search" menu="#search_menu" />
                        <div id="search_menu" style="width: 120px">
                            <div name="vid">
                                微信ID
                            </div>
                            <div name="ip">
                                IP地址
                            </div>                            
                        </div>
                    </td>            
                </tr>
            </table>    
        </div>
    </form>

    <script type="text/javascript">
        $(function () {
            InitGird();
            InitSearch();            
        });
        //初始化表格
        function InitGird() {
            $('#tab_list').datagrid({
                title: '访问记录', //表格标题
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
	                { title: '微信ID', field: 'JSON_vid', width: 250, sortable: false },                   
                ]],
                columns: [[                                                              
                    { title: 'IP地址', field: 'JSON_ip', width: 250 },                    
                    { title: '访问地址', field: 'JSON_url', width: 500 },
                    { title: '访问时间', field: 'JSON_visittime', width: 250 },                                   
                ]],
                toolbar: "#tab_toolbar",
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
                width: 300,
                iconCls: 'icon-save',
                searcher: function (val, name) {
                    $('#tab_list').datagrid({
                        title: '访问记录', //表格标题
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
                            { title: '微信ID', field: 'JSON_vid', width: 250, sortable: false },
                        ]],
                        columns: [[
                            { title: 'IP地址', field: 'JSON_ip', width: 250 },
                            { title: '访问地址', field: 'JSON_url', width: 500 },
                            { title: '访问时间', field: 'JSON_visittime', width: 250 },
                        ]],
                        toolbar: "#tab_toolbar",
                        queryParams: { "action": "query", "search_type": name, "search_value": val },
                        pagination: true, //是否开启分页
                        pageNumber: 1, //默认索引页
                        pageSize: 10, //默认一页数据条数
                        rownumbers: true //行号
                    });
                    //$('#tab_list').datagrid('options').queryParams.search_type = name;
                    //$('#tab_list').datagrid('options').queryParams.search_value = val;
                    //$('#tab_list').datagrid('reload');
                },
                prompt: '请输入要查询的信息'
            });            
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
        $('#startDate').datebox({
            onSelect: function (beginDate) { //影响月的初始化 TODO
                $('#endDate').datebox().datebox('calendar').calendar({
                    validator: function (date) {
                        return beginDate <= date;
                    }
                });
            },
            formatter: function (date) {
                var y = date.getFullYear();
                var m = date.getMonth() + 1;
                var d = date.getDate();
                //return y + '/' + (m < 10 ? ('0' + m) : m) + '/' + (d < 10 ? ('0' + d) : d);
                return y + '/' + m + '/' + d;
            },
            parser: function (s) {
                if (!s) return new Date();
                var ss = (s.split('/'));
                var y = parseInt(ss[0], 10);
                var m = parseInt(ss[1], 10);
                var d = parseInt(ss[2], 10);
                if (!isNaN(y) && !isNaN(m) && !isNaN(d)) {
                    return new Date(y, m - 1, d);
                } else {
                    return new Date();
                }
            }
        });
        $('#endDate').datebox({
            onShowPanel: function () { },
            formatter: function (date) {
                var y = date.getFullYear();
                var m = date.getMonth() + 1;
                var d = date.getDate();
                //return y + '/' + (m < 10 ? ('0' + m) : m) + '/' + (d < 10 ? ('0' + d) : d);
                return y + '/' + m + '/' + d;
            },
            parser: function (s) {
                if (!s) return new Date();
                var ss = (s.split('/'));
                var y = parseInt(ss[0], 10);
                var m = parseInt(ss[1], 10);
                var d = parseInt(ss[2], 10);
                if (!isNaN(y) && !isNaN(m) && !isNaN(d)) {
                    return new Date(y, m - 1, d);
                } else {
                    return new Date();
                }
            }
        });
        function GetJsonDate(cmd, start, end){
            var postdata = "{ \"action\":\"" + cmd + "\",";
            postdata += "\"" + "startDate" + "\":\"" + start + "\",";
            postdata += "\"" + "endDate" + "\":\"" + end + "\",";
            postdata = postdata.substr(0, postdata.length - 1);
            postdata += "}";
            return eval("(" + postdata + ")");
        }
        function Search() {
            var startDate = $("#startDate").datebox("getValue");
            var endDate = $("#endDate").datebox("getValue");
            //alert(v);

            //var json = GetJsonDate("queryBydate", startDate, endDate);

            //alert(JSON.stringify(json));

            //$.ajax({
            //    url: 'VisitRecord.aspx',
            //    type: 'post',
            //    data: json,
            //    async: false,
            //    success: function (data) {
            //        var dataObj = eval("(" + data + ")");
            //        //alert(JSON.stringify(dataObj));
            //        $("#tab_list").datagrid('loadData', dataObj);
            //    }
            //});

            $('#tab_list').datagrid({
                title: '访问记录', //表格标题
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
	                { title: '微信ID', field: 'JSON_vid', width: 250, sortable: false },
                ]],
                columns: [[
                    { title: 'IP地址', field: 'JSON_ip', width: 250 },
                    { title: '访问地址', field: 'JSON_url', width: 500 },
                    { title: '访问时间', field: 'JSON_visittime', width: 250 },
                ]],
                toolbar: "#tab_toolbar",
                queryParams: { "action": "queryBydate", "startDate":startDate, "endDate":endDate },
                pagination: true, //是否开启分页
                pageNumber: 1, //默认索引页
                pageSize: 10, //默认一页数据条数
                rownumbers: true //行号
            });            
        }
    </script>
</body>
</html>
