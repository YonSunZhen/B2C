<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="GoosleB2C.Web.Admin.Product.Category" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="/JS/easyUI/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="/JS/easyUI/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="/JS/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <link href="/JS/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="/JS/easyUI/themes/gray/easyui.css" rel="stylesheet" type="text/css" /> 
    <script src="/JS/wikmenu.js" type="text/javascript"></script>
    <script src="/JS/wikmain.js" type="text/javascript"></script>
    <style>
         .submit{
            width:100px;
            height:50px;
            color:white;
            font-size:15px;
            background:lightblue;
            border:none;
        }
         #up{
             padding:15px;
             background:url('../../Images/上移.png') no-repeat center;
         }
         #down{
              padding:15px;
              background:url('../../Images/下移.png') no-repeat center;
         }
    </style>
</head>
<body>

    <form id="form2" runat="server" method="post">
	<h2>Tree</h2>
	<ul id="tt2" class="easyui-tree" animate="true" dnd="true">
        
	</ul>
	<hr></hr>
    <button type="button" class="submit" onclick="save()">保存</button>
    <div id="edit" class="easyui-dialog" title="编辑产品类" style="width: 350px; height: 300px;"
        modal="true" closed="true" buttons="#edit-buttons">
          <form id="form_edit" name="form_edit" method="post" url="Category.aspx">
        <table class="table_edit">
            <tr>
                <td class="tdal">
                    产品类名：
                </td>
                <td class="tdar">
                    <input id="ipt_categoryname"  name="text" type="text" class="easyui-validatebox"
                        required="true" />
                </td>
            </tr>
             <tr>
                <td class="tdal">
                    seoTitle：
                </td>
                <td class="tdar">
                    <input id="ipt_seotitle" name="seotitle" type="text" class="easyui-validatebox"/>
                </td>
            </tr>
             <tr>
                <td class="tdal">
                    seoKey：
                </td>
                <td class="tdar">
                    <input id="ipt_seokey" name="seokey" type="text" class="easyui-validatebox" />
                </td>
            </tr>
             <tr>
                <td class="tdal">
                    seoRemark：
                </td>
                <td class="tdar">
                    <input id="ipt_seoremark" name="seoremark" type="text" class="easyui-validatebox"  />
                </td>
            </tr>
        </table>
        </form>
    </div>
    <div id="edit-buttons">
        <a id="btn_add" href="javascript:;" class="easyui-linkbutton" onclick="Add();return false">提交</a> 
        <a href="javascript:;" class="easyui-linkbutton" onclick="$('#edit').dialog('close');return false;">取消</a>
    </div>     
           	
    </form>

