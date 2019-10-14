var dbs = require("../dbs");
var express = require('express');
var router = express.Router();//创建了一个路由模块
// global.successResult1 = new Object();
let successResult1 = new Object();
let successResult2 = new Object();


router.get('/', function(req, res, next) {
    dbs.getSuccessCases(function(data){
        let success = JSON.parse(data);
        for(let i = 0;i < success.rows.length; i++){
            success.rows[i].JSON_createtime = success.rows[i].JSON_createtime.trim().split(/\s+/)[0];
        }
        //successResult1.successAll = new Array();
        // for(let i = 0; i < success.rows.length; i++){
        //     successResult1.successAll.push({
        //         id     : success.rows[i].JSON_id,
        //         mainImg: success.rows[i].JSON_mainimg,
        //         summary: success.rows[i].JSON_summay,
        //         title  : success.rows[i].JSON_title,
        //         time   : success.rows[i].JSON_createtime.trim().split(/\s+/)[0]
        //     });
        // };
        res.render('successCase',success);
    });
});

router.get('/page/',function(req, res, next){ 
    const start = req.query.start;
    const end = req.query.end;
    dbs.getSuccessByPage(function(data){
        let success = JSON.parse(data);
        for(let i = 0;i < success.rows.length; i++){
            success.rows[i].JSON_createtime = success.rows[i].JSON_createtime.trim().split(/\s+/)[0];
        }
        res.render('successCase',success);
    },start,end);  
})

module.exports = router;