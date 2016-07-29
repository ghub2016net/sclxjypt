$(function () {
    $("#lbtnSearch").click(function () {
        if ($.trim($("#txtKeywords").val()) != "")
            location.href = GetPageName() + "?keywords=" + $("#txtKeywords").val()+"&logType=" + $("#ddlProperty option:selected").val();
        else
            $.dialog.alert("请填写查询内容！");
       
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
        $.ajax({ type: "POST", url: "/AjaxLink/DeleteLink.ashx", data: { param: ids.join(':') }, dataType: "json", success: function (data) {
        alert(data.info);
            if (data.status == "y")
                location.reload();
            else
                $.dialog.alert(data.info);
        }
        });
    }
}