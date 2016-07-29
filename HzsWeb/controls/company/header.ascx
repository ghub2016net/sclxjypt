<%@ Control Language="C#" AutoEventWireup="true" CodeFile="header.ascx.cs" Inherits="controls_company_header" %>
	<div class="htop">
    <div class="hlogo"><%=hzuModel.corpname %></div>
    <div class="clear"></div>
    </div>
    <div class="hlogoRB">
    	<ul>
            <li><a href="/company/default.aspx?uid=<%=hzuModel.uid %>">首　　页</a></li>
          <li><a href="/company/view.aspx?uid=<%=hzuModel.uid %>&typeid=1">公司简介</a></li>
            <li><a href="/company/news.aspx?uid=<%=hzuModel.uid %>">新闻中心</a></li>
            <li><a href="/company/glorys.aspx?uid=<%=hzuModel.uid %>">荣誉资质</a></li>
            <li><a href="/company/products.aspx?uid=<%=hzuModel.uid %>">产品中心</a></li>
            <li><a href="/company/view.aspx?uid=<%=hzuModel.uid %>&typeid=4">联系我们</a></li>
        </ul>
    </div>