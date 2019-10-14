const app = getApp()
var phoneUrl = app.globalData.url + '/back/BackSer.asmx/getWxCompanyContact';
Page({
  data: {
    src: "../image/kefu.jpg",
    text_phone: '电话联系',
    text_1: '留言板',
    phone_number: '020-00000000',
    msg: '../image/msg1.jpg',
    userInfo: {},
    hasUserInfo: false,
    canIUse: wx.canIUse('button.open-type.getUserInfo')
  },
  switchtopost: function() {
    wx.navigateTo({
      url: '../msg_post/msg_post',
    })
    // wx.showModal({
    //   title: '即将清空旧留言',
    //   content: '新建留言将清空旧留言',
    //   cancelColor: '#3CC51F',
    //   confirmColor: '#000000',
    //   success: function (res) {
    //     if (res.confirm) {
    //       wx.navigateTo({
    //         url: '../msg_post/msg_post',
    //       })
    //     }

    //   }
    // })
  },
  sw_mymsg: function() {
    wx.navigateTo({
      url: '../my_msg/my_msg',
    })
  },
  sw_remsg: function() {
    wx.navigateTo({
      url: '../re_msg/re_msg',
    })
  },
  //拨打客服电话
  calling: function() {
    var that = this;
    wx.makePhoneCall({
      phoneNumber: that.data.phone_number,
    })
  },
  onLoad: function() {
    var that = this;
    wx.request({
      url: phoneUrl,
      header: {
        "Content-Type": "application/x-www-form-urlencoded",
      },
      success: function(res) {
        console.log(res.data.rows)
        that.setData({
          phone_number: res.data.rows[0].JSON_contacts
        })
      }
    })
    // console.log(app.globalData.userInfo)
    if (app.globalData.userInfo) {
      this.setData({
        userInfo: app.globalData.userInfo,
        hasUserInfo: true
      })
    } else if (this.data.canIUse) {
      // 由于 getUserInfo 是网络请求，可能会在 Page.onLoad 之后才返回
      // 所以此处加入 callback 以防止这种情况
      app.userInfoReadyCallback = res => {
        this.setData({
          userInfo: res.userInfo,
          hasUserInfo: true
        })
      }
    } else {
      // 在没有 open-type=getUserInfo 版本的兼容处理
      wx.getUserInfo({
        success: res => {
          app.globalData.userInfo = res.userInfo
          this.setData({
            userInfo: res.userInfo,
            hasUserInfo: true
          })
        }
      })
    }
  },
  getUserInfo: function(e) {
    console.log(e)
    app.globalData.userInfo = e.detail.userInfo
    if (e.detail.errMsg == "getUserInfo:ok") {
      app.globalData.hasUserInfo = true
    } else {
      wx.navigateBack({
        delta: -1
      })
    }
    console.log(app.globalData.hasUserInfo)
    this.setData({
      userInfo: e.detail.userInfo
    })
  }
})