<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="GoosleB2C.Web.Admin.Sys.Message" %>

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
        #left_list {            
            width:925px;
            height: 300px;
            margin-right: 5px;            
            overflow: auto;
            padding-left: 5px;
            margin-left:8px;           
        }
        #right_list {           
            width:925px;
            height: 300px;            
            overflow: auto;
            padding-left: 5px;           
            margin-left:8px;
            margin-right:5px;            
        }
        textarea {            
            resize: none;
            outline: none;
            border: 0.5px;
            border-style: solid;
            border-color: #528ecc;
            margin-top:28px;           
            margin-left:13px;
        }
        textarea:hover{
            box-shadow:0px 0px 10px #137fef;
        }
        textarea:focus{
            box-shadow:0px 0px 10px #137fef;
        }
        .vid{
            color:cornflowerblue;
        }
        .time{
            color:lightgray;
        }
        .msg{
           margin-left:10px; 
        }
        .to{
            color:cornflowerblue;
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
                        <a href="#" onclick="DelData(0);return false;" id="a_del" class="easyui-linkbutton" iconcls="icon-cancel">删除</a>                   
                    </td>            
                </tr>
                <tr>              
                    <td style="text-align: right; padding-right: 15px">
                        <input id="ipt_search" menu="#search_menu" />
                        <div id="search_menu" style="width: 120px">
                            <div name="weixin">
                                微信号
                            </div>
                            <div name="name">
                                昵称
                            </div>                            
                        </div>
                    </td>           
                </tr>
            </table>    
        </div>
    </form>

    <%--回复框--%>
    <div id="edit" class="easyui-dialog" title="" style="width: 971px; height: 450px;"
        modal="true" closed="true" closable="false" resizable="true" buttons="#edit-buttons">
          <form id="form_edit" name="form_edit" method="post" url="Message.aspx">                                                
              <div class="" style="margin-left:13px;font-weight:900;margin-top:20px;">留言:</div>
              <div id="left_list">
                  <%--<div class="">留言：</div>--%>
              </div>
              <div class="" style="margin-left:13px;font-weight:900;margin-top:20px;">回复:</div>
              <div id="right_list">
                  <%--<div class="">回复：</div>--%>
              </div>                            
              
              <div class="" style="margin-left:13px;font-weight:900;margin-top:20px;">回复信息是否显示:</div>
              <div style="margin-left:13px;">
                  <select id="ipt_isshow" class="easyui-combobox" name="ipt_isshow" panelmaxheight="200px" panelheight="auto" editable="false" style="width: 175px;">
                      
                      <option value='1'>显示</option>
                      <option value='0'>不显示</option>
                      
                  </select>
              </div>
              <textarea id="ipt_content" name="ipt_content" rows="7" cols="121" placeholder="请输入回复信息"></textarea>                                      
              
                                                                                                 
          </form>
    </div>
    <div id="edit-buttons">
        <a id="btn_add" href="javascript:;" class="easyui-linkbutton">回复</a>
        <%--<a id="btn_re" href="javascript:;" class="easyui-linkbutton">取消</a>--%> 
        <a id="btn_re" href="javascript:;" class="easyui-linkbutton"
            onclick="re();return false;">取消</a>
    </div>

    <script type="text/javascript">
        $(function () {
            InitGird();
            InitSearch();           
        });
        //初始化表格
        function InitGird() {
            $('#tab_list').datagrid({
                title: '留言列表', //表格标题
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
                //fitColumns: true,
                frozenColumns: [[//冻结的列，不会随横向滚动轴移动
	                { field: 'cbx', checkbox: true },
	                { title: '微信ID', field: 'JSON_vid', width: 150, sortable: false },
                ]],
                columns: [[
                    { title: '微信号', field: 'JSON_weixin', width: 150 },
                    { title: '昵称', field: 'JSON_name', width: 150 },
                    { title: '对谁回复', field: 'JSON_to', width: 150 },
                    { title: '留言/回复内容', field: 'JSON_content', width: 150, formatter: sulContent },
                    { title: '留言/回复时间', field: 'JSON_createtime', width: 150 },
                    { title: 'IP地址', field: 'JSON_ip', width: 150 },
                    //{
                    //    title: '操作', field: 'JSON_id', width: 80, formatter: function (value, rec) {
                    //        return '<a style="color:red" href="javascript:;" onclick="EditData(\'' + value + '\');$(this).parent().click();return false;">查看</a>';
                    //    }
                    //}
                    {
                        title: '操作', field: 'JSON_id', width: 80, formatter: function (value, row, index) {                          
                            if (row.JSON_vid != "" && row.JSON_vid != "0") {
                                return '<a style="color:red" href="javascript:;" onclick="EditData(\'' + row.JSON_vid + ';' + row.JSON_id + ';' + row.JSON_isread + ';' + index + ';' + row.JSON_isanswer + '\');$(this).parent().click();return false;">查看(回复)</a>';
                            }
                            else {
                                return ;
                            }                           
                        }
                    }
                    //{
                    //    title: '操作', field: 'JSON_id', width: 80, formatter: re_Vid                        
                    //}
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
                    $('#tab_list').datagrid('options').queryParams.search_type = name;
                    $('#tab_list').datagrid('options').queryParams.search_value = val;
                    $('#tab_list').datagrid('reload');
                },
                prompt: '请输入要查询的信息'
            });
        }
        //留言提取前十五个字符
        function sulContent(value, row, index) {
            var res = "";
            switch (row.JSON_isread) {
                case "0":
                    res = '<font style="font-weight:1000;">' + value.substr(0, 15) + '</font>';
                    break;
                case "1":
                    res = '<font style="">' + value.substr(0, 15) + '</font>';
                    break;
            }
            return res;
            //return row.JSON_content.substr(0, 15);
        }
        //获得每行数据JSON_vid的值
        function re_Vid(value, row, index) {
            return '<a style="color:red" href="javascript:;" onclick="EditData(\'' + row.JSON_vid + '\');$(this).parent().click();return false;">查看</a>';
        }
        function EditData(vid_id) {           
            $(".other_Div").remove();
            $('#ipt_isshow').combobox('setValue', '1');
            $("#ipt_content").val("");                        

            var vid = vid_id.split(";")[0];
            var id = vid_id.split(";")[1];
            var isRead = vid_id.split(";")[2];
            var index = vid_id.split(";")[3];
            var isanswer = vid_id.split(";")[4];
            var rows = $('#tab_list').datagrid('getRows');
            var row = rows[index];
            //alert(row.JSON_content);          
            $.ajax({
                url: 'Message.aspx',
                type: 'post',
                async: false,
                data: { "action": "queryone", "vid": vid, "id": id, "isread": isRead },
                success: function (data) {
                    //alert("success!");
                    //alert(data);
                    var dataObjl = eval("(" + data + ")");                    
                    //alert(dataObjl["rows"].length);
                    $("#edit").dialog({ title: dataObjl["rows"][0]["JSON_vid"] + "的留言及回复" });
                    var dataLength = dataObjl["rows"].length;
                    for (var i = 0; i < dataLength; i++) {
                        if (!(dataObjl["rows"][i]["JSON_to"] != "")) {
                            var vid = dataObjl["rows"][i]["JSON_vid"];
                            var time = dataObjl["rows"][i]["JSON_createtime"];
                            var msg = dataObjl["rows"][i]["JSON_content"];
                            createMessage(vid, time, msg);
                        }
                        else if (dataObjl["rows"][i]["JSON_to"] != "") {
                            var vid = dataObjl["rows"][i]["JSON_vid"];
                            var to = dataObjl["rows"][i]["JSON_to"];
                            var time = dataObjl["rows"][i]["JSON_createtime"];
                            var msg = dataObjl["rows"][i]["JSON_content"];
                            createReply(vid, to, time, msg);
                        }
                    }                    
                    //$("#form_edit").form('load', dataObj1);
                }
            });
            
            $("#edit").dialog("open");
            
            $("#btn_add").attr("onclick", "Add(\'" + vid + ";" + id + ";" + isanswer + "\'); return false;");
            //$("#btn_re").attr("onclick", "re(\'" + id + "\'); return false;");
        }
        function Add(vid_id) {
            var content = encodeURI($("#ipt_content").val());
            var vid = vid_id.split(";")[0];
            var id = vid_id.split(";")[1];
            var isanswer = vid_id.split(";")[2];
            var isshow = $("#ipt_isshow").val();
            //alert(content);

            if (decodeURI(content) == "") {
                $.messager.alert('提示', '请输入回复的信息！', 'info');
                return;
            }
            $.ajax({
                url: 'Message.aspx',
                type: 'post',
                data: { "action": "submit", "vid": vid, "ipt_content": content, "id": id, "isanswer": isanswer, "isshow": isshow },
                async: false,
                success: function (data) {
                    $.messager.alert('提示', data, 'info', function () {
                        if (data.indexOf("成功") > 0) {
                            console.info(data);
                            $("#tab_list").datagrid("reload");                            
                            $("#edit").dialog("close");
                        }
                    });
                }
            });
        }
        function createMessage(vid, time, msg) {
            //msg = decodeURI(msg);
            var record = $('<div id="" class="other_Div"><span class="vid">' + vid + '</span>' + '&nbsp;' + '<span class="time">' + '(' + time + ')' + '</span><br/>' + '<div class="msg">' + msg + '</div>' + '</div>');
            $("#left_list").append(record);
        }
        function createReply(vid, to, time, msg) {
            //msg = decodeURI(msg);
            var record = $('<div id="" class="other_Div"><span class="vid">' + vid + '</span>' + '&nbsp;' + '回复' + '&nbsp;' + '<span class="to">' + to + '</span>' + '&nbsp;' + '<span class="time">' + '(' + time + ')' + '</span><br/>' + '<div class="msg">' + msg + '</div>' + '</div>');
            $("#right_list").append(record);
        }
        function re() {
            $(".other_Div").remove();
            $("#ipt_content").val("");
            $('#edit').dialog('close');
            //$('#tab_list').datagrid('reload'); return false;
            //$("#ipt_isshow option:first").prop("selected", 'selected');
                       
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
