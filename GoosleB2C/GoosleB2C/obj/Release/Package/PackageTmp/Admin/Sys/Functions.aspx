<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Functions.aspx.cs" Inherits="GoosleB2C.Web.Admin.Sys.Functions" %>

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
    <title></title>
    <style>
        #table{
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
                            <div name="functionname">
                                页面名</div>
                            <div name="funlevel">
                                级数</div>
                        </div>
                    </td>
                </tr>
            </table>     
        </div>
    </form>
    <%--列表 end--%>
    <%--添加 修改 start--%>
    <div id="edit" class="easyui-dialog" title="修改菜单表" style="width: 350px; height: 300px;"
        modal="true" closed="true" buttons="#edit-buttons">
        <form id="form_edit" name="form_edit" method="post" url="Functions.aspx">
        <table class="table_edit" id="table">
            <tr>
                <td class="tdal">菜单页面名</td>
                <td class="tdar">
                    <input id="ipt_functionname"  name="ipt_functionname" type="text" class="easyui-validatebox" required="true" />
                </td>
            </tr>
            <tr>
                <td class="tdal">rul地址</td>
                <td class="tdar">
                    <input id="ipt_url" name="ipt_url" type="text" class="easyui-validatebox" required="true" />
                </td>
            </tr>
            <tr>
                <td class="tdal">父级页面</td>
                <td class="tdar">                  
                   <input id="ipt_fathername" class="easyui-combotree"  name="ipt_father" style="width:150px;"/>                  
                </td>
            </tr>
            <tr>
                <td class="tdal">排序</td>
                <td class="tdar">
                    <input id="ipt_funorder" name="ipt_funorder" type="text"  class="easyui-numberbox" data-options="min:1" placeholder="只能输入数字" />     
                </td>
            </tr>
            <tr>
                <td class="tdal">类型</td>
                <td class="tdar">
                    <%--<input id="ipt_funtype" name="ipt_funtype" type="text" class="easyui-validatebox" required="true" />--%>
                    <select id="ipt_funtype" class="easyui-combobox" name="ipt_funtype" editable="false" required="true" style="width:150px";>
                        <option value="0">不显示类型</option>
                        <option value="1">显示类型</option>
                        <option value="2">显示</option>
                        <option value="3">隐藏</option>
                        </select>
                </td>
            </tr>
            <tr>
                <td class="tdal">小菜单图片</td>
                <td class="tdar">
                    <input name="ipt_img1" id="ipt_img1" type="text" class="easyui-validatebox"  />
                </td>
            </tr>
            <tr>
                <td class="tdal">大菜单图片</td>
                <td class="tdar">
                    <input name="ipt_img2" id="ipt_img2" type="text" class="easyui-validatebox"  />
                </td>
            </tr>
            <tr>
                <td class="tdal">说明</td>
                <td class="tdar">
                    <input name="ipt_intro" id="ipt_intro" type="text" class="easyui-validatebox"  />
                </td>
            </tr>
            <tr>
                <td class="tdal">备注</td>
                <td class="tdar">
                    <input name="ipt_remark" id="ipt_remark" type="text" class="easyui-validatebox"  />
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
    <%--添加 修改 end--%>
    <script type="text/javascript">
        
        $(function () {
            InitGird();
            InitSearch();
        });
        //初始化表格
        function InitGird() {
            $('#tab_list').datagrid({
                title: '菜单列表', //表格标题
                url: location.href, //请求数据的页面
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
                frozenColumns: [[//冻结的列，不会随横向滚动轴移动
	                { field: 'cbx', checkbox: true },
                   
	                { title: '菜单页面名', field: 'JSON_functionname', width: 100, align: 'center' },
                    { title: '页面地址', field: 'JSON_url', width: 150, align: 'center' }
                ]],
                columns: [[
                    //{ title: '父级id', field: "father",formatter:function(value,rec,index){return value==0?'管理员':'普通用户'},width: 80 },
                    { title: '级数', field: 'JSON_funlevel', width: 100, align: 'center' },
                    { title: '排序', field: 'JSON_funorder', width: 100, align: 'center' },
                    {
                        title: '类型', field: 'JSON_funtype', width: 100, align: 'center', formatter: function (value, rec, index) {
                            if (value == 0) {
                                return "不显示类型"
                            }
                            else if (value == 1) {
                                return "显示类型"
                            }
                            else if (value == 2) {
                                return "显示"
                            }
                            else {
                                return "隐藏"
                            }
                            //return value == 0 || value == 1 ? '普通业务' : '系统管理级'
                        },
                    },
                    { title: '小菜单图片', field: 'JSON_img1', width: 100, align: 'center' },
                    { title: '大菜单图片', field: 'JSON_img2', width: 100, align: 'center' },
                    { title: '说明', field: 'JSON_intro', width: 130, align: 'center' },
                    { title: '备注', field: 'JSON_remark', width: 130, align: 'center' },
                    {
                        title: '操作', field: "JSON_id", formatter: function (value,rec) {
                            return '<a style="color:red" href="javascript:;" onclick="EditData(\'' + value + '\');$(this).parent().click();return false;">修改</a>';
                        }
                        ,width: 100
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
                width: 200,
                iconCls: 'icon-save',
                searcher: function (val, name) {
                    $('#tab_list').datagrid('options').queryParams.search_type = name;
                    $('#tab_list').datagrid('options').queryParams.search_value = val;
                    $('#tab_list').datagrid('reload');
                },
                prompt: '请输入要查询的页面名'
            });
        }

        //打开添加窗口
        function OpenWin() {
            powertree();
            $('#edit').dialog('setTitle', '添加菜单表');
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


            var json = GetInputData('edit', 'submit');

            json.id = uid;
            $.post(location.href, json, function (data) {
                $.messager.alert('提示', data, 'info', function () {
                    if (data.indexOf("成功") > 0) {
                        //console.info(data);
                        $("#tab_list").datagrid("reload");
                        $("#edit").dialog("close");
                    }

                });
            });

        }

        //修改链接 事件
        function EditData(uid) {
            //$.ajaxSettings.async = false;// 设置为同步
            $('#edit').dialog('setTitle', '修改菜单表');
            $("#edit").dialog("open");
            powertree();
            $("#btn_add").attr("onclick", "Add(\'" + uid + "\'); return false;")

            //$.post(location.href, { "action": "queryone", "id": uid }, function (data) {//请求成功时执行的回调函数
            //    var dataObj = eval("(" + data + ")"); //转换为json对象    
            //    console.info(dataObj);
            //    $("#form_edit").form('load', dataObj);
            //});
            //console.log('haha');

            $.ajax({
                url: location.href,
                type: "post",
                async: false,
                data: {
                    "action": "queryone",
                    "id": uid
                },
                success: function (data) {
                    var dataObj = eval("(" + data + ")"); //转换为json对象
                    if (dataObj.ipt_father == '0') {
                        dataObj.ipt_father = '';
                    }
                    //console.info(dataObj);
                    $("#form_edit").form('load', dataObj);
                }
            })
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
        //添加按钮事件
        function ADD() {
            $.post(location.href, { "action": "ADD" }, function (data) {//请求成功时执行的回调函数
                var dataObj = eval("(" + data + ")"); //转换为json对象    
                //console.info(dataObj);
                $('#ipt_fathername').combobox({
                    valueField: "ipt_id",
                    textField: "ipt_functionname",
                }).combobox("loadData", dataObj);
            });
        }

        //验证排序输入框的只能是数字
        function checkNumber(value) {
            var value = document.getElementById("ipt_funorder").value;
            reg = /^\d+$/; // 注意：故意限制了 0321 这种格式，如不需要，直接reg=/^\d+$/;
            if (reg.test(value) == true) {
                //alert("都是数字！通过");
                return true;
            } else {
                alert("请输入数字");
                //$("#ipt_funorder").attr("placeholder", "请输入数字");
                return false;
            }
        }

        //获取权限树
        function powertree(uid) {
            
            $.ajax({
                url: location.href,
                type: 'post',
                async: false,
                data: {
                    "action": "querypower",
                    "id": uid,
                },
                success: function (data) {
                    //console.log('haha11');
                    //console.info(data);
                    var treedata = transData(data, 'JSON_id', 'JSON_father');

                    //console.info(treedata);

                    $('#ipt_fathername').combotree({
                        checkbox: true,
                        data: treedata,
                        multiple: true,//当为true时，为多选，false为单选
                        lines: true,
                        //checkbox: true,
                        
                        cascadeCheck: false,
                        //editable: true,
                        //disabled:true
                        //onlyLeafCheck: true,//当为多选时，起作用，只允许选择叶子节点
                        //onSelect: function (node) {//当为单选时，只允许选择叶子节点的设置
                        //    //返回树对象  
                        //    var tree = $(this).tree;
                        //    //选中的节点是否为叶子节点,如果不是叶子节点,清除选中  
                        //    var isLeaf = tree('isLeaf', node.target);
                        //    if (!isLeaf) {
                        //        //清除选中  
                        //        $('#comboDepartment').combotree('clear');
                        //    }
                        //}
                        onBeforeSelect:function(node){  
                            //单用户单击一个节点的时候，触发  
                            $("#ipt_fathername").combotree('clear');
                        },

                        //实现下拉面板清除组件中的值
                        onShowPanel: function () {
                            $('#ipt_fathername').combotree('clear');
                        }

                    });
                },
                error: function (errorMsg) {

                },

                dataType: "json"
            });
            //console.log('haha2');
        }

        function transData(a, idStr, pidStr) {
            var r = [], hash = {}, pid = pidStr, i = 0, j = 0, k = 0, len = a['total'], id = idStr;
            var temp = a['rows'], count = 0;
            var father;
            //先插入有父节点的项
            for (i = 0; i < len; i++) {
                if (temp[i][pidStr] != "0") {
                    if (temp[i]['JSON_id1']){
                        hash[count] = { text: temp[i]['JSON_functionname'], state: 'opened', id: temp[i][idStr], order: i, father: temp[i][pid], checked: true };
                    }
                    else{
                        hash[count] = { text: temp[i]['JSON_functionname'], state: 'opened', id: temp[i][idStr], order: i, father: temp[i][pid], checked: false };
                    }
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
            console.log(r);
        }
        //获取选中节点
        function getChecked() {
            var nodes = $('#ipt_fathername').combotree('getChecked');//获取:checked的结点
            //    console.info(nodes);
            var s = '';
            for (var i = 0; i < nodes.length; i++) {
                if (s != '') s += ',';
                s = s + nodes[i].id;
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

    </script>
    
        

        
</body>
</html>
