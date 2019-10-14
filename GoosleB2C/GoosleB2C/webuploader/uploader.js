var arry = [];
//var webuploader;
var uploadBtnArry = [];
$(function () {
    //初始化绑定默认的属性
    $.upLoadDefaults = $.upLoadDefaults || {};
    $.upLoadDefaults.property = {
        multiple: false, //是否多文件
        water: false, //是否加水印
        thumbnail: false, //是否生成缩略图
        sendurl: null, //发送地址
        filetypes: "jpg,jpeg,png,gif,bmp", //文件类型
        filesize: "5120", //文件大小(每张图片的最大尺寸，单位:M)
        btntext: "点击上传", //上传按钮的文字
        swf: "/webuploader/uploader.swf" //SWF上传控件相对地址
    };
    //初始化上传控件
    $.fn.InitUploader = function (b) {
        var fun = function (parentObj) {
             var p = $.extend({}, $.upLoadDefaults.property, b || {});
            var btnObj = $('<div class="upload-btn">' + p.btntext + '</div>').appendTo(parentObj);
            //初始化属性           
            p.sendurl += "?action=UpLoadFile";
            if (p.water) {
                p.sendurl += "&IsWater=1";
            }
            if (p.thumbnail) {
                p.sendurl += "&IsThumbnail=1";
            }
            //if (!p.multiple) {
            //    p.sendurl += "&DelFilePath=" + parentObj.siblings(".upload-path").val();
            //}

            //初始化WebUploader
            var uploader = WebUploader.create({
                auto: true, //自动上传
                swf: p.swf, //SWF路径
                server: p.sendurl, //上传地址
                pick: {
                    id: btnObj,
                    multiple: p.multiple
                },
                accept: {
                    /*title: 'Images',*/
                    extensions: p.filetypes
                    /*mimeTypes: 'image/*'*/
                },
                formData: {
                	'DelFilePath': '', //定义参数
                	url: '算定义参数'
                },
                fileVal: 'Filedata', //上传域的名称
                fileSingleSizeLimit: p.filesize * 1024 //文件大小
            });

            //webuploader = uploader;
            uploadBtnArry.push(uploader);

            //当validate不通过时，会以派送错误事件的形式通知
            uploader.on('error', function (type) {
                switch (type) {
                    case 'Q_EXCEED_NUM_LIMIT':
                        alert("错误：上传文件数量过多！");
                        break;
                    case 'Q_EXCEED_SIZE_LIMIT':
                        alert("错误：文件总大小超出限制！");
                        break;
                    case 'F_EXCEED_SIZE':
                        alert("错误：部分文件大小超出5M！");
                        break;
                    case 'Q_TYPE_DENIED':
                        alert("错误：禁止上传该类型文件！");
                        break;
                    case 'F_DUPLICATE':
                        alert("错误：请勿重复上传该文件！");
                        break;
                    default:
                        alert('错误代码：' + type);
                        break;
                }
            });


           



            //当有文件添加进来的时候
            uploader.on('fileQueued', function (file) {
                //如果是单文件上传，把旧的文件地址传过去
                if (!p.multiple) {
                	uploader.options.formData.DelFilePath = parentObj.siblings(".upload-path").val(); 
                }
				//是否生成缩略图
                if (!p.thumbnail) {                	
                    //uploader.options.formData.thumbnail = $('#chkThumb').is(':checked');
                    uploader.options.formData.thumbnail = true;
                    //上传图片的大小
                    uploader.options.formData.width = p.width;
                    uploader.options.formData.height = p.height;
                    uploader.options.formData.Logo_brand = p.Logo_brand;
                    uploader.options.formData.waterMarkType = p.waterMarkType;
                    uploader.options.formData.waterMarkPosition = p.waterMarkPosition;
                    uploader.options.formData.waterMarkContent = p.waterMarkContent;
                    uploader.options.formData.waterMarkPicture = p.waterMarkPicture;
                    uploader.options.formData.waterMarkTransparency = p.waterMarkTransparency;
                }                
                //防止重复创建
                if (parentObj.children(".upload-progress").length == 0) {
                    //创建进度条
                    var fileProgressObj = $('<div class="upload-progress"></div>').appendTo(parentObj);
                    var progressText = $('<span class="txt">正在上传，请稍候...</span>').appendTo(fileProgressObj);
                    var progressBar = $('<span class="bar"><b></b></span>').appendTo(fileProgressObj);
                    var progressCancel = $('<a class="close" title="取消上传">关闭</a>').appendTo(fileProgressObj);
                    //绑定点击事件
                    progressCancel.click(function () {
                        uploader.cancelFile(file);
                        fileProgressObj.remove();
                    });
                }
            });

            //文件上传过程中创建进度条实时显示
            uploader.on('uploadProgress', function (file, percentage) {
                var progressObj = parentObj.children(".upload-progress");
                progressObj.children(".txt").html(file.name);
                progressObj.find(".bar b").width(percentage * 100 + "%");
            });

            //当文件上传出错时触发
            uploader.on('uploadError', function (file, reason) {
                uploader.removeFile(file); //从队列中移除
                alert(file.name + "上传失败，错误代码：" + reason);
            });

            //当文件上传成功时触发
            uploader.on('uploadSuccess', function (file, data) {             
                if (data.status == '0') {
                    var progressObj = parentObj.children(".upload-progress");
                    progressObj.children(".txt").html(data.msg);
                }
                if (data.status == '1') {
                    //如果是单文件上传，则赋值相应的表单
                    if (!p.multiple) {
                        if (parentObj.siblings("a")) {
                            parentObj.siblings("a").remove();
                        }
                        //parentObj.siblings(".photo-one").children("ul").children("li").remove();
                        //var a_del = $('<li class="fl">' + '<input type="hidden" name="hid_photo_name" value="' + data.path + '|' + data.thumb + '" />' + '<img id="imageurl" class="upload-imgurl" />' + '<a href="javascript:;" onclick="delImg(this);">删除</a>' + '</li>');
                        var a_del = $('<a href="javascript:;" onclick="delImg_(this);"><img src="/UpLoadImg/a7.png" class="delete" /></a>');
                        var Input = $('<input type="hidden" class="hidden-src" name="hid_photo_name" value="' + data.path + '|' + data.thumb + '" />');
                        //parentObj.siblings(".photo-one").children("ul").children("li").children(".upload-imgurl").attr("src", data.thumb);
                        parentObj.siblings(".upload-name").val(data.name);                       
                        parentObj.siblings(".upload-size").val(data.size);                    
                        parentObj.siblings(".upload-path").val(data.path);
                        parentObj.siblings(".imgDiv").children(".upload-imgurl").attr("src", data.thumb);
                        //parentObj.siblings(".upload-imgurl").attr("src", data.thumb);
                        a_del.appendTo(parentObj.siblings(".imgDiv"));
                        Input.appendTo(parentObj.parent());
                    } else {
                        addImage(parentObj, data.path, data.thumb);
                    }
                    var progressObj = parentObj.children(".upload-progress");
                    //progressObj.children(".txt").html("上传成功：" + file.name);
                }
                uploader.removeFile(file); //从队列中移除
            });

            //不管成功或者失败，文件上传完成时触发
            uploader.on('uploadComplete', function (file) {
                var progressObj = parentObj.children(".upload-progress");
                progressObj.children(".txt").html("上传完成");
                //如果队列为空，则移除进度条
                if (uploader.getStats().queueNum == 0) {
                    progressObj.remove();
                }
            });
        };
        return $(this).each(function () {
            fun($(this));
        });
    }
});

