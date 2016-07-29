<%@ Control Language="C#" AutoEventWireup="true" CodeFile="login.ascx.cs" Inherits="controls_login" %>
<div class="admin" style="width:246px; height:212px">
    <div class="flanmu moreL">会员登录</div>
    <div class="clear02"></div>
    <div  id="divlogin">
    <div style="padding-left:15px;">欢迎您登录</div>
    <div class="loginTxt">泸县数字农经网</div>
    <form id="frmlogin" method="post" >
    <table class="login" >
      <tr>
        <th>用户名：</th>
        <td><input class="txt" name="hname" type="text" id="txt_uname" size="20" /></td>
      </tr>
      <tr>
        <th>密　码：</th>
        <td><input class="txt" name="hpwd" type="password" id="txt_pwd" size="20" /></td>
      </tr>
      <tr>
        <th>&nbsp;</th>
        <td style="padding-bottom:0px;">
        <img class="lef8" src="../images/login.jpg" id="imglogin" style="cursor:pointer;" />
        
        <a href="../community/reg.aspx"><img src="../images/zhuce.jpg" /></a></td>
      </tr>
    </table>
    <div class="loginBot"></div>
    </form>
    </div>
    <div  id="divuser" style="display:none;">
    <% if (uid>0){ %>
    <script>$("#divlogin").hide();$("#divuser").show();  </script>
    <div class="loginTxt">泸县数字农经网</div>
    <div class="loginTxt">欢迎您：<%=uname %></div>
    <% if (htype>1)
       {%>
    <div style="padding-left:15px;">[<a href="/lsadmin/" target="_blank">理事会员专享</a>]</div>
    <% }
       if (htype != 0)
       { %>
    <div style="padding-left:15px; line-height:30px;">[<a href="/user/" target="_blank">管理</a>]</div>
    <%} %>
    <div style="padding-left:15px; line-height:30px;">[<a href="javascript:uout();" id="zhuxiao"> 安全注销 </a>]</div>
    <% }else{ %>
    <div style="padding-left:15px; line-height:30px;">审核中....</div>
    <%} %>
    </div>
</div>
<script type="text/javascript">
$(function(){
    $('#imglogin').click(function () {
        if(CheckNull()){
            $("#frmlogin").ajaxSubmit({
                success: function (data) {
                if(data.status=="n"){ alert(data.info);}  
                else{
                    $("#divuser").html(data.info);
                    $("#divlogin").hide();
                    $("#divuser").show();  
                }
                },
                url: "/AjaxViewHzsUserLogin/ViewHzsUserLogin.ashx",
                type: "post",
                dataType: "json"
            });
        }
    });
});
function CheckNull(){
    var ckz = true;
    if($("#txt_uname").val()=="")
    {
        ckz=false;
    }
    if($("#txt_pwd").val()=="")
    {
        ckz=false;
    }
    if(ckz ==false){ alert("用户名或密码不能为空！");}
    return ckz;
}
function uout()
{
    $.ajax({
        type: "post", 
        url: "/AjaxViewHzsUserLogin/ViewHzsUserLoginOut.ashx",
        dataType: "json",
        success: function(data) {
            $("#divlogin :text").val("");
            $("#txt_pwd").val("");
            $("#divlogin").show();
            $("#divuser").hide();   
        }
    });
}
</script>
