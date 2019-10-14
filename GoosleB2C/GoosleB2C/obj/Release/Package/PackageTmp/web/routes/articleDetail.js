var dbs = require("../dbs");
var express = require('express');
var router = express.Router();//创建了一个路由模块
const querystring = require("querystring");

router.get('/:id', function(req, res, next) {
    // const c = {
    //     'title': 'Express',
    //     'name': 'haha',
    //     'id':'1234',
    //     "img":"/UpLoadImg/2018/7/7c7aa71f-0d0a-485e-a6a1-c47e04455a08_%E8%AF%A6%E5%9B%BE_01044.jpg"
    // }
    const id = req.params.id;
    // 这里做了修改，改变了url中获取id的方式
    // const id = req.query.id;
    dbs.getArticleDetail(function(data){
        const result = JSON.parse(data);
        //console.log(result);
        const webDetails = result.rows[0].JSON_webcontent;
        const content = querystring.unescape(webDetails);
        result.rows[0].JSON_webcontent = content;
        console.log(webDetails);
        res.render('articleDetail',result);
        //next();
        res.end();
    },id);
    // res.render('articleDetail',c);
});

module.exports = router;