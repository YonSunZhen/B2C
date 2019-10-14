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
        url: link+"/back/WebSer.asmx/AddVisitRecord?url="+visitUrl,
        success: function (data) {
            console.log(data);        
        }
    });
    
     
    //轮播图
    $(function(){
        $('.flexslider').flexslider({
            directionNav:true,
            pauseOnAction:false,
            controlNav: true
        });
    })

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


    // var bigClass = $('#toTop');
    // var timer = null;
    // var isTop = true;
    // //获取页面的可视窗口高度
    // //var clientHeight = document.documentElement.clientHeight || document.body.clientHeight;
    // //滚动条滚动时触发
    // window.onscroll = function(){
    //     //在滚动的时候增加判断
    //     var osTop = $(document).scrollTop();//特别注意这句，忘了的话很容易出错
    //     if (osTop > 20) {
    //         bigClass.css('display','block');
    //     }else{
    //         bigClass.css('display','none');
    //     }
    // };
    // $('#backTop').click(function() {
    //     $('html,body').animate({
    //         scrollTop:0
    //     },300);
    // });
})