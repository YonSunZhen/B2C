$(document).ready(function(){

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

    var imgCon = $("#showbox1");//正常图片容器
    var drag = $("#slider");//获得滑块
    var show = $("#showbox > #big > img");//获得大图片
    var big = $("#big");//获得大图片容器
    var img = $("#normal");//获得正常图片
    var imgList = $("#showsum > ul > li > img");//下方小图片
    var showbox = $("#showbox");
    var sub_mainright_ = $("#sub_mainright_");
    var imgName = $("#imgName");
    var price = $("#price");
    var photoContent = $("#photoContent");

    //富文本中img路径的转换
    let img1 = $("#bottombox img");
    // let link = "http://localhost:12238";
    for(let i = 0; i < img1.length; i++){
        console.log( img1[i].src);
        let a = img1[i].src.search(/UploadImg/);//获得相对路径中UpLoadImg的位置
        console.log(a);
        let str = img1[i].src.slice(a-1);//获得相对图片地址除去（前面的file://）
        console.log(window.link + str); 
        img1[i].src = window.link + str;
    }

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

            var node1 = zTreeObj.getNodesByFilter(function (node) { 
                return node.level == 1; 
            });
            zTreeObj.expandNode(node1[0],true);
            zTreeObj.expandNode(node1[1],true); 

            function getCategoryId(event,treeId,treeNode){
                console.log(treeNode.JSON_id);
                $.ajax({
                    url:'/product/tree?id='+treeNode.JSON_id,
                    type:'get'
                }).done(function(data){
                    let a = data.rows;
                    console.log(data.rows);
                    //渲染第一个页面
                    let html1 = ejs.render('<%rows.forEach(function(item,index){%><%if(index < rows.length && index < 9){%><div class="produce"><div class="produce_img"><a href="/productDetail/<%- item.JSON_pid %>" target="_blank"><img src="<%-window.link+item.JSON_img1 %>" alt=""></a></div><div class="produce_detail"><div class="produce_price"><div class="produce_price_detali"><span>￥</span><strong><%= item.JSON_price %></strong></div></div><div class="produce_title"><a href="/productDetail/<%- item.JSON_pid %>" target="_blank"><%= item.JSON_title %></a></div></div></div><%}%><%})%> ',{rows: a} );
                    $("#ul1").html(html1);
                    $("#ul2").html('<div class="clear"></div><div class="pager"></div>');

                    let typeLength = data.rows.length;
                    $(".pager").pager({
                        pageIndex:0,
                        pageSize:9,
                        itemCount:typeLength,
                        maxButtonCount:4,
                        onPageChanged:function(pageIndex){
                            // let start = 9 * pageIndex + 1;
                            // let end = 9 * pageIndex + 9;
                            let page = pageIndex + 1;
                            //console.log(pageIndex);
                            if(typeLength > 9){
                                let b = a.slice(9*pageIndex,9*pageIndex+9);
                                let html2 = ejs.render('<%rows.forEach(function(item,index){%><%if(index < rows.length && index < 9){%><div class="produce"><div class="produce_img"><a href="/productDetail/<%- item.JSON_pid %>" target="_blank"><img src="<%-window.link+item.JSON_img1 %>" alt=""></a></div><div class="produce_detail"><div class="produce_price"><div class="produce_price_detali"><span>￥</span><strong><%= item.JSON_price %></strong></div></div><div class="produce_title"><a href="/productDetail/<%- item.JSON_pid %>" target="_blank"><%= item.JSON_title %></a></div></div></div><%}%><%})%>',{rows: b} );
                                $("#ul1").html(html2);
                               
                            }
                            
                        }     
                    });                   
                })

                

                
                console.log(length);
                console.log(treeNode.JSON_id);
            }
            
        }         
    });

    //实现右侧点击小图片选项卡效果
    imgList.click(function(){
        var nowSrc = $(this).data('bigimg');
        img.attr('src',nowSrc);
        show.attr('src',nowSrc);
        $(this).parent().addClass('active').siblings().removeClass('active');
    })
    //jq为元素添加事件的写法
    imgCon.mousemove(function(e){
        drag.css('display','block');
        big.css('display','block');//jq修改样式的写法
        // drag.style.left = e.clientX + "px";
        // drag.style.top = e.clientY + "px";
        var ev = e || window.event;
        var iX = ev.pageX - drag.outerWidth() / 2;
        var iY = ev.pageY - drag.outerHeight() / 2;
        var maxX = imgCon.width() + showbox.offset().left - drag.width();
        var maxY = imgCon.height() + showbox.offset().top - drag.height();
        // var iX = ev.pageX ;
        // var iY = ev.pageY ;

        //约束滑块左右的位置
        if(iX < showbox.offset().left){
            iX = showbox.offset().left
        }
        if(iX > maxX){
            iX = maxX
        }
        //约束滑块上下的位置
        if(iY < showbox.offset().top){
            iY = showbox.offset().top;
        }
        if(iY > maxY){
            iY = maxY;
        }       
        drag.css({left:iX+'px',top:iY+'px'});
        
        //计算大图移动的L值
        //左右两侧的
        var sliderL = iX - showbox.offset().left;
        var sliderMaxL = maxX - showbox.offset().left;
        var bigMaxL =  show.width() - big.width();
        var bigL = sliderL * bigMaxL / sliderMaxL;
        //上下两侧的
        var sliderT = iY - showbox.offset().top;
        var sliderMaxT = maxY - showbox.offset().top;
        var bigMaxT =  show.height() - big.height();
        var bigT = sliderT * bigMaxT / sliderMaxT;    
        show.css({right:bigL+'px',bottom:bigT+'px'});	   	
    })
    imgCon.mouseout(function(){
        drag.css('display','none');
        big.css('display','none');
    }) 
});
	
			
		
		

