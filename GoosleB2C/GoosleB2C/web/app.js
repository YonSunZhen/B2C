var createError = require('http-errors');
var express = require('express');
var path = require('path');
var cookieParser = require('cookie-parser');
var logger = require('morgan');
var dbs = require('./dbs');
const querystring = require("querystring");

var indexRouter = require('./routes/index');
var companyRouter = require('./routes/companyInfo');
var articleRouter = require('./routes/article');
var articleDetailRouter = require('./routes/articleDetail');
var productRouter = require('./routes/product');
var productDetailRouter = require('./routes/productDetail');
var successCaseRouter = require('./routes/successCase');
var successDetailRouter = require('./routes/successDetail');
var contactRouter = require('./routes/contact');
var messageRouter = require('./routes/message');


var app = express();//创建一个express实例
app.locals.link = "http://localhost:12238";//设置外部接口全局变量的主机名
app.locals.host = "http://localhost:3000";//内部网站的链接
app.locals.left = {};
app.locals.index = {};
app.locals.headerFooter = {};
//获得left.ejs,header.ejs,footer.ejs的数据
app.use(function (req, res, next) {
  dbs.getTitle(function(data){ 
    const article = JSON.parse(data);
    app.locals.left.articles = new Array();
    for(let i = 0; i < 6; i++){
      app.locals.left.articles.push({
        name: article.rows[i].JSON_title,
        id: article.rows[i].JSON_id
      });
    }
  }) 
  next();  
},function(req, res, next){
dbs.getCompanyContact(function(data){
    const contact = JSON.parse(data);
    app.locals.left.contacts = new Array();
    // app.locals.left.contacts.push({
    //     name: contact.rows[0].JSON_name,
    //     address: contact.rows[0].JSON_address,
    //     phone: contact.rows[0].JSON_phone,
    //     email: contact.rows[0].JSON_email
    // })
    app.locals.left.contacts = contact.rows;
  })
  next();
},function(req, res, next){
  dbs.getHeaderFooter(function(data){
    const indexInfo = JSON.parse(data);
    const bottom = indexInfo.rows[0].JSON_bottominfo;
    indexInfo.rows[0].JSON_bottominfo = querystring.unescape(bottom);
    //app.locals.headerFooter.indexInfos = new Array();
    app.locals.headerFooter.logo = indexInfo.rows[0].JSON_logo;
    app.locals.headerFooter.bottomContent = indexInfo.rows[0].JSON_bottominfo;
    app.locals.headerFooter.seoKey = indexInfo.rows[0].JSON_seokey;
    app.locals.headerFooter.seoDescribe = indexInfo.rows[0].JSON_seodescribe;
  })
  next();
},function(req, res, next){
  dbs.getArticleType(function(data){
    const articleType = JSON.parse(data);
    app.locals.headerFooter.articleTypes = new Array();
    app.locals.headerFooter.articleTypes = articleType.rows;
    // for(let i = 0; i < articleType.rows.length; i++){
    //   app.locals.headerFooter.articleTypes.push({
    //     id:articleType.rows[i].JSON_id,
    //     name:articleType.rows[i].JSON_typename
    //   });
    // }
  })
  next();
});

//获取成功案例的长度
app.use('/successCase',function(req, res, next){
  dbs.getSuccessCases(function(data){
    const success = JSON.parse(data);
    app.locals.successLength = success.rows.length;
    app.locals.successCase = success.rows;
  })
  next();
})
app.use('/successCase/page/',function(req, res, next){
  dbs.getSuccessCases(function(data){
    const success = JSON.parse(data);
    app.locals.successLength = success.rows.length;
    app.locals.successCase = success.rows;
  })
  next();
})
//获得产品的长度
app.use('/product',function(req, res, next){
  dbs.getProducts(function(data){
    const product = JSON.parse(data);
    app.locals.productLength = product.rows.length;
  })
  next();
})

app.use('/product/page/',function(req, res, next){
  dbs.getProducts(function(data){
    const product = JSON.parse(data);
    app.locals.productLength = product.rows.length;
  })
  next();
})

