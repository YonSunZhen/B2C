var app = getApp();
var artcleTypeUrl = app.globalData.url + '/back/BackSer.asmx/getWxArtcleType';
var artcleUrl = app.globalData.url + '/back/BackSer.asmx/getWxArticle';
Page({

  /**
   * 页面的初始数据
   */

  data: {
    artcle:[],
    artcleType: [],
    viewHeight: "",
    winHeight: "", //窗口高度
    currentTab: 0, //预设当前项的值
    scrollLeft: 0, //tab标题的滚动条位置
    passage_img: '../image/passage_img.jpg',
  },
  sw_passage_detail: function (event) {
    var content = event.currentTarget.dataset.id;
    content = JSON.stringify(content);
    console.log(content);
    wx.navigateTo({
      url: '../passageDetail/passageDetail?content=' + content,
    })
  },
  // 滚动切换标签样式
  switchTab: function(e) {
    this.setData({
      currentTab: e.detail.current
    });
    this.checkCor();
  },
  // 点击标题切换当前页时改变样式
  swichNav: function(e) {
    console.log(e);
    var cur = e.target.dataset.sort;
    if (this.data.currentTaB == cur) {
      return false;
    } else {
      this.setData({
        currentTab: cur
      })
    }
  },
  //判断当前滚动超过一屏时，设置tab标题滚动条。
  checkCor: function() {
    if (this.data.currentTab > 4) {
      this.setData({
        scrollLeft: 300
      })
    } else {
      this.setData({
        scrollLeft: 0
      })
    }
  },
  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function() {
    var that = this;
    var tempArray = [];
    //  高度自适应
    wx.getSystemInfo({
      success: function(res) {
        var clientHeight = res.windowHeight,
          clientWidth = res.windowWidth,
          rpxR = 750 / clientWidth;
        var calc = clientHeight * rpxR - 421;
        var viewcalc = clientHeight * rpxR - 321;
        console.log(calc)
        that.setData({
          winHeight: calc,
          viewHeight: viewcalc
        });
      }
    });
    //获取文章类型
    wx.request({
      url: artcleTypeUrl,
      header: {
        "Content-Type": "application/x-www-form-urlencoded"
      },
      method: 'POST',
      success: function(res) {
        console.log(res.data)
        var Atype = res.data.rows;
        tempArray = res.data.rows;
        if (res.data.rows.length > 0) {
          for(var i=0;i<res.data.rows.length;i++){
            Atype[i].sort=i;
          }
          that.setData({
            artcleType: Atype
          })
          // console.log("Atype");
          // console.log(Atype);
        }

        
      }
    })

  },
  footerTap: app.footerTap,

  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function() {
    var that = this;
    // 获取文章列表
    wx.request({
      url: artcleUrl,
      header: {
        "Content-Type": "application/x-www-form-urlencoded"
      },
      method: 'POST',
      success: function (res) {
        console.log(res.data.rows);
        for (var i = 0; i < res.data.rows.length; i++) {
          var t = res.data.rows[i].JSON_imgs.split(';');
          res.data.rows[i].JSON_mainimg = res.data.rows[i].JSON_imgs == '' ? '../image/img_null.png' : app.globalData.url + t[0];
        }
        that.setData({
          artcle: res.data.rows
        })
        console.log(that.data.artcle);
        //匹配类型
        var artcleTemp = new Array();
        for (var i = 0; i < that.data.artcleType.length; i++) {
          var temp = new Array();
          for (var j = 0; j < that.data.artcle.length; j++) {
            if (that.data.artcleType[i].JSON_id == that.data.artcle[j].JSON_type)
              temp.push(that.data.artcle[j])
          }
          artcleTemp.push(temp);
        }
        console.log(artcleTemp[0])
        that.setData({
          artcle: artcleTemp
        })
      }
    })

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