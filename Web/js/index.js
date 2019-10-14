$(document).ready(function(){
    //轮播图
    $(function(){
        $('.flexslider').flexslider({
            directionNav:true,
            pauseOnAction:false,
            controlNav: true
        });
    })
    //企业简介后台调用
    // $.ajax({
    //     type: "GET",
    //     url: "http://localhost:12238/back/WebSer.asmx/GetDetails",
    //     dataType: "json",
    //     success: function (data) {
    //         let result = JSON.parse(data); //json对象转成字符串
    //         //alert(data);
    //         //console.info(result.rows[0].JSON_mainimg);
    //         //console.log(result);
    //         let mainImg = result.rows[0].JSON_mainimg;
    //         let content = result.rows[0].JSON_details;
    //         let imgLink = "http://localhost:12238" + mainImg;
    //         //console.log(imgLink);
    //         let textNode = document.createTextNode(content);
    //         // var div = $('.content_oneleftcon');
    //         let div = document.getElementById('content_oneleftcon');
    //         div.appendChild(textNode);
    //         let img = div.children[0];
    //         //var img = div.firstChild;//为什么出错
    //         img.src = imgLink;
    //         //$("#img").attr("src",imgLink);
    //         console.log(imgLink);
    //     },
    //     complete: function (XMLHttpRequest, textStatus) {
    //            var returnText = XMLHttpRequest.responseText;                    
    //     },
    //     error: function (err) {
    //        alert("跨域访问失败！");
    //    }
    // });
    
    //新闻列表后台调用
    // $.ajax({
    //     type: "GET",
    //     url: "http://localhost:12238/back/WebSer.asmx/GetTitle",
    //     dataType: "json",
    //     success: function (data) {
    //         let result = JSON.parse(data); //json对象转成字符串
    //         //console.log(result);
    //         for(let i = 0;i < 8; i++){
    //             let title1 = result.rows[i].JSON_title;
    //             let time1 = result.rows[i].JSON_createtime;
    //             let array = time1.trim().split(/\s+/);//以空格分割字符串
    //             let time1_ = array[0]
    //             //console.log(title1);
    //             let div = document.getElementById('content_onerightcon');
    //             div.children[i].children[0].children[0].innerHTML = title1;
    //             div.children[i].children[1].innerHTML = time1_;
    //         }           
    //     }
    // });

    //跑马灯产品展示后台调用
    // $.ajax({
    //     type: "POST",
    //     url: "http://localhost:12238/back/BackSer.asmx/getProduction",
    //     dataType: "jsonp",
    //     jsonp:"jsoncallback",
    //     jsonpCallback:"getProduction",
    //     success: function (result) {
    //         //let result = JSON.parse(data); //json对象转成字符串
    //         console.log(result);
    //         for(let i = 0;i < 6; i++){
    //             let title1 = result.rows[i].JSON_title;
    //             let price1 = result.rows[i].JSON_price;
    //             let productId = result.rows[i].JSON_pid;
    //             let mainImg = result.rows[i].JSON_img1;
    //             let imgLink = "http://localhost:12238" + mainImg;
    //             console.info(title1);
    //             let div = document.getElementById('swiper-wrapper');
    //             let img = document.getElementById('img'+i);
    //             let price = document.getElementById('price'+i);
    //             let title = document.getElementById('title'+i);
    //             //获取产品图片a标签
    //             let imgUrl = div.children[i].children[0].children[0].children[0];
    //             let href =  "product_detail.html?id=" +  productId;
    //             img.src = imgLink;
    //             price.innerHTML = price1;
    //             title.innerHTML = title1;

    //             imgUrl.href = href;
    //             title.href = href;
    //             console.log(href);
    //             // div.children[i].children[1].innerHTML = time1_;
    //         } 
            
    //         //底部产品循环播放
    //         var mySwiper = new Swiper('.swiper-container',{
    //             // pagination : '.pagination',//定义一个Swiper的分页器。默认会在这个分页器里面生成与slide对应的span标签。
    //             // autoplay:1000,
    //             // // speed://滑动的速度
    //             // loop: true,//设置为true 则开启loop模式。loop模式：会在wrapper前后生成若干个slides让slides看起来是衔接的，用于无限循环切换
    //             // slidesPerView: 3,//一屏显示3个数据，也可自动
    //             // autoplayDisableOnInteraction : false,
    //             // paginationClickable: true
    //             pagination: '.pagination',
    //             autoplay:1000,
    //             paginationClickable: true,
    //             slidesPerView: 4,
    //             autoplayDisableOnInteraction : false,
    //             loop: true,
    //             speed:1000,
    //             spaceBetween:20
    //         });
    //         $(".swiper-container").mouseenter(function () {//滑过悬停
    //             mySwiper.stopAutoplay();//mySwiper 为上面你swiper实例化的名称
    //         }).mouseleave(function(){//离开开启
    //             mySwiper.startAutoplay();
    //         });
    //     }
    // });

    //底部产品循环播放
    var mySwiper = new Swiper('.swiper-container',{
      // pagination : '.pagination',//定义一个Swiper的分页器。默认会在这个分页器里面生成与slide对应的span标签。
      // autoplay:1000,
      // // speed://滑动的速度
      // loop: true,//设置为true 则开启loop模式。loop模式：会在wrapper前后生成若干个slides让slides看起来是衔接的，用于无限循环切换
      // slidesPerView: 3,//一屏显示3个数据，也可自动
      // autoplayDisableOnInteraction : false,
      // paginationClickable: true
      pagination: '.pagination',
      autoplay:1000,
      paginationClickable: true,
      slidesPerView: 4,
      autoplayDisableOnInteraction : false,
      loop: true,
      speed:1000,
      spaceBetween:20
    });
    $(".swiper-container").mouseenter(function () {//滑过悬停
        mySwiper.stopAutoplay();//mySwiper 为上面你swiper实例化的名称
    }).mouseleave(function(){//离开开启
        mySwiper.startAutoplay();
    });




})