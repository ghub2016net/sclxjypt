<%@ Control Language="C#" Inherits="MyUserControlView<Trade_Controlcs>" %>
<%if (Model.molist.Count > 0){  foreach (HzsModel.Models.Trade mo in Model.molist) { %>
<tr>
<td><script>$.each(arrarea, function (i, n) { if (n.oid == <%=mo.province %>) { document.write(n.oname); } });</script>
<script>$.each(arrarea, function (i, n) { if (n.oid == <%=mo.city %>) { document.write(" "+n.oname); } });</script>
</td>
<td><a href="/trade/detail.aspx?id=<%=mo.id %>" target="_blank"><%=mo.title %></a></td>
<td><%=string.Format("{0:C}",mo.price) %>元/<%=mo.units==null?"未填":mo.units %></td>
<td><%=mo.addtime.ToString("yyyy-MM-dd") %></td>
</tr>
<%} }%>
