$(function () {
    $("#ddlProperty").change(function () {
        if ($("#ddlProperty").val() != "0")
            location.href = "cooperation.aspx?rid=" + $("#ddlProperty").val();
    });

    $("#lbtnSearch").click(function () {
        if ($.trim($("#txtKeywords").val()) != "")
            location.href = "?keywords=" + $("#txtKeywords").val();
        else
            $.dialog.alert("请填写查询内容！");
    });
});
function __doPostBack(a, b) {
    if (a == "btnDelete")
        _del();
    else if (a == "btnShow")
        _verifytrue();
    else if (a == "btnHide")
        _verifyfalse();
}
function _del() {
    var ids = [];
    $(".ltable :checkbox").each(function () {
        if ($(this).attr("checked")) {
            ids.push($(this).val());
        }
    });
    if (ids.join(':').length > 0) {
        $.ajax({ type: "POST", url: "/AjaxTrade/Del.ashx", data: { param: ids.join(':') }, dataType: "json", success: function (data) {
            if (data.status == "y")
                location.reload();
            else
                $.dialog.alert(data.info);
        }
        });
    }
}

function _verifytrue() {
    var ids = [];
    $(".ltable :checkbox").each(function () {
        if ($(this).attr("checked")) {
            ids.push($(this).val());
        }
    });
    if (ids.join(':').length > 0) {
        $.ajax({ type: "POST", url: "/AjaxTrade/VerifyNews.ashx", data: { param: ids.join(':') }, dataType: "json", success: function (data) {
            if (data.status == "y")
                location.reload();
            else
                $.dialog.alert(data.info);
        }
        });
    }
}

function _verifyfalse() {
    var ids = [];
    $(".ltable :checkbox").each(function () {
        if ($(this).attr("checked")) {
            ids.push($(this).val());
        }
    });
    if (ids.join(':').length > 0) {
        $.ajax({ type: "POST", url: "/AjaxTrade/VerifyNewsFalse.ashx", data: { param: ids.join(':') }, dataType: "json", success: function (data) {
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
        content: "<img src='" + obj + "' alt='缩略图片....' style='width:300px;'>",
        max: false,
        min: false,
        lock: true
    });
}

function getType(p, p2) {
    var getzhi;
    if (p2 > 0) {
        $.each(arrtrade, function (i, n) {
            if (n.tid == p) {
                getzhi = n.tname + "--";
            }
            if (n.tid == p2) {
                getzhi += n.tname;
            }
        });
    } else {
        $.each(arrtrade, function (i, n) {
            if (n.tid == p) {
                getzhi = n.tname;
            }
        });
    }
    document.write(getzhi);
}
