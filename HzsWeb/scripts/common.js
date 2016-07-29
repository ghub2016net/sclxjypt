function GetPageName() {
    var url = window.location.href; 
    var tmp = new Array();
    tmp = url.split("/");
    var pp = tmp[tmp.length - 1];
    tmp = pp.split("?"); 
    return tmp[0];
}