/*图片相册处理事件
=====================================================*/
//添加图片相册
function addImage(targetObj, originalSrc, thumbSrc) {
    //插入到相册UL里面
    var newLi = $('<li class="fl">'
    + '<img id="imagelist" class="imgage-list" src="' + thumbSrc + '"/>'
    + '<input type="hidden" class="hidden-src" name="hid_photo_name" value="' + originalSrc + '|' + thumbSrc + '" />'
    //+ '<input type="hidden" name="hid_photo_remark" value="" />'
    //+ '<div class="img-box" onclick="setFocusImg(this);">'
    //+ '<img src="' + thumbSrc + '" bigsrc="' + originalSrc + '" />'
    //+ '<span class="remark"><i>暂无描述...</i></span>'
    //+ '</div>'
    //+ '<a href="javascript:;" onclick="setRemark(this);">描述</a>'
    + '<a href="javascript:;" onclick="delImg(this);"><img src="/UpLoadImg/a7.png" class="delete" /></a>'
    + '</li>');
    //targetObj.siblings(".photo-list").children("ul").children(".fl_").remove();
    newLi.appendTo(targetObj.siblings(".photo-list").children("ul"));
    pre_delImg();

    //默认第一个为相册封面
    var focusPhotoObj = targetObj.siblings(".focus-photo");
    if (focusPhotoObj.val() == "") {
        focusPhotoObj.val(thumbSrc);
        newLi.children(".img-box").addClass("selected");
    }
}
//设置相册封面
function setFocusImg(obj) {
    var focusPhotoObj = $(obj).parents(".photo-list").siblings(".focus-photo");
    focusPhotoObj.val($(obj).children("img").eq(0).attr("src"));
    $(obj).parent().siblings().children(".img-box").removeClass("selected");
    $(obj).addClass("selected");
}
//设置图片描述
function setRemark(obj) {
    var parentObj = $(obj); //父对象
    var hidRemarkObj = parentObj.prevAll("input[name='hid_photo_remark']").eq(0); //取得隐藏值
    var d = parent.dialog({
        title: "图片描述",
        content: '<textarea id="ImageRemark" style="margin:10px 0;font-size:12px;padding:3px;color:#000;border:1px #d2d2d2 solid;vertical-align:middle;width:300px;height:50px;">' + hidRemarkObj.val() + '</textarea>',
        button: [{
            value: '批量描述',
            callback: function () {
                var remarkObj = $('#ImageRemark', parent.document);
                if (remarkObj.val() == "") {
                    parent.dialog({
                        title: '提示',
                        content: '亲，总该写点什么吧？',
                        okValue: '确定',
                        ok: function () { },
                        onclose: function(){
                            remarkObj.focus();
                        }
                    }).showModal();
                    return false;
                }
                parentObj.parent().parent().find("li input[name='hid_photo_remark']").val(remarkObj.val());
                parentObj.parent().parent().find("li .img-box .remark i").html(remarkObj.val());
            }
        }, {
            value: '单张描述',
            callback: function () {
                var remarkObj = $('#ImageRemark', parent.document);
                if (remarkObj.val() == "") {
                    parent.dialog({
                        title: '提示',
                        content: '亲，总该写点什么吧？',
                        okValue: '确定',
                        ok: function () { },
                        onclose: function () {
                            remarkObj.focus();
                        }
                    }).showModal();
                    return false;
                }
                hidRemarkObj.val(remarkObj.val());
                parentObj.siblings(".img-box").children(".remark").children("i").html(remarkObj.val());
            },
            autofocus: true
        }]
    }).showModal();
}
//删除图片LI节点
function delImg(obj) {
    var parentObj = $(obj).parent().parent();
    var focusPhotoObj = parentObj.parent().siblings(".focus-photo");
    var smallImg = $(obj).siblings(".img-box").children("img").attr("src");
    //获得删除的图片
    var names = $(obj).siblings(".hidden-src").val();
    var oriSrc = names.split("|")[0];
    var thumbSrc = names.split("|")[1];    
    arry.push(oriSrc, thumbSrc);    
    $(obj).parent().remove(); //删除的LI节点                  
    //检查是否为封面
    if (focusPhotoObj.val() == smallImg) {
        focusPhotoObj.val("");
        var firtImgBox = parentObj.find("li .img-box").eq(0); //取第一张做为封面
        firtImgBox.addClass("selected");
        focusPhotoObj.val(firtImgBox.children("img").attr("src")); //重新给封面的隐藏域赋值
    }
}
function delImg_(obj) {
    //获得删除的图片
    var names = $(obj).parent().siblings(".hidden-src").val();
    var oriSrc = names.split("|")[0];
    var thumbSrc = names.split("|")[1];
    arry.push(oriSrc, thumbSrc);
    $(obj).siblings(".upload-imgurl").removeAttr("src");
    $(obj).parent().siblings("input").val("");
    $(obj).parent().siblings(".hidden-src").remove();
    $(obj).remove();
}
function Del() {
    for (var i = 0; i < arry.length - 1;) {
        del_ajax(arry[i], arry[i + 1]);
        i += 2;
    }
}
function Del_() {
    for (var i = 0; i < arry.length - 1;) {
        del_ajax(arry[i], arry[i + 1]);
        del_ajax(arry[i + 1] + '_1.jpg', arry[i + 1] + '_2.jpg');
        i += 2;
    }
}
function Del_pro() {
    for (var i = 0; i < arry.length - 1;) {
        //del_ajax(arry[i], arry[i + 1]);
        del_ajax(arry[i + 1], arry[i + 1] + '_400.jpg');
        del_ajax(arry[i + 1] + '_200.jpg', arry[i + 1] + '_60.jpg');
        //del_ajax(arry[i + 1] + '_400.jpg', arry[i + 1] + '_60.jpg');
        i += 2;
    }
}
function del_ajax(a, b) {
    $.ajax({
        url: "/webuploader/cs_ashx/ajax.ashx?action=delImg&oriSrc=" + a + "&thumbSrc=" + b,
        type: "GET",
        async: false,
        success: function (result) {
            var result = eval("(" + result + ")");
            console.log(result);
        }
    });
}
//显示隐藏图片右上角的叉img
function pre_delImg() {
    $(".fl").mouseenter(function () {
        $(this).find(".delete").show();
    });
    $(".fl").mouseleave(function () {
        $(this).find(".delete").hide();
    });
}