<%@  Language="C#"  AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="GoosleB2C.Web.Admin.Sys.Roles" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="/JS/easyUI/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="/JS/easyUI/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="/JS/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <link href="/JS/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="/JS/easyUI/themes/gray/easyui.css" rel="stylesheet" type="text/css" /> 

    <script src="/JS/wikmenu.js" type="text/javascript"></script>
    <script src="/JS/wikmain.js" type="text/javascript"></script>
    <title>Roles</title>
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
                    <div id="search_menu" style="width:200px">
                        <div name="角色名称">
                            角色名称</div>
                    </div>
                </td>
            </tr>
           </table>
       
    </div>
    </form>
<%--列表 end--%>
<%--添加 查看明细 start--%>
 <div id="detail" class="easyui-dialog" title="角色信息" style="width:700px; height:600px" closed="true" modal="true" buttons="#detail-buttons">
                <div style="margin:10px">
                    <label style="font-size:20px"><b>角色关联</b></label><br /><hr />
                    <table id="dg_roleinfo"></table>
                </div>           
 
            <div id="de_roleinfo" style="margin:10px">
                <label style="font-size:20px"><b>角色信息</b></label><br /><hr />

                <label style="font-size:15px">角色名称：</label>
                <label id="role_name"></label><br />

                <label style="font-size:15px">角色排序：</label>
                <label id="role_order"></label><br />

                <label style="font-size:15px">角色介绍：</label>
                <label id="role_intro"></label><br />

                <label style="font-size:15px">角色创建人：</label>
                <label id="role_createuser"></label><br />

                <label style="font-size:15px">角色创建日期：</label>
                <label id="role_createdate"></label><br />

                <label style="font-size:15px">角色更新人：</label>
                <label id="role_updateuser"></label><br />

                <label style="font-size:15px">角色更新日期：</label>
                <label id="role_updatedate"></label><br />

                <label style="font-size:15px">角色备注：</label>
                <label id="role_remark"></label><br />

            </div>
        <div style="margin:10px">
            <label style="font-size:20px"><b>权限信息</b></label><br /><hr />
            <ul id="ts" class="easyui-tree">

            </ul>

        </div>
               





 </div>
