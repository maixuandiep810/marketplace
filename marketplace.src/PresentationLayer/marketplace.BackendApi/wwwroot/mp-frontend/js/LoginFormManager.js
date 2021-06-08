$(function () {
  $.validator.setDefaults({
    submitHandler: function () {
      alert("Form successful submitted!");
    }
  });
  $('#loginForm').validate({
    submitHandler: function (form) {
      var formData = new FormData(form);
      var bodyJson = {
        'Email': formData.get('Email'),
        'Password': formData.get('Password'),
        'RememberMe': formData.get('RememberMe') == 'true',
        'RoleName': formData.get('RoleName')
      }
      $.ajax({
        // crossDomain: true,
        xhrFields: { 
          withCredentials: true
        },
        url: '/user/login',
        type: 'POST',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(bodyJson),
      }).done(function (response) {
        if (response.isSuccessed == true) {
          $('#loginForm').attr("hidden", true);
          $('#loginFormResult').attr("hidden", false);
          // $(location).attr('href', '/');
        }
        else {
          alert("Quá trình đăng nhập thất bại");
        };
      }).fail( function(jqXHR, textStatus, errorThrown) {
        alert("Quá trình đăng nhập thất bại");
        console.log('Could not get posts, server response: ' + textStatus + ': ' + errorThrown);
      });
      return false;
    },
    rules: {
      Email: {
        required: true,
        email: true,
      },
      Password: {
        required: true,
        minlength: 6
      },
    },
    messages: {
      email: {
        required: "Please enter a email address",
        email: "Please enter a vaild email address"
      },
      password: {
        required: "Please provide a password",
        minlength: "Your password must be at least 6 characters long"
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

// function getFormData($form) {
//   var unindexed_array = $form.serializeArray();
//   var indexed_array = {};

//   $.map(unindexed_array, function (n, i) {
//     indexed_array[n['name']] = n['value'];
//   });

//   return indexed_array;
// }
