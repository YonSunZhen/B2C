var dbs = require("../dbs");
var express = require('express');
var router = express.Router();//创建了一个路由模块
const querystring = require("querystring");

router.get('/:id', function(req, res, next) {
    const id = req.params.id;
    dbs.getSuccessDetail(function(data){
        const detail = JSON.parse(data);
        const webContent= detail.rows[0].JSON_webcontent;
        const content = querystring.unescape(webContent);
        detail.rows[0].JSON_webcontent = content;
        res.render('successDetail',detail);
    },id)
    //res.render('successDetail',c);
});

module.exports = router;