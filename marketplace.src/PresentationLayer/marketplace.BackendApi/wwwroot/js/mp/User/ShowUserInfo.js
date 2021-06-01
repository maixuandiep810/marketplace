function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}
var UserImage = getCookie("UserImage");
var UserName = getCookie("UserName");

$(function () {
    if (UserImage != "") {
        $("#UserImage").attr("src", UserImage);
    }
    if (UserName != "") {
        $("#UserName").text(UserName);
    }
});