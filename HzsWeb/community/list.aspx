<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="community_list" %>
<%@ Register src="../controls/header.ascx" tagname="header" tagprefix="uc1" %>
<%@ Register src="../controls/xsheader.ascx" tagname="xsheader" tagprefix="uc2" %>
<%@ Register src="../controls/footer.ascx" tagname="footer" tagprefix="uc3" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %> 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>泸县数字农经网</title>
    <meta name="keywords" content="泸县数字农经网,泸县农业局,农民专业合作社,农民专业合作社网,泸县特产,供应求购泸县农产品" /><meta name="description" content="泸县数字农经网,泸县农业局,农民专业合作社,农民专业合作社网,泸县特产,供应求购泸县农产品" />
    <link rel="stylesheet" type="text/css" href="../css/css.css">
    <link rel="stylesheet" type="text/css" href="../css/nei.css">
    <script src="../scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../scripts/MSClass.js" type="text/javascript"></script>
    <script src="../js/areajs.js" type="text/javascript"></script>
    <script src="../js/hy.js" type="text/javascript"></script>
    <style type="text/css">
    .selectList {
    border: 1px solid #CCCCCC;
    height: 22px;
    line-height: 22px;
    width: 122px;
    }

    input {
        vertical-align: middle;
    }
    .searchbtn{
    display:block; width:77px; float:right; height:20px; color:#fff; background-color:#f3e17f; text-align:center; font-weight:bold; 
    }
    .aabb{ height:30px; font-weight:bold; border:solid 1px #EAF0DB;}
    </style>
    <script type="text/javascript">
        $(function () {
            $("#sltJyms").change(function () {
                if ($("#sltJyms").val() != "")
                    $("#txtjyms").val($("#sltJyms").val());
                else { $("#txtjyms").val(""); }
            });
            $("#sltGxsj").change(function () {
                if ($("#sltGxsj").val() != "")
                    $("#txtgxsj").val($("#txtgxsj").val());
                else { $("#txtgxsj").val(""); }
            });
        });
        function ontj()
        {
            var pv = "?";
            if ($("#ddlcounty").val() != "") {
                pv += "county=" + $("#ddlcounty").val() + "&";
            } else if($("#ddlcity").val()!="") {
                pv += "city=" + $("#ddlcounty").val() + "&";
            }else if($("#ddlProvince").val()!=""){
                pv += "province=" + $("#ddlProvince").val() + "&";
            }

            if ($("#txtjyms").val() != "")
            {
                pv += "jyms=" + $("#txtjyms").val() + "&";
            }
            if ($("#txtgxsj").val() != "")
            {
                pv += "gxsj=" + $("#txtgxsj").val() + "&";
            }
            if(pv=="?")
                pv="";
                else pv+="p=true";
                location.href = 'list.aspx' + pv;
        }
    </script>
</head>
<body>
    <div class="contents">
	<uc1:header ID="header1" runat="server" />
	<uc2:xsheader ID="xsheader1" runat="server" />   
    <div class="clear01"></div>
        <div class="mainRighTitleMessageIco">
        	当前位置：<a href="../">首页</a> > 合作社会员列表</a>
        	</div>   
              
<table style=" margin-top:10px; padding-top:2px;width:1000px;border:solid 1px #EAF0DB;background-color:#FFFFFF;">
<tr>
<td style="height:24px;" align="left">
&nbsp;<b> 检索 </b>&nbsp;城市:</td><td><table>
	<tr>
	<td>
    <select name="province" id="ddlProvince" class="selectList"></select>
        &nbsp; <select name="city" id="ddlcity" class="selectList"><option value="">==选择市==</option></select>
        &nbsp;<select name="county" id="ddlcounty" class="selectList"><option value="">==选择县==</option></select>
       </td></tr></table></td>
       <td style="text-align: left">
经营模式:<select id="sltJyms" class="selectList floatLef marginBottom10">
            <option value="">==选择==</option>
                <%foreach (HzsModel.HZSModels.HzsUserJyms jtype in jymslist.HzsUserJyms)
                  {%>
                    <option value="<%=jtype.id %>" ><%= jtype.jname %></option>
                <%} %>
                </select>
                
                &nbsp;更新时间:
                <select id="sltGxsj" class="selectList">
                <option selected="selected" >请选择</option>
                <option value="1" >十天</option>
                <option value="2" >一个月</option>
                <option value="3" >三个月</option>
                <option value="4" >半年</option>
                <input type="hidden" id="txtgxsj" name="txtgxsj" />
                <input type="hidden" id="txtjyms" name="txtjyms" />
                <input type="hidden" name="city" id="txt_city" />
                </select><input id="searchbtn" type="button" onclick="ontj()" value=" 搜 索 " class="searchbtn" />
                </td></tr>
</table>
<!--层画线-->
<div style="width:1000px;height:1px;border-top:1px solid #FFFFFF;" ></div>
<form id="listform" runat="server">
<table style=" margin-top:10px; padding-top:2px;width:1000px;border:solid 1px #EAF0DB;background-color:#FFFFFF; text-align:center;">
    <tr>
        <td style="height:30px; font-weight:bold; border:solid 1px #EAF0DB;" width="28%">
            单位名称
        </td>
        <td style="height:30px; font-weight:bold; border:solid 1px #EAF0DB" width="10%">
            所在城市
        </td>
        <td style="height:30px; font-weight:bold; border:solid 1px #EAF0DB" width="15%">
            经营模式
        </td>
        <td style="height:30px; font-weight:bold; border:solid 1px #EAF0DB" width="12%">
            联系人
        </td>
        <td style="height:30px; font-weight:bold; border:solid 1px #EAF0DB" width="12%">
            联系电话
        </td>
        <td style="height:30px; font-weight:bold; border:solid 1px #EAF0DB" width="15%">
            登记时间
        </td>
    </tr>
    <asp:Repeater ID="rptList" runat="server">
    <ItemTemplate>
    <tr>
        <td class="aabb" width="28%" style="text-align:left;">
        <a href="../company/default.aspx?uid=<%#Eval("uid") %>" style="color:#6FAA0A; padding-left:5px;">
            <%#Eval("corpname")%>
            </a>
        </td>
        <td class="aabb" width="20%">
            <script>$.each(arrarea, function (i, n) { if (n.oid == <%#Eval("province")%>) { document.write(n.oname); } });</script>
            <script>$.each(arrarea, function (i, n) { if (n.oid == <%#Eval("city")%>) { document.write(" "+n.oname); } });</script>
            <script>$.each(arrarea, function (i, n) { if (n.oid == <%#Eval("county")%>) { document.write(" "+n.oname); } });</script>
        </td>
        <td class="aabb" width="15%" style="text-align:left;">
          <%#GetScope(Eval("scope").ToString()) %>
        </td>
        <td class="aabb" width="12%">
            <%#Eval("linkman") %>
        </td>
        <td class="aabb" width="12%">
            <%#Eval("tel") %>
        </td>
        <td class="aabb" width="10%">
            <%#Convert.ToDateTime(Eval("addtime")).ToString("yyyy-MM-dd") %>
        </td>
    </tr>
    </ItemTemplate>
        </asp:Repeater>
</table>
<div style="width:100%; text-align:right; right:20px;">
                <webdiyer:AspNetPager ID="AspNetPagerAskAnswer" runat="server" 
            AlwaysShow="True" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" 
             PrevPageText="上一页" 
            PageSize="15" onpagechanged="AspNetPagerAskAnswer_PageChanged">
                </webdiyer:AspNetPager> </div>
</form>
                <div class="clear01"></div>
                <uc3:footer ID="nfooter1" runat="server" />    
  <div class="clear01"></div>	
</div>
</body>
</html>
