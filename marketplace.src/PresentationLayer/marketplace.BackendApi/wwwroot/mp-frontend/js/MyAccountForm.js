$(function () {


    $('#MyAccountForm').validate({
        submitHandler: function (form) {
            var formData = new FormData(form);
            var bodyJson = {
                'Dob': (new Date(formData.get('Dob'))).toISOString(),
                'FullName': formData.get('FullName'),
            }
            $.ajax({
                // crossDomain: true,
                xhrFields: {
                    withCredentials: true
                },
                url: '/user/update',
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify(bodyJson),
            }).done(function (response) {
                if (response.isSuccessed == true) {
                    alert('Cập nhật thành công');
                }
                else {
                    alert("Cập nhật thất bại");
                };
            }).fail(function (jqXHR, textStatus, errorThrown) {
                alert("Cập nhật thất bại");
                console.log('Could not get posts, server response: ' + textStatus + ': ' + errorThrown);
            });
            return false;
        },
        rules: {
            FullName: {
                required: true,
                minlength: 3
            },
            Dob: {
                required: true,
            },
        },
        messages: {
            FullName: {
                required: "Nhập Họ và Tên",
                minlength: "Họ và tên phải dài hơn 3 kí tự",
            },
            Dob: {
                required: "Nhập ngày sinh",
            },
        },
        errorElement: 'span',
        errorPlacement: function (error, element) {
            error.addClass('invalid-feedback');
            element.closest('.form-group').append(error);
        },
        highlight: function (element, errorClass, validClass) {
            $(element).addClass('is-invalid');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass('is-invalid');
        }
    });
});
