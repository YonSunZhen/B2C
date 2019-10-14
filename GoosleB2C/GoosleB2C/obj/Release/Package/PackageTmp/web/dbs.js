var http = require('http');
const link = "http://localhost:12238";

module.exports = {
    
    //首页企业简介展示
    getDetails: function (cb) {
        http.get(link+'/back/WebSer.asmx/GetDetails', function (res) {
            res.setEncoding('utf8');
            var rawData = '';
            res.on('data', function (chunk) {
                rawData += chunk;
            });
            res.on('end', function () {
                try {
                    const parsedData = JSON.parse(rawData);
                    const parsedData1 = JSON.parse(parsedData);
                    console.log(parsedData);
                    return cb(parsedData);//回调函数返回数据
                } catch (e) {
                console.error(e.message);
                    return cb('error');
                }
            });
        });
    },

    //获得公司信息
    getCompanyInfo: function (cb,id) {
        http.get(link+'/back/WebSer.asmx/GetCompanyInfo?id='+id, function (res) {
            res.setEncoding('utf8');
            var rawData = '';
            res.on('data', function (chunk) {
                rawData += chunk;
            });
            res.on('end', function () {
                try {
                    const parsedData = JSON.parse(rawData);
                    const parsedData1 = JSON.parse(parsedData);
                    console.log(parsedData);
                    return cb(parsedData);//回调函数返回数据
                } catch (e) {
                console.error(e.message);
                    return cb('error');
                }
            });
        });
    },
    //首页新闻列表展示
    getTitle: function (cb) {
        http.get(link+'/back/WebSer.asmx/GetTitle', function (res) {
            res.setEncoding('utf8');
            var rawData = '';
            res.on('data', function (chunk) {
                rawData += chunk;
            });
            res.on('end', function () {
                try {
                    const parsedData = JSON.parse(rawData);
                    const parsedData1 = JSON.parse(parsedData);
                    console.log(parsedData);
                    return cb(parsedData);//回调函数返回数据
                } catch (e) {
                console.error(e.message);
                    return cb('error');
                }
            });
        });
    },
    //首页跑马灯产品展示
    getProducts: function (cb) {
        http.get(link+'/back/WebSer.asmx/GetProducts', function (res) {
            res.setEncoding('utf8');
            var rawData = '';
            res.on('data', function (chunk) {
                rawData += chunk;
            });
            res.on('end', function () {
                try {
                    const parsedData = JSON.parse(rawData);
                    const parsedData1 = JSON.parse(parsedData);
                    console.log(parsedData);
                    return cb(parsedData);//回调函数返回数据
                } catch (e) {
                console.error(e.message);
                    return cb('error');
                }
            });
        });
    },

    //首页友情链接展示
    getLinks: function (cb) {
        http.get(link+'/back/WebSer.asmx/GetLinks', function (res) {
            res.setEncoding('utf8');
            var rawData = '';
            res.on('data', function (chunk) {
                rawData += chunk;
            });
            res.on('end', function () {
                try {
                    const parsedData = JSON.parse(rawData);
                    const parsedData1 = JSON.parse(parsedData);
                    console.log(parsedData);
                    return cb(parsedData);//回调函数返回数据
                } catch (e) {
                console.error(e.message);
                    return cb('error');
                }
            });
        });
    },

    //获得公司详细联系方式和地址
    getCompanyContact: function (cb) {
        http.get(link+'/back/WebSer.asmx/GetCompanyContact', function (res) {
            res.setEncoding('utf8');
            var rawData = '';
            res.on('data', function (chunk) {
                rawData += chunk;
            });
            res.on('end', function () {
                try {
                    const parsedData = JSON.parse(rawData);
                    const parsedData1 = JSON.parse(parsedData);
                    console.log(parsedData);
                    return cb(parsedData);//回调函数返回数据
                } catch (e) {
                console.error(e.message);
                    return cb('error');
                }
            });
        });
    },

    //根据产品id获得产品详情
    getOneProduct: function (cb,id) {
        http.get(link+'/back/WebSer.asmx/GetOneProduct?id='+id, function (res) {
            res.setEncoding('utf8');
            var rawData = '';
            res.on('data', function (chunk) {
                rawData += chunk;
            });
            res.on('end', function () {
                try {
                    const parsedData = JSON.parse(rawData);
                    const parsedData1 = JSON.parse(parsedData);
                    console.log(parsedData);
                    return cb(parsedData);//回调函数返回数据
                } catch (e) {
                console.error(e.message);
                    return cb('error');
                }
            });
        });
    },

    //根据文章id获得产品详情
    getArticleDetail: function (cb,id) {
        http.get(link+'/back/WebSer.asmx/GetArticleDetail?id='+id, function (res) {
            res.setEncoding('utf8');
            var rawData = '';
            res.on('data', function (chunk) {
                rawData += chunk;
            });
            res.on('end', function () {
                try {
                    const parsedData = JSON.parse(rawData);
                    const parsedData1 = JSON.parse(parsedData);
                    console.log(parsedData);
                    return cb(parsedData);//回调函数返回数据
                } catch (e) {
                console.error(e.message);
                    return cb('error');
                }
            });
        });
    },

    //获得分页文章
    getArticleByPage: function (cb,start,end) {
        http.get(link+'/back/WebSer.asmx/GetArticleByPage?start='+start+'&end='+end, function (res) {
            res.setEncoding('utf8');
            var rawData = '';
            res.on('data', function (chunk) {
                rawData += chunk;
            });
            res.on('end', function () {
                try {
                    const parsedData = JSON.parse(rawData);
                    const parsedData1 = JSON.parse(parsedData);
                    console.log(parsedData);
                    return cb(parsedData);//回调函数返回数据
                } catch (e) {
                console.error(e.message);
                    return cb('error');
                }
            });
        });
    },

    //获得成功案例
    getSuccessCases: function (cb) {
        http.get(link+'/back/WebSer.asmx/GetSuccessCases', function (res) {
            res.setEncoding('utf8');
            var rawData = '';
            res.on('data', function (chunk) {
                rawData += chunk;
            });
            res.on('end', function () {
                try {
                    const parsedData = JSON.parse(rawData);
                    const parsedData1 = JSON.parse(parsedData);
                    console.log(parsedData);
                    return cb(parsedData);//回调函数返回数据
                } catch (e) {
                console.error(e.message);
                    return cb('error');
                }
            });
        });
    },

    //根据id获得成功案例详情
    getSuccessDetail: function (cb,id) {
        http.get(link+'/back/WebSer.asmx/GetSuccessCaseById?id='+id, function (res) {
            res.setEncoding('utf8');
            var rawData = '';
            res.on('data', function (chunk) {
                rawData += chunk;
            });
            res.on('end', function () {
                try {
                    const parsedData = JSON.parse(rawData);
                    const parsedData1 = JSON.parse(parsedData);
                    console.log(parsedData);
                    return cb(parsedData);//回调函数返回数据
                } catch (e) {
                console.error(e.message);
                    return cb('error');
                }
            });
        });
    },

    //获得分页成功案例
    getSuccessByPage: function (cb,start,end) {
        http.get(link+'/back/WebSer.asmx/GetSuccessByPage?start='+start+'&end='+end, function (res) {
            res.setEncoding('utf8');
            var rawData = '';
            res.on('data', function (chunk) {
                rawData += chunk;
            });
            res.on('end', function () {
                try {
                    const parsedData = JSON.parse(rawData);
                    const parsedData1 = JSON.parse(parsedData);
                    console.log(parsedData);
                    return cb(parsedData);//回调函数返回数据
                } catch (e) {
                console.error(e.message);
                    return cb('error');
                }
            });
        });
    },

    //获得分页产品列表
    getProductsByPage: function (cb,start,end) {
        http.get(link+'/back/WebSer.asmx/GetProductsByPage?start='+start+'&end='+end, function (res) {
            res.setEncoding('utf8');
            var rawData = '';
            res.on('data', function (chunk) {
                rawData += chunk;
            });
            res.on('end', function () {
                try {
                    const parsedData = JSON.parse(rawData);
                    const parsedData1 = JSON.parse(parsedData);
                    console.log(parsedData);
                    return cb(parsedData);//回调函数返回数据
                } catch (e) {
                console.error(e.message);
                    return cb('error');
                }
            });
        });
    },

    //根据产品类型获取产品列表
    getProductsByType: function (cb,id) {
        http.get(link+'/back/WebSer.asmx/GetProductsByType?id='+id, function (res) {
            res.setEncoding('utf8');
            var rawData = '';
            res.on('data', function (chunk) {
                rawData += chunk;
            });
            res.on('end', function () {
                try {
                    const parsedData = JSON.parse(rawData);
                    const parsedData1 = JSON.parse(parsedData);
                    console.log(parsedData);
                    return cb(parsedData);//回调函数返回数据
                } catch (e) {
                console.error(e.message);
                    return cb('error');
                }
            });
        });
    },

    //根据产品类型获得分页产品列表
    getProductsByPage1: function (cb,id,start,end) {
        http.get(link+'/back/WebSer.asmx/GetProductsByPage1?id='+id+'&start='+start+'&end='+end, function (res) {
            res.setEncoding('utf8');
            var rawData = '';
            res.on('data', function (chunk) {
                rawData += chunk;
            });
            res.on('end', function () {
                try {
                    const parsedData = JSON.parse(rawData);
                    const parsedData1 = JSON.parse(parsedData);
                    console.log(parsedData);
                    return cb(parsedData);//回调函数返回数据
                 } catch (e) {
                console.error(e.message);
                    return cb('error');
                }
            });
        });
    },

    //根据文章类型id获得文章列表
    getTitleByType: function (cb,id) {
        http.get(link+'/back/WebSer.asmx/GetTitleByType?id='+id, function (res) {
            res.setEncoding('utf8');
            var rawData = '';
            res.on('data', function (chunk) {
                rawData += chunk;
            });
            res.on('end', function () {
                try {
                    const parsedData = JSON.parse(rawData);
                    const parsedData1 = JSON.parse(parsedData);
                    console.log(parsedData);
                    return cb(parsedData);//回调函数返回数据
                } catch (e) {
                console.error(e.message);
                    return cb('error');
                }
            });
        });
    },

    //根据文章类型id分页获得文章列表
    getTitleByPageAndType: function (cb,id,start,end) {
        http.get(link+'/back/WebSer.asmx/GetArticleByPageAndType?id='+id+'&start='+start+'&end='+end, function (res) {
            res.setEncoding('utf8');
            var rawData = '';
            res.on('data', function (chunk) {
                rawData += chunk;
            });
            res.on('end', function () {
                try {
                    const parsedData = JSON.parse(rawData);
                    const parsedData1 = JSON.parse(parsedData);
                    console.log(parsedData);
                    return cb(parsedData);//回调函数返回数据
                } catch (e) {
                console.error(e.message);
                    return cb('error');
                }
            });
        });
    },

    //获得首页轮播图(brand)
    getBrand: function (cb) {
        http.get(link+'/back/WebSer.asmx/GetBrand', function (res) {
            res.setEncoding('utf8');
            var rawData = '';
            res.on('data', function (chunk) {
                rawData += chunk;
            });
            res.on('end', function () {
                try {
                    const parsedData = JSON.parse(rawData);
                    const parsedData1 = JSON.parse(parsedData);
                    console.log(parsedData);
                    return cb(parsedData);//回调函数返回数据
                } catch (e) {
                console.error(e.message);
                    return cb('error');
                }
            });
        });
    },

    //获得头部和脚部信息
    getHeaderFooter: function (cb) {
        http.get(link+'/back/WebSer.asmx/GetHeaderFooter', function (res) {
            res.setEncoding('utf8');
            var rawData = '';
            res.on('data', function (chunk) {
                rawData += chunk;
            });
            res.on('end', function () {
                try {
                    const parsedData = JSON.parse(rawData);
                    const parsedData1 = JSON.parse(parsedData);
                    console.log(parsedData);
                    return cb(parsedData);//回调函数返回数据
                } catch (e) {
                console.error(e.message);
                    return cb('error');
                }
            });
        });
    },

    //获得文章类型
    getArticleType: function (cb) {
        http.get(link+'/back/WebSer.asmx/GetArticleType', function (res) {
            res.setEncoding('utf8');
            var rawData = '';
            res.on('data', function (chunk) {
                rawData += chunk;
            });
            res.on('end', function () {
                try {
                    const parsedData = JSON.parse(rawData);
                    const parsedData1 = JSON.parse(parsedData);
                    console.log(parsedData);
                    return cb(parsedData);//回调函数返回数据
                } catch (e) {
                console.error(e.message);
                    return cb('error');
                }
            });
        });
    }
}