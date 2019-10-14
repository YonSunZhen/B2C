//app.js
App({
  onLaunch: function() {
    var that = this;
    // 登录
    wx.login({
      success: function(res) {
        
        if (res.code) {
          wx.request({
            header: {
              "Content-Type": "application/x-www-form-urlencoded"
            },
            url: 'http://localhost:12238/back/BackSer.asmx/getUserStatus',
            method:'POST',
            dataType:'json',
            data: {
              code: res.code
            },
            success:function(code){
              that.globalData.openid = code.data.openid
              that.globalData.session_key = code.data.session_key
            }
          })

        }
        // 发送 res.code 到后台换取 openId, sessionKey, unionId
        else {
          console.log('获取用户登录态失败！' + res.errMsg)
        }
      }
    })
    // 获取用户信息
    wx.getSetting({
      success: res => {
        if (res.authSetting['scope.userInfo']) {
          // 已经授权，可以直接调用 getUserInfo 获取头像昵称，不会弹框
          wx.getUserInfo({
            success: res => {
              // 可以将 res 发送给后台解码出 unionId
              this.globalData.userInfo = res.userInfo

              // 由于 getUserInfo 是网络请求，可能会在 Page.onLoad 之后才返回
              // 所以此处加入 callback 以防止这种情况
              if (this.userInfoReadyCallback) {
                this.userInfoReadyCallback(res)
              }
            }
          })
        }
      }
    })
  },
  globalData: {
    userInfo: null,
    hasUserInfo:false,
    session_key:null,
    openid:null,
    //全局url配置
    url:"http://localhost:12238"
  }
})