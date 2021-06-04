var isLoadAddressMenuLi = false;
$(document).ready(function () {
    $("#AddressMenuLi").hover(function () {
        if (isLoadAddressMenuLi == false) {
            $.ajax({
                url: "/address/dropdown-area",
                contentType: 'application/html; charset=utf-8',  
                type: 'GET' ,  
                dataType: 'html',
                success: function (result) {
                    $("#AddressMenuLi").append(result);
                    isLoadAddressMenuLi = true;
                },
                error: function (req, status, error) {
                    console.log("Error");
                }
            });
        }
    });

});