if (typeof arrarea == 'undefined') {
    document.write('<script type="text/javascript" src="../../js/areajs.js"></script>');
}
if (typeof arrclass == 'undefined') {
    document.write('<script type="text/javascript" src="../../js/hzsclassjs.js"></script>');
}
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

    var classid = 0; //合作社类型
    $.each(arrclass, function (i, n) {
        if (n.pid == classid) {
            $("#ddlhzsbigclass").prepend("<option value='" + n.hid + "'>" + n.cname + "</option>");
        }
    });
    $("#ddlhzsbigclass").prepend("<option value=\"\">==大类==</option>");

    $("#ddlhzsbigclass").change(function () {
        $("#ddlhzssmallclass").empty();
        var bigzhi = $("#ddlhzsbigclass").val();
        $.each(arrclass, function (i, n) {
            if (n.pid == bigzhi) {
                $("#ddlhzssmallclass").append("<option value='" + n.hid + "'>" + n.cname + "</option>");
            }
        });
        $("#ddlhzssmallclass").prepend("<option value=\"\">==小类==</option>");
    });
});
function tj() {
    var jyms="";
    $("#cbxHzsJyms :checkbox").each(function () {
        if ($(this).attr("checked"))
            jyms += $(this).val() + "|";
    });
    $("#txtscope").val(jyms);
}