<script>
    var MaxID = 0;              //用于path字段
    var InitMaxID;
    var newNode;
    var TotalData = { append: [], child:[], remove:[]};
    //初始化
    $(function () {
        function transDate(list, idstr, pidstr) {
            var result = [];
            var temp = {};
            for (let i = 0; i < list.length; i++) {
                //var obj = { "level": list[i].level, "path": list[i].path, "father": list[i].father, "order": list[i].order, "ipt_seotitle": list[i].seotitle, "ipt_seokey": list[i].seokey, "ipt_seoremark": list[i].seoremark, "ipt_categoryname": list[i].text };
                //list[i].attributes = obj;
                temp[list[i][idstr]] = list[i];//将nodes数组转成对象类型                
            }
            for (let j = 0; j < list.length; j++) {
                tempVp = temp[list[j][pidstr]]; //获取每一个子对象的父对象
                if (tempVp) {                   //判断父对象是否存在，如果不存在直接将对象放到第一层
                    if (!tempVp["children"]) tempVp["children"] = [];//如果父元素的nodes对象不存在，则创建数组
                    tempVp["children"].push(list[j]);//将本对象压入父对象的nodes数组
                } else {
                    result.push(list[j]);       //将不存在父对象的对象直接放入一级目录
                }
            }
            return result;
        }
        $.ajax({
            type: "post",
            async: false, //同步执行
            url: location.href,
            data: {
                "action": "query",
            },
            dataType: "json", //返回数据形式为json
            success: function (data) {
                if (data) {
                    var tdata = JSON.parse(JSON.stringify(data).replace(/JSON_/g, "").replace(/categoryname/g, "text"));
                    //tdata = JSON.parse(JSON.stringify(tdata).replace(/categoryname/g, "text"));
                    var tree = transDate(tdata.rows, "id", "father");
                    console.log(tree);
                    MaxID = parseInt(tdata.MaxID);
                    InitMaxID = MaxID;
                    $('#tt2').tree({
                        data: tree,
                        onlyLeafCheck: true,
                        onDrop: function (target, source) {
                            var nodes = $('#tt2').tree('getChildren');
                            var t = $(target).find('.tree-title').text();
                            var targetNode;
                            for(let i of nodes) {
                                if (i.text == t) {
                                    targetNode = i;
                                }
                            }
                            DragChange(source, targetNode);
                        }                                   
                    });
                }
            },
            error: function (errorMsg) {
                alert("不好意思，请求数据失败啦!");
            }
        });
        $('#tt2 .tree-node').append('<a href="#" iconCls="icon-pencil" onclick="OpenEditWin(this)">编辑</a> <a href="#" iconCls="icon-add" onclick="append(this)">添加</a> <a href="#" iconCls="icon-remove" onclick="remove(this)">删除</a> <i id="up" onclick="Up(this)"></i> <i id="down" onclick="Down(this)"></i>');
        $('#tt2 .tree-node').first().find('a,i').remove();
        $('#tt2 .tree-node').first().append('<a href="#" iconCls="icon-pencil" onclick="append(this)">添加</a>');
    });
    //编辑窗口
    function OpenEditWin(e) {                       //编辑
        $('#tt2').tree('select', e.parentNode);
        var select = $('#tt2').tree('getSelected');
        $("#btn_add").attr('onclick', 'Add()');
        $("#edit").dialog("open");
        $('.table_edit input').each(function () {
            var name = this.name;
            $(this).attr('value', select[name]);
        });
        console.log($('#tt2').tree('getData', e.parentNode));
    }

    //获取用户编辑信息
    function GetInputData() {
        var node = $('#tt2').tree('getSelected');
        console.log(node);
        if (node) {
            node.text = $('#ipt_categoryname').val();
            node.seotitle = $('#ipt_seotitle').val();
            node.seokey = $('#ipt_seokey').val();
            node.seoremark = $('#ipt_seoremark').val();
        }
    }

    //获取用户添加编辑信息
    function GetAddInputData() {
        var node = TotalData.append[0];
        if (node) {
            node.text = $('#ipt_categoryname').val();
            node.seotitle = $('#ipt_seotitle').val();
            node.seokey = $('#ipt_seokey').val();
            node.seoremark = $('#ipt_seoremark').val();
        }
    }

    //提交按钮事件
    function Add() {
        GetInputData();
        var node = $('#tt2').tree('getSelected');
        TotalData.child.push(node);
        var json = TotalData;
        $.ajax({
            type: "post",
            async: false, //同步执行
            url: location.href,
            data: {
                "action": "edit",
                "json": JSON.stringify(json)
            },
            success: function (data) {
                alert('修改编辑成功');
                location.reload();
            }
        });
        //$("#edit").dialog("close");
    }

    //提交按钮事件
    function Add2() {
        TotalData.append.push(newNode);
        GetAddInputData();
        var json = TotalData;
        $.ajax({
            type: "post",
            async: false, //同步执行
            url: location.href,
            data: {
                "action": "add",
                "json": JSON.stringify(json)
            },
            success: function (data) {
                location.reload();
            }
        });
        //$("#edit").dialog("close");
    }

    //添加事件
    function append(e) {
        $('#tt2').tree('select', e.parentNode);
        var node = $('#tt2').tree('getSelected');
        newNode = {
            id: String(MaxID),
            text: 'new1',
            father: node.id,
            level: parseInt(node.level) + 1,
            path: node.path + '-' + String(MaxID),
            order: (node.children ? node.children.length + 1 : '1'),
            seotitle: '',
            seokey: '',
            seoremark: ''
        }
        $("#edit").dialog("open");
        $('.table_edit input').each(function () {
            var name = this.name;
            $(this).attr('value', '');
        });
        $("#btn_add").attr('onclick', 'Add2()');
    }

    //删除事件
    function remove(e) {
        $('#tt2').tree('select', e.parentNode);
        $.messager.confirm('提示', '确认删除？', function (r) {
            if (r) {
                var node = $('#tt2').tree('getSelected');
                if (node) {
                    var data = $('#tt2').tree('getChildren', node.target);
                } else {
                    var data = $('#tt2').tree('getChildren');
                }
                for (var i in data) {
                    TotalData.remove.push(data[i]);
                }
                TotalData.remove.push(node);
                var json = TotalData;
                $.ajax({
                    type: "post",
                    async: false, //同步执行
                    url: location.href,
                    data: {
                        "action": "del",
                        "json": JSON.stringify(json)
                    },
                    success: function (data) {
                        location.reload();
                    }
                });
            }
        });
    }

    //上移按钮事件
    function Up(e) {
        $('#tt2').tree('select', e.parentNode);
        var select = $('#tt2').tree('getSelected');
        var order = parseInt(select.order);
        if (order != 1) {
            order--;
            select.order = String(order);
            var pre = $(e.parentNode.parentNode).prev().children()[0];
            var preSelect = $('#tt2').tree('getNode', pre);
            var preOrder = parseInt(preSelect.order);
            preOrder++;
            preSelect.order = String(preOrder);

            $(pre.parentNode).before($(e.parentNode.parentNode));
        }
    }

    //下移按钮事件
    function Down(e) {
        var children = $(e.parentNode.parentNode.parentNode).children();
        $('#tt2').tree('select', e.parentNode);
        var select = $('#tt2').tree('getSelected');
        var order = parseInt(select.order);
        if (order != children.length) {
            order++;
            select.order = String(order);
            var next = $(e.parentNode.parentNode).next().children()[0];
            var nextSelect = $('#tt2').tree('getNode', next);
            var nextOrder = parseInt(nextSelect.order);
            nextOrder--;
            nextSelect.order = String(nextOrder);

            $(next.parentNode).after($(e.parentNode.parentNode));
        }
    }

    //拖拽修改事件
    function DragChange(node, f) {
        console.log(f);
        //拖拽的子节点
        var data = $('#tt2').tree('getChildren', node.target);
        //判断是否拖入节点内
        var check = true;
        var a = $(f.target.parentNode).siblings().children('div').children('span.tree-title');
        a.each(function () {
            if ($(this).text() == node.text) {
                check = false;
            }
        });
        // 拖入节点上/下方
        if (!check) {
            var f_target = $(f.target.parentNode.parentNode).siblings()[0];
            var f = $('#tt2').tree('getNode', f_target);
            var newOrder = parseInt($(node.target.parentNode).index()) + 1;
            node.father = f.id;
            node.level = String((parseInt(f.level) + 1));
            node.path = f.path + '-' + node.id;
            node.order = String(newOrder);
            GetAttrData(data, node, f);
            reload();
            return false;
        }

        console.log(1);

        //拖入节点内
        node.father = f.id;
        node.level = String((parseInt(f.level) + 1));
        node.path = f.path + '-' + node.id;
        if (f.children) {
            node.order = String(f.children.length);            
        }else {
            node.order = '1';            
        }
        GetAttrData(data, node, f);
        reload();
    }
    function iterTree(data, node, f) {
        for (var key in data) {
            if (key == 'path') {
                var fstr = data[key].substr(0, data[key].indexOf(node.id) - 1);          //更改父目录
                data[key] = data[key].replace(fstr, f.path);
                data.level = data[key].split('-').length;                       //根据path中数字取level
            }
            if (key && typeof key == 'children') {
                iterTree(data[key], node, f);
            } else {
                //console.log
            }
        }
    }
    function GetAttrData(data, node, f) {
        for (let i of data) {
            iterTree(i, node, f);
        }
        //清除data多余属性
        /*for(let j of data) {
            for (var k in j) {
                if (k != 'level' && k != 'path' && k != 'father' && k != 'id') {
                    delete j[k];
                }
            }
        }*/
    }

    //重新加载
    function reload() {
        var roots = $('#tt2').tree('getRoots');
        $('#tt2').tree('loadData', roots);
        $('#tt2 .tree-node').append('<a href="#" iconCls="icon-pencil" onclick="OpenEditWin(this)">编辑</a> <a href="#" iconCls="icon-add" onclick="append(this)">添加</a> <a href="#" iconCls="icon-remove" onclick="remove(this)">删除</a> <i id="up" onclick="Up(this)"></i> <i  id="down" onclick="Down(this)"></i>');
        $('#tt2 .tree-node').first().find('a, i').remove();
        $('#tt2 .tree-node').first().append('<a href="#" iconCls="icon-pencil" onclick="append(this)">添加</a>');
    }

    //保存
    function save() {
        TotalData.child = $('#tt2').tree('getChildren', $('#tt2')[0]);
        var json = TotalData;
        console.log(json);
        $.ajax({
            type: "post",
            async: false, //同步执行
            url: location.href,
            data: {
                "action": "submit",
                "json": JSON.stringify(json)
            },
            success: function(data){
                alert('保存成功');
                location.reload();
            }
        });
    }

</script>
</body>
</html>
