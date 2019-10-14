$(document).ready(function(){
    var imgCon = $("#showbox1");//正常图片容器
    var drag = $("#slider");//获得滑块
    var show = $("#showbox1 > #big > img");//获得大图片
    var big = $("#big");//获得大图片容器
    var img = $("#normal");//获得正常图片
    var imgList = $("#showsum > ul > li > img");//下方小图片
    var showbox = $("#showbox");
    var sub_mainright_ = $("#sub_mainright_");
    var imgName = $("#imgName");
    var price = $("#price");

    //根据传过来的id进行单个产品的查询
    var id1 = window.location.href.split("=")[1];
    var id = "id=" + id1;
    $.ajax({
        type: "post",
        url: "http://localhost:12238/back/WebSer.asmx/GetOneProduct",
        dataType: "json",
        data:id,
        success: function (data) {
            let result = JSON.parse(data); //json字符串转成js对象
            console.log(result);

            let title1 = result.rows[0].JSON_title;
            let price1 = result.rows[0].JSON_price;
            let mainImg = result.rows[0].JSON_img1;
            let smallImg = [
                result.rows[0].JSON_img1,
                result.rows[0].JSON_img2,
                result.rows[0].JSON_img3,
                result.rows[0].JSON_img4,
                result.rows[0].JSON_img5
            ];
            let domain = "http://localhost:12238";

            img.attr('src',domain+mainImg);
            show.attr('src',domain+mainImg);
            imgName.text(title1);
            price.text('￥ '+price1); 
            //console.log(imgList[0]);
            for(let i = 0;i < 5; i++){
                imgList[i].src = domain+smallImg[i];
                //console.log(smallImg[i]);
                imgList[i].setAttribute('data-bigimg',domain+smallImg[i]);
            }           
        }
    });
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
	
			
		
		