<%--添加 修改 start--%>
        <div id="edit" class="easyui-dialog" title="编辑角色" style="width: 450px; height: 500px;"
        modal="true" closed="true" buttons="#edit-buttons">
          <form id="form_edit" name="form_edit" method="post" url="Roles.aspx">
        <table class="table_edit">

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
                    <input id="ipt_roleorder" name="ipt_roleorder" type="text" class="easyui-validatebox" required="true"  onkeyup="this.value=this.value.replace(/[^0-9.]/g,'')"
                        />
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
    <%--   树型表展示权限--%>
            <hr />
            <h3 style="margin:10px">权限设置</h3>
        <ul id="tt" class="easyui-tree">

        </ul>
    </div>
    <!--查看明细按钮-->
    <div id="detail-buttons">

            <a href="javascript:;" class="easyui-linkbutton"
            onclick="$('#detail').dialog('close');clean();return false;">关闭</a>

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
        //转换备注展示:&uty->;
        function transForm(value, row, index) {
            return row.JSON_remark.replace(/&uty/g,";")
            
        }
        //初始化表格
        function InitGird() {
            $('#tab_list').datagrid({
                title: '角色列表', //表格标题
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
	                { field: 'cbx', checkbox: true },
                    { title: '排序', field: 'JSON_roleorder', width: 50, sortable: true },
//                    { title: 'ID', field: 'JSON_id', width: 80, sortable: true },
	                { title: '角色名称', field: 'JSON_rolename', width: 150, }
                    
                    
				]],
                columns: [[
                    { title: '介绍说明', field: 'JSON_intro', width: 150 },
                    {title:'创建人',field:'JSON_createuser',width:100},
                    { title: '创建日期', field: 'JSON_createdate', width: 150 }, 
                    { title: '更新人', field: 'JSON_updateuser', width: 100},
                    {title: '更新日期',field:'JSON_updatedate',width:150},
                    { title: '备注', field: 'JSON_remark', width: 250, formatter: transForm},
                { title: '操作', field: 'JSON_id', width: 100, formatter: function (value, rec) {
                    return '<a style="color:red" href="javascript:;" onclick="EditData(\''+value+'\');$(this).parent().click();return false;">修改</a>'+ '    '+'<a style="color:red" href="javascript:;" onclick="Detail(\''+value+'\');$(this).parent().click();return false;">查看明细</a>';
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
        //初始化搜索框
        function InitSearch() {
            $("#ipt_search").searchbox({
                width: 250,
                
                searcher: function (val, name) {
                    console.log(val + name);
                    $('#tab_list').datagrid('load', { "searchKey": name, "searchValue": val });
                    //$('#tab_list').datagrid('options').queryParams.search_value = val;
                    //$('#tab_list').datagrid('reload');
                },
                prompt: '请输入要查询的角色名称'
            });
        }

        //打开添加窗口
        function OpenWin() {
            powertree();
            $("#edit").dialog("open");
            $("#edit-buttons a:first").attr("onclick", "Add(0); return false;")
        }
        //表格数据生成JSON
        //id = edit 
        function GetInputData(id, cmd) {
            var remark = document.getElementById("ipt_remark").value;
            var mark;
            if ( remark!=null) {
                mark = remark.replace(/\n/g,"&uty");
                //alert(mark);
            }
            
            var postdata = "{ \"action\":\"" + cmd + "\",";
            postdata += "\"funid\":\"" + getChecked() + "\",";
            $("#" + id + " input[type!='checkbox']").each(function () {
                postdata += "\"" + $(this).attr("name") + "\":\"" + $(this).val() + "\",";
            });
            $("#" + id + " input[type='checkbox']").each(function () {
            //当表格为checkbox时
                postdata += "\"" + $(this).attr("name") + "\":\"" + this.checked + "\",";
            });
            //remark添加进Json
            postdata += "\"" + "ipt_remark" + "\":\"" + mark + "\",";

            postdata = postdata.substr(0, postdata.length - 1);
            postdata += "}";
            console.info(postdata);
            return eval("(" + postdata + ")");
        }
        //提交按钮事件
        function Add(uid) {
            //getChecked();
        if (!$("#form_edit").form("validate")) {
            return;
        }


        var json = GetInputData('edit', 'submit');
      
        json.id = uid;       
        $.post(location.href,json, function (data) {
            $.messager.alert('提示', data, 'info', function () {
                if (data.indexOf("成功") > 0) {
                  //  console.info(data);
                    $("#tab_list").datagrid("reload");
                    $("#edit").dialog("close");
                    clean();
                    
                }

            });
        });
        //数字展示转换用户类型
        }
        function Type(value, row, index) {
            //console.log(row.JSON_usertype);
            if (row.JSON_usertype == 1) {
                return "普通管理";
            } else if(row.JSON_usertype == 9){
                return "高级管理员";
            }
            else if (row.JSON_usertype == 99) {
                return "超级管理员";
            }
            else {
                return "未知"
            }
        }
        //查看明细
        function Detail(uid) {
            $('#detail').dialog("open");
        
            //获取角色信息
            $.ajax({
                url: location.href,
                type: 'post',
                async: 'false',
                data: {
                    "action": "queryone",
                    "id":uid,
                },
                success: function (data) {
                    console.info(data);
                    var da = eval("("+data+")");
                    console.info(da['ipt_rolename']);
                    $('#role_name').html(da['ipt_rolename']);
                    $('#role_order').html(da['ipt_roleorder']);
                    $('#role_intro').html(da['ipt_intro']);
                    $('#role_createuser').html(da['ipt_createuser']);
                    $('#role_createdate').html(da['ipt_createdate']);
                    $('#role_updatedate').html(da['ipt_updatedate']);
                    $('#role_updateuser').html(da['ipt_updateuser']);
                    $('#role_remark').html(da['ipt_remark']);
                    console.info(data);
                }
            });
            //获取角色关联
            $('#dg_roleinfo').datagrid({
                title: '关联账号列表', //表格标题
                url: location.href, //请求数据的页面
                //               sortName: 'JSON_id', //排序字段
                //               idField: 'JSON_id', //标识字段,主键
                iconCls: '', //标题左边的图标
                width: '100%', //宽度
                //height: $(parent.document).find("#mainPanle").height() - 10 > 0 ? $(parent.document).find("#mainPanle").height() - 10 : 500, //高度
                nowrap: false, //是否换行，True 就会把数据显示在一行里
                striped: true, //True 奇偶行使用不同背景色
                collapsible: false, //可折叠
                sortOrder: 'desc', //排序类型
                remoteSort: true, //定义是否从服务器给数据排序
                frozenColumns: [[//冻结的列，不会随横向滚动轴移动
	                //{ field: 'cbx', checkbox: true },
	                //{ title: '角色名称', field: 'JSON_rolename', width: 140, sortable: true },
                    { title: '用户名', field: 'JSON_username', width: 140 },
                    { title: '中文名', field: 'JSON_cnname', width: 140 },
                { title: '手机', field: 'JSON_mobile', width: 140 }
                ]],
                columns: [[
                    { title: '状态', field: 'JSON_createuser', width: 50 },
                    { title: '类型', field: 'JSON_usertype', width: 150 ,formatter:Type},
                    

                //{
                //    title: '操作', field: 'JSON_id', width: 100, formatter: function (value, rec) {
                //        return '<a style="color:red" href="javascript:;" onclick="EditData(\'' + value + '\');$(this).parent().click();return false;">修改</a>' + '    ' + '<a style="color:red" href="javascript:;" onclick="Detail(\'' + value + '\');$(this).parent().click();return false;">查看明细</a>';
                //    }
                //}
                ]],
                //toolbar: "#tab_toolbar",
                queryParams: {
                    "action": "queryManagers",
                    "id":uid,
                },
                onLoadSuccess: function (data) {

                    console.log('Managers' + data);
                },
                onLoadError:function(none){
                    console.log('error' + none);
                },
                pagination: true, //是否开启分页
                pageNumber: 1, //默认索引页
                pageSize: 10, //默认一页数据条数
                rownumbers: true //行号
            });


            //获取权限表
            $('#ts').tree({
                animate: false,
                checkbox:true,
            });
            
            $.ajax({
                url: location.href,
                type: 'post',
                async: 'false',
                data: {
                    "action": "querypower",
                    "id": uid,
                },
                success: function (data) {
                    console.info(data);
                    var treedata = transview(data, 'JSON_id', 'JSON_father');

                    console.info(treedata);
                    $('#ts').tree({
                        onBeforeCheck:function(){
                            return false;
                        },
                        onBeforeSelect() {
                            return false;
                        },
                        data: treedata,
                    });
                },
                error: function (errorMsg) {
                    alert("请求数据失败");
                },

                dataType: "json",
            });

        }
        //转换权限查看树
        function transview(a, idStr, pidStr) {
            var r = [], hash = {}, pid = pidStr, i = 0, j = 0, k = 0, len = a['total'], id = idStr;
            var temp = a['rows'], count = 0;
            var father;
            //首先插入有父节点的项
            for (i = 0; i < len; i++) {
                if (temp[i][pidStr] != "0") {
                    if (temp[i]['JSON_id1']) hash[count] = { text: temp[i]['JSON_functionname'], state: 'opened', id: temp[i][idStr], order: i, father: temp[i][pid], checked: true };
                    else hash[count] = { text: temp[i]['JSON_functionname'], state: 'opened', id: temp[i][idStr], order: i, father: temp[i][pid] };
                    count++;
                }


            }
            //再插入无父节点的项
            for (i = 0; i < len; i++) {
                if (temp[i][pidStr] == "0") {
                    if (temp[i]['JSON_id1']) hash[count] = { text: temp[i]['JSON_functionname'], state: 'opened', id: temp[i][idStr], order: i, father: temp[i][pid], checked: true };
                    else hash[count] = { text: temp[i]['JSON_functionname'], state: 'opened', id: temp[i][idStr], order: i, father: temp[i][pid] };
                    count++;
                }
            }
            //    console.info(hash);
            for (j = 0; j < count; j++) {
                if (hash[j]['father'] != "0") {
                    var faterid = hash[j]['father'];
                    //获取父节点的hash中的位置
                    for (k = 0; k < count; k++) {
                        if (hash[k]['id'] == faterid) { father = k; }
                    }
                    //console.info(faterid);
                    //console.info(father);
                    //如果父元素的nodes对象不存在，则创建数组
                    if (!hash[father]['children']) hash[father]['children'] = [];
                    //把对应的子节点加入父节点
                    hash[father]['children'].push(hash[j]);
                } else {
                    r.push(hash[j]);
                }
            }
            //console.info(r);
            return r;
        }
    //获取权限树
    function powertree(uid) {
        $('#tt').tree({
            animate: true,
            checkbox: true,
            

        });
        $.ajax({
            url: location.href,
            type: 'post',
            async: 'false',
            data: {
                "action": "querypower",
                "id" : uid,
            },
            success: function (data) {
                console.info(data);
                var treedata = transData(data,'JSON_id','JSON_father');
                
                console.info(treedata);
                $('#tt').tree({
                    onBeforeSelect(node) {
                        return false;

                    },
                        data: treedata,
                    });
                },
            error: function (errorMsg) {
                
            },
            
            dataType: "json",
        });

    }
    function transData(a,idStr,pidStr) {
        var r = [], hash = {}, pid = pidStr, i = 0, j = 0,k = 0, len = a['total'], id = idStr;
        var temp = a['rows'],count = 0;
        var father;
        //先插入有父节点的项
        for (i = 0; i < len; i++) {
            if (temp[i][pidStr] != "0") {
                if (temp[i]['JSON_id1']) hash[count] = { text: temp[i]['JSON_functionname'], state: 'opened', id: temp[i][idStr], order: i, father: temp[i][pid], checked: true };
                else hash[count] = { text: temp[i]['JSON_functionname'], state: 'opened', id: temp[i][idStr], order: i, father: temp[i][pid] ,checked:false};
                count++;
            }
         
            
        }
        //再插入无父节点的项
        for (i = 0; i < len; i++) {
            if (temp[i][pidStr] == "0") {
                if (temp[i]['JSON_id1']) hash[count] = { text: temp[i]['JSON_functionname'], state: 'opened', id: temp[i][idStr], order: i, father: temp[i][pid], checked: true };
                else hash[count] = { text: temp[i]['JSON_functionname'], state: 'opened', id: temp[i][idStr], order: i, father: temp[i][pid], checked: false };
                count++;
            }
        }
    //    console.info(hash);
        for (j = 0; j < len; j++) {
            if (hash[j]['father'] != "0") {
                var faterid = hash[j]['father'];
                //获取父节点的hash中的位置
                for (k = 0; k < len; k++) {
                    if (hash[k]['id'] == faterid) { father = k; }
                }
                //console.info(faterid);
                //console.info(father);
                //如果父元素的nodes对象不存在，则创建数组
                if (!hash[father]['children']) hash[father]['children'] = [];
                //把对应的子节点加入父节点
                hash[father]['children'].push(hash[j]);
            } else {
                r.push(hash[j]);
            }
        }
        //console.info(r);
        return r;
    }
        //获取选中节点
    function getChecked() {
        var nodes = $('#tt').tree('getChecked');//获取:checked的结点
    //    console.info(nodes);
        var s = '';
        for (var i = 0; i < nodes.length; i++) {
            if (s != '') s += ',';
            s = s+nodes[i].id;
        }
        return s;
        //$.ajax({
        //    url: location.href,
        //    async: 'false',
        //    type: 'post',
        //    data: {
        //        "action":"submitpower",
        //        "roleid": uid,
        //        "funid":s,
        //    },
        //    success: function () {

        //    },
        //    error: function () {

        //    },
        //});
    //    console.info(s);
    }
    function clean() {
        $("")
        $("#ipt_remark").val("");
    }


        //修改链接 事件
    function EditData(uid) {
        powertree(uid);
        $("#edit").dialog("open");
        $("#btn_add").attr("onclick", "Add(\'" + uid + "\'); return false;")       
 
        $.post(location.href, { "action": "queryone", "id": uid }, function (data) {//请求成功时执行的回调函数
            var dataObj = eval("(" + data + ")"); //转换为json对象    
            //备注空格转换
            dataObj["ipt_remark"] = dataObj["ipt_remark"].replace(/&uty/g, "\n");
            //alert(dataObj["ipt_remark"]);
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
