var app = getApp();
var categoryUrl = app.globalData.url + '/back/BackSer.asmx/getWxCategory'
var productUrl = app.globalData.url + '/back/BackSer.asmx/getWxProduction'
Page({

  /**
   * 页面的初始数据
   */
  data: {
    section: "",
    section2: "",
    imgURL: app.globalData.url,
    categoryAll: [],
    categoryTop: [],
    category_2nd: [],
    produce: [],
    viewHeight: "",
    currentTab: 0, //预设当前项的值
    scrollLeft: 0, //tab标题的滚动条位置
    produce_img: '../image/produce_img.png',
    produce_img_1: '../image/fire.png'
  },

  // 点击一级目录获取二级目录
  swichNav: function(e) {
    var that = this;
    that.setData({
      produce: []
    })
    var array = [];
    var id = e.target.dataset.id;
    for (var i = 0; i < that.data.categoryTop.length; i++) {
      if (that.data.categoryTop[i].JSON_father == id) {
        array.push(that.data.categoryTop[i]);

      }

    }
    // console.log(array);
    that.setData({
      category_2nd: array,
      section: e.target.dataset.id
    })
    // console.log(that.data.section)
  },
  //搜索跳转
  sw_search:function(){
    wx.navigateTo({
      url: '../searchProduct/searchProduct',
    })
  },
  //根据二级目录获取产品
  getproduct: function(e) {
    var that = this;
    that.setData({
      produce: [],
      section2: e.target.dataset.id
    })
    var id = e.target.dataset.id;
    // console.log(id);
    wx.request({
      url: productUrl,
      method: "POST",
      header: {
        "Content-Type": "application/x-www-form-urlencoded"
      },
      data: {
        id: id
      },
      success: function(res) {
        if (res.data.rows.length != 0) {
          var array = res.data.rows;
          for (var i = 0; i < array.length; i++) {
            // console.log(res.data.rows[i].JSON_img1);
            array[i].JSON_img1 = res.data.rows[i].JSON_img1 == '' ? '' : app.globalData.url + res.data.rows[i].JSON_img1;
            array[i].JSON_img2 = res.data.rows[i].JSON_img2 == '' ? '' : app.globalData.url + res.data.rows[i].JSON_img2;
            array[i].JSON_img3 = res.data.rows[i].JSON_img3 == '' ? '' : app.globalData.url + res.data.rows[i].JSON_img3;
            array[i].JSON_img4 = res.data.rows[i].JSON_img4 == '' ? '' : app.globalData.url + res.data.rows[i].JSON_img4;
            array[i].JSON_img5 = res.data.rows[i].JSON_img5 == '' ? '' : app.globalData.url + res.data.rows[i].JSON_img5;
          }
          that.setData({
            produce: array,
          })
          // console.log(array)
        }

      }
    })
  },
  /**
   * 生命周期函数--监听页面加载
   */
  good: function(event) {
    // console.log(event)
    //获取被点击案例的内容
    var content = event.currentTarget.dataset.id;
    content = JSON.stringify(content);
    console.log(content);
    wx.navigateTo({
      url: '../good/good?content=' + content,
    })
  },
  onLoad: function() {
    var that = this;
    wx.request({
      url: categoryUrl,
      method: "POST",
      header: {
        "Content-Type": "application/x-www-form-urlencoded"
      },
      success: function(res) {
        if (res.data.rows.length > 0) {
          // console.log(res.data.total)
          that.setData({
            categoryTop: res.data.rows,
            total: res.data.total
          })
        }

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