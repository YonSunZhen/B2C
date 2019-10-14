var app = getApp();
Page({

  /**
   * 页面的初始数据
   */
  data: {
    content: [],
    imgUrls:[],
    detail:'',
    title:'',
    detail_imgs:[],
    price:'',
    indicatorDots: true, //是否显示面板指示点
    autoplay: true, //是否自动切换
    interval: 5000, //自动切换时间间隔
    duration: 1000, //滑动动画时长
    inputShowed: false,
    inputVal: "",
    show_1:'../image/productDetail.png'
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    var temp = JSON.parse(options.content)
    var that = this;
    var imgs = [];
    var detail_imgs=[];
    var imgs_t = '';
    // console.log(that.data.content.data);
    if ((temp['JSON_img1'] != '') && (temp['JSON_img1']!= null)){
      imgs.push(temp['JSON_img1']);
    }
    if ((temp['JSON_img2'] != '') && (temp['JSON_img2'] != null)){
      imgs.push(temp['JSON_img2']);
    }
    if ((temp['JSON_img3'] != '' )&& (temp['JSON_img3'] != null)){
      imgs.push(temp['JSON_img3']);
    }
    if ((temp['JSON_img4'] != '') && (temp['JSON_img4'] != null)){
      imgs.push(temp['JSON_img4']);
    }
    if ((temp['JSON_img5'] != '' )&& (temp['JSON_img5'] != null)){
      imgs.push(temp['JSON_img5']);
    }
    //图片详情
    imgs_t = temp['JSON_detailimgs'];
    detail_imgs = imgs_t.split(';');
    for(var i=0;i<detail_imgs.length;i++){
      detail_imgs[i] = app.globalData.url+detail_imgs[i]
    }


    that.setData({
      imgUrls: imgs,
      title: temp.JSON_title,
      detail: temp.JSON_details,
      price: temp.JSON_price,
      detail_imgs: detail_imgs
    });
  
    console.log(detail_imgs);
    console.log(imgs_t);

    // this.setData({
    //   content: temp
    // });
    // console.log(options.content); 
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