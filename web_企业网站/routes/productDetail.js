var dbs = require("../dbs");
var express = require('express');
var router = express.Router();//创建了一个路由模块
const querystring = require("querystring");

// router.get('/', function(req, res, next) {
//   const id = req.params.id;
//   console.log(id);
//   dbs.getOneProduct(function(data){
//     const result = JSON.parse(data);
//     //console.log(result);
//     const webDetails = result.rows[0].JSON_webdetails;
//     const content = querystring.unescape(webDetails);
//     result.rows[0].JSON_webdetails = content;
//     //console.log(webDetails);
//     res.render('productDetail',result);
//     //next();
//     // res.end();
//   },id);
// });

router.get('/:id', function(req, res, next) {
    const id = req.params.id;
    console.log(id);
    dbs.getOneProduct(function(data){
      const result = JSON.parse(data);
      //console.log(result);
      const webDetails = result.rows[0].JSON_webdetails;
      const content = querystring.unescape(webDetails);
      result.rows[0].JSON_webdetails = content;
      //console.log(webDetails);
      res.render('productDetail',result);
      //next();
      // res.end();
    },id);
});

// router.get('/tree/', function(req, res, next) {
//   const id = req.query.id;
//   dbs.getProductsByType(function(data){
//       const products = JSON.parse(data);
//       res.json(products);  
//   },id)
// });

module.exports = router;