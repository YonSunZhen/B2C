var express = require('express');
var router = express.Router();
var dbs = require('../dbs');
const querystring = require("querystring");

/* GET home page. */
router.get('/:id', function(req, res, next) {
  const id = req.params.id;
  console.log(id);
  dbs.getCompanyInfo(function(data){
    const result = JSON.parse(data);
    //console.log(result);
    const webDetails = result.rows[0].JSON_webdetails;
    const content = querystring.unescape(webDetails);
    result.rows[0].JSON_webdetails = content;
    console.log(webDetails);
    res.render('companyInfo',result);
    //next();
    // res.end();
  },id);
    // res.render('companyInfo', { title: 'Express' });
});

module.exports = router;