$(document).ready(function(){
    //动态加载产品树
    $.ajax({
        type: "GET",
        url: "http://localhost:12238/back/WebSer.asmx/GetCategory",
        dataType: "json",
        success: function (data) {
            let result = JSON.parse(data); //json字符串转成js对象
            let json = result.rows;
            console.log(json);

            function initTreeJson(treeJson, idKey, pidKey, childKey) {
                var idKey = idKey || 'id';
                var pidKey = pidKey || 'pid';
                var childKey = childKey || 'children';
                var ret = []
                var initChild = function(n) {
                    for(var i = 0; i < treeJson.length; i++) {
                        var cur = treeJson[i];//cur是一个对象
                        if(n[idKey] === cur[pidKey]) {
                            (n[childKey] || (n[childKey] = [])).push(cur);
                            initChild(cur);
                        }
                    }
                }
                for(var i = 0; i < treeJson.length; i++) {
                    var cur = treeJson[i]
                    // 这里的意思是normalizedId返回的为0或者null
                    // 说明这一级是最外层id 把最外层push进ret，
                    // 然后对最外层节点cur进行递归
                    if(!normalizedId(cur[pidKey])) {
                        ret.push(cur);
                        initChild(cur);
                    }
                }
                return ret;
            }

            // 将id格式化，找出最外层id
            function normalizedId(id) {
                var idInt = Number(id);
                    // id是非数字类型 直接return
                if(isNaN(idInt)) {
                    return id;
                } else {
                    return idInt;
                }
            }
            var setting = {
                data:{
                    key:{
                        children:"children",
                        name:"JSON_categoryname"
                    }
                },
                callback:{
                    onClick:getCategoryId
                }
                };
            var treeJson = initTreeJson(json,'JSON_id','JSON_father');
            var zTreeObj = $.fn.zTree.init($("#treeDemo"), setting, treeJson);
            //zTreeObj.expandAll(true);
            //var treeObj = $.fn.zTree.getZTreeObj("treeDemo"); 
            //返回一个根节点 
            var node = zTreeObj.getNodesByFilter(function (node) { return node.level == 0 }, true);
            zTreeObj.expandNode(node,true); 
            function getCategoryId(event,treeId,treeNode){
                console.log(treeNode.JSON_id);
            }
            //console.log(treeJson);
        }         
    });
})