//获取index.ejs的部分数据
app.use('/',function(req, res, next){
  dbs.getDetails(function(data){
    const detail = JSON.parse(data);
    app.locals.index.companyDetail = detail.rows[0].JSON_details;
    app.locals.index.detailImg = detail.rows[0].JSON_mainimg;
  })
  next();
},function(req, res, next){
  dbs.getTitle(function(data){
    const article = JSON.parse(data);
    app.locals.index.articles = new Array();
    for(let i = 0; i < 8; i++){
      app.locals.index.articles.push({
        id: article.rows[i].JSON_id,
        name: article.rows[i].JSON_title,
        time: article.rows[i].JSON_createtime.trim().split(/\s+/)[0] 
      });
    }
  });
  next();
},function(req, res, next){
  dbs.getLinks(function(data){
    const link = JSON.parse(data);
    app.locals.index.links = new Array();
    for(let i = 0; i < link.rows.length; i++){
      app.locals.index.links.push({
        name: link.rows[i].JSON_linkname,
        url: link.rows[i].JSON_url,
        tag: link.rows[i].JSON_tags
      });
    }
  })
  next();
},function(req, res, next){
  dbs.getBrand(function(data){
    const brand = JSON.parse(data);
    //app.locals.index.brands = new Array();
    app.locals.index.img1 = brand.rows[0].JSON_img1;
    app.locals.index.img2 = brand.rows[0].JSON_img2;
    app.locals.index.img3 = brand.rows[0].JSON_img3;
    app.locals.index.url1 = brand.rows[0].JSON_url1;
    app.locals.index.url2 = brand.rows[0].JSON_url2;
    app.locals.index.url3 = brand.rows[0].JSON_url3;
    // app.locals.index.brands.push({
    //   img1 : brand.rows[0].JSON_img1,
    //   img2 : brand.rows[0].JSON_img2,
    //   img3 : brand.rows[0].JSON_img3,
    //   url1 : brand.rows[0].JSON_url1,
    //   url2 : brand.rows[0].JSON_url2,
    //   url3 : brand.rows[0].JSON_url3
    // });
  })
  next();
})



// 设置模板引擎（必须）
app.set('views', path.join(__dirname, 'views')); //设置存放模板文件的目录
app.set('view engine', 'ejs');//指定模板引擎扩展名的省略

app.use(logger('dev'));
app.use(express.json());
app.use(express.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(express.static(path.join(__dirname, 'public')));

//app.use(express.static('public'));//express.static中间件访问静态资源

app.use('/', indexRouter);//加载路由模块
app.use('/companyInfo',companyRouter);
app.use('/article',articleRouter);
app.use('/articleDetail',articleDetailRouter);
app.use('/product',productRouter);
app.use('/productDetail',productDetailRouter);
app.use('/successCase',successCaseRouter);
app.use('/successDetail',successDetailRouter);
app.use('/contact',contactRouter);
app.use('/message',messageRouter);


// catch 404 and forward to error handler
app.use(function(req, res, next) {
  next(createError(404));
});

// error handler
app.use(function(err, req, res, next) {
  // set locals, only providing error in development
  res.locals.message = err.message;
  res.locals.error = req.app.get('env') === 'development' ? err : {};

  // render the error page
  res.status(err.status || 500);
  res.render('error');
});


var debug = require('debug')('web:server');
var http = require('http');

/**
 * Get port from environment and store in Express.
 */

var port = normalizePort(process.env.PORT || '3000');
app.set('port', port);

/**
 * Create HTTP server.
 */

var server = http.createServer(app);

/**
 * Listen on provided port, on all network interfaces.
 */

server.listen(port);
server.on('error', onError);
server.on('listening', onListening);

/**
 * Normalize a port into a number, string, or false.
 */

function normalizePort(val) {
  var port = parseInt(val, 10);

  if (isNaN(port)) {
    // named pipe
    return val;
  }

  if (port >= 0) {
    // port number
    return port;
  }

  return false;
}

/**
 * Event listener for HTTP server "error" event.
 */

function onError(error) {
  if (error.syscall !== 'listen') {
    throw error;
  }

  var bind = typeof port === 'string'
    ? 'Pipe ' + port
    : 'Port ' + port;

  // handle specific listen errors with friendly messages
  switch (error.code) {
    case 'EACCES':
      console.error(bind + ' requires elevated privileges');
      process.exit(1);
      break;
    case 'EADDRINUSE':
      console.error(bind + ' is already in use');
      process.exit(1);
      break;
    default:
      throw error;
  }
}

/**
 * Event listener for HTTP server "listening" event.
 */

function onListening() {
  var addr = server.address();
  var bind = typeof addr === 'string'
    ? 'pipe ' + addr
    : 'port ' + addr.port;
  debug('Listening on ' + bind);
}


module.exports = app;

