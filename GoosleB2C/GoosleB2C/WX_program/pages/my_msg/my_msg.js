var app = getApp()
var Url = app.globalData.url + "/back/BackSer.asmx/getWxUserMsg";
Page({

  /**
   * 页面的初始数据
   */
  data: {
    isanswer:-1,
    msg_y: '已回复',
    UserMessage: [],
    my_image: '',
    my_msg_img: '../image/massage.jpg',
    s_image: '../image/service.png',
    text_1: '我的留言',
    answer: '请稍后，客服正在为您答疑!',
    msg_time: '2018-7-20 17:10:01',
    msg_psg: '',
    msg_n: '未回复',
    msg_none:'暂无留言'
  },
  newMsg: function () {

  },
  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function(options) {
    var that = this;
    var userinfo = app.globalData.userInfo
    this.setData({
      my_image: userinfo.avatarUrl
    })
    wx.request({
      url: Url,
      header: {
        "Content-Type": "application/x-www-form-urlencoded",
      },
      method: "POST",
      data: {
        openid: app.globalData.openid
      },
      success: function(res) {
        console.log(res.data.rows)
        if (res.data.total>0){
          that.setData({
            UserMessage: res.data.rows,
            isanswer: res.data.rows[res.data.total - 1].JSON_isread
          })
        }

        console.log(res.data.rows[0].JSON_to==0)
      },
      fail: function(err) {
        console.log(err.data);
      }

    })
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