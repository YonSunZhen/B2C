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

var code ; //在全局定义验证码  
const input = $("#input");//验证输入框
const checkCode = $("#code");//验证部分
const add = $("#add");//提交代码
const name = $("#name");
const wx = $("#wx");
const phone = $("#phone");
const content = $("#content");
//点击更换验证码
checkCode.click(function(){
    createCode();
})
//提交留言按钮执行的事件
add.click(function(){
    //获取输入框的值
    let name1 = name.val();
    let sex = $("input:radio[name='sex']:checked").val();
    let wx1 = wx.val();
    let phone1 =  phone.val();
    let content1 = content.val();
    // let visitor_ip = returnCitySN["cip"];//有点问题，谷歌获取不到

    try{
        var visitor_ip = returnCitySN["cip"];
    }catch(error){
        // console.log("此浏览器无法获取ip");
    }
    if(visitor_ip){
        var ip = visitor_ip;
        // console.log(ip);
    }else{
        var ip = '';
        // console.log(ip);
    }

    const inputCode = input.val().toUpperCase(); //取得输入的验证码并转化为大写
    //验证输入框的值
    if( !name1.trim() ){
        alert('姓名不能为空');
        name1 = '';
        name.focus();
    }else if(phone1.trim().length > 11){
        alert('请输入正确的手机');
        phone.val('');
        phone.focus();
    }else if( !content1.trim() ){
        alert('留言不能为空');
        content1 = '';
        content.focus();
        validate();
    }else if(inputCode.length <= 0){
        alert("请输入验证码！");
    }else if(inputCode != code){
        alert("验证码输入错误！@_@");
        createCode();//刷新验证码  
        input.val("");//清空文本框 
    }else{
        const data = {
            "name" : name1,
            "sex": sex,
            "wx" : wx1,
            "phone" : phone1,
            "msg" : content1,
            "ip": ip
        }
        const stringData = JSON.stringify(data);
        var obj = "obj=" + stringData;
        $.ajax({
            type:"post", 
            url:link+"/back/BackSer.asmx/addMessage",
            data:obj,
            dataType: 'jsonp',
            jsonp: 'jsoncallback',
            // 对应着后台返回的回调函数
            jsonpCallback: 'addMessage',
            // contentType:"application/json", 
            success:function(result){
                if(result.indexOf('成功') !== -1){
                    alert('留言成功');
                    location.reload();
                }
                else{
                    alert('留言失败');
                }
            },
            error:function(xhr){
                alert("错误提示： " + xhr.status + " " + xhr.statusText);
            }
        });
    }
       
    // console.log(obj);
    
});

//生成验证码
function createCode(){ 
    code = "";  
    const codeLength = 4;//验证码的长度    
    const random = new Array(0,1,2,3,4,5,6,7,8,9,'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R',  
    'S','T','U','V','W','X','Y','Z');//随机数  
    for(let i = 0; i < codeLength; i++) {//循环操作  
        const index = Math.floor(Math.random()*36);//取得随机数的索引（0~35）  
        code += random[index];//根据索引取得随机数加到code上  
    }  
    checkCode.val(code);//把code值赋给验证码  
} 
//校验验证码  
// function validate(){  
//     const inputCode = input.val().toUpperCase(); //取得输入的验证码并转化为大写     
//     if(inputCode.length <= 0) { //若输入的验证码长度为0  
//         alert("请输入验证码！"); //则弹出请输入验证码  
//     }else if(inputCode != code ) { //若输入的验证码与产生的验证码不一致时  
//         alert("验证码输入错误！@_@"); //则弹出验证码输入错误  
//         createCode();//刷新验证码  
//         input.val("");//清空文本框  
//     }else { //输入正确时  
//         alert("合格！^-^"); 
//     } 
// }