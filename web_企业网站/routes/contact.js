var express = require('express');
var router = express.Router();
var dbs = require('../dbs');
const querystring = require("querystring");

/* GET home page. */
router.get('/', function(req, res, next) {
  const id = 4;
  console.log(id);
  dbs.getCompanyInfo(function(data){
    const result = JSON.parse(data);
    //console.log(result);
    const webDetails = result.rows[0].JSON_webdetails;
    const content = querystring.unescape(webDetails);
    result.rows[0].JSON_webdetails = content;
    console.log(webDetails);
    res.render('contact',result);
    //next();
    // res.end();
  },id);
    // res.render('companyInfo', { title: 'Express' });
});

module.exports = router;