var dbs = require("../dbs");
var express = require('express');
var router = express.Router();//创建了一个路由模块
var articleResult1 = new Object();
var articleResult2 = new Object();
var articleResult3 = new Object();
var articleResult4 = new Object();

router.get('/', function(req, res, next) {
    dbs.getTitle(function(data){
        const article = JSON.parse(data);
        articleResult1.articleAll = new Array();
        //global.indexResult.time = [];
        //暂时只取到18条数据
        for(let i = 0; i < 18; i++){
            articleResult1.articleAll.push({
                id: article.rows[i].JSON_id,
                name: article.rows[i].JSON_title,
                time: article.rows[i].JSON_createtime.trim().split(/\s+/)[0] 
            });
        };
        res.render('article',articleResult1);
    });
    
});

router.get('/page/', function(req, res, next) {
    const start = req.query.start;
    const end = req.query.end;
    dbs.getArticleByPage(function(data){
        const article = JSON.parse(data);
        articleResult2.articleAll = new Array();
        for(let i = 0; i < article.rows.length; i++){
            //取到标题的前20个字符
            if(article.rows[i].JSON_title.length <= 20){
                article.rows[i].JSON_title = article.rows[i].JSON_title;
            }else{
                article.rows[i].JSON_title = article.rows[i].JSON_title.substr(0,20) + '...';
            }
            articleResult2.articleAll.push({
                id: article.rows[i].JSON_id,
                name: article.rows[i].JSON_title,
                time: article.rows[i].JSON_createtime.trim().split(/\s+/)[0] 
            });
        }
        res.render('article',articleResult2);
    },start,end)
     
    //next();
});
//获取文章总数
router.get('/total', function(req, res, next) {
    dbs.getTitle(function(data){
        const article = JSON.parse(data);
        res.json(article);
    });
    
});

//根据文章类型获取文章总数
router.get('/totalByType/', function(req, res, next) {
    const id = req.query.id;
    dbs.getTitleByType(function(data){
        const article = JSON.parse(data);
        res.json(article);
    },id);
    
});

router.get('/type/', function(req, res, next) {
    const id = req.query.id;
    dbs.getTitleByType(function(data){
        const article = JSON.parse(data);
        articleResult3.articleAll = new Array();
        //global.indexResult.time = [];
        //暂时只取到18条数据
        for(let i = 0; i < article.rows.length; i++){
            articleResult3.articleAll.push({
                id: article.rows[i].JSON_id,
                name: article.rows[i].JSON_title,
                time: article.rows[i].JSON_createtime.trim().split(/\s+/)[0] 
            });
        };
        res.render('article',articleResult3);
    },id);   
});

router.get('/typePage/', function(req, res, next) {
    const id = req.query.id;
    const start = req.query.start;
    const end = req.query.end;
    dbs.getTitleByPageAndType(function(data){
        const article = JSON.parse(data);
        articleResult4.articleAll = new Array();
        for(let i = 0; i < article.rows.length; i++){
            //取到标题的前20个字符
            if(article.rows[i].JSON_title.length <= 20){
                article.rows[i].JSON_title = article.rows[i].JSON_title;
            }else{
                article.rows[i].JSON_title = article.rows[i].JSON_title.substr(0,20) + '...';
            }
            articleResult4.articleAll.push({
                id: article.rows[i].JSON_id,
                name: article.rows[i].JSON_title,
                time: article.rows[i].JSON_createtime.trim().split(/\s+/)[0] 
            });
        }
        res.render('article',articleResult4);
    },id,start,end)
     
    //next();
});

module.exports = router;