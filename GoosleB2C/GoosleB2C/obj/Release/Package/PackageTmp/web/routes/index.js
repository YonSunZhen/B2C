var dbs = require("../dbs");
var express = require('express');
var router = express.Router();//创建了一个路由模块
const querystring = require("querystring");
let indexResult = new Object();

/* GET home page. */
router.get('/',function(req, res, next){
  dbs.getProducts(function(data){
    const product = JSON.parse(data);
    indexResult.products = new Array();
    for(let i = 0; i < 6; i++){
      indexResult.products.push({
        title: product.rows[i].JSON_title,
        price: product.rows[i].JSON_price,
        mainImg: product.rows[i].JSON_img1,
        id: product.rows[i].JSON_pid
      });
    }
    res.render('index',indexResult);
  });
})
  

  

module.exports = router;
