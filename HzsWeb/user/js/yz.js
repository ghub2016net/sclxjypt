﻿$(function () { $.fn.initValidform = function () { var a = function (b) { $(b).Validform({ tiptype: function (h, g, f) { if (!g.obj.is("form")) { if (g.obj.parents("td").find(".Validform_checktip").length == 0) { g.obj.parents("td").append("<span class='Validform_checktip' />"); g.obj.parents("td").next().find(".Validform_checktip").remove() } var c = g.obj.parents("td").find(".Validform_checktip"); f(c, g.type); c.text(h) } }, showAllError: true }) }; return $(this).each(function () { a($(this)) }) } });