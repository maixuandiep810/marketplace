$(function () {
  $.validator.setDefaults({
    submitHandler: function () {
      alert("Form successful submitted!");
    }
  });

  $.validator.addMethod(
    "isempty",
    function (value, element, isempty) {
      var valueTrim = value.trim();
      return (valueTrim.length == 0) != isempty;
    });

  $('#registerForm').validate({
    submitHandler: function (form) {
      $.ajax({
        url: '/user/register',
        type: 'POST',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(Object.fromEntries(new FormData(form))),
      }).done(function (response) {
        if (response.isSuccessed == true) {
          $('#registerForm').attr("hidden", true);
          $('#registerFormResult').attr("hidden", false);
        }
        else {
          alert(response.messages);
        };
      }).fail(function (error) {
        alert("Quá trình đăng ký thất bại");
      });
      return false;
    },
    rules: {
      Email: {
        required: true,
        email: true,
      },
      Username: {
        required: true,
        minlength: 3,
        isempty: false,
      },
      Password: {
        required: true,
        minlength: 1
      },
      ConfirmPassword: {
        equalTo: Password
      },
    },
    messages: {
      Email: {
        required: "Xin nhập Email",
        email: "Địa chỉ email không đúng định đạng email"
      },
      Username: {
        required: "Xin nhập Tên tài khoản",
        minlength: "Tên tài khoản phải dài hơn 10 kí tự",
        isempty: "Tên tài khoản không được chứa toàn khoảng trắng"
      },
      Password: {
        required: "Xin nhập mật khẩu",
        minlength: "Mật khẩu phải dài hơn 5 kí tự"
      },
      ConfirmPassword: {
        equalTo: "Xac thực mật khẩu không hợp lệ - không trùng"
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

// $(function () {
//   $('#submitRegister').click(function (e) {
//     e.preventDefault();
//     var registerData = $('#registerForm').serializeArray();
//     $.ajax({
//       url: '/user/register',
//       type: 'POST',
//       dataType: 'json',
//       contentType: 'application/json; charset=utf-8',
//       data: registerData,
//     }).done(function (response) {
//       if (response.isSuccessed == true) {
//         $('#registerForm').attr("hidden", true);
//         $('#registerFormResult').attr("hidden", false);
//       }
//       else {
//         alert(response.messages);
//       };
//     }).fail(function (error) {
//       alert("Quá trình đăng ký thất bại");
//     });

//   });
// });