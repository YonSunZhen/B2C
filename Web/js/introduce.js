$(document).ready(function(){
    //$('p').unbind(mouseenter).unbind(mouseleave);
    //企业简介后台调用
    $.ajax({
        type: "GET",
        url: "http://localhost:12238/back/WebSer.asmx/GetDetails",
        dataType: "json",
        success: function (data) {
            let result = JSON.parse(data); //json字符串转成对象
            //alert(data);
            //console.info(result.rows[0].JSON_mainimg);
            console.log(result);
            let webDetail = result.rows[0].JSON_webdetails;
            let contentPlace = $("#contentPlace");
            let content = decodeURIComponent(webDetail);
            contentPlace.html(content);
            let img = $("#contentPlace img");
            let link = "http://localhost:12238";

            //console.log(link+img[0].src);
            //let str1 = img[0].src.replace('file:///E:',link);
            //img[0].src = str1;
            // let a = img[0].src.search(/UpLoadImg/);
            // let str1 = img[0].src.slice(a-1);
            console.log(content);
            // console.log(str1);
            // console.log(link+str1);
            
            for(let i = 0; i < img.length; i++){
                let a = img[i].src.search(/UpLoadImg/);//获得相对路径中UpLoadImg的位置
                let str = img[i].src.slice(a-1);//获得相对图片地址除去（前面的file://）
                console.log(link + str); 
                img[i].src = link + str;
            }
            console.log(content);
        }     
    });
})