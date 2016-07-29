$(function () {
    $("#lbtnSearch").click(function () {
        location.href = GetPageName() + "?keywords=" + $("#txtKeywords").val()+"&rid=" + $("#ddlProperty").val();
    });
});
function __doPostBack(a, b) {
    if(a=='btnDelete')
        _del()
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
        $.ajax({ type: "post", url: "/AjaxSysLog/DeleteSysLog.ashx", data: { param: ids.join(':') }, dataType: "json", success: function (data) {
        alert(data.info);
            if (data.status == "y")
                location.reload();
            else
                $.dialog.alert(data.info);
        }
        });
    }
}