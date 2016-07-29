$(function () {
    var poid = arrarea[0].oid; //获取最顶级地区单位 全国
    $.each(arrarea, function (i, n) {
        if (n.pid == poid) {
            $("#ddlProvince").prepend("<option value='" + n.oid + "'>" + n.oname + "</option>");
        }
    });
    $("#ddlProvince").prepend("<option value=\"\">==选择省==</option>");

    $("#ddlProvince").change(function () {
        $("#ddlcity").empty();
        var zhi = $("#ddlProvince").val();
        $.each(arrarea, function (i, n) {
            if (n.pid == zhi) {
                $("#ddlcity").append("<option value='" + n.oid + "'>" + n.oname + "</option>");
            }
        });
        $("#ddlcity").prepend("<option value=\"\">==选择市==</option>");
        $("#ddlcounty").empty();
        $("#ddlcounty").prepend("<option value=\"\">==选择县==</option>");
    });

    $("#ddlcity").change(function () {
        $("#ddlcounty").empty();
        var zhi = $("#ddlcity").val();
        $.each(arrarea, function (i, n) {
            if (n.pid == zhi) {
                $("#ddlcounty").prepend("<option value='" + n.oid + "'>" + n.oname + "</option>");
            }
        });
        $("#ddlcounty").prepend("<option value=\"\">==选择县==</option>");
    });
});
