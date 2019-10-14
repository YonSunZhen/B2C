if(/Android|Windows Phone|webOS|iPhone|iPod|BlackBerry/i.test(navigator.userAgent)){  //测试当前是哪个手机系统，可根据业务需要选择
    console.log("现在是手机端")
}else if(/iPad/i.test(navigator.userAgent)){ // ipad
    console.log("现在是平板端")
}else {
    console.log("现在是PC端")
}