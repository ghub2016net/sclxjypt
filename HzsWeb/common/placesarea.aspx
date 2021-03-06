﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="placesarea.aspx.cs" Inherits="common_placesarea" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <script src="../scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../ztree/js/jquery.ztree.core-3.5.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <link href="../ztree/css/zTreeStyle/zTreeStyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        var api = frameElement.api, W = api.opener;
        var tt="<%=tt %>",trid='';
        api.button({
        name: '确定',
        focus: true,
        callback: function () {
            if(tt=="hik")
                api.opener.document.location.href="/AjaxPlacesInfo/ToListUrl.ashx?l="+trid;
        }
    }, {
        name: '取消'
    });

        var setting = {
		view: {
			showLine: true,
			selectedMulti: false
		},
		data: {
			simpleData: {
				enable:true,
				idKey: "ZZDW_DM",
				pIdKey: "ZZDW_SJDM",
				rootPId: ""
			}
		},
		callback: {
			onClick: NewsTypeOnClick
		}
	};
    var NewsTypeNodes = <%=zhi %>;
    var liHtml;
    function NewsTypeOnClick(event, treeId, treeNode) {   
            liHtml='<input name="areacode" id="areacode" type="hidden" value="'+treeNode.ZZDW_DM+'" />';
            $("#sslb", api.opener.document).find("#txtntype").val(treeNode.name);
            $("#showInfoList", api.opener.document).children("ul").html(liHtml);
            trid = treeNode.ZZDW_DM;
		}	
    $(document).ready(function(){
	var nt = $("#tree");
	t = $.fn.zTree.init(nt, setting, NewsTypeNodes);
	});
    
    </script>
</head>
<body>
    <div class="left">
		<ul id="tree" class="ztree"></ul>
	</div>
</body>
</html>
