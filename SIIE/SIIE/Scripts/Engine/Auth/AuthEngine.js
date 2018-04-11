$(document).ready(function () {
    $('#login').on('click', function () {
        var data = {
            noControl: $('#controlNumber').val(),
            Constraseña: $('#password').val()
        }
        $.ajax({
            url: '/Login',
            method: 'POST',
            data: data,
            success: function (response) {
                if (response.status == 200)
                    window.location.href = response.route;
                else
                    alert("Usuario o contraseña incorrecto")
            }
        });
    });
});