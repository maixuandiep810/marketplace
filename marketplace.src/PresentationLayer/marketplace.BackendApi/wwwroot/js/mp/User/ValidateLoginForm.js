$(function () {
    $.validator.setDefaults({
        submitHandler: function () {
            alert("Form successful submitted!");
        }
    });
    $('#loginForm').validate({
        rules: {
            Email: {
                required: true,
                email: true,
            },
            Password: {
                required: true,
                minlength: 5
            }
        },
        messages: {
            Email: {
                required: "Please enter a email address",
                email: "Please enter a vaild email address"
            },
            Password: {
                required: "Please provide a password",
                minlength: "Your password must be at least 5 characters long"
            }
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