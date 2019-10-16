$(document).ready(function(){

    var loading = $("#loading");

    //访问记录
    const visitUrl = window.location.href;
    // try{
    //     var visitIp = returnCitySN["cip"];
    // }catch(error){
    //     // console.log("此浏览器无法获取ip");
    // }
    // if(visitIp){
    //     var ip = visitIp;
    //     console.log(ip);
    // }else{
    //     var ip = '';
    //     console.log(ip);
    // }
    $.ajax({
        type: "get",
        url: window.link+"/back/WebSer.asmx/AddVisitRecord?url="+visitUrl,
        success: function (data) {
            console.log(data);        
        }
    });

    //动态加载产品树
    $.ajax({
        type: "GET",
        url: window.link+"/back/WebSer.asmx/GetCategory",
        dataType: "json",
        success: function (data) {
            let result = JSON.parse(data); //json字符串转成js对象
            let json = result.rows;

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
            //序列化树结构
            var treeJson = initTreeJson(json,'JSON_id','JSON_father');
            //配置生成树
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
            var zTreeObj = $.fn.zTree.init($("#treeDemo"), setting, treeJson);         
            //zTreeObj.expandAll(true);
            //var treeObj = $.fn.zTree.getZTreeObj("treeDemo"); 
            
            //返回一个根节点 
            var node0 = zTreeObj.getNodesByFilter(function (node) { return node.level == 0 }, true);
            zTreeObj.expandNode(node0,true);

            var node1 = zTreeObj.getNodesByFilter(function (node) { 
                return node.level == 1; 
            });
            zTreeObj.expandNode(node1[0],true);
            zTreeObj.expandNode(node1[1],true);
    
            //树回调函数，点击树节点之后的操作 
            function getCategoryId(event,treeId,treeNode){
              $("#ul").html('');
              loading.css('display','block');
              $.ajax({
                  url:'/product/tree?id='+treeNode.JSON_id,
                  type:'get'
              }).done(function(data){
                  loading.css('display','none');
                  let a = data.rows;
                  //console.log(data.rows);
                  //渲染第一个页面
                  let html1 = ejs.render('<%rows.forEach(function(item,index){%><%if(index < rows.length && index < 12){%><div class="produce"><div class="produce_img"><a href="/productDetail/<%- item.JSON_pid %>" target="_blank"><img src="<%-window.link+item.JSON_img1 %>" alt=""></a></div><div class="produce_detail"><div class="produce_price"><div class="produce_price_detali"><span>￥</span><strong><%= item.JSON_price %></strong></div></div><div class="produce_title"><a href="/productDetail/<%- item.JSON_pid %>" target="_blank"><%= item.JSON_title %></a></div></div></div><%}%><%})%> ',{rows: a} );
                  $("#ul").html(html1);

                  let typeLength = data.rows.length;
                  $(".pager").pager({
                      pageIndex:0,
                      pageSize:12,
                      itemCount:typeLength,
                      maxButtonCount:4,
                      onPageChanged:function(pageIndex){
                          let page = pageIndex + 1;
                          //console.log(pageIndex);
                          if(typeLength > 12){
                              let b = a.slice(12*pageIndex,12*pageIndex+12);
                              let html2 = ejs.render('<%rows.forEach(function(item,index){%><%if(index < rows.length && index < 12){%><div class="produce"><div class="produce_img"><a href="/productDetail/<%- item.JSON_pid %>" target="_blank"><img src="<%-window.link+item.JSON_img1 %>" alt=""></a></div><div class="produce_detail"><div class="produce_price"><div class="produce_price_detali"><span>￥</span><strong><%= item.JSON_price %></strong></div></div><div class="produce_title"><a href="/productDetail/<%- item.JSON_pid %>" target="_blank"><%= item.JSON_title %></a></div></div></div><%}%><%})%>',{rows: b} );
                              $("#ul").html(html2);
                          }
                      }     
                  });                   
              })
            }
        }         
    });


    if(location.href.indexOf('?') != -1){
        const end = location.href.split('end=')[1];
        var num = (end-12)/12;
    }else{
        var num = 0;
    }

    $(".pager").pager({
        pageIndex:num,
        pageSize:12,
        itemCount:length,
        maxButtonCount:4,
        onPageChanged:function(pageIndex){
            let start = 12 * pageIndex + 1;
            let end = 12 * pageIndex + 12;
            console.log(pageIndex);
            location.href = "/product/page?start="+start+"&end="+end;
        }     
    });

    //根据产品名搜索产品
    $("#search").click(function(){
      $("#ul").html('');
      loading.css('display','block');
      let name = $("#searchName").val();
      // console.log(name);
      $.ajax({
        url:"/product/searchProduct?name="+name,
        type:"GET",
        success:function(data){
          loading.css('display','none');
          let a = data.rows;
          let html = ejs.render('<%rows.forEach(function(item,index){%><%if(index < rows.length && index < 12){%><div class="produce"><div class="produce_img"><a href="/productDetail/<%- item.JSON_pid %>" target="_blank"><img src="<%-window.link+item.JSON_img1 %>" alt=""></a></div><div class="produce_detail"><div class="produce_price"><div class="produce_price_detali"><span>￥</span><strong><%= item.JSON_price %></strong></div></div><div class="produce_title"><a href="/productDetail/<%- item.JSON_pid %>" target="_blank"><%= item.JSON_title %></a></div></div></div><%}%><%})%> ',{rows: a} );
          $("#ul").html(html);
          let typeLength = data.rows.length;
          $(".pager").pager({
            pageIndex:0,
            pageSize:12,
            itemCount:typeLength,
            maxButtonCount:4,
            onPageChanged:function(pageIndex){
              let page = pageIndex + 1;
              //console.log(pageIndex);
              if(typeLength > 12){
                let b = a.slice(12*pageIndex,12*pageIndex+12);
                let html2 = ejs.render('<%rows.forEach(function(item,index){%><%if(index < rows.length && index < 12){%><div class="produce"><div class="produce_img"><a href="/productDetail/<%- item.JSON_pid %>" target="_blank"><img src="<%-window.link+item.JSON_img1 %>" alt=""></a></div><div class="produce_detail"><div class="produce_price"><div class="produce_price_detali"><span>￥</span><strong><%= item.JSON_price %></strong></div></div><div class="produce_title"><a href="/productDetail/<%- item.JSON_pid %>" target="_blank"><%= item.JSON_title %></a></div></div></div><%}%><%})%>',{rows: b} );
                $("#ul").html(html2);
              }
            }     
          });
        }
      })
    })
})