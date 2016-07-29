<%@ Control Language="C#" AutoEventWireup="true" CodeFile="xsheader.ascx.cs" Inherits="controls_xsheader" %>
<div class="xz">
  		<div class="xzBtn"><img src="../images/dfpd.jpg" title="地方频道" /></div>
   	    <div class="countiesBtn" id="hotArea">
          <ul id="ulid">
              <% foreach (HzsModel.Models.DM_ZZDW c in arealist)
                 { %>
                    <li><a href="../difang/Default_Cun.aspx?aid=<%=c.ZZDW_DM %>" target="_blank"><%=c.ZZDW_JC %></a></li>
              <%} %>
          </ul>
		</div>
    </div>
<script type="text/javascript"> new Marquee(["hotArea", "ulid"], 2, 2, 900, 30, 20, 0, 0);</script>