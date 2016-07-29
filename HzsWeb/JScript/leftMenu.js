
$(document).ready(function () {
            var firstMenu = $(".firstMenu");
            var secondMenu = $('.secondMenu');
			firstMenu.each(function () {			
                $(this).click(function () {									    
                    var aSel = $(this).attr('selected');                   
                    if (aSel != 'selected') {
						secondMenu.slideUp(); 
						$(this).siblings(".secondMenu").slideToggle();
                        $(this).siblings(".secondMenu").find('li:last').addClass('borderNone');
                        firstMenu.removeAttr('selected').removeClass('firstMenuClick').addClass('firstMenu');
                        $(this).removeClass("firstMenu").addClass("firstMenuClick").attr("selected", "selected");
                    }else{
						$(this).siblings(".secondMenu").slideUp(function(){
							firstMenu.removeAttr('selected').removeClass('firstMenuClick').addClass('firstMenu');
							});
					}									
                });
                $(this).hover(function () {
                    var aSel = $(this).attr('selected');
                    if (aSel != 'selected') {
                        $(this).removeClass("firstMenu").addClass("firstMenuClick");
                    }
                }, function () {
                    var aSel = $(this).attr('selected');
                    if (aSel != 'selected') {
                        $(this).removeClass('firstMenuClick').addClass('firstMenu');
                    }
                });
            });
            
});
function tourl(zhi){
    var url = $("#"+zhi).attr("href");
    frames["usermainframe"].location.href = url;
}

