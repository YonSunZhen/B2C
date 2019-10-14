const app = getApp()
var postUrl = app.globalData.url + "/back/BackSer.asmx/WxMsgPost";
Page({

  /**
   * 页面的初始数据
   */
  data: {
    sex: '',
    massage: '',
    name: '',
    phone: '',
    userInfo: [],
    items: [{
        name: 'male',
        value: '男士'
      },
      {
        name: 'female',
        value: '女士'
      },

    ]
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function(options) {
    this.setData({
      userInfo: app.globalData.userInfo
    })
  },

  radioChange: function(e) {
    var that = this;
    console.log('radio发生change事件，携带value值为：', e.detail.value)
    that.setData({
      sex: e.detail.value
    })
  },
  //获取值
  changeMsg: function(e) {
    var that = this;
    // console.log(e.detail.value)
    that.setData({
      massage: e.detail.value
    })
  },
  changePhone: function(e) {
    var that = this;
    // console.log(e.detail.value)
    that.setData({
      phone: e.detail.value
    })
  },

  changeName: function(e) {
    var that = this;
    // console.log(e.detail.value)
    that.setData({
      name: e.detail.value
    })
  },
  warn: function(msg) {
    wx.showToast({
      title: msg,
      duration: 1000,
      mask: true
    })
  },
  //留言板检测
  check: function(that) {
    var phonereg = /^(((13[0-9]{1})|(15[0-9]{1})|(18[0-9]{1})|(17[0-9]{1}))+\d{8})$/;
    var namereg = /^[u4E00-u9FA5]+$/;
    if (that.data.massage == '') {
      that.warn("请输入留言");
      return false;
    } else if (that.data.phone == '') {
      that.warn("请输入手机号");
    } else if (that.data.phone.length != 11) {
      that.warn("手机号长度有误");
    } else if (!phonereg.test(that.data.phone)) {
      that.warn("手机号有误");
    } else if (that.data.name == '') {
      that.warn("请输入名字");
    } else if (that.data.sex == '') {
      that.warn("请选择性别");
    } else {
      return true;
    }
  },
  massage_post: function() {
    var that = this;
    var info = JSON.stringify(app.globalData.userInfo);
    if (that.check(that)) {
      console.log(that.data.massage)
      wx.request({
        url: postUrl,
        method: "POST",
        header: {
          "Content-Type": "application/x-www-form-urlencoded"
        },
        data: {
          massage: that.data.massage,
          phone: that.data.phone,
          name: that.data.name,
          sex: that.data.sex,
          openid: app.globalData.openid,
          userInfo: info
        },
        success: function(req) {
          console.log(req);
          if (req.statusCode == 200) {
            wx.showToast({
              title: '成功留言',
              duration: 1000,
              mask: true,
              success: function() {

                setTimeout(function() {
                  wx.navigateBack({
                    delta: -1
                  })
                }, 1000)

              }

            })
          }else{
            that.warn("留言失败，请重试")
          }


        }
      })
    } else {}
  },
  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function() {

  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function() {

  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function() {

  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function() {

  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function() {

  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function() {

  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function() {

  }
})