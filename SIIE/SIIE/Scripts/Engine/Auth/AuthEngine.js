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
            contentType: 'application/json; charset=utf-8',
            success: function (response) {
                if (response.status == 200)
                    alert("OK");
                else
                    alert("BadRequest")
            }
        });
    });
});