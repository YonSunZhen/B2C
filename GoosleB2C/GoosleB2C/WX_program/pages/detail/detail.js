var app = getApp();
var Url = app.globalData.url+'/back/BackSer.asmx/getWXCompanyInfo'
Page({

  /**
   * 页面的初始数据
   */
  data: {
    com_detail:'',
    com_employment:'',
    com_contactus:'',
    com_culture:'',
    imgUrls: [
      '../image/demo.jpg',
    ],
    indicatorDots: true, //是否显示面板指示点
    autoplay: true, //是否自动切换
    interval: 5000, //自动切换时间间隔
    duration: 1000, //滑动动画时长
    inputShowed: false,
    inputVal: "",
    logo_1: '../image/home.png',
    logo_2: '../image/produce.png',
    logo_3: '../image/passage.png',
    logo_4: '../image/case.png',
    show_1: '../image/company_img.png',
    show_2: '../image/coculture.png',
    show_3: '../image/employment.png',
    show_4: '../image/contactus.png',

  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function(options) {
    var that = this;
    var imgs =[];
    wx.request({
      url: Url,
      header: {
        "Content-Type": "application/x-www-form-urlencoded"
      },
      success: function(res) {
        console.log(res.data.rows)
        for(var i=0;i<res.data.rows.length;i++){
          imgs.push(app.globalData.url+res.data.rows[i].JSON_mainimg)
        }
        that.setData({
          Case: res.data.rows,
          com_detail: res.data.rows[0].JSON_details,
          com_contactus: res.data.rows[3].JSON_details,
          com_culture: res.data.rows[1].JSON_details,
          com_employment: res.data.rows[2].JSON_details,
          imgUrls:imgs
        })
      },
      fail: function(err) {
        console.log(err)

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