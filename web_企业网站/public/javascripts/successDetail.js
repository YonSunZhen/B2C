$(document).ready(function(){

    //记录成功案例访问记录
    console.log(successId);
    console.log(successReadCount);
    const readCount = Number(successReadCount) + 1;
    $.ajax({
        type: "get",
        url: link+"/back/WebSer.asmx/UpdateSuccessReadCount?id="+successId+"&readCount="+readCount,
        success: function (data) {
            console.log(data);        
        }
    });

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

    let img = $("#webContent img");
    // let link = "http://localhost:12238";
    for(let i = 0; i < img.length; i++){
        console.log( img[i].src);
        let a = img[i].src.search(/UploadImg/);//获得相对路径中UpLoadImg的位置
        console.log(a);
        let str = img[i].src.slice(a-1);//获得相对图片地址除去（前面的file://）
        console.log(link + str); 
        img[i].src = link + str;
    }
})