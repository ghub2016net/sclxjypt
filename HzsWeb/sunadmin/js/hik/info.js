function checkNewsType(obj) {
    var NewsTypeDialog = $.dialog({
        id: 'DialogNewsType',
        title: "新闻类型",
        height: 300,
        content: "url:../../common/newstype.aspx?t=hik",
        max: false,
        min: false,
        lock: true
    });
}
$(function () {
    $("#ddlProperty").change(function(){
        if($("#ddlProperty").val()!="0")
            location.href="Default.aspx?rid="+$("#ddlProperty").val();
    });

    $("#lbtnSearch").click(function () {
        if ($.trim($("#txtKeywords").val()) != "")
            location.href = "?keywords=" + $("#txtKeywords").val();
        else
            $.dialog.alert("请填写查询内容！");
    });
});
function __doPostBack(a, b) {
    if(a=="btnDelete")
        _del();
    else if(a=="btnShow")
        _verifytrue();
    else if(a=="btnHide")
        _verifyfalse();
}
function _del()
{
    var ids = [];
    $(".ltable :checkbox").each(function () {
        if ($(this).attr("checked")) {
            ids.push($(this).val());
        }
    });
    if (ids.join(':').length > 0) {
        $.ajax({ type: "POST", url: "/AjaxNewsInfo/DelNews.ashx", data: { param: ids.join(':') }, dataType: "json", success: function (data) {
            if (data.status == "y")
                location.reload();
            else
                $.dialog.alert(data.info);
        }
        });
    }
}

function _verifytrue()
{
    var ids = [];
    $(".ltable :checkbox").each(function () {
        if ($(this).attr("checked")) {
            ids.push($(this).val());
        }
    });
    if (ids.join(':').length > 0) {
        $.ajax({ type: "POST", url: "/AjaxNewsInfo/VerifyNews.ashx", data: { param: ids.join(':') }, dataType: "json", success: function (data) {
            if (data.status == "y")
                location.reload();
            else
                $.dialog.alert(data.info);
        }
        });
    }
}

function _verifyfalse()
{
    var ids = [];
    $(".ltable :checkbox").each(function () {
        if ($(this).attr("checked")) {
            ids.push($(this).val());
        }
    });
    if (ids.join(':').length > 0) {
        $.ajax({ type: "POST", url: "/AjaxNewsInfo/VerifyNewsFalse.ashx", data: { param: ids.join(':') }, dataType: "json", success: function (data) {
            if (data.status == "y")
                location.reload();
            else
                $.dialog.alert(data.info);
        }
        });
    }
}

function checkimg(obj) {
    var NewsTypeDialog = $.dialog({
        id: 'clickimg',
        title: "加载图片",
        content: "<img src='"+obj+"' alt='缩略图片....' style='width:300px;'>",
        max: false,
        min: false,
        lock: true
    });
}
