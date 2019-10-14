var app = getApp();
var searchUrl = app.globalData.url + "/back/BackSer.asmx/WxSearchPro";
Page({

  /**
   * 页面的初始数据
   */
  data: {
    total:'0',
    product:[],
    searchInput:''
  },
  changeSearch:function(e){
    var that = this;
    // console.log(e.detail.value)
    that.setData({
      searchInput: e.detail.value
    })
  },
  good: function (event) {
    // console.log(event)
    //获取被点击案例的内容
    var content = event.currentTarget.dataset.id;
    content = JSON.stringify(content);
    console.log(content);
    wx.navigateTo({
      url: '../good/good?content=' + content,
    })
  },
// 搜索
  doSearch:function(){
    var that = this;
    that.setData({
      product: []
    })
    wx.request({
      url: searchUrl,
      header:{
        "Content-Type":"application/x-www-form-urlencoded"
      },
      method:'Post',
      data:{
        name:that.data.searchInput
      },
      success:function(res){
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
            product: array,
          })
          console.log(that.data.product)
        }
      }
    })
  },
  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    
  },

  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function () {
    
  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function () {
    
  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function () {
    
  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function () {
    
  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function () {
    
  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function () {
    
  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function () {
    
  }
})