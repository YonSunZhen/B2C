<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyContact.aspx.cs" Inherits="GoosleB2C.Web.Admin.CompanyInfo.CompanyContact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="/webuploader/smart-green.css" />
    <script src="/JS/easyUI/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="/JS/easyUI/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="/JS/easyUI/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <link href="/JS/easyUI/themes/gray/easyui.css" rel="stylesheet" type="text/css" /> 
    <link href="/JS/easyUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="/JS/wikmenu.js" type="text/javascript"></script>
    <script src="/JS/wikmain.js" type="text/javascript"></script>
    <title></title>
    <style>
        .edit_info{
            width:1060px;
            margin:auto;            
        }
        
        label{
            float:right;
            margin-left:14px;
            margin-top:14px;
            margin-bottom:14px;
        }
        .button {
            background: #79bbff;
            background-image: -webkit-linear-gradient(top, #79bbff, #378de5);
            background-image: -moz-linear-gradient(top, #79bbff, #378de5);
            background-image: -ms-linear-gradient(top, #79bbff, #378de5);
            background-image: -o-linear-gradient(top, #79bbff, #378de5);
            background-image: linear-gradient(to bottom, #79bbff, #378de5);
            -webkit-border-radius: 5;
            -moz-border-radius: 5;
            border-radius: 5px;
            text-shadow: 0px 1px 0px #528ecc;
            -webkit-box-shadow: 3px 4px 0px 0px #1564ad;
            -moz-box-shadow: 3px 4px 0px 0px #1564ad;
            box-shadow: 3px 4px 0px 0px #1564ad;
            font-family: Arial;
            color: #000000;
            font-size: 17px;
            border: solid #337bc4 1px;
            text-decoration: none;
        }
        .button:hover {
            color: #ffffff;
            background: #378de5;
            text-decoration: none;
        }
    </style>
</head>
<body>
    <form id="form_edit" name="form_edit" method="post" url="CompanyContact.aspx">
        <div style="font-size:30px;font-weight:bold;margin-top:13px;">
            公司联系方式管理
            <hr style="height:5px;border:none;border-top:1px solid #ffffff;" />                     
        </div>
        <div id="" class="edit_info">
            <div id="" class="title_Div">
                <span class="">公司名</span>
                <br />
                <input id="ipt_name" name="ipt_name" type="text" class="easyui-validatebox" required="true" />            
            </div>                        
            <div id="" class="other_Div">
                <span class="">地址</span>
                <br />
                <input id="ipt_address" name="ipt_address" type="text" />
            </div>
            <div id="" class="other_Div">
                <span class="">电话</span>
                <br />
                <input id="ipt_telephone" name="ipt_telephone" class="easyui-validatebox"
                          data-options="validType:'telephone'" />
            </div>
            <div id="" class="other_Div">
                <span class="">手机</span>
                <br />
                <input id="ipt_phone" name="ipt_phone" class="easyui-validatebox"
                          data-options="validType:'phone'" />
            </div>
            <div id="" class="other_Div">
                <span class="">邮箱</span>
                <br />
                <input id="ipt_email" name="ipt_email" class="easyui-validatebox"
                          data-options="validType:'email'" />
            </div>
            <div id="" class="other_Div">
                <span class="">联系人</span>
                <br />
                <input id="ipt_contacts" name="ipt_contacts" />
            </div>                      
            <div id="" class="other_Div">
                <span class="">微信</span>
                <br />
                <input id="ipt_weixin" name="ipt_weixin" />
            </div>                     
        </div>
        <div style="margin-right:180px;">
            <label>
                <input id="cancel" type="button" class="button" value="取消" onclick="re(); " />
            </label>
            <label>
                <input id="refer" type="button" class="button" value="提交" onclick="Editdata();" />
            </label>
        </div>                       
    </form>

    <script type="text/javascript">
        $(function () {
            initGird();
        })
        function initGird() {
            $.ajax({
                url: 'CompanyContact.aspx',
                type: 'post',
                data: { "action": "query" },
                async: false,
                success: function (data) {
                    var dataObj1 = eval("(" + data + ")"); //转换为json对象
                    console.info(data);
                    $("#form_edit").form('load', dataObj1);
                }
            })
        }
        $.extend($.fn.validatebox.defaults.rules, {                       
            phone: {//手机号码校验  
                validator: function (value, param) {
                    return /^1[3 | 4 | 5 | 8 | 9]+\d{9}$/.test(value);
                },
                message: '请输入正确的手机号码。'
            },
            telephone: { //既验证手机号，又验证座机号
                validator: function (value, param) {
                    return /(^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$)|(^((\d3)|(\d{3}\-))?(1[358]\d{9})$)/.test(value);
                },
                message: '请输入正确的电话号码。'
            }
        });
        function re() {
            location.reload();
        }
        function GetInputData(id, cmd) {
            var postdata = "{ \"action\":\"" + cmd + "\",";
            $("#" + id + " input[type!='checkbox']").each(function () {
                postdata += "\"" + $(this).attr("name") + "\":\"" + $(this).val() + "\",";
            });
            $("#" + id + " input[type='checkbox']").each(function () {
                postdata += "\"" + $(this).attr("name") + "\":\"" + this.checked + "\",";
            });

            postdata = postdata.substr(0, postdata.length - 1);
            postdata += "}";
            return eval("(" + postdata + ")");
        }
        function Editdata() {
            var json = GetInputData("form_edit", "edit")
            $.ajax({
                url: 'CompanyContact.aspx',
                type: 'post',
                data: json,
                async: false,
                success: function (data) {
                    $.messager.alert('提示', data, 'info', function () {
                        if (data.indexOf("成功") > 0) {
                            console.info(data);
                            location.reload();
                        }
                    });
                }
            })
        }
    </script>
</body>
</html>
