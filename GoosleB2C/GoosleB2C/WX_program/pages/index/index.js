//index.js
//获取应用实例
const app = getApp()
var topProduceUrl = app.globalData.url+'/back/BackSer.asmx/getWxIndexProduce'
var requestUrl = app.globalData.url +'/back/BackSer.asmx/getIndexData'
var topCaseUrl = app.globalData.url + '/back/BackSer.asmx/getIndexCase'
var topInfoUrl = app.globalData.url + '/back/BackSer.asmx/getWxIndexArticle'
var indexBrandUrl = app.globalData.url + '/back/BackSer.asmx/getWxIndexBrand'
var ProductGuidUrl = app.globalData.url + '/back/BackSer.asmx/getWxProductByGuid'
var CaseGuidUrl = app.globalData.url + '/back/BackSer.asmx/getWxCaseByGuid'
var PassageGuidUrl = app.globalData.url + '/back/BackSer.asmx/getWxPassageByGuid'
var IndexContentUrl = app.globalData.url + '/back/BackSer.asmx/WxIndexContent'
Page({

  /**
   * 页面的初始数据
   */
  data: {
    isshowSuccess:'',
    successTotal:'',
    isshowproduct:'',
    productTotal:'',
    isshowVideo:'',
    videoUrl:'',
    videoTitle:'',
    isshowArticle:'',
    articleTotal:'',
    top_comInfo:[],
    top_produce: [],
    top_cases:[],
    imgs: [],
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
    show_1: '../image/show_1.png',
    show_case:'../image/case_img_1.jpg',
    show_info:'../image/Company_Inof.png'
  },
  sw_detail: function() {
    wx.navigateTo({
      url: '../detail/detail',
    })

  },
  delicateTap:function(event){
    var content = event.currentTarget.dataset.id;
    content = JSON.stringify(content);
    // console.log(content);
    wx.navigateTo({
      url: '../good/good?content=' + content,
    })
  },
  sw_case: function() {
    wx.navigateTo({
      url: '../case/case',
    })
  },

  sw_passage: function() {
    wx.navigateTo({
      url: '../passage/passage',
    })
  },
  sw_passage_detail:function(event){
    var content = event.currentTarget.dataset.id;
    content = JSON.stringify(content);
    console.log(content);
    wx.navigateTo({
      url: '../passageDetail/passageDetail?content='+content,
    })
  },
  sw_category: function() {
    wx.switchTab({
      url: '../category/category',
    })
  },
  // 轮播图事件绑定
  sw_brand_product:function(event){
    var id = event.currentTarget.dataset.id;
    wx.request({
      url: ProductGuidUrl,
      header: {
        "Content-Type": "application/x-www-form-urlencoded"
      },
      method: 'POST',
      data:{
        guid:id
      },
      success:function(res){
        // console.log(res.data.rows[0]);
        var content = JSON.stringify(res.data.rows[0]);
        wx.navigateTo({
          url: '../good/good?content='+content,
        })
      }
    })
  },
  sw_brand_case: function (event) {
    var id = event.currentTarget.dataset.id;
    wx.request({
      url: CaseGuidUrl,
      header: {
        "Content-Type": "application/x-www-form-urlencoded"
      },
      method: 'POST',
      data: {
        guid: id
      },
      success: function (res) {
        // console.log(res.data.rows[0]);
        var content = JSON.stringify(res.data.rows[0]);
        wx.navigateTo({
          url: '../case_detail/case_detail?content=' + content,
        })
      }
    })
  },
  sw_brand_passage: function (event) {
    var id = event.currentTarget.dataset.id;
    wx.request({
      url: PassageGuidUrl,
      header: {
        "Content-Type": "application/x-www-form-urlencoded"
      },
      method: 'POST',
      data: {
        guid: id
      },
      success: function (res) {
        // console.log(res.data.rows[0]);
        var content = JSON.stringify(res.data.rows[0]);
        wx.navigateTo({
          url: '../passageDetail/passageDetail?content=' + content,
        })
      }
    })
  },

  sw_case_detail:function(event){
    console.log(event)
    //获取被点击案例的内容
    var content = JSON.stringify(event.currentTarget.dataset.id);
    // console.log(content)
    wx.navigateTo({
      url: '../case_detail/case_detail?content=' + content,
    })
  },
  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function(options) {
    var that = this;
    var produces = [];
    var cases = [];
    var brandImgs = [];
    wx.request({
      url: IndexContentUrl,
      method:'post',
      header: {
        "Content-Type": "application/x-www-form-urlencoded"
      },
      success:function(res){
        
        that.setData({
          isshowSuccess:res.data.rows[0].JSON_isshowsuccess,
          successTotal:res.data.rows[0].JSON_successtotal,
          isshowproduct:res.data.rows[0].JSON_isshowproduct,
          productTotal:res.data.rows[0].JSON_producttotal,
          isshowVideo: res.data.rows[0].JSON_isshowvideo,
          videoUrl: res.data.rows[0].JSON_videopath,
          videoTitle: res.data.rows[0].JSON_videotitle,
          isshowArticle: res.data.rows[0].JSON_isshowarticle,
          articleTotal: res.data.rows[0].JSON_articletotal
        })
        console.log(that.data);
        //获取首页成功案例
        wx.request({
          url: topCaseUrl,
          header: {
            "Content-Type": "application/x-www-form-urlencoded"
          },
          method: 'POST',
          data: {
            num: that.data.successTotal
          },
          success: function (res) {
            cases = res.data.rows;
            //格式化数据
            // console.log(res.data)
            for (var i = 0; i < res.data.rows.length; i++) {
              if (res.data.rows[i].JSON_mainimg != '')
                cases[i].JSON_mainimg = app.globalData.url + res.data.rows[i].JSON_mainimg
              else {
                cases[i].JSON_mainimg = '../image/img_null.png';
              }
            }
            that.setData({
              top_cases: cases
            })
          },
        })
        //获取Brand
        wx.request({
          url: indexBrandUrl,
          header: {
            "Content-Type": "application/x-www-form-urlencoded"
          },
          method: 'POST',
          success: function (res) {
            // console.log(res.data.rows);
            if (res.data.rows[0].JSON_vimg1 != '') {
              var tempObj = {
                img: '',
                id: '',
                typ: ''
              };
              tempObj.img = app.globalData.url + res.data.rows[0].JSON_vimg1;
              var t = res.data.rows[0].JSON_vurl1.split(";");
              tempObj.id = t[2];
              tempObj.typ = t[0];
              brandImgs.push(tempObj);
            }
            if (res.data.rows[0].JSON_vimg2 != '') {
              var tempObj = {
                img: '',
                id: '',
                typ: ''
              };
              tempObj.img = app.globalData.url + res.data.rows[0].JSON_vimg2;
              var t = res.data.rows[0].JSON_vurl2.split(";");
              tempObj.id = t[2];
              tempObj.typ = t[0];
              brandImgs.push(tempObj);
            }
            if (res.data.rows[0].JSON_vimg3 != '') {
              var tempObj = {
                img: '',
                id: '',
                typ: ''
              };
              tempObj.img = app.globalData.url + res.data.rows[0].JSON_vimg3;
              var t = res.data.rows[0].JSON_vurl3.split(";");
              tempObj.id = t[2];
              tempObj.typ = t[0];
              brandImgs.push(tempObj);
            }
            if (res.data.rows[0].JSON_vimg4 != '') {
              var tempObj = {
                img: '',
                id: '',
                typ: ''
              };
              tempObj.img = app.globalData.url + res.data.rows[0].JSON_vimg4;
              var t = res.data.rows[0].JSON_vurl4.split(";");
              tempObj.id = t[2];
              tempObj.typ = t[0];
              brandImgs.push(tempObj);
            }
            if (res.data.rows[0].JSON_vimg5 != '') {
              var tempObj = {
                img: '',
                id: '',
                typ: ''
              };
              tempObj.img = app.globalData.url + res.data.rows[0].JSON_vimg5;
              var t = res.data.rows[0].JSON_vurl5.split(";");
              tempObj.id = t[2];
              tempObj.typ = t[0];
              brandImgs.push(tempObj);
            }
            that.setData({
              imgs: brandImgs
            })
            // console.log(brandImgs);
          }
        })

        //获取首页精品产品
        wx.request({
          url: topProduceUrl,
          header: {
            "Content-Type": "application/x-www-form-urlencoded"
          },
          method: 'POST',
          data:{
            num: that.data.productTotal
          },
          success: function (res) {
            produces = res.data.rows;
            //格式化数据
            // console.log(res.data)
            for (var i = 0; i < res.data.rows.length; i++) {
              if (res.data.rows[i].JSON_img1 != '') {
                produces[i].JSON_img1 = app.globalData.url + res.data.rows[i].JSON_img1;
              } else {
                produces[i].JSON_img1 = '../image/img_null.png';
              }
              if (res.data.rows[i].JSON_img2 != '') {
                produces[i].JSON_img2 = app.globalData.url + res.data.rows[i].JSON_img2;
              } else {
                produces[i].JSON_img2 = '../image/img_null.png';
              }
              if (res.data.rows[i].JSON_img3 != '') {
                produces[i].JSON_img3 = app.globalData.url + res.data.rows[i].JSON_img3;
              } else {
                produces[i].JSON_img3 = '../image/img_null.png';
              }
              if (res.data.rows[i].JSON_img4 != '') {
                produces[i].JSON_img4 = app.globalData.url + res.data.rows[i].JSON_img4;
              } else {
                produces[i].JSON_img4 = '../image/img_null.png';
              }
              if (res.data.rows[i].JSON_img5 != '') {
                produces[i].JSON_img5 = app.globalData.url + res.data.rows[i].JSON_img5;
              } else {
                produces[i].JSON_img5 = '../image/img_null.png';
              }
            }

            that.setData({
              top_produce: produces
            })
          },
          fail: function (err) {
            console.log(err)

          }
        })
        //首页公司资讯
        wx.request({
          url: topInfoUrl,
          header: {
            "Content-Type": "application/x-www-form-urlencoded"
          },
          method: 'POST',
          data:{
            num: that.data.articleTotal
          },
          success: function (res) {
            for (var i = 0; i < res.data.rows.length; i++) {
              var t = res.data.rows[i].JSON_imgs.split(';');
              res.data.rows[i].JSON_mainimg = res.data.rows[i].JSON_imgs == '' ? '../image/img_null.png' : app.globalData.url + t[0];
            }
            that.setData({
              top_comInfo: res.data.rows
            })
            console.log(res.data.rows);
          }
        })
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

  },

})