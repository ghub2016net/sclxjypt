$(function () {
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
    else
        _save();
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
        $.ajax({ type: "POST", url: "/AjaxNewsType/DelNewsTypeByArray.ashx", data: { param: ids.join(':') }, dataType: "json", success: function (data) {
            if (data.status == "y")
                location.reload();
            else
                $.dialog.alert(data.info);
        }
        });
    }
}

function _save()
{

}