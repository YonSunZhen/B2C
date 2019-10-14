<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="GoosleB2C.Web.Admin.Product.Category2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="/JS/easyUI/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="/JS/easyUI/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="/JS/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <link href="/JS/easyUI/themes/gray/easyui.css" rel="stylesheet" type="text/css" /> 
    <link href="/JS/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="/JS/wikmenu.js" type="text/javascript"></script>
    <script src="/JS/wikmain.js" type="text/javascript"></script>
    <link href="/css/default1.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript">
		$(function(){
			$('#tt2').tree({
				checkbox: true,
				url: 'Category.asmx/GetTreeData',
				onClick:function(node){
					$(this).tree('toggle', node.target);
					//alert('you click '+node.text);
				},
				onContextMenu: function(e, node){
					e.preventDefault();
					$('#tt2').tree('select', node.target);
					$('#mm').menu('show', {
						left: e.pageX,
						top: e.pageY
					});
				}
			});
		});
		function reload(){
			var node = $('#tt2').tree('getSelected');
			if (node){
				$('#tt2').tree('reload', node.target);
			} else {
				$('#tt2').tree('reload');
			}
		}
		function getChildren(){
			var node = $('#tt2').tree('getSelected');
			if (node){
				var children = $('#tt2').tree('getChildren', node.target);
			} else {
				var children = $('#tt2').tree('getChildren');
			}
			var s = '';
			for(var i=0; i<children.length; i++){
				s += children[i].text + ',';
			}
			alert(s);
		}
		function getChecked(){
			var nodes = $('#tt2').tree('getChecked');
			var s = '';
			for(var i=0; i<nodes.length; i++){
				if (s != '') s += ',';
				s += nodes[i].text;
			}
			alert(s);
		}
		function getSelected(){
			var node = $('#tt2').tree('getSelected');
			alert(node.text);
		}
		function collapse(){
			var node = $('#tt2').tree('getSelected');
			$('#tt2').tree('collapse',node.target);
		}
		function expand(){
			var node = $('#tt2').tree('getSelected');
			$('#tt2').tree('expand',node.target);
		}
		function collapseAll(){
			var node = $('#tt2').tree('getSelected');
			if (node){
				$('#tt2').tree('collapseAll', node.target);
			} else {
				$('#tt2').tree('collapseAll');
			}
		}
		function expandAll(){
			var node = $('#tt2').tree('getSelected');
			if (node){
				$('#tt2').tree('expandAll', node.target);
			} else {
				$('#tt2').tree('expandAll');
			}
		}
		function append(){
			var node = $('#tt2').tree('getSelected');
			$('#tt2').tree('append',{
				parent: (node?node.target:null),
				data:[{
					text:'new1',
					checked:true
				},{
					text:'new2',
					state:'closed',
					children:[{
						text:'subnew1'
					},{
						text:'subnew2'
					}]
				}]
			});
		}
		function remove(){
			var node = $('#tt2').tree('getSelected');
			$('#tt2').tree('remove', node.target);
		}
		function update(){
			var node = $('#tt2').tree('getSelected');
			if (node){
				node.text = '<span style="font-weight:bold">new text</span>';
				node.iconCls = 'icon-save';
				$('#tt2').tree('update', node);
			}
		}
		function isLeaf(){
			var node = $('#tt2').tree('getSelected');
			var b = $('#tt2').tree('isLeaf', node.target);
			alert(b)
		}
	</script>
</head>
<body>
    <form id="form2" runat="server">
    <h2>Tree</h2>
	<div class="demo-info" style="margin-bottom:10px">
		<div class="demo-tip icon-tip"></div>
		<div>Click the node and drag it to other position.</div>
	</div>
	
	<p>Create from HTML markup</p>
	<ul id="tt2" class="easyui-tree" animate="true" dnd="true">
		<li>
			<span>Folder</span>
			<ul>
				<li state="closed">
					<span>Sub Folder 1</span>
					<ul>
						<li>
							<span><a href="#">File 11</a></span>
						</li>
						<li>
							<span>File 12</span>
						</li>
						<li>
							<span>File 13</span>
						</li>
					</ul>
				</li>
				<li>
					<span>File 2</span>
				</li>
				<li>
					<span>File 3</span>
				</li>
				<li>File 4</li>
				<li>File 5</li>
			</ul>
		</li>
		<li>
			<span>File21</span>
		</li>
	</ul>
	<hr></hr>
	<p>Create from JSON data</p>
	<div style="margin:10px;">
		<a href="#" onclick="reload()">reload</a>
		<a href="#" onclick="getChildren()">getChildren</a>
		<a href="#" onclick="getChecked()">getChecked</a>
		<a href="#" onclick="getSelected()">getSelected</a>
		<a href="#" onclick="collapse()">collapse</a>
		<a href="#" onclick="expand()">expand</a>
		<a href="#" onclick="collapseAll()">collapseAll</a>
		<a href="#" onclick="expandAll()">expandAll</a>
		<a href="#" onclick="append()">append</a>
		<a href="#" onclick="remove()">remove</a>
		<a href="#" onclick="update()">update</a>
		<a href="#" onclick="isLeaf()">isLeaf</a>
	</div>


	
	<div id="mm" class="easyui-menu" style="width:120px;">
		<div onclick="append()" iconCls="icon-add">Append</div>
		<div onclick="remove()" iconCls="icon-remove">Remove</div>
		<div class="menu-sep"></div>
		<div onclick="expand()">Expand</div>
		<div onclick="collapse()">Collapse</div>
	</div>
    </form>
</body>
</html>
