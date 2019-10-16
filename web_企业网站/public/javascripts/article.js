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

    if( (window.location.href.indexOf('/type?') == -1) &&  (window.location.href.indexOf('/page1?') == -1) ){
        $.ajax({
            url:'/article/total',
            type:'get'
        }).done(function(data){
            let length = data.rows.length;
            console.log(length);
    
            if(location.href.indexOf('?') != -1){
                const end = location.href.split('end=')[1];
                var num = (end-18)/18;
            }else{
                var num = 0;
            }
            $(".pager").pager({
                pageIndex:num,
                pageSize:18,
                itemCount:length,
                maxButtonCount:4,
                onPageChanged:function(pageIndex){
                    let start = 18 * pageIndex + 1;
                    let end = 18 * pageIndex + 18;
                    console.log(pageIndex);
                    location.href = "/article/page?start="+start+"&end="+end;   
                }     
            });       
        })
    };

    if( (window.location.href.indexOf('/type?') != -1) || (window.location.href.indexOf('page1?') != -1) ){

        //获取href后面type的id
        //let id = window.location.href.split('?')[1].split('=')[1];
        let n = window.location.href.indexOf('id');
        console.log(window.location.href.charAt(n+3));
        //得到文章类型的id
        let id = window.location.href.charAt(n+3);
        $.ajax({
            url:'/article/totalByType?id='+id,
            type:'get'
        }).done(function(data){
            //得到类型为id的文章的总数
            let length = data.rows.length;
            console.log(length);
    
            if(location.href.indexOf('&start') != -1){
                const end = location.href.split('end=')[1];
                //console.log(end);
                var num = (end-18)/18;
            }else{
                var num = 0;
            }
            $(".pager").pager({
                pageIndex:num,
                pageSize:18,
                itemCount:length,
                maxButtonCount:4,
                onPageChanged:function(pageIndex){
                    let start = 18 * pageIndex + 1;
                    let end = 18 * pageIndex + 18;
                    //console.log(pageIndex);
                    location.href = "/article/typePage?id="+id+"&start="+start+"&end="+end;   
                }     
            });       
        })
    }


})