$(function () {
    $('#loginButton').on('click', function () {
        $('#loginButton').css('disabled', true);
        var data = {
            noControl: $('#controlNumber').val(),
            Constraseña: $('#password').val()
        }
        $.ajax({
            url: '/Login',
            method: 'POST',
            data: data,
            success: function (response) {
                $('#loginButton').css('disabled', false);
                if (response.status == 200)
                    window.location.href = "/Tutorias/List";
                else
                    alert("Usuario o contraseña incorrecto")
            }
        });
    });
});
$(function () {
    $('#logout').on('click', function () {
        $.ajax({
            url: '/Login',
            method: 'PATCH',
            success: function (response) {
                window.location.href = response.route;
            }
        });
    });
})