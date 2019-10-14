<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeliveryTemplate.aspx.cs" Inherits="GoosleB2C.Web.Admin.Sys.DeliveryTemplate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="../../JS/easyUI/jquery-1.7.2.min.js"></script>
    <script src="../../JS/easyUI/jquery.easyui.min.js"></script>
    <script src="../../JS/easyUI/locale/easyui-lang-zh_CN.js"></script>
    <link href="../../JS/easyUI/themes/gray/easyui.css" rel="stylesheet" />
    <link href="../../JS/easyUI/themes/icon.css" rel="stylesheet" />
    <script src="../../JS/wikmain.js"></script>
    <script src="../../JS/wikmenu.js"></script>
    <script src="../../JS/easyUI/jquery.edatagrid.js"></script>
    <title></title>
    <style>
        .table{
            margin-top:20px;
            margin-left:30px;
            margin-bottom:20px;
        }
        .tdal{
           text-align:center;
        }
    </style>
</head>
<body>
     <%--列表 start--%>
   <form id="form_list" name="form_list" method="post">
        <table id="tab_list">

        </table>
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
                        <div name="tempname">
                            模板名</div>
                    </div>
                </td>
            </tr>
           </table>     
    </div>
    </form>
    <%--列表 end--%>

    <%--添加运费模板 start--%>
    <div id="edit" class="easyui-dialog" title="添加运费模板" style="width: 350px; height: 300px;"
        modal="true" closed="true" buttons="#edit-buttons">
        <form id="form_edit" name="form_edit" method="post" url="DeliveryTemplate.aspx">
        <table class="table">
            <tr>
                <td class="tdal">模板名</td>
                <td class="tdar">
                    <input id="ipt_tempname1"  name="ipt_tempname" type="text" class="easyui-validatebox" required="true"/>
                </td>
            </tr>
            <tr>
                <td class="tdal">是否选中</td>
                <td class="tdar">
                    <select id="ipt_ischoose2" class="easyui-combobox" name="ipt_ischoose" editable="false" required="true" style="width:150px";>
                        <option value="" disabled selected>只能有一项是选中的</option>  
                       <%-- <option value='' disabled selected style='display:none;'></option>  --%>
                        <option value="0">不选中</option>
                        <option value="1">选中</option>   
                    </select>
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
    <%--添加运费模板--end--%>
    
    <%--修改运费模板--start--%>
    <div id="update" class="easyui-dialog" title="修改运费模板" style="width: 600px; height: 500px;"
        modal="true" closed="true" buttons="#update-buttons">
        <form id="form_update" name="form_update" method="post" url="DeliveryTemplate.aspx">
        <table class="table">
            <tr>
                <td class="tdal">模板名</td>
                <td class="tdar">
                    <input id="ipt_tempname"  name="ipt_tempname" type="text" class="easyui-validatebox" required="true" />
                </td>
            </tr>
            <tr>
                <td class="tdal">是否选中</td>
                <td class="tdar">
                    <select id="ipt_ischoose" class="easyui-combobox" name="ipt_ischoose" editable="false" required="true" style="width:150px";>
                        <option value="" disabled selected>只能有一项是选中的 </option>
                        <option value="0">不选中</option>
                        <option value="1">选中</option>   
                    </select>
                </td>
            </tr>
        </table>
        <a id="btn_update" href="javascript:;" class="easyui-linkbutton" style="margin-left:490px;">修改模板</a> 
        <hr />
        
        <table class="table">
            <tr>
                <td class="tdal">首重</td>
                <td class="tdar">
                    <input id="firstWeight"  type="text" class="easyui-numberbox" data-options="min:0,precision:3"/>
                </td>
            </tr>
            <tr>
                <td class="tdal">续重</td>
                <td class="tdar">
                    <input id="addedWeight" type="text" class="easyui-numberbox" data-options="min:0,precision:3"/>
                </td>
            </tr>
        </table>
        <a id="btn_addAll" href="javascript:;" onclick="addAll();" class="easyui-linkbutton" style="margin-left:490px;">批量修改</a> 

        <table id="tt" style="width:600px;height:500px" title="修改运费明细" url="" singleSelect="true">
		<thead>
			<tr>
				<th field="JSON_regionname" width="140"  align="center">省份</th>				
				<th field="JSON_firstweight" width="100" align="center" editor="{type:'numberbox',options:{precision:3}}">首重</th>
				<th field="JSON_addedweight" width="100" align="center"  editor="{type:'numberbox',options:{precision:3}}">续重</th>				
			</tr>
		</thead>
	</table>
        </form>
    </div>
    <div id="update-buttons">
        <a id="btn_update_detail" href="javascript:;" class="easyui-linkbutton" onclick="update_detail()">修改明细</a> 
        <a href="javascript:;" class="easyui-linkbutton" onclick="$('#update').dialog('close');return false;">取消</a>
    </div>


    <%--修改运费模板--end--%>
       
    <script type="text/javascript">
        
        $(function () {
            InitGird();
            InitSearch();
        });
        //初始运费模板表格
        function InitGird() {
            $('#tab_list').datagrid({
                title: '运费模板列表', //表格标题
                //sortName: 'JSON_id', //排序字段
                //idField: 'JSON_id', //标识字段,主键
                iconCls: '', //标题左边的图标
                width: '100%', //宽度
                height: $(parent.document).find("#mainPanle").height() - 10 > 0 ? $(parent.document).find("#mainPanle").height() - 10 : 500, //高度
                nowrap: false, //是否换行，True 就会把数据显示在一行里
                striped: true, //True 奇偶行使用不同背景色
                collapsible: false, //可折叠
                sortOrder: 'desc', //排序类型
                remoteSort: true, //定义是否从服务器给数据排序
                //frozenColumns: [[//冻结的列，不会随横向滚动轴移动
	            //    { field: 'cbx', checkbox: true },
                   
	            //    { title: '菜单页面名', field: 'JSON_functionname', width: 100, align: 'center' },
                //    { title: '页面地址', field: 'JSON_url', width: 150, align: 'center' }
                //]],
                columns: [[
                    { field: 'cbx', checkbox: true },
                    //{ title: '父级id', field: "father",formatter:function(value,rec,index){return value==0?'管理员':'普通用户'},width: 80 },
                    { title: '模板名', field: 'JSON_tempname', width: 100, align: 'center' },
                    {
                        title: '是否选中', field: 'JSON_ischoose', width: 100, align: 'center', formatter: function (value, rec, index) {
                            if (value == 0) {
                                return "不选中"
                            }
                            else {
                                return "选中"
                            }
                        }
                    },
                    {
                        title: '操作', field: "JSON_id", formatter: function (value,rec) {
                            return '<a style="color:red" href="javascript:;" onclick="EditData(\'' + value + '\');$(this).parent().click();return false;">修改</a>';
                        }
                        , width: 100, align: 'center'
                    }
                ]],
                toolbar: "#tab_toolbar",
                url: location.href,
                queryParams: { "action": "QueryDeliveryTemplateData" },
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
                prompt: '请输入要查询的模板名'
            });
        }

        //打开添加窗口
        function OpenWin() {
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
            //postdata += "\"" + "ipt_remark" + "\":\"" + $("#ipt_remark").val() + "\",";

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


            var json = GetInputData('edit', 'UpdateDeliveryTemplateData');

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

        //修改链接 事件
        function EditData(uid) {
            $("#update").dialog("open");
            $("#btn_update").attr("onclick", "Add_update(\'" + uid + "\'); return false;")
            $.post(location.href, { "action": "QueryOneTemplateData", "id": uid }, function (data) {//请求成功时执行的回调函数
                var dataObj = eval("(" + data + ")"); //转换为json对象    
                console.info(dataObj);
                $("#form_update").form('load', dataObj);
            });
            //初始化运费明细窗口
            $('#tt').edatagrid({
                //autoSave:true,
                queryParams: {
                    "action": "QueryDeliveryDetailData",
                    "id": uid,
                },
                url: location.href , //请求数据的页面
                sortName: 'JSON_provinceid', //排序字段
                //idField: 'JSON_provinceid', //标识字段,主键
                iconCls: '', //标题左边的图标
                width: '100%', //宽度
                height: $(parent.document).find("#mainPanle").height() - 10 > 0 ? $(parent.document).find("#mainPanle").height() - 10 : 500, //高度
                nowrap: false, //是否换行，True 就会把数据显示在一行里
                striped: true, //True 奇偶行使用不同背景色
                collapsible: false, //可折叠
                sortOrder: 'desc', //排序类型
                //toolbar: "#tab_toolbar",
                //pagination: true, //是否开启分页
                pageNumber: 1, //默认索引页
                pageSize: 31, //默认一页数据条数
                rownumbers: true //行号
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
                    $.post(location.href, { "action": "DelDeliveryTemplateData", "cbx_select": selected }, function (data) {
                        $.messager.alert('提示', data, 'info', function () { $("#tab_list").datagrid("reload"); });
                    });

                }
            });
        }

        //修改模板提交按钮事件
        function Add_update(uid) {
            if (!$("#form_update").form("validate")) {
                return ;
            }


            var json = GetInputData('update', 'UpdateDeliveryTemplateData');

            json.id = uid;
            $.post(location.href, json, function (data) {
                $.messager.alert('提示', data, 'info', function () {
                    if (data.indexOf("成功") > 0) {
                        console.info(data);
                        $("#tab_list").datagrid("reload");
                        //$("#update").dialog("close");
                    }

                });
            });

        }
        //修改明细提交按钮事件
        function update_detail() {
            
            $('#tt').edatagrid('saveRow');

            //获得表格全部数据数据 
            var updated = $('#tt').edatagrid('getRows');
            //var updated = $('#tt').edatagrid('getChanges', "updated");
            console.log(updated);
            if (updated.length) {
                var update = JSON.stringify(updated);
                var update1 = "{" + "\"Detail\"" + ":" + update + "}";


                $.ajax({
                    url: location.href,
                    type: "post",
                    //dataType: "json",
                    async: "true",
                    data: {
                        "action": "UpdateDeliveryDetailData",
                        "update1": update1
                    },
                    success: function (data) {
                        //$('#tt').edatagrid('reload');
                        ////$("#update").dialog("close");
                        //alert("修改成功");

                        $.messager.alert('提示', data, 'info', function () {
                            if (data.indexOf("成功") > 0) {
                                console.info(data);
                                $('#tt').edatagrid('reload');
                                $("#update").dialog("close");
                            }

                        });

                    }
                })
            }

        }

        //批量添加首重和续重
        function addAll() {
            var first = $("#firstWeight").val();
            var added = $("#addedWeight").val();
            //获取原表格里面的数据
            var rows = $('#tt').edatagrid('getRows');
            //console.log(rows[0].JSON_firstweight);
            //更新首重和续重的值
            for (var i = 1; i <= rows.length; i++) {
                rows[i-1].JSON_firstweight = first;
                rows[i-1].JSON_addedweight = added;
            }
            //console.log(rows);
         
            var str1 = JSON.stringify(rows);
            //console.log(str1);
            str1 = "{\"rows\":" + str1;
            str1 = str1 + ",\"total\":31";
            str1 = str1 + "}";
            //将字符串转化为对象
            var data = $.parseJSON(str1);
            console.log(data);
            $('#tt').edatagrid('loadData', data);
            $('#firstWeight').numberbox('clear');
            $('#addedWeight').numberbox('clear');
        }

    </script>


</body>
</html>
