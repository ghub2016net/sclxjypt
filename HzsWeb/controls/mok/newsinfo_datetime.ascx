<%@ Control Language="C#" Inherits="MyUserControlView<Newsinfo_Controlcs>" %>
<%if (Model.molist.Count > 0){  foreach (HzsModel.Models.NewsInfo mo in Model.molist) { %>
<li><a href="/info/detail.aspx?id=<%=mo.id %>" title="<%=mo.title %>"><%=StringClass.CutString(mo.title, 36)%></a><span class="mainDate"><%=mo.addtime.ToString("yyyy-MM-dd")%></span></li>
<%} }%>
