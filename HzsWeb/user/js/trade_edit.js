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

    var sortid = 0; //供求产品类型
    $.each(arrtrade, function (i, n) {
        if (n.pid == sortid) {
            $("#ddlptype").prepend("<option value='" + n.tid + "'>" + n.tname + "</option>");
        }
    });
    $("#ddlptype").prepend("<option value=\"\">==大类==</option>");

    $("#ddlptype").change(function () {
        $("#ddlptype2").empty();
        var bigzhi = $("#ddlptype").val();
        $.each(arrtrade, function (i, n) {
            if (n.pid == bigzhi) {
                $("#ddlptype2").append("<option value='" + n.tid + "'>" + n.tname + "</option>");
            }
        });
        $("#ddlptype2").prepend("<option value=\"\">==小类==</option>");
    });
});