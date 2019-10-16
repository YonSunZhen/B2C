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

    if(location.href.indexOf('?') != -1){
        const end = location.href.split('?')[1].split('&')[1].split('=')[1];
        var num = (end-5)/5;
    }else{
        var num = 0;
    }
    var length = length1;
    //console.log(length);
    $(".pager").pager({
        pageIndex:num,
        pageSize:5,
        itemCount:length,
        maxButtonCount:4,
        onPageChanged:function(pageIndex){
            let start = 5 * pageIndex + 1;
            let end = 5 * pageIndex + 5;
            console.log(pageIndex);
            location.href = "/successCase/page?start="+start+"&end="+end;
        }     
    });
})