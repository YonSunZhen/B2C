var dbs = require("../dbs");
var express = require('express');
var router = express.Router();//创建了一个路由模块

router.get('/', function(req, res, next) {
    dbs.getProducts(function(data){
        const products = JSON.parse(data);
        res.render('product',products);
    })
});

router.get('/page/',function(req, res, next){
    const start = req.query.start;
    const end = req.query.end;
    dbs.getProductsByPage(function(data){
        const products = JSON.parse(data);
        res.render('product',products);
        //res.json(products);
    },start,end)
})


router.get('/tree/', function(req, res, next) {
    const id = req.query.id;
    dbs.getProductsByType(function(data){
        const products = JSON.parse(data);
        res.json(products);  
    },id)
});

router.get('/searchProduct/', function(req, res, next) {
  const name = req.query.name;
  dbs.getProductByName(function(data){
      const products = JSON.parse(data);
      res.json(products);  
  },name)
});

module.exports = router;