function checkAreaType(obj) {/*点击地方触发选择框*/
    var PlaceAreaDialog = $.dialog({
        id: 'DialogPlaceArea',
        title: "",
        height: 300,
        content: "url:../../common/placesarea.aspx?t=hik",
        max: false,
        min: false,
        lock: true
    });
}
$(function () {
    $("#ddlProperty").change(function(){/*属性列表改变触发跳转*/
        if($("#ddlProperty").val()!="0")
            location.href="?nid="+$("#ddlProperty").val();
    });
    /*点击搜索触发跳转*/
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
}
/*删除操作*/
function _del()
{
    var ids = [];
    $(".ltable :checkbox").each(function () {
        if ($(this).attr("checked")) {
            ids.push($(this).val());
        }
    });
    if (ids.join(':').length > 0) {
        $.ajax({ type: "POST", url: "/AjaxPlacesInfo/Del.ashx", data: { param: ids.join(':') }, dataType: "json", success: function (data) {
            if (data.status == "y")
                location.reload();
            else
                $.dialog.alert(data.info);
        }
        });
    }
}
//列表属性图片
function checkimg(obj) {
    var SmallDialog = $.dialog({
        id: 'DialogSmall',
        title: "加载图片",
        content: "<img src='"+obj+"' alt='缩略图片....' style='width:300px;'>",
        max: false,
        min: false,
        lock: true
    });
}
