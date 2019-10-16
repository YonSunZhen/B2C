/* GET users listing. */
var dbs = require("../dbs");
var express = require('express');
var router = express.Router();//创建了一个路由模块
//global.leftResult = new Object();

/* GET home page. */
router.get('/', function(req, res, next) {
    const c = {
        'title': 'Express',
        'name': 'haha',
        'id':'1234',
        "img":"/UpLoadImg/2018/7/7c7aa71f-0d0a-485e-a6a1-c47e04455a08_%E8%AF%A6%E5%9B%BE_01044.jpg"
    }
    res.render('message',c);
    
});

module.exports = router;