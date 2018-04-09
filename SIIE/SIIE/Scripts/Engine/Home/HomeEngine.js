$(document).ready(function () {
    $('#logout').on('click', function () {
        $.ajax({
            url: '/Login',
            method: 'PATCH',
            success: function (response) {
                window.location.href = response.route;
            }
        });
    